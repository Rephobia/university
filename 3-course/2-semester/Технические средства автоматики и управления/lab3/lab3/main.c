/*
 * lab3.c
 *
 * Полноценный ШИМ на пинах 3, 5, 6 с использованием прерываний
 * Автор: erdyakov
 * Плата: Arduino Uno (ATmega328P)
 */

#define F_CPU 16000000UL
#include <avr/io.h>
#include <avr/interrupt.h>
#include <stdbool.h>

void pwm_setup()
{
    // ===== ТАЙМЕР 0: ПИНЫ 5 (OC0B) и 6 (OC0A) =====
    TCCR0A = 0;  // Очищаем все биты
    TCCR0B = 0;  // Очищаем все биты
    
    // ===== НАСТРОЙКА РЕЖИМА ТАЙМЕРА (ОБЩИЙ ДЛЯ ОБОИХ КАНАЛОВ) =====
    // Fast PWM режим (WGM00=1, WGM01=1)
    TCCR0A |= (1 << WGM00) | (1 << WGM01);
	// Phase Correct PWM
    //TCCR0A |= (1 << WGM00);
	
	// неинвертирующий для А, инвертирующий для Б
    TCCR0A |= (1 << COM0A1) | (1 << COM0B1) | (1 << COM0B0);  
	
    // ===== НАСТРОЙКА ПРЕДЕЛИТЕЛЯ (ОБЩИЙ ДЛЯ ОБОИХ КАНАЛОВ) =====
	/*
      CS02 CS01 CS00 | Предделитель
     ----------------|-------------
        0    0    0  | Таймер остановлен
        0    0    1  | 1          (16 МГц)
        0    1    0  | 8          (2 МГц)
        0    1    1  | 64         (250 кГц) 
        1    0    0  | 256        (62.5 кГц)
        1    0    1  | 1024       (15.625 кГц)
        1    1    0  | Внешний такт на пине T0 
        1    1    1  | Внешний такт на пине T0
    */
    TCCR0B |= (0 << CS02) | (1 << CS01) | (1 << CS00);
    
    // ===== НАЧАЛЬНЫЕ ЗНАЧЕНИЯ (РАЗДЕЛЬНЫЕ ДЛЯ КАЖДОГО КАНАЛА) =====
    OCR0A = 0;  // Пин 6 (канал A) - выключен
    OCR0B = 0;  // Пин 5 (канал B) - включен
}

void timer1_setup(void)
{
    TCCR1A = 0;
    TCCR1B = 0;
    TCNT1 = 0;
    
    // Режим CTC (Clear Timer on Compare Match)
    TCCR1B |= (1 << WGM12);
    
    // Предделитель 64 (CS11=1, CS10=1)
    TCCR1B |= (1 << CS11) | (1 << CS10);
    
    /*
     * Расчет OCR1A для 10 мс:
     * Частота таймера = 16 000 000 / 64 = 250 000 Гц
     * Период = 1 / 250 000 = 0.000004 с = 4 мкс
     * Для 10 мс: 0.01 / 0.000004 = 2500
     * OCR1A = 2500 - 1 = 2499
     */
    OCR1A = 2500 - 1;
    
    // Разрешаем прерывание по совпадению с OCR1A
    TIMSK1 |= (1 << OCIE1A);
}

volatile uint8_t pwm_value = 0; 
volatile bool direction_up = true;
ISR(TIMER1_COMPA_vect)
{
    if (direction_up) {
        pwm_value++;
        if (pwm_value >= 255) {
            pwm_value = 255;
            direction_up = false;
        }
    } else {
        pwm_value--;
        if (pwm_value <= 0) {
            pwm_value = 0;
            direction_up = true;
        }
    }

    OCR0A = pwm_value;
    OCR0B = pwm_value; 
}

int main(void)
{
	DDRD = 0xFF;
	sei();
    pwm_setup();
    timer1_setup();
    
    while (1)
    {

    }
    
    return 0; 
}