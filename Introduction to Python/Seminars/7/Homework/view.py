from fractions import Fraction


def get_log_format():
    return int(input("В каком формате будет сохраняться лог? 1 – csv, 2 – json: "))


def get_number():
    while True:
        number = input("Введите число: ")
        try:
            if "j" in number: return complex(number)
            else: return Fraction(number)
        except: print("Некорректный ввод!")


def get_sign():
    while True:
        sign = input("Введите арифметический знак: ")
        if sign in ("*", "/", "-", "+"): return sign


def get_status():
    while True:
        try:
            status = int(input("Продолжить работу программы (1 – да, 0 – нет): "))
            if status == 0 or status == 1: return bool(status)
        except: print("Некорректный ввод!")


def print_result(data):
    print(f"Результат: {data['result']}")
