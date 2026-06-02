import re

from base_rule import BaseRule

class PassportRule(BaseRule):
    name = "Паспорт РФ"
    severity = "critical"
    pattern = r'\b(\d{4})\s?(\d{6})\b'

    def validate(self, match: str) -> bool:
        digits = ''.join(re.findall(r'\d', match))
        if len(digits) != 10:
            return False
        series = int(digits[:4])
        return 1000 <= series <= 9999
