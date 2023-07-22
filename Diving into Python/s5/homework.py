class Path:
    """ Класс, представляющий путь к файлу. """
    parent: str
    name: str
    extension: str

    def __init__(self, path):
        if '/' in path:
            self.parent, self.name = path.rsplit('/', 1)
        else:
            self.parent = ''
            self.name = path

        if '.' in self.name:
            self.name, self.extension = self.name.split('.', 1)
        else:
            self.extension = ''

    def __str__(self):
        ext = f'.{self.extension}' if self.extension else ''
        return f'Путь: {self.parent}\nИмя файла: {self.name}\nРасширение: {ext}'


def main():
    task1()
    task2()
    task3()


def task1():
    """
    ✔Напишите функцию, которая принимает на вход строку — абсолютный путь до файла.
    Функция возвращает кортеж из трёх элементов: путь, имя файла, расширение файла.
    """
    path = input('Введите абсолютный путь к файлу: ')
    print(Path(path))


def task2():
    """
    ✔Напишите однострочный генератор словаря, который принимает на вход три списка
    одинаковой длины: имена str, ставка int, премия str с указанием процентов вида «10.25%».
    В результате получаем словарь с именем в качестве ключа и суммой премии в качестве значения.
    Сумма рассчитывается как ставка умноженная на процент премии.
    """
    names = ['Петя', 'Вася', 'Миша', 'Ваня', 'Саша']
    salaries = [40000, 45000, 50000, 43000, 41000]
    bonuses = ['10.0%', '10.5%', '11.0%', '11.3%', '11.1%']

    result = {name: round(salary * float(bonus.rstrip('%')) / 100, 2)
              for name, salary, bonus in zip(names, salaries, bonuses)}
    print(result)


def task3():
    """ ✔Создайте функцию генератор чисел Фибоначчи. """
    numbers = list(fibonacci_generator(10))
    print(numbers)


def fibonacci_generator(n: int):
    a, b = 0, 1
    for _ in range(n):
        yield a
        a, b = b, a + b


if __name__ == '__main__':
    main()
