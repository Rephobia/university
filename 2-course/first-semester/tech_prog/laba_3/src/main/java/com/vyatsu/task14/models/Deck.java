package com.vyatsu.task14.models;


import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.validation.constraints.NotBlank;
import javax.validation.constraints.NotNull;
import javax.validation.constraints.Size;

@Entity
public class Deck {
    
    private static final long MINUTES_TO_MILLISECONDS = 60 * 1000;        // 1 минута = 60000 миллисекунд
    private static final long DAYS_TO_MILLISECONDS = 24 * 60 * 60 * 1000; // 1 день = 86400000 миллисекунд
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    @NotBlank(message = "Имя обязательное поле") 
    @Size(min = 3, max = 50, message = "Имя не может быть больше 50 символов и меньше 3")
    private String name;

    private String username;
    
    @NotNull(message = "Второй период обязательное поле")
    private Long secondPeriod;
    @NotNull(message = "Третий период обязательное поле")
    private Long thirdPeriod;

    
    // Getters and Setters
    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }

    public Long getSecondPeriod() {
        return secondPeriod;
    }

    public Long getSecondPeriodInMs() {
        return secondPeriod * DAYS_TO_MILLISECONDS;
    }
    
    public void setSecondPeriod(Long secondPeriod) {
        this.secondPeriod = secondPeriod;
    }

    public Long getThirdPeriod() {
        return thirdPeriod;
    }

    public Long getThirdPeriodInMs()
    {
	return thirdPeriod * DAYS_TO_MILLISECONDS;
    }

    public void setThirdPeriod(Long thirdPeriod) {
        this.thirdPeriod = thirdPeriod;
    }
}
