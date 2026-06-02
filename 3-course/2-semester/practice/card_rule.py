import re

from base_rule import BaseRule

class CardRule(BaseRule):
    name = "Номер банковской карты"
    severity = "critical"
    pattern = r'\b(\d{4})[\s-]?(\d{4})[\s-]?(\d{4})[\s-]?(\d{4})\b'

    def validate(self, match: str) -> bool:
        digits = ''.join(re.findall(r'\d', match))
        return self.luhn_checksum(match)

    def luhn_checksum(self, card_number: str) -> bool:
        digits = [int(d) for d in card_number if d.isdigit()]
        
        if len(digits) < 13 or len(digits) > 19:  # более реалистичные границы
            return False
        
        total = 0
        # Начинаем с конца
        for i, digit in enumerate(reversed(digits)):
            if i % 2 == 1:          # удваиваем каждую вторую с конца
                digit *= 2
                if digit > 9:
                    digit -= 9
            total += digit
        
        return total % 10 == 0
