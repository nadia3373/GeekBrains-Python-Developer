import lib


def task1():
    """
    Напишите программу, которая найдёт произведение пар чисел списка. Парой считаем первый и последний элемент, второй и предпоследний и т.д.
    """
    lst = [2, 3, 4, 5, 6]
    print([i * j for i, j in zip(lst[:len(lst) // 2 + 1], lst[len(lst) - 1: len(lst) // 2 - 1: -1])])


def task2():
    """
    Задайте список из вещественных чисел. Напишите программу, которая найдёт разницу между максимальным и минимальным значением дробной части элементов.
    """
    lst = [1.1, 1.2, 3.1, 5.1, 10.01]
    lst = list(map(lambda i: round(i - int(i), 2), lst))
    print(max(lst) - min(lst))


def task3():
    """
    Напишите программу, которая будет преобразовывать десятичное число в двоичное.
    """
    n = int(input("Введите n: "))
    print(f"Число {n} в двоичном представлении: ", end = "")
    lib.bin(n)
    print()


def task4():
    """
    Задайте число. Составьте список чисел Фибоначчи, в том числе для отрицательных индексов.
    """
    n = int(input("Введите n: "))
    print(f"Последовательность НегаФибоначчи для числа {n}: {[lib.fib(i) for i in range(-n, n + 1, 1)]}")


task1()
if (input("\nНажмите Y для перехода к следующему заданию: ").lower() == "y"):
    task2()
if (input("\nНажмите Y для перехода к следующему заданию: ").lower() == "y"):
    task3()
if (input("\nНажмите Y для перехода к следующему заданию: ").lower() == "y"):
    task4()