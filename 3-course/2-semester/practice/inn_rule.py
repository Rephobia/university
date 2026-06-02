import re

from base_rule import BaseRule

class INNRule(BaseRule):
    name = "ИНН"
    severity = "high"
    pattern = r'\b(\d{10}|\d{12})\b'

    def validate(self, match: str) -> bool:
        digits = [int(d) for d in match]
        if len(digits) == 10:
            coeffs = [2, 4, 10, 3, 5, 9, 4, 6, 8]
            n = sum(d * c for d, c in zip(digits[:9], coeffs)) % 11 % 10
            return n == digits[9]
        elif len(digits) == 12:
            coeffs_11 = [7, 2, 4, 10, 3, 5, 9, 4, 6, 8]
            coeffs_12 = [3, 7, 2, 4, 10, 3, 5, 9, 4, 6, 8]
            n10 = sum(d * c for d, c in zip(digits[:10], coeffs_11)) % 11 % 10
            n11 = sum(d * c for d, c in zip(digits[:11], coeffs_12)) % 11 % 10
            return n10 == digits[10] and n11 == digits[11]
        return False
