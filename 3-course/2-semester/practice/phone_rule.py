import re

from base_rule import BaseRule

class PhoneRule(BaseRule):
    name = "Телефон РФ"
    severity = "medium"
    pattern = r'(?:\+7|8)[\s-]?\(?(\d{3})\)?[\s-]?(\d{3})[\s-]?(\d{2})[\s-]?(\d{2})\b'

    def validate(self, match: str) -> bool:
        digits = ''.join(re.findall(r'\d', match))
        if len(digits) not in (11, 12):
            return False
        last10 = digits[-10:]
        if last10 in ('0000000000', '1111111111', '2222222222',
                      '3333333333', '4444444444', '5555555555',
                      '6666666666', '7777777777', '8888888888', '9999999999'):
            return False
        return True
