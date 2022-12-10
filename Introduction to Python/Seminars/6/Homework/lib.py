import re


def calculate(index, sign, substring):
    if sign == "*": substring[index] = str(round(float(substring[index - 1]) * float(substring[index + 1]), 2))
    elif sign == "/": substring[index] = str(round(float(substring[index - 1]) / float(substring[index + 1]), 2))
    elif sign == "-": substring[index] = str(round(float(substring[index - 1]) - float(substring[index + 1]), 2))
    elif sign == "+": substring[index] = str(round(float(substring[index - 1]) + float(substring[index + 1]), 2))
    substring.remove(substring[index - 1])
    substring.remove(substring[index])
    return index - 2


def replace(s):
    return s + "1" if s in ("+", "-", "") else s


def find_arithmetic_signs(substring):
    i = 0
    while i < len(substring):
        if i > 0:
            # Для индексов > 0 найти первый из равнозначных арифметических знаков (* или /) и выполнить вычисления.
            if "*" in substring and "/" in substring: sign = "*" if substring.index("*") < substring.index("/") else "/"
            elif "*" in substring: sign = "*"
            elif "/" in substring: sign = "/"
            # После выполнения всех вычислений с * и / найти первый из равнозначных арифметических знаков (- или +) и выполнить вычисления с ними.
            elif "-" in substring and "+" in substring: sign = "-" if substring.index("-") < substring.index("+") else "+"
            elif "-" in substring: sign = "-"
            elif "+" in substring: sign = "+"
            i = calculate(substring.index(sign), sign, substring)
        else:
            # На индексе 0 может быть только число, либо знак "-", если он есть, добавить его к следующему числу, а элемент с индексом 0 удалить.
            if "-" in substring and substring.index("-") == 0:
                substring[substring.index("-") + 1] = substring[substring.index("-")] + substring[substring.index("-") + 1]
                substring.remove(substring[substring.index("-")])
                i -= 2
        i += 1
    return substring[0]


def parse(equation):
    # Убрать " = 0"
    equation = equation[:-4]
    # Найти элементы из отдельных цифр, добавить к ним "^0", если такие есть.
    element = re.search(r'([-+]?\d+$)', equation)
    if element is not None: equation = equation[0:element.span()[1]] + "^0" + equation[element.span()[1]:]
    # Найти элементы с x в 1 степени, добавить к ним "^1", если такие есть.
    element = re.search(r'([-+]?\d*x[-+])', equation)
    if element is None: element = re.search(r'([-+]?\d*x$)', equation)
    # Убрать все x в выражении, разделить его на словарь по символу "^".
    if element is not None: equation = equation[0:element.span()[1] - 1] + "^1" + equation[element.span()[1] - 1:]
    equation = {int(x[1]):int(replace(x[0])) for x in [x.split("^") for x in list(filter(lambda x: x != "", re.split(r'([-+]?\d*\^?\d?)', equation.replace("x", ""))))]}
    return equation


def save_to_file(equation, filename):
    s = ""
    for i in equation:
        polynomial = ""
        if abs(equation[i]) > 1:
            if i > 1: polynomial = f"{equation[i]}x^{i}"
            elif i == 1: polynomial = f"{equation[i]}x"
            elif i == 0: polynomial = f"{equation[i]}"
        elif abs(equation[i]) == 1:
            if i > 1: polynomial = f"x^{i}"
            elif i == 1: polynomial = "x"
            elif i == 0: polynomial = f"{equation[i]}"
        s += "+" + polynomial if not polynomial.startswith("-") and len(polynomial) > 0 else polynomial
    with open(f"{filename}.txt", "w") as f: f.write(s[1:] + " = 0") if s.startswith("+") else f.write(s + " = 0")