package com.vyatsu.task14.services;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.PageRequest;
import org.springframework.data.domain.Pageable;
import org.springframework.stereotype.Service;
import com.vyatsu.task14.repositories.CardRepository;
import com.vyatsu.task14.repositories.DeckRepository;
import com.vyatsu.task14.models.Card;
import com.vyatsu.task14.models.Deck;
import java.util.Optional;
import java.time.LocalDateTime;

import java.util.List;

@Service
public class CardService {

    @Autowired
    private CardRepository cardRepository;

    @Autowired
    private DeckRepository deckRepository;

    public Page<Card> getCardsByDeckId(Long deckId, int page, int size) {
        Pageable pageable = PageRequest.of(page, size);
	
        return cardRepository.findByDeckId(deckId, pageable);
    }

    public Card getCardById(Long cardId) {
        return cardRepository.findById(cardId)
	    .orElseThrow(() -> new RuntimeException("Card not found"));
    }

    public Card saveCard(Long deckId, Card card) {
        Deck deck = deckRepository.findById(deckId)
            .orElseThrow(() -> new RuntimeException("Deck not found"));

        card.setDeck(deck);

        return cardRepository.save(card);
    }

    public void updateCard(Card card, Deck deck) {
	card.setDeck(deck);
	cardRepository.save(card);
    }
    
    public void deleteCardById(Long id) {
        if (!cardRepository.existsById(id)) {
            throw new IllegalArgumentException("Карта не найдена" + id);
        }
        cardRepository.deleteById(id);
    }

    public Optional<Card> getNextCardByDeckId(Long deckId) {
	List<Card> cards = cardRepository.findCardWithDateBeforeNow(LocalDateTime.now(), deckId);
	return cards.isEmpty() ? Optional.empty() : Optional.of(cards.get(0));
    }

    public void addPeriod(Long cardId, Long period) {
        Card card = cardRepository.findById(cardId)
	    .orElseThrow(() -> new RuntimeException("Карта не найдена"));

	if (period == null) {
	    new RuntimeException("Период не задан");
	}
	
        card.setShowTime(LocalDateTime.now().plusNanos(period * 1_000_000));
	
        cardRepository.save(card);
    }
}
