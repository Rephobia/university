import math

def euclidean_distance(a, b):
    diff = [(a[i] - b[i]) ** 2 for i in range(len(a))]
    return math.sqrt(sum(diff))

point1 = [1, 2, 3]
point2 = [4, 6, 3]

distance = euclidean_distance(point1, point2)
print(distance)
