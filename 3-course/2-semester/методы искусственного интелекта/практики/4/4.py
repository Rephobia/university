import os
from math import sqrt

from recommendations import critics

def get_same(critics, person1, person2):
    same = {}
    for item in critics[person1]:
        if item in critics[person2]:
            same[item] = 1

    return same
    

def sim_distance(critics, person1, person2):
    same = get_same(critics, person1, person2)

    if len(same) == 0:
        return 0

    sum_of_squares = sum(
        [(critics[person1][item] - critics[person2][item]) ** 2 for item in same]
    )

    return 1 / (1 + sqrt(sum_of_squares))


def sim_pearson(critics, person1, person2):
    same = get_same(critics, person1, person2)

    if len(same) == 0:
        return 0
    
    sum1 = sum(critics[person1][item] for item in same)
    sum2 = sum(critics[person2][item] for item in same)

    sum1Sq = sum(critics[person1][item] ** 2 for item in same)
    sum2Sq = sum(critics[person2][item] ** 2 for item in same)

    pSum = sum(critics[person1][item] * critics[person2][item] for item in same)

    num = pSum - (sum1 * sum2 / len(same))

    div = sqrt(
        (sum1Sq - sum1 ** 2 / len(same)) *
        (sum2Sq - sum2 ** 2 / len(same))
    )

    if div == 0:
        return 0

    return num / div


def top_matches(critics, person, similarity=sim_pearson):
    scores = []

    for other in critics:
        if other == person:
            continue

        score = similarity(critics, person, other)
        scores.append((score, other))

    scores.sort(reverse=True)
    
    return scores



print("Евклидово расстояние:")
print(sim_distance(critics, 'Пёс Шарик', 'Телёнок Гаврюша'))
print(sim_distance(critics, 'Кот Матроскин', 'Галчонок'))

print("\nПирсон:")
print(sim_pearson(critics, 'Пёс Шарик', 'Телёнок Гаврюша'))
print(sim_pearson(critics, 'Кот Матроскин', 'Галчонок'))

print("\n=== Похожие критики для Пса Шарика ===")
matches = top_matches(critics, 'Пёс Шарик')

for score, name in matches:
    print(name, ":", score)

print("\nСамый похожий:")
print(matches[0])

print("\nСамый непохожий:")
print(matches[-1])

import matplotlib.pyplot as plt

def draw_comparison(critics, person1, person2, title):
    x = []
    y = []
    labels = []

    for movie in critics[person1]:
        if movie in critics[person2]:
            x.append(critics[person1][movie])
            y.append(critics[person2][movie])
            labels.append(movie)

    plt.figure(figsize=(8, 6))

    plt.scatter(x, y)

    for i in range(len(labels)):
        plt.annotate(
            labels[i],
            (x[i], y[i]),
            xytext=(5, 5),
            textcoords="offset points"
        )
        
    plt.plot([1, 5], [1, 5], '--')

    plt.xlabel(person1)
    plt.ylabel(person2)
    plt.title(title)
    plt.grid(True)

    # plt.show()
    
most_similar = matches[0][1]
least_similar = matches[-1][1]

print("Самый похожий:", most_similar)
print("Самый непохожий:", least_similar)

draw_comparison(
    critics,
    'Пёс Шарик',
    most_similar,
    f'Пёс Шарик и {most_similar}'
)

draw_comparison(
    critics,
    'Пёс Шарик',
    least_similar,
    f'Пёс Шарик и {least_similar}'
)

plt.show()
