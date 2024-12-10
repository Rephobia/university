package com.vyatsu.task14.controllers;

import javax.validation.Valid;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;
import org.springframework.security.access.prepost.PreAuthorize;
import org.springframework.stereotype.Controller;
import com.vyatsu.task14.services.CardService;
import com.vyatsu.task14.services.DeckService;
import com.vyatsu.task14.models.Card;
import com.vyatsu.task14.models.Deck;
import org.springframework.data.domain.Pageable;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.PageRequest;
import org.springframework.ui.Model;
import java.util.List;
import org.springframework.validation.BindingResult;
import org.springframework.web.servlet.mvc.support.RedirectAttributes;

@PreAuthorize("isAuthenticated()")
@Controller
@RequestMapping("/deck/{deckId}/card")
public class CardController {

    @Autowired
    private CardService cardService;

    @Autowired
    private DeckService deckService;

    @GetMapping("/list")
    public String getCardsByDeckId(@PathVariable Long deckId,
				   @RequestParam(defaultValue = "0") int page,
				   @RequestParam(defaultValue = "10") int size,
				   Model model
				   ) {
        Page<Card> cardPage = cardService.getCardsByDeckId(deckId, page, size);

        model.addAttribute("cards", cardPage.getContent());
        model.addAttribute("currentPage", page);
	model.addAttribute("deck", deckService.getDeckById(deckId));

	if (cardPage.isEmpty()) {
	    model.addAttribute("totalPages", 0);
	} else {
	    model.addAttribute("totalPages", cardPage.getTotalPages());
	}

        return "repetition/card/list";
    }

    @GetMapping("/create")
    public String showCreateForm(@PathVariable Long deckId,
				 Model model) {
	model.addAttribute("card", new Card());
	model.addAttribute("deck", deckService.getDeckById(deckId));

	return "repetition/card/create";
    }
	
    @PostMapping("/create")
    public String createCard(@PathVariable Long deckId,
			     @Valid @ModelAttribute("card") Card card,
			     BindingResult bindingResult) {

	if (bindingResult.hasErrors()) {
	    System.out.println("Validation errors:");
	    bindingResult.getAllErrors().forEach(error -> {
		    System.out.println(" - " + error.getDefaultMessage());
		});
	    return "repetition/card/create";
	}

	cardService.saveCard(deckId, card);

	return "redirect:/deck/" + deckId + "/card/list";
    }

    @GetMapping("/edit/{id}")
    public String editDeck(@PathVariable Long deckId,
			   @PathVariable Long id, Model model) {
	Deck deck = deckService.getDeckById(deckId);
	model.addAttribute("deck", deck);
	Card card = cardService.getCardById(id);
	model.addAttribute("card", card);

	return "repetition/card/edit";
    }

    @PostMapping("/edit/{id}")
    public String updateCard(@PathVariable Long deckId,
			     @ModelAttribute Card card,
			     RedirectAttributes redirectAttributes) {
	try {
	    Deck deck = deckService.getDeckById(deckId);

	    cardService.updateCard(card, deck);
	    redirectAttributes.addFlashAttribute("successMessage", "Карта успешно обновлена");
	} catch (Exception e) {
	    redirectAttributes.addFlashAttribute("errorMessage", "Ошибка обновления карты: " + e.getMessage());
	}
	
	return "redirect:/deck/" + deckId + "/card/list";
    }

    @PostMapping("/delete/{id}")
    public String deleteCardById(@PathVariable Long deckId,
				 @PathVariable Long id,
				 RedirectAttributes redirectAttributes) {
        try {
            cardService.deleteCardById(id);
            redirectAttributes.addFlashAttribute("successMessage", "Карта успешно удалена");
        } catch (Exception e) {
            redirectAttributes.addFlashAttribute("errorMessage", "Ошибка удаления карты: " + e.getMessage());
        }
	
	return "redirect:/deck/" + deckId + "/card/list";
    }
}
