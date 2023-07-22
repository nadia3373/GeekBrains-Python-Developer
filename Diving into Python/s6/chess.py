from random import randint
from typing import List

BOARD_LENGTH = 8


class Point:
    """
    Класс, представляющий точку.
    """
    x: int
    y: int

    def __init__(self, x: int, y: int):
        self.x = x
        self.y = y


class Queen:
    """
    Класс, представляющий ферзя.
    """
    coordinates: Point

    def __init__(self, point: Point):
        self.coordinates = point

    def is_clashing(self, other_queen: 'Queen') -> bool:
        return (
                self.coordinates.x == other_queen.coordinates.x
                or self.coordinates.y == other_queen.coordinates.y
                or abs(self.coordinates.x - other_queen.coordinates.x) ==
                abs(self.coordinates.y - other_queen.coordinates.y)
        )


class Board:
    """
    Класс, представляющий игровое поле.
    """
    cells: List[Point]
    queens: List[Queen]

    def __init__(self, queens: List[List[int]]):
        self.cells = [Point(x, y) for x in range(BOARD_LENGTH) for y in range(BOARD_LENGTH)]
        self.queens = [Queen(Point(int(x), int(y))) for x, y in queens]

    def __str__(self):
        rows = [['.' for _ in range(BOARD_LENGTH)] for _ in range(BOARD_LENGTH)]
        for queen in self.queens:
            rows[queen.coordinates.x][queen.coordinates.y] = 'Q'
        return '\n'.join([' '.join(row) for row in rows])


def check_queens(board: Board) -> bool:
    """ Проверка пересечения маршрутов ферзей. """
    for queen in board.queens:
        for q in board.queens:
            if queen != q:
                if q.is_clashing(queen):
                    return False
    return True


def generate_random_boards():
    """ Генерация рандомных размещений ферзей. """
    while True:
        numbers = [[randint(0, BOARD_LENGTH - 1), randint(0, BOARD_LENGTH - 1)] for _ in range(BOARD_LENGTH)]
        board = Board(numbers)
        if check_queens(board):
            yield board
