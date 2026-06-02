import re

from base_rule import BaseRule

class SNILSRule(BaseRule):
    name = "СНИЛС"
    severity = "high"
    pattern = r'(?:(?<=\D)|^)(?:\d[ -]*?){13,19}\d(?=\D|$)'

    def validate(self, match: str) -> bool:
        digits = ''.join(re.findall(r'\d', match))
        if len(digits) != 11:
            return False
        main_part = [int(d) for d in digits[:9]]
        checksum = int(digits[9:])
        total = sum(d * (9 - i) for i, d in enumerate(main_part))
        if total < 100:
            expected = total
        elif total in (100, 101):
            expected = 0
        else:
            expected = total % 101
            if expected == 100:
                expected = 0
        return expected == checksum
