from math import sqrt
from random import randint


ATTEMPTS = 10
GUESS_LOWER = 0
GUESS_UPPER = 1000
NUMBER_LOWER = 0
NUMBER_UPPER = 100_000
TRIANGLES_LOWER = 0
TRIANGLES_UPPER = 100

def main():
    task1()
    task2()
    task3()

def check_number(n, limit):
    """
    Определение типа числа – простое | составное"""
    return (any(n % i == 0 for i in range(2, limit + 1) if i != n))
    
def check_triangle(a, b, c):
    """
    Определение типа треугольника
    """
    if not all([a < b + c, b < a + c, c < a + b]):
        return 'Треугольника не существует'
    if a == b == c:
        return 'Равносторонний'
    elif a == b or b == c or c == a:
        return 'Равнобедренный'
    else:
        return 'Разносторонний'

def guess(number):
    """
    Угадывание чисел
    """
    print('Введите число в диапазоне от', GUESS_LOWER, 'до', GUESS_UPPER)
    for count in range(ATTEMPTS):
        choice = int(input(f'{count + 1} попытка: '))
        if choice == number:
            return f'Верно. Загаданное число: {number}'
        print('Больше') if choice < number else print('Меньше')
    return f'Попытки закончились. Загаданное число: {number}'

def task1():
    a = randint(TRIANGLES_LOWER, TRIANGLES_UPPER)
    b = randint(TRIANGLES_LOWER, TRIANGLES_UPPER)
    c = randint(TRIANGLES_LOWER, TRIANGLES_UPPER)
    print(f'Сторона a: {a}, сторона b: {b}, сторона c: {c}')
    print(check_triangle(a, b, c))

def task2():
    number = None
    while not number or (number < NUMBER_LOWER or number > NUMBER_UPPER):
        number = int(input(f'Введите число в диапазоне от {NUMBER_LOWER} до {NUMBER_UPPER}: '))
    print('Простое') if not check_number(number, round(sqrt(number))) else print('Составное')

def task3():
    number = randint(GUESS_LOWER, GUESS_UPPER)
    print(guess(number))

if __name__ == '__main__':
    main()
