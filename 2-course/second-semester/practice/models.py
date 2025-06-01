from database import Database
from abc import ABC, abstractmethod

class Entity(Database, ABC):
    registry = {}

    def __init_subclass__(cls, **kwargs):
        super().__init_subclass__(**kwargs)
        if hasattr(cls, 'type') and callable(cls.type):
            Entity.registry[cls.type()] = cls

    def __init__(self, entity_id, name, author, price):
        self.id = entity_id
        self.name = name
        self.author = author
        self.price = price
    
    @classmethod
    @abstractmethod
    def from_row(cls, row):
        pass

    def get_fields(self):
        return vars(self).copy()

    def get_fields_values(self):
        return list(self.get_fields().values())
    
    @staticmethod
    @abstractmethod
    def type():
        pass

    def store(self):
        Database.store(self)

    def update(self):
        Database.update(self)

    @classmethod
    def get_all(cls):
        rows = Database.get_all()
        items = []
        for row in rows:
            type_ = row["type"]
            klass = cls.registry.get(type_)
            if klass:
                items.append(klass.from_row(row))
        return items

class Book(Entity):
    def __init__(self, entity_id, name, author, price):
        super().__init__(entity_id, name, author, price)

    @staticmethod
    def type():
        return "book"
    
    @classmethod
    def from_row(cls, row):
        id_, _, name, author, price, _, _ = row
        return cls(id_, name, author, price)

class AudioBook(Entity):
    def __init__(self, entity_id, name, author, price, narrator, duration):
        super().__init__(entity_id, name, author, price)
        self.narrator = narrator
        self.duration = duration

    @staticmethod
    def type():
        return "audiobook"

    @classmethod
    def from_row(cls, row):
        id_, _, name, author, price, narrator, duration = row
        return cls(id_, name, author, price, narrator, duration)
