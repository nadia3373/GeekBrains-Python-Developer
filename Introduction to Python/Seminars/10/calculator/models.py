from fractions import Fraction
import re


def aritmetic_action(index, sign, s):
    if "j" in s[index - 1]: s[index - 1] = complex(s[index - 1])
    else: s[index - 1] = Fraction(s[index - 1])
    if "j" in s[index + 1]: s[index + 1] = complex(s[index + 1])
    else: s[index + 1] = Fraction(s[index + 1])
    if sign == "*": s[index] = str(s[index - 1] * s[index + 1])
    elif sign == "/": s[index] = str(s[index - 1] / s[index + 1])
    elif sign == "-": s[index] = str(s[index - 1] - s[index + 1])
    elif sign == "+": s[index] = str(s[index - 1] + s[index + 1])
    s.remove(s[index - 1])
    s.remove(s[index])
    return index - 2


def arithmetic_signs(s):
    i = 0
    while i < len(s):
        if i > 0:
            # Для индексов > 0 найти первый из равнозначных арифметических знаков (* или /) и выполнить вычисления.
            if "*" in s and "/" in s: sign = "*" if s.index("*") < s.index("/") else "/"
            elif "*" in s: sign = "*"
            elif "/" in s: sign = "/"
            # После выполнения всех вычислений с * и / найти первый из равнозначных арифметических знаков (- или +) и выполнить вычисления с ними.
            elif "-" in s and "+" in s: sign = "-" if s.index("-") < s.index("+") else "+"
            elif "-" in s: sign = "-"
            elif "+" in s: sign = "+"
            i = aritmetic_action(s.index(sign), sign, s)
        else:
            # На индексе 0 может быть только число, либо знак "-", если он есть, добавить его к следующему числу, а элемент с индексом 0 удалить.
            if "-" in s and s.index("-") == 0:
                s[s.index("-") + 1] = s[s.index("-")] + s[s.index("-") + 1]
                s.remove(s[s.index("-")])
                i -= 2
        i += 1
    return s[0]


def calculate(s):
    substring = re.search(r'(\(-?\d+j?([-+*\/]\d+j?)+\))', s)
    while substring is not None:
        # Определить диапазон от открывающей скобки до закрывающей, он будет заменён результатом вычисления выражения в скобках.
        span = substring.span()
        left_half = s[0:span[0]]
        right_half = s[span[1]:]
        # Разделить выражение внутри скобок по знакам и выполнить арифметические действия с каждым из них.
        substring = list(filter(lambda x: x != "", re.split(r'([-+*\/])', substring.group()[1:-1])))
        result = arithmetic_signs(substring)
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
    s = arithmetic_signs(s)
    return str(s)