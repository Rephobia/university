#define F_CPU 16000000UL

#include <avr/io.h>
#include <avr/interrupt.h>
#include <util/delay.h>

uint8_t map(uint16_t value, uint16_t in_max, uint8_t out_max)
{
	return (uint32_t)value * out_max / in_max;
}

void adc_setup(void)
{
    DDRC &= ~((1 << PC0) | (1 << PC1));
    PORTC &= ~((1 << PC0) | (1 << PC1));

	ADMUX =
		(0 << REFS1)
		| (1 << REFS0)
		| (0 << ADLAR)   // выравнивание вправо
		| (0 << MUX3)    // ADC0
		| (0 << MUX2)
		| (0 << MUX1)
		| (0 << MUX0);
		
	ADCSRA =
		(1 << ADEN)   // включить ј÷ѕ 
		| (1 << ADSC)   // запускаем преобразование
		| (0 << ADATE)  // 1 включить авто-триггер (Free Running)
		| (0 << ADIF)   // 0 флаг прерывани€ (очищаетс€ записью 1)
		| (1 << ADIE)   // 1 ? разрешить прерывание ј÷ѕ
		| (1 << ADPS2)  // ADPS2 = 1
		| (1 << ADPS1)  // ADPS1 = 1
		| (1 << ADPS0); // ADPS0 = 1 ? делитель 128
		
    sei();
}
void pwm_setup(void)
{
	DDRB |= (1 << PB1) | (1 << PB2);  // PB1 и PB2 как выходы

	//  COM1x1 COM1x0 | –ежим
	//  0      0      | ќтключен
	//  0      1      | »нвертирующий
	//  1      0      | Ќеинвертирующий
	//  1      1      | »нвертирующий
	TCCR1A |= (1 << COM1A1) | (1 << COM1A0);
	TCCR1A |= (1 << COM1B1) | (0 << COM1B0);
	
    // https://www.alldatasheet.com/datasheet-pdf/view/313560/ATMEL/ATmega328P.html 128 страница
	TCCR1B |= (0 << WGM13) | (0 << WGM12); 
	TCCR1A |= (1 << WGM11) | (1 << WGM10);


	// 0    0    1    | 1            | ~15.6 к√ц
	// 0    1    0    | 8            | ~1.9 к√ц
	// 0    1    1    | 64           | ~244 √ц 
	// 1    0    0    | 256          | ~61 √ц
	// 1    0    1    | 1024         | ~15 √ц
	TCCR1B |= (0 << CS12) | (1 << CS11) | (1 << CS10);

	OCR1A = 0;
	OCR1B = 0;
}

volatile uint16_t adc_led = 0;
volatile uint16_t adc_brightness = 0;
volatile uint8_t channel = 0;
ISR(ADC_vect)
{
	if (channel == 0)
	{
		adc_led = ADC;

		ADMUX = (ADMUX & 0xF0) | 1; // ADC1
		channel = 1;
	}
	else
	{
		adc_brightness = ADC;

		ADMUX = (ADMUX & 0xF0) | 0; // ADC0
		channel = 0;
	}

	ADCSRA |= (1 << ADSC);
}

void leds_setup(void)
{
	DDRD = 0xFF;
	PORTD = 0x00;
	DDRB = 0xFF;
	PORTB = 0xFF;
}

int main(void)
{
    leds_setup();
	pwm_setup();
    adc_setup();
	
    while (1)
    {
        PORTD = (1 << map(adc_led, 1023, 7));
        OCR1A = adc_brightness;
        OCR1B = adc_brightness;
    }
}