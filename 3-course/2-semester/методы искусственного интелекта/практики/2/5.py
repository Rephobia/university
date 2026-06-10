import re

def extract_domain(url):
   pattern = r'^https?://([a-zA-Z0-9-]+\.[a-zA-Z]{2,})/?'
   match = re.match(pattern, url)
   if match:
       return match.group(1)

   return None

urls = [
    "http://ya.ru/index.html", 
    "https://wikipedia.org/",
    
    "ftp://some.server/",
    "https://ru.wikipedia.org/",
]
    
    
for url in urls:
    domain = extract_domain(url)
    print(f"{url} : {domain}")
