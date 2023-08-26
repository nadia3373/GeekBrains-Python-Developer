import argparse


def parse_args(func):
    def wrapper(*args, **kwargs):
        parser = argparse.ArgumentParser(description="Действия с прямугольником")
        parser.add_argument("--action", choices=["add", "subtract", "compare"],
                            help="Выберите действие: сложение (add), вычесть (subtract), сравнить (compare)")
        parser.add_argument("--l1", type=float, help="Длина первого прямоугольника")
        parser.add_argument("--w1", type=float, help="Ширина первого прямоугольника")
        parser.add_argument("--l2", type=float, help="Длина второго прямоугольника")
        parser.add_argument("--w2", type=float, help="Ширина второго прямоугольника")
        parsed_args = parser.parse_args()
        return func(parsed_args, *args, **kwargs)

    return wrapper
