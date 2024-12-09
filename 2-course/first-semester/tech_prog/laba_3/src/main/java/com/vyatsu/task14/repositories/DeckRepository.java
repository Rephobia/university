package com.vyatsu.task14.repositories;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;

import com.vyatsu.task14.models.Deck;

@Repository
public interface DeckRepository extends JpaRepository<Deck, Long> {
        Page<Deck> findByNameContainingIgnoreCase(String name, Pageable pageable);
}
