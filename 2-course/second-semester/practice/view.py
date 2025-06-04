from abc import ABC, abstractmethod
import tkinter as tk
from tkinter import ttk, messagebox, simpledialog
import statistics
from models import Entity, Book, AudioBook

class View(ABC):
    @abstractmethod
    def start(self):
        pass

class Tinker(View):
    tinker_handle = None
    
    def __init__(self):
        self.tinker_handle = tk.Tk()
        self.tinker_handle.title("Библиотека")
        self.list_widget()
        self.buttons_widget()

        self.refresh()

    def start(self):
        self.tinker_handle.mainloop()

    def list_widget(self):
        columns = ('type', 'ID', 'Наименование', 'Автор', 'Стоимость', 'Диктор', 'Длительность')
        self.tree = ttk.Treeview(self.tinker_handle, columns=columns, show='headings', selectmode='extended')
        for col in columns:
            self.tree.heading(col, text=col)
            self.tree.column(col, width=120)
        self.tree.pack(fill=tk.BOTH, expand=True)
        
        self.tree.column("type", width=0, stretch=False)
        
    def buttons_widget(self):
        btn_frame = tk.Frame(self.tinker_handle)
        btn_frame.pack(pady=5)

        ttk.Button(btn_frame, text="Добавить книгу", command=self.add_book).grid(row=0, column=0, padx=5)
        ttk.Button(btn_frame, text="Добавить аудиокнигу", command=self.add_audiobook).grid(row=0, column=1, padx=5)
        ttk.Button(btn_frame, text="Редактировать", command=self.edit_selected).grid(row=0, column=2, padx=5)
        ttk.Button(btn_frame, text="Удалить", command=self.delete_selected).grid(row=0, column=3, padx=5)
        ttk.Button(btn_frame, text="Посчитать среднюю и медиану", command=self.calculate_stats).grid(row=0, column=4, padx=5)

    def refresh(self):
        for i in self.tree.get_children():
            self.tree.delete(i)

        for entity in Entity.get_all():
            values = [entity.type()] + entity.get_fields_values()
            self.tree.insert('', tk.END, values=values)

    def add_book(self):
        name = simpledialog.askstring("Добавить книгу", "Наименование:")
        author = simpledialog.askstring("Автор", "Автор:")
        price = simpledialog.askfloat("Стоимость", "Стоимость:")
        if name and author and price is not None:
            Book(None, name, author, price).store()
            self.refresh()

    def add_audiobook(self):
        name = simpledialog.askstring("Добавить аудиокнигу", "Наименование:")
        author = simpledialog.askstring("Автор", "Автор:")
        price = simpledialog.askfloat("Стоимость", "Стоимость:")
        narrator = simpledialog.askstring("Диктор", "Диктор:")
        duration = simpledialog.askstring("Длительность", "Длительность:")
        if name and author and price is not None and narrator and duration:
            AudioBook(None, name, author, price, narrator, duration).store()
            self.refresh()

    def edit_selected(self):
        selected = self.tree.selection()
        if not selected:
            messagebox.showwarning("Предупреждение", "Выберите элемент для редактирования.")
            return
        item = self.tree.item(selected[0])['values']
        type_ = item[0]
        entity_id = item[1]
        name = simpledialog.askstring("Редактировать", "Наименование:", initialvalue=item[2])
        author = simpledialog.askstring("Автор", "Автор:", initialvalue=item[3])
        price = simpledialog.askfloat("Стоимость", "Стоимость:", initialvalue=item[4])
        if type_ == Book.type():
            if name and author and price is not None:
                Book(entity_id, name, author, price).update()
        else:
            narrator = simpledialog.askstring("Диктор", "Диктор:", initialvalue=item[5])
            duration = simpledialog.askstring("Длительность", "Длительность:", initialvalue=item[6])
            if name and author and price is not None and narrator and duration:
                AudioBook(entity_id, name, author, price, narrator, duration).update()
        self.refresh()

    def delete_selected(self):
        selected = self.tree.selection()
        if not selected:
            messagebox.showwarning("Предупреждение", "Выберите элемент для удаления.")
            return
        for sel in selected:
            item = self.tree.item(sel)
            entity_id = item['values'][1]
            Entity.delete(entity_id)
        self.refresh()

    def calculate_stats(self):
        selected_items = self.tree.selection()
        if not selected_items:
            messagebox.showinfo("Информация", "Выберите хотя бы один элемент.")
            return

        prices = []
        for item_id in selected_items:
            item = self.tree.item(item_id)
            values = item['values']
            try:
                price = float(values[4])
                prices.append(price)
            except (IndexError, ValueError):
                continue

        if not prices:
            messagebox.showwarning("Ошибка", "Не удалось получить стоимость из выбранных элементов.")
            return

        avg = round(sum(prices) / len(prices), 2)
        med = round(statistics.median(prices), 2)

        messagebox.showinfo("Результат", f"Средняя стоимость: {avg}₽\nМедиана: {med}₽")
