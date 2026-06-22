#define F_CPU 16000000

#include <avr/io.h>
#include <util/delay.h>
#include <stdint.h>

void setup()
{
	DDRD = 0xFF;

	DDRB &= ~((1 << PB0) | (1 << PB1));
	PORTB |= (1 << PB0) | (1 << PB1);
}

void sprint_left(int8_t len)
{
	for(int8_t i = 0; i < len; i++)
	{
		PORTD = 1 << i;
		_delay_ms(200);
	}
}

void sprint_right(int8_t len)
{
	for(int8_t i = len - 1; i >= 0; i--)
	{
		PORTD = 1 << i;
		_delay_ms(200);
	}
}

void sprint_full(int8_t len)
{
	int8_t i = 0;
	int8_t j = len - 1;
	
	for(; i < len / 2; i++, j--)
	{
		PORTD = (1 << i) + (1 << j);
		_delay_ms(200);
	}

	i++;
	j--;
	
	for(; i < len; i++, j--)
	{
		PORTD = (1 << i) + (1 << j);
		_delay_ms(200);
	}
	
}


int main(void)
{
	setup();

	while (1)
	{	
		PORTD = 0xFF;
		_delay_ms(300);
		
		if (!(PINB & (1 << PB0)) && !(PINB & (1 << PB1)))
		{
			sprint_full(8);
		}
		else if (!(PINB & (1 << PB0)) && (PINB & (1 << PB1)))
		{
			sprint_left(8);
		}
		else if ((PINB & (1 << PB0)) && !(PINB & (1 << PB1)))
		{
			sprint_right(8);
		}
	}
}