import random

def generate_max_sum_array(num: int, length: int) -> list:
    result = []
    if num <= 0 or length <= 0:
        return result
    
    max_sum = 0
    
    for i in range(num):
        array = [random.random() for _ in range(length)]
        current_sum = sum(array)
        
        if current_sum > max_sum:
            max_sum = current_sum
            result = array
    
    return result


result = generate_max_sum_array(5, 10)
print(f"Массив с наибольшей суммой: {result}")
print()
print(f"Сумма элементов: {sum(result)}")
