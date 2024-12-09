package com.vyatsu.task14.controllers;

import javax.validation.Valid;

import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.*;
import org.springframework.validation.BindingResult;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.core.annotation.AuthenticationPrincipal;
import org.springframework.security.access.prepost.PreAuthorize;
import org.springframework.data.domain.Pageable;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.PageRequest;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.ui.Model;
import org.springframework.web.servlet.mvc.support.RedirectAttributes;

import com.vyatsu.task14.services.DeckService;
import com.vyatsu.task14.models.Deck;

@PreAuthorize("isAuthenticated()")
@Controller
public class DeckController {
	
    @Autowired
    private DeckService deckService;
	
    @GetMapping
    public String getDecks(@RequestParam(defaultValue = "") String name,
			   @RequestParam(defaultValue = "0") int page, 
			   @RequestParam(defaultValue = "10") int size,
			   Model model
			   ) {
	Pageable pageable = PageRequest.of(page, size);
        Page<Deck> deckPage = deckService.searchDecks(name, pageable);

        model.addAttribute("decks", deckPage.getContent());
        model.addAttribute("currentPage", page);
	if (deckPage.isEmpty()) {
	    model.addAttribute("totalPages", 0);
	} else {
	    model.addAttribute("totalPages", deckPage.getTotalPages());
	}
        model.addAttribute("name", name);
        return "repetition/deck/list";
    }
    
    @GetMapping("/deck/create")
    public String showCreateForm(Model model) {
	model.addAttribute("deck", new Deck());
	return "repetition/deck/create";
    }
	
    @PostMapping("/deck/create")
    public String createDeck(@Valid @ModelAttribute("deck") Deck deck,
			     BindingResult bindingResult) {

	if (bindingResult.hasErrors()) {
	    System.out.println("Validation errors:");
	    bindingResult.getAllErrors().forEach(error -> {
		    System.out.println(" - " + error.getDefaultMessage());
		});
	    return "repetition/deck/create";
	}

	deckService.save(deck);

	return "redirect:/decks";
    }

    @GetMapping("/deck/edit/{id}")
    public String editDeck(@PathVariable Long id, Model model) {
	System.out.println("dlsd");
	Deck deck = deckService.getDeckById(id);
	model.addAttribute("deck", deck);
	return "repetition/deck/edit";
    }

    @PostMapping("/deck/edit")
    public String updateDeck(@ModelAttribute Deck deck, RedirectAttributes redirectAttributes) {
	try {
	    deckService.updateDeck(deck);
	    redirectAttributes.addFlashAttribute("successMessage", "Колода успешно обновлена");
	} catch (Exception e) {
	    redirectAttributes.addFlashAttribute("errorMessage", "Ошибка обновления колоды: " + e.getMessage());
	}
	return "redirect:/decks";
    }

    @PostMapping("/deck/delete/{id}")
    public String deleteDeck(@PathVariable Long id, RedirectAttributes redirectAttributes) {
        try {
            deckService.deleteDeckById(id);
            redirectAttributes.addFlashAttribute("successMessage", "Колода успешно удалена");
        } catch (Exception e) {
            redirectAttributes.addFlashAttribute("errorMessage", "Ошибка удаления колоды: " + e.getMessage());
        }
        return "redirect:/decks";
    }
}
