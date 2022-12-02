import random, time


def task1():
    lst = [1, 2, 3, 4, 5]
    print(lst)
    random.shuffle(lst)
    print(lst)


def task1Alt():
    lst = [1, 2, 3, 4, 5]
    print(lst)
    for i in range(len(lst)):
        new_place = rand_number(len(lst) - 1)
        (lst[i], lst[new_place]) = (lst[new_place], lst[i])
    print(lst, )


def task2():
    """
    Задайте список. Напишите программу, которая определит, присутствует ли в заданном списке строк некое число.
    """
    lst = ["hello", "2", "test3", "4", "5sd7svs4"]
    print(find_number(lst, input("Введите число для проверки: ")))


def task3():
    """
    Напишите программу, которая определит позицию второго вхождения строки в списке либо сообщит, что её нет.
    """
    lst = ["hello", "2", "test3", "4", "5sd7svs4", "hello", 4, "4"]
    element = input()
    count = 0; index = -1
    for i in range(len(lst)):
        if lst[i] == element: count += 1
        if count == 2:
            count = 0
            index = i
    print(index)


def task4():
    """
    Задайте список из нескольких чисел. Напишите программу, которая найдёт сумму элементов списка, стоящих на нечётной позиции.
    """
    lst = [1, 2, 3, 4, 5]
    sum = 0
    if len(lst) >= 2:
        for i in range(1, len(lst), 2):
            sum += lst[i]
    print(sum)
    

def find_number(lst, n):
    for i in lst:
        if n in i: return True
    return False


def rand_number(rng):
    """
    Функция рандомной генерации числа.
    Принимает граничное значение, в пределах которого будет генерироваться число.
    Для генерации случайного числа из системного времени выделяется наиболее быстро изменяющаяся часть и делится по модулю на диапазон.
    """
    return int(((time.time() - int(time.time())) * 1000000) % rng)

# task1()
# task1Alt()
# task2()
# task3()
task4()