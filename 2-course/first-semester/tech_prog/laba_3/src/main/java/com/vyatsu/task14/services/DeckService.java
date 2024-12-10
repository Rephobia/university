package com.vyatsu.task14.services;

import org.springframework.security.core.Authentication;
import org.springframework.security.core.context.SecurityContextHolder;
import org.springframework.stereotype.Service;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.core.annotation.AuthenticationPrincipal;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;

import com.vyatsu.task14.repositories.DeckRepository;
import com.vyatsu.task14.models.Deck;
import java.util.Optional;

import com.vyatsu.task14.models.User;

@Service
public class DeckService {

    @Autowired
    private DeckRepository deckRepository;

    @Autowired
    private final CurrentUserService currentUserService;

    public DeckService(DeckRepository deckRepository, CurrentUserService currentUserService) {
	this.deckRepository = deckRepository;
	this.currentUserService = currentUserService;
    }
    
    public Deck getDeckById(Long id) {
        return deckRepository.findById(id)
	    .orElseThrow(() -> new IllegalArgumentException("Колода не найдена" + id));
    }
	
    public Deck save(Deck deck) {
	deck.setUsername(currentUserService.getCurrentUsername());
	return deckRepository.save(deck);
    }

    public Page<Deck> searchDecks(String name, Pageable pageable) {
        return deckRepository.findByNameContainingIgnoreCase(name, pageable);
    }

    public void updateDeck(Deck deck) {
	deck.setUsername(currentUserService.getCurrentUsername());
	deckRepository.save(deck);
    }

    public void deleteDeckById(Long id) {
        if (!deckRepository.existsById(id)) {
            throw new IllegalArgumentException("Колода не найдена" + id);
        }
        deckRepository.deleteById(id);
    }
}
