package com.vyatsu.task14.repositories;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import java.util.Optional;
import java.time.LocalDate;
import com.vyatsu.task14.models.Card;

@Repository
public interface CardRepository extends JpaRepository<Card, Long> {
    Page<Card> findByDeckId(Long deckId, Pageable pageable);

    // Custom query to find a card with a date less than now (using Java LocalDate)
    @Query("SELECT c FROM Card c WHERE c.showTime < :currentDate AND c.deck.id = :deckId")
    Optional<Card> findCardWithDateBeforeNow(@Param("currentDate") LocalDate currentDate, @Param("deckId") Long deckId);
}
