import time


def sum_digits(n):
    """
    Функция суммирования цифр в числе
    """
    sum = power = 0
    while (n * 10 ** (power + 1)) % 10 != 0: power += 1
    n *= 10 ** power
    while n >= 1:
        sum += int(n % 10)
        n //= 10
    return sum


def sum_digits_str(n):
    """
    Функция суммирования цифр в строке
    """
    sum = 0
    for i in n:
        if i.isdigit(): sum += int(i)
    return sum


def multiply(n):
    """
    Функция умножения чисел в диапазоне от 1 до n
    """
    result = n
    for i in range(1, n):
        result *= i
    return result


def rand_number(rng):
    """
    Функция рандомной генерации числа.
    Принимает граничное значение, в пределах которого будет генерироваться число.
    Для генерации случайного числа из системного времени выделяется наиболее быстро изменяющаяся часть и делится по модулю на диапазон.
    """
    return int(((time.time() - int(time.time())) * 1000000) % rng)


def read_from_file(filename):
    """
    Функция чтения из файла
    """
    f = open(filename, "r")
    indices = f.read().split()
    f.close()
    return indices


def write_to_file(filename, length, quantity):
    """
    Функция записи в файл
    """
    f = open(filename, "w")
    for _ in range(quantity):
        f.write(f"{rand_number(length)}\n")
    f.close()