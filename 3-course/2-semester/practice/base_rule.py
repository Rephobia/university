from abc import ABC, abstractmethod
import re

class BaseRule(ABC):
    """Базовый класс для правила поиска."""

    @property
    @abstractmethod
    def name(self) -> str:
        pass

    @property
    @abstractmethod
    def severity(self) -> str:
        pass

    @property
    @abstractmethod
    def pattern(self) -> str:
        pass

    @abstractmethod
    def validate(self, match: str) -> bool:
        """Валидация найденного совпадения (контрольные суммы и т.п.)."""
        pass

    def check(self, line: str, line_num: int, filepath: str) -> list:
        """Ищет совпадения в строке, возвращает список находок."""
        findings = []
        for match in re.finditer(self.pattern, line):
            matched_text = match.group(0)
            # Валидация
            if not self.validate(matched_text):
                continue

            findings.append({
                'file': str(filepath),
                'line': line_num,
                'column': match.start() + 1,
                'match': matched_text,
                'rule_name': self.name,
                'severity': self.severity,
                'context': line.strip(),
            })
        return findings
