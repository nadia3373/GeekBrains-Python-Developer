import csv
import random


GENERATOR_MIN_VALUE = 1
GENERATOR_MAX_VALUE = 100


def from_csv(func):
    def wrapper(filename):
        """ Декоратор для получения значений из csv. """
        with open(filename, 'r') as csv_file:
            csv_reader = csv.reader(csv_file)
            numbers = []
            for row in csv_reader:
                numbers.append([float(value) for value in row])
            func(*numbers)

    return wrapper


def generate_csv(filename, columns, rows):
    """ Функция записи в csv сгенерированных значений. """
    with open(filename, 'w', newline='') as file:
        writer = csv.writer(file)
        for _ in range(rows):
            row = [random.randint(GENERATOR_MIN_VALUE, GENERATOR_MAX_VALUE) for _ in range(columns)]
            writer.writerow(row)
