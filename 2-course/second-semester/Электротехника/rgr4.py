import numpy as np
import matplotlib.pyplot as plt
from scipy.signal import square

# Параметры входного сигнала
U_m = 20       # Амплитуда (В)
T = 20e-6      # Период (с)
q = 4          # Скважность
tau_pulse = T / q  # Длительность импульса (с)

# Номиналы элементов
R1 = 2.2e3     # Сопротивление R1 (Ом)
R2 = 2.7e3     # Сопротивление R2 (Ом)
C1 = 0.01e-6   # Ёмкость C1 (Ф)
C2 = 0.08e-6   # Ёмкость C2 (Ф)

# Постоянные времени RC-цепей
tau1 = R1 * C1  # Постоянная времени для R1C1 (с)
tau2 = R2 * C2  # Постоянная времени для R2C2 (с)

# Время моделирования
t_total = 5 * T  # Общее время моделирования (5 периодов)
t = np.linspace(0, t_total, 5000)  # Временная шкала

# Генерация входного сигнала (прямоугольные импульсы)
input_signal = U_m * (square(2 * np.pi * t / T, duty=100/q) > 0)

# Моделирование u_ex (выход R1C1)
u_ex = np.zeros_like(t)
for i in range(1, len(t)):
    dt = t[i] - t[i-1]
    if input_signal[i] > 0:
        u_ex[i] = u_ex[i-1] + (U_m - u_ex[i-1]) * (dt / tau1)
    else:
        u_ex[i] = u_ex[i-1] - u_ex[i-1] * (dt / tau1)

# Моделирование u_aux (выход R2C2)
u_aux = np.zeros_like(t)
for i in range(1, len(t)):
    dt = t[i] - t[i-1]
    u_aux[i] = u_aux[i-1] + (u_ex[i] - u_aux[i-1]) * (dt / tau2)

# Построение графиков
plt.figure(figsize=(12, 8))

# Входной сигнал
plt.subplot(3, 1, 1)
plt.plot(t, input_signal, 'r', label='Входной сигнал')
plt.title('Временные диаграммы работы схемы')
plt.ylabel('Напряжение (В)')
plt.legend()
plt.grid(True)

# Сигнал u_ex (R1C1)
plt.subplot(3, 1, 2)
plt.plot(t, u_ex, 'g', label='u_ex (R1C1)')
plt.ylabel('Напряжение (В)')
plt.legend()
plt.grid(True)

# Сигнал u_aux (R2C2)
plt.subplot(3, 1, 3)
plt.plot(t, u_aux, 'b', label='u_aux (R2C2)')
plt.xlabel('Время (с)')
plt.ylabel('Напряжение (В)')
plt.legend()
plt.grid(True)

plt.tight_layout()
plt.show()
