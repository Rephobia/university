/*
 * lab2.c
 *
 * Created: 18.06.2026 23:05:38
 * Author : erdyakov
 */ 


#include <avr/io.h>
#include <avr/interrupt.h>

#define F_CPU 16000000UL


void delay_second()
{
	TCNT1 = 0;
	
	TCCR1B |= (1 << CS12) | (0 << CS11) | (0 << CS10);
	OCR1A = 62500 - 1;
	// —брос флага переполнени€ (на вс€кий случай)
	// —огласно таблице 15-6 (регистр TIFR1)
	TIFR1 |= (1 << OCF1A); // —брос флага совпадени€ OCF1A
	
	// ∆дем, пока таймер не досчитает до OCR1A
	// Ѕиты регистра TIFR1 описаны в таблице 15-6 даташита
	while (!(TIFR1 & (1 << OCF1A)))
	{
		// ѕустой цикл - процессор ждет, пока таймер досчитает
		// ‘лаг OCF1A устанавливаетс€ в 1 при совпадении TCNT1 и OCR1A
		// —огласно таблице 15-6: OCF1A - бит 1 в TIFR1
		// 1<<1 = 0b00000010 (провер€ем бит 1)
	}
	
	// ќстанавливаем таймер (CS12=0, CS11=0, CS10=0)
	TCCR1B &= ~((1 << CS12) | (1 << CS11) | (1 << CS10));
	
	// —брасываем флаг совпадени€
	TIFR1 |= (1 << OCF1A);
}

void timer_shadow()
{
    TCCR1A = 0;
    TCCR1B = 0;
    TCNT1 = 0;
    
    // Ќастройка режима CTC (Clear Timer on Compare)
    // Ѕит WGM12 = 1 в регистре TCCR1B
    //TCCR1B |= (1 << WGM12);
	/*
     * “аблица выбора предделител€ (Clock Select):
     * CS12 CS11 CS10 | ƒелитель
     *  0    0    0   | “аймер остановлен
     *  0    0    1   | 1 (без делени€) - 16 ћ√ц
     *  0    1    0   | 8 - 2 ћ√ц
     *  0    1    1   | 64 - 250 к√ц
     *  1    0    0   | 256 - 62.5 к√ц
     *  1    0    1   | 1024 - 15.625 к√ц
	*/
	TCCR1B |= (1 << CS12) | (0 << CS11) | (0 << CS10);
	TIMSK1 |= (1 << OCIE1A) | (1 << OCIE1B); // разрешить прерывани€ при совпадении
    // Ќастройка регистра сравнени€ OCR1A, флаг success будет OCF1A
    // ƒл€ задержки 1 секунду:
    // „астота тактировани€ таймера = F_CPU / делитель
    // Ќапример, с делителем 64: 16 ћ√ц / 64 = 250 к√ц
    // ќдин такт = 1/250000 = 4 мкс
    // ƒл€ 1 секунды нужно: 1 / 0.000004 = 250000 тактов
    OCR1A = 25000 - 1;
	OCR1B = 62500 - 1;
}

volatile int8_t shadow_led = 0;
ISR(TIMER1_COMPA_vect)
{
	PORTD = 0xFF;
}


ISR(TIMER1_COMPB_vect)
{
	PORTD = 0x00;
}

void timer_move()
{
    TCCR2A = 0;
    TCCR2B = 0;
    TCNT2 = 0;
    
    // Ќастройка режима CTC (Clear Timer on Compare)
    // Ѕит WGM12 = 1 в регистре TCCR1B
    TCCR2B |= (1 << WGM22);
	
	/*
     * “аблица выбора предделител€ (Clock Select):
     * CS12 CS11 CS10 | ƒелитель
     *  0    0    0   | “аймер остановлен
     *  0    0    1   | 1 (без делени€) - 16 ћ√ц
     *  0    1    0   | 8 - 2 ћ√ц
     *  0    1    1   | 64 - 250 к√ц
     *  1    0    0   | 256 - 62.5 к√ц
     *  1    0    1   | 1024 - 15.625 к√ц
	*/
	TCCR2B |= (1 << CS22) | (1 << CS21) | (1 << CS20);
	TIMSK2 |= (1 << OCIE2A); // разрешить прерывани€ при совпадении
    // Ќастройка регистра сравнени€ OCR1A, флаг success будет OCF1A
    // ƒл€ задержки 1 секунду:
    // „астота тактировани€ таймера = F_CPU / делитель
    // Ќапример, с делителем 64: 16 ћ√ц / 64 = 250 к√ц
    // ќдин такт = 1/250000 = 4 мкс
    // ƒл€ 1 секунды нужно: 1 / 0.000004 = 250000 тактов
    OCR2A = 155 - 1;
}

volatile int8_t move_led = 4;
ISR(TIMER2_COMPA_vect)
{
    PORTD &= 0x0F;
	PORTD |= (1 << move_led++);
	if (move_led == 8) {
		move_led = 4;
		
	}
}


volatile uint8_t timer1_enabled = 1;
void toggle_timer1()
{
	timer1_enabled ^= 1;

	if (timer1_enabled)
	{
		TIMSK1 |= (1 << OCIE1A);
	}
	else
	{
		TIMSK1 &= ~(1 << OCIE1A);
	}
}

volatile uint8_t timer2_enabled = 1;
void toggle_timer2()
{
	timer2_enabled ^= 1;

	if (timer2_enabled)
	{
		TIMSK2 |= (1 << OCIE2A);
	}
	else
	{
		TIMSK2 &= ~(1 << OCIE2A);
	}
}

int main(void)
{
	DDRD |= 0xFF;
	DDRB &= ~((1 << PB0) | (1 << PB1));
	sei();
	timer_shadow();
	
    while (1)
    {

	}
}