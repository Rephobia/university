import re

def check_phone(phone):
    pattern = r'^(\+7|8)\((909|912|922)\)\d{3}-\d{2}-\d{2}$'

    return bool(re.match(pattern, phone))


phones = [
    "+7(922)123-45-67",
    "8(922)123-45-67",
    "+7(909)123-45-67",
    "+7(923)123-45-67",
    "+5(922)123-45-67",
    "+7(922)1234567",
    "+7(922)123456",
]
    
    
for phone in phones:
    res = check_phone(phone)
    print(f"{phone} : {res}")
