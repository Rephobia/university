import matplotlib.pyplot as plt

from recommendations import critics

film_x = "Зима в Простоквашино"
film_y = "Ну, погоди!"

plt.figure(figsize=(8, 6))

for critic in critics:
    if film_x in critics[critic] and film_y in critics[critic]:
        x_value = critics[critic][film_x]
        y_value = critics[critic][film_y]

        plt.scatter(x_value, y_value)
        plt.annotate(
            critic,
            (x_value, y_value),
            xytext=(5, 5),
            textcoords="offset points"
        )

plt.xlabel(film_x)
plt.ylabel(film_y)
plt.title("Задание 1. Вариант 4")
plt.grid(True)

plt.show()
