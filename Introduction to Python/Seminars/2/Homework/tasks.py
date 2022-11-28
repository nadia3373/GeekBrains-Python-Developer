import lib

def task1():
    """
    Напишите программу, которая принимает на вход вещественное число и показывает сумму его цифр.
    """
    n = float(input("Введите число: "))
    print(f"Сумма цифр числа {n} равна {lib.sum_digits(n)}")


def task1V2():
    """
    Напишите программу, которая принимает на вход вещественное число и показывает сумму его цифр.
    """
    n = input("Введите число: ")
    print(f"Сумма цифр числа {n} равна {lib.sum_digits_str(n)}")


def task2():
    """
    Напишите программу, которая принимает на вход число N и выдает набор произведений чисел от 1 до N.
    """
    n = int(input("Введите N: "))
    for i in range(1, n + 1):
        print(f"Произведение чисел от 1 до {i} = {lib.multiply(i)}")


def task3():
    """
    Задайте словарь из n чисел последовательности (1 + (1/n))^n и выведите на экран их сумму.
    """
    numbers = {n: round((1 + (1 / n)) ** n, 2) for n in range(1, int(input("Введите количество элементов последовательности: ")) + 1)}
    print(f"Полученный словарь: {numbers}, сумма элементов = {sum(numbers.values())}")


def task4():
    """
    Задайте список из N элементов, заполненных числами из промежутка [-N, N]. Найдите произведение элементов на указанных позициях. Позиции хранятся в файле file.txt в одной строке одно число.
    """
    num = int(input("Введите N: "))
    step = -1 if num < -num else 1
    numbers = [i for i in range(-num, num + step, step)]
    print(f"Список: {numbers}")
    lib.write_to_file("file.txt", len(numbers), 3)
    indices = lib.read_from_file("file.txt")
    result = numbers[int(indices[0])]
    for i in range(1, len(indices)):
        result *= numbers[int(indices[i])]
    print(f"Произведение элементов списка на индексах {indices} = {result}")
    


def task5():
    """
    Реализуйте алгоритм генерации случайного числа.(Не используя библиотеки связанные с рандомом)
    """
    print("Случайные сгенерированные числа: ", end = "")
    for _ in range(10):
        print(f"{lib.rand_number(20)} ", end = "")
    print()


task1()
if (input("\nНажмите Y для перехода к следующему заданию: ").lower() == "y"):
    task1V2()
if (input("\nНажмите Y для перехода к следующему заданию: ").lower() == "y"):
    task2()
if (input("\nНажмите Y для перехода к следующему заданию: ").lower() == "y"):
    task3()
if (input("\nНажмите Y для перехода к следующему заданию: ").lower() == "y"):
    task4()
if (input("\nНажмите Y для перехода к следующему заданию: ").lower() == "y"):
    task5()