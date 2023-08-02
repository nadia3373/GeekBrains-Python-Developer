import math


def solve(a, b, c):
    """ Функция решения квадратного уравнения. """
    discriminant = b ** 2 - 4 * a * c
    if discriminant < 0:
        return "Корней нет"
    elif discriminant == 0:
        x = -b / (2 * a)
        return f'{x=:.2f}'
    else:
        x1 = (-b + math.sqrt(discriminant)) / (2 * a)
        x2 = (-b - math.sqrt(discriminant)) / (2 * a)
        return f'{x1=:.2f}, {x2=:.2f}'
