import re

from base_rule import BaseRule

class EmailRule(BaseRule):
    name = "Email"
    severity = "medium"
    pattern = r'\b[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}\b'

    def validate(self, match: str) -> bool:
        return True
