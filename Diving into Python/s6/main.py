import sys
from chess import Board, check_queens, generate_random_boards
from date_checking import check_date


def main():
    task1()
    task2()


def task1():
    """
    В модуль с проверкой даты добавьте возможность запуска
    в терминале с передачей даты на проверку.
    """
    args = sys.argv
    if len(args) > 1:
        date_input = args[1]
    else:
        date_input = input('Введите дату в формате DD.MM.YYYY: ')
    if check_date(date_input):
        print('Дата может существовать.')
    else:
        print('Дата некорректна.')


def task2():
    """
    Добавьте в пакет, созданный на семинаре, шахматный модуль. Внутри него напишите код, решающий задачу о 8 ферзях.
    Известно, что на доске 8×8 можно расставить 8 ферзей так чтобы они не били друг друга. Вам дана расстановка 8
    ферзей на доске, определите, есть ли среди них пара бьющих друг друга. Программа получает на вход восемь
    пар чисел, каждое число от 1 до 8 - координаты 8 ферзей. Если ферзи не бьют друг друга
    верните истину, а если бьют - ложь.

    Напишите функцию в шахматный модуль. Используйте генератор случайных чисел для случайной расстановки
    ферзей в задаче выше. Проверяйте различный случайные варианты и выведите 4 успешных расстановки.

    Пример удачной расстановки: [[0, 0], [1, 4], [2, 7], [3, 5], [4, 2], [5, 6], [6, 1], [7, 3]
    """
    boards = []
    choice = input('Сгенерировать координаты ферзей случайно? y - да, n - нет: ')
    if choice == 'y':
        while len(boards) < 4:
            random_boards = generate_random_boards()
            print('Удачные расстановки: ')
            for _ in range(4):
                board = next(random_boards)
                print(board)
    elif choice == 'n':
        numbers = [[int(x), int(y)] for x, y in (input(f'Введите координаты ферзя {i+1}: ').split() for i in range(8))]
        board = Board(numbers)
        if check_queens(board):
            print('Удачная расстановка:')
            print(board)
        else:
            print('Ферзи бьют друг друга.')
    else:
        print('Некорректный выбор.')
    print('Удачные расстановки: ')
    for board in boards:
        print(board)


if __name__ == '__main__':
    main()
