import sys
from database import Database
from models import Book, AudioBook

def seed_data():
    Book(None, 'Преступление и наказание', 'Фёдор Достоевский', 399.99).store()
    Book(None, 'Война и мир', 'Лев Толстой', 499.99).store()
    Book(None, 'Мастер и Маргарита', 'Михаил Булгаков', 349.00).store()

    AudioBook(None, '1984', 'Джордж Оруэлл', 299.00, 'Иван Иванов', '11ч 30м').store()
    AudioBook(None, 'Атлант расправил плечи', 'Айн Рэнд', 599.50, 'Ольга Петрова', '35ч 00м').store()
    AudioBook(None, 'Гарри Поттер и философский камень', 'Джоан Роулинг', 279.90, 'Дмитрий Губ', '8ч 45м').store()


def main():
    clear_flag = '--clear' in sys.argv
    if clear_flag:
        Database.clear_db()
        print("База очищена")

    Database.create_table()
    seed_data()
    print("База наполнена")


if __name__ == "__main__":
    main()
