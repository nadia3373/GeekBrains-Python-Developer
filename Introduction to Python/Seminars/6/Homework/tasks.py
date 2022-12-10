import lib, re, random


def task1():
    """
    Напишите программу вычисления арифметического выражения заданного строкой. Используйте операции +,-,/,*. приоритет операций стандартный. 
    """
    s = source = "(-1+2*3/5)*3+(1-2)-(-12/5)+2"
    # В первую очередь найти и вычислить все выражения в скобках.
    substring = re.search(r'(\(-?\d+([-+*\/]\d+)+\))', s)
    while substring is not None:
        # Определить диапазон от открывающей скобки до закрывающей, он будет заменён результатом вычисления выражения в скобках.
        span = substring.span()
        left_half = s[0:span[0]]
        right_half = s[span[1]:]
        # Разделить выражение внутри скобок по знакам и выполнить арифметические действия с каждым из них.
        substring = list(filter(lambda x: x != "", re.split(r'([-+*\/])', substring.group()[1:-1])))
        result = lib.find_arithmetic_signs(substring)
        # corner case: раскрытие скобок, если результат вычисления внутри них отрицательный.
        if result.startswith("-"):
            result = result[1:]
            if left_half[-1] == "-": left_half = left_half[:-1] + "+"
            elif left_half[-1] == "+": left_half = left_half[:-1] + "-"
        s = left_half + result + right_half
        # Попробовать найти следующее выражение в скобках.
        substring = re.search(r'(\(-?\d+([-+*\/]\d+)+\))', s)
    # Все выражения в скобках вычислены – разделить оставшееся выражение по знакам и вычислить.
    s = list(filter(lambda x: x != "", re.split(r'([-+*\/])', s)))
    s = lib.find_arithmetic_signs(s)
    print(f"Исходное выражение: {source}, результат вычислений: {s}")


def refactoring1():
    """
    Задана натуральная степень key. Сформировать случайным образом список коэффициентов (значения от 0 до 100) многочлена и записать в файл многочлен степени key(до 6 степени).
    """
    for i in range(2):
        power = random.randint(1, 6)
        equation = {x: random.randint(-100, 100) for x in range(power - 1, -1, -1)}
        lib.save_to_file(equation, f"{i + 1}")


def refactoring2():
    """
    Даны два файла, в каждом из которых находится запись многочлена. Задача - сформировать файл, содержащий сумму многочленов.
    """
    with open("1.txt", "r") as f: equation1 = f.read()
    with open("2.txt", "r") as f: equation2 = f.read()
    print(f"Уравнение 1: {equation1}\nУравнение 2: {equation2}")
    equation1 = lib.parse(equation1)
    equation2 = lib.parse(equation2)
    equation = {key: equation1.get(key, 0) + equation2.get(key, 0) for key in list(equation2.keys()) + list(equation1.keys())}
    lib.save_to_file(equation, "result")
    with open("result.txt", "r") as f: equation = f.read()
    print(f"Полученное уравнение: {equation}")


def refactoring3():
    """
    В файле находится N натуральных чисел, записанных через пробел. Среди чисел не хватает одного, чтобы выполнялось условие A[i] - 1 = A[i-1]. Найдите это число.
    """
    with open("numbers.txt", "r") as f: lst = f.read().split()
    number = [int(lst[x]) for x in range(1, len(lst) - 1) if int(lst[x]) - 1 != int(lst[x - 1]) and x > 0][0]
    print(f"Исходный список: {lst}, недостающее число: {number - 1}")


task1()
if (input("\nНажмите Y для перехода к следующему заданию: ").lower() == "y"):
    refactoring1()
    refactoring2()
if (input("\nНажмите Y для перехода к следующему заданию: ").lower() == "y"):
    refactoring3()