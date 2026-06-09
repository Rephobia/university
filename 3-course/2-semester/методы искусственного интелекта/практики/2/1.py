import re

def is_color(code: str) -> bool:
    pattern = "^#([a-fA-F0-9]{6}|[a-f-A-F0-9]){3}"
    return bool(re.match(pattern, code))    

codes = [
    "#03B63A",
    "#FFF",
    "#000",
    "ABCDEF",
    "123",
    "#GHIJKL",
]
    
for code in codes:
    print()
    print(f"{code} : {is_color(code)}")
