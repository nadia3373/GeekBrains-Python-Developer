from fractions import Fraction
import math


BASE = 16
SHIFT = 87

class CustomFraction():
    """
    Класс, представляющий дробь
    """
    def __init__(self, string_fraction=None, numerator=None, denominator=None):
        if numerator is not None and denominator is not None:
            self.numerator = numerator
            self.denominator = denominator
        elif string_fraction is not None:
            self.numerator, self.denominator = map(int, string_fraction.split('/'))
        else:
            raise ValueError('Некорректная дробь')
        if self.denominator == 0:
            raise ValueError('Знаменатель не может быть равен 0')
        self.reduce()
    
    def __str__(self):
        return f'{self.numerator}/{self.denominator}'
    
    def reduce(self):
        """
        Сокращение
        """
        gcd = math.gcd(self.numerator, self.denominator)
        self.numerator //= gcd
        self.denominator //= gcd
    
    def validate(func):
        def wrapper(self, other):
            if not isinstance(other, CustomFraction):
                raise TypeError('Один из элементов не является дробью')
            return func(self, other)
        return wrapper
    
    @validate
    def __add__(self, other):
        """
        Сложение
        """
        new_numerator = (self.numerator * other.denominator) + (other.numerator * self.denominator)
        new_denominator = self.denominator * other.denominator
        return CustomFraction(numerator=new_numerator, denominator=new_denominator)
    
    @validate
    def __mul__(self, other):
        """
        Умножение
        """
        new_numerator = self.numerator * other.numerator
        new_denominator = self.denominator * other.denominator
        return CustomFraction(numerator=new_numerator, denominator=new_denominator)

def main():
    task1()
    task2()

def convert_to_hex(number):
    """
    Приведение числа к шестнадцатеричному виду
    """
    result = ''
    while number > 0:
        remainder = number % BASE
        digit = str(remainder) if remainder < 10 else chr(remainder + SHIFT)
        result = f'{digit}{result}'
        number //= BASE
    return f'0x{result}'

def task1():
    # Напишите программу, которая получает целое число и возвращает его шестнадцатеричное строковое представление.
    # Функцию hex используйте для проверки своего результата.
    try:
        number = int(input('Введите целое число: '))
        hex_number = convert_to_hex(number)
        print(f'Проверка: {hex_number} == {hex(number)} -> {hex_number == hex(number)}')
    except:
        print('Введено не число')

def task2():
    # ✔ Напишите программу, которая принимает две строки вида “a/b” — дробь с числителем и знаменателем.
    # Программа должна возвращать сумму и *произведение дробей. Для проверки своего кода используйте модуль fractions.
    a, b = input('Введите первую дробь: '), input('Введите вторую дробь: ')
    custom_a, custom_b = CustomFraction(string_fraction=a), CustomFraction(string_fraction=b)
    fraction_a, fraction_b = Fraction(a), Fraction(b)
    print(f'Результат. Сумма: {custom_a + custom_b}, произведение: {custom_a * custom_b}')
    print(f'Проверка. Сумма: {fraction_a + fraction_b}, произведение: {fraction_a * fraction_b}')

if __name__ == "__main__":
    main()
