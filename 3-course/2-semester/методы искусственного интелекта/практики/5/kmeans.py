import numpy as np
from random import *
import math


# k - количество искомых кластеров
# X - объекты
def k_means(k, X):
    m = X.shape[0]  # количество точек
    n = X.shape[1]  # количество признаков объекта
    curr_iteration = prev_iteration = np.zeros([m, 1])

    # генерируем k центров со случайными координатами
    idx = np.arange(0, m)
    shuffle(idx)
    centers = X[idx[0: k], :]

    all_centers = np.copy(centers)
    errors = np.array([])

    # приписываем каждую точку к заданному классу
    curr_iteration, e = class_of_each_point(X, centers)
    # TODO: внести ошибку e для текущей итерации в вектор errors
    # Для этого необходимо воспользоваться функцией append из библиотеки numpy.
    # Для справки выполнить в консоли Python команду help('numpy.append')
    # и поэкспериментировать с функцией append
    # Пример:
    # >>> import numpy as np
    # >>> a = np.array([1, 2])
    # >>> b = 3
    # >>> c = np.append(a, b)
    # >>> c
    #   array([1, 2, 3])
    # errors = ...
    errors = np.append(errors, e)
    # цикл до тех пор, пока центры не стабилизируются
    iteration_count = 1
    while not np.all(curr_iteration == prev_iteration):

        prev_iteration = curr_iteration

        # вычисляем новые центры масс
        for i in range(0, k):
            sub_X = X[curr_iteration == i, :]
            if len(sub_X) > 0:
                centers[i, :] = mass_center(sub_X)
            else:
                centers[i, :] = X[randint(0, m-1)]

        # TODO: внести текущие центры кластеров (centers) в список всех центров (all_centers)
        # присоединить подматрицу к матрице можно с помощью уже знакомой функции append из библиотеки numpy
        # all_centers = ...

        # приписываем каждую точку к заданному классу
        all_centers = np.append(all_centers, centers)
        
        curr_iteration, e = class_of_each_point(X, centers)

        # TODO: внести ошибку e для текущей итерации в вектор errors
        # errors = ...
        errors = np.append(errors, e)
        iteration_count += 1

    # TODO: преобразовать матрицу all_centers в трехмерную.
    # размерность можно менять с помощью функции numpy.reshape
    # первый параметр - матрица, для которой меняем размерность
    # второй параметр - размеры:
    #  первое измерение - количество итераций алгоритма (iteration_count)
    #  второе измерение - количество искомых кластеров
    #  третье измерение - количество признаков (рост и вес)
    # Пример:
    # >>> a = np.arange(1, 9)
    # >>> a
    # array([1, 2, 3, 4, 5, 6, 7, 8])
    # >>> b = np.reshape(a, [2, 2, 2])
    # >>> b
    # array([[[1, 2],
    #         [3, 4]],
    # 
    #        [[5, 6],
    #         [7, 8]]])
    # >>> b.shape
    # (2, 2, 2)
    # all_centers = np.reshape(...)

    # TODO: модифицировать оператор return так, чтобы
    # функция возвращала переменные centers, all_centers и errors

    all_centers = np.reshape(
        all_centers,
        [iteration_count, k, n]
    )
    return centers, all_centers, errors


# вычисление расстояния между двумя точками
def dist(p1, p2):
    return math.sqrt(sum((p1 - p2)**2))


# вычисление центра масс X (среднее по каждому столбцу)
def mass_center(X):
    return np.mean(X, axis=0)


# возвращает список индексов ближайших центров по каждой точке
def class_of_each_point(X, centers):

    m = X.shape[0]
    k = centers.shape[0]

    # матрица расстояний от каждой точки до каждого центра
    distances = np.zeros([k, m])
    for i in range(0, k):
        for j in range(0, m):
            distances[i, j] = dist(centers[i], X[j])

    # поиск ближайшего центра для каждой точки
    min_dist = np.min(distances, axis=0)
    classes = np.argmin(distances, axis=0)

    # TODO: вычислить ошибку кластеризации
    # ошибка вычисляется как средний квадрат расстояния
    # от каждой точки до ближайшего центра кластера
    # Для возведения в квадрат используйте функцию pow(a, 2),
    # а для вычисления среднего numpy.mean(a), где a - это numpy.array
    # err = ...
    err = np.mean(pow(min_dist, 2))
    return classes, err
