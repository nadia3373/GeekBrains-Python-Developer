from math import acos
import random
import lib


def task1():
    """
    Вычислить число ПИ (3,1415926535897932384626433832795) c заданной точностью d
    Точность от 0.1 до 0.0000000001
    """
    pi = str(2 * acos(0.0))
    n = input("Введите количество цифр в дробном формате (например: 0.0001 -> 4 цифры после точки): ")
    try:
        n = len(n.split(".")[1])
        print(pi[:n+2])
    except: print("Некорректный ввод")


def task2():
    """
    Задайте натуральное число N. Напишите программу, которая составит список простых множителей числа N. (Выполнили на семинаре)
    """
    n = int(input("Введите число N: "))
    factors = []
    factor = 2
    while n > 1:
        if n % factor == 0:
            factors.append(factor)
            while n % factor == 0: n /= factor
        if factor == 2: factor += 1
        else: factor += 2
    print(factors)
        


def task3():
    """
    Задайте последовательность чисел. Напишите программу, которая выведет список неповторяющихся элементов исходной последовательности.
    """
    lst = lib.generate_sequence()
    print(f"Заданная последовательность чисел: {lst}")
    lst = lib.unique_elements(lst)
    print(f"Неповторяющиеся элементы: {lst}")
                        

def task4():
    """
    Задана натуральная степень k. Сформировать случайным образом список коэффициентов (значения от 0 до 100) многочлена и записать в файл многочлен степени k(до 6 степени).*
    """
    k = random.randint(1, 6)
    eq1 = lib.generate_polynomials(k)
    eq2 = lib.generate_polynomials(k)
    lib.save_to_file(eq1, "1")
    lib.save_to_file(eq2, "2")


def task5():
    """
    Даны два файла, в каждом из которых находится запись многочлена. Задача - сформировать файл, содержащий сумму многочленов.
    """
    with open("1.txt", "r") as f: eq1 = f.read()
    with open("2.txt", "r") as f: eq2 = f.read()
    print(f"Уравнение 1: {eq1}\nУравнение 2: {eq2}")
    eq1 = eq1.split()
    eq2 = eq2.split()
    eq1 = [eq1[i].split("*") for i in range(len(eq1)) if eq1[i] != "=" and eq1[i] != "0"]
    eq2 = [eq2[i].split("*") for i in range(len(eq2)) if eq2[i] != "=" and eq2[i] != "0"]
    lib.normalize(eq1)
    lib.normalize(eq2)
    lib.sum_polynomials(eq1, eq2)
    lib.save_to_file(eq1, "result")
    with open("result.txt", "r") as f: eq1 = f.read()
    print(f"Итоговое уравнение: {eq1}")
    

task1()
if (input("\nНажмите Y для перехода к следующему заданию: ").lower() == "y"):
    task2()
if (input("\nНажмите Y для перехода к следующему заданию: ").lower() == "y"):
    task3()
if (input("\nНажмите Y для перехода к следующему заданию: ").lower() == "y"):
    task4()
    task5()