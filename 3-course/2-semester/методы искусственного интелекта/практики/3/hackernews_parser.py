import requests
from bs4 import BeautifulSoup

def getRows(url):
    response = requests.get(url)
    doc = BeautifulSoup(response.text, "html.parser")
    return doc.find_all("tr", class_="athing")
    
news = []
for row in getRows("https://news.ycombinator.com/"):
    title = row.find("span", class_="titleline").get_text()
    subtext = row.find_next_sibling("tr").find("td", class_="subtext")

    points = 0
    comments = 0

    if subtext:
        score = subtext.find("span", class_="score")
        if score:
            points = int(score.text.split()[0]) # raw 12 points 

        links = subtext.find_all("a")
        if links:
            last_link = links[-1].text # последняя ссылка комменты

            if "comment" in last_link:
                comments = int(last_link.split()[0])

    news.append({
        "title": title,
        "points": points,
        "comments": comments
    })

for item in news:
    print(
        f"{item['title']}\n"
        f"Рейтинг: {item['points']}, "
        f"Комментарии: {item['comments']}\n"
    )

max_points = max(news, key=lambda x: x["points"])
max_comments = max(news, key=lambda x: x["comments"])

avg_points = sum(x["points"] for x in news) / len(news)
avg_comments = sum(x["comments"] for x in news) / len(news)

print("\nСтатистика")
print(f"Количество новостей: {len(news)}")
print(f"Средний рейтинг: {avg_points:.2f}")
print(f"Среднее число комментариев: {avg_comments:.2f}")
print(f"Самая популярная новость: {max_points['title']}")
print(f"Максимальный рейтинг: {max_points['points']}")
print(f"Больше всего комментариев: {max_comments['title']}")
print(f"Комментариев: {max_comments['comments']}")
