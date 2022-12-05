from collections import Counter
from functools import reduce
import math
import random


def task1():
    """
    Задайте строку из набора чисел. Напишите программу, которая покажет большее и меньшее число. В качестве символа-разделителя используйте пробел.
    """
    l = random.randint(5, 15)
    s = ""
    for i in range(l):
        s += f"{random.randint(-100, 100)} "
    print(s)
    print(f"Max: {max([int(i) for i in s.split()])} min: {min([int(i) for i in s.split()])}")


def task2():
    """
    Найдите корни квадратного уравнения Ax² + Bx + C = 0 двумя способами
    """
    s = "-5x^2 + 7x + 3 = 0"
    s = s[:-4].split()
    while "+" in s: s.remove(s[s.index("+")])
    while "-" in s:
        s[s.index("-") + 1] = "-" + s[s.index("-") + 1]
        s.remove(s[s.index("-")])
    s = [int(s[i][:s[i].index("x")]) if "x" in s[i] else int(s[i]) for i in range(len(s))]
    d = s[1] ** 2 - 4 * s[0] * s[2]
    if d < 0: print("Корней нет")
    elif d == 0: print(f"x = {-s[1] / 2 * s[0]}")
    else: print(f"x1 = {(-s[1] + d ** 0.5) / (2 * s[0])} x2 = {(-s[1] - d ** 0.5) / (2 * s[0])}")


def task3():
    """
    Задайте два числа. Напишите программу, которая найдёт НОК (наименьшее общее кратное) этих двух чисел.
    """
    m = 60
    n = 24
    m_factors = []
    n_factors = []
    factor = 2
    while m > 1 or n > 1:
        if m % factor == 0:
            while m % factor == 0:
                m_factors.append(factor)
                m /= factor
        if n % factor == 0:
            while n % factor == 0:
                n_factors.append(factor)
                n /= factor
        factor += 1
    print(reduce((lambda x, y: x* y), m_factors + list((Counter(n_factors) - Counter(m_factors)).elements())))


def task3Alt():
    """
    Задайте два числа. Напишите программу, которая найдёт НОК (наименьшее общее кратное) этих двух чисел.
    """
    m = 60
    n = 24
    print(math.lcm(m, n))


def task3Alt2():
    """
    Задайте два числа. Напишите программу, которая найдёт НОК (наименьшее общее кратное) этих двух чисел.
    """
    m = m_copy = 60
    n = n_copy = 24
    m_factors = []
    n_factors = []
    factor = 2
    while m_copy > 1 or n_copy > 1:
        if m_copy % factor == 0:
            while m_copy % factor == 0:
                m_factors.append(factor)
                m_copy /= factor
        if n_copy % factor == 0:
            while n_copy % factor == 0:
                n_factors.append(factor)
                n_copy /= factor
        factor += 1
    result = 1
    for i in m_factors:
        if i in n_factors: result *= i
    print(int(m * n / result))


# task1()
# task2()
# task3()
# task3Alt()
# task3Alt2()
