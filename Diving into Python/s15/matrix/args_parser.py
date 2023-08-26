import argparse


def parse_args(func):
    def wrapper(*args, **kwargs):
        parser = argparse.ArgumentParser(description="Действия с матрицами")
        parser.add_argument("--action", choices=["compare", "add", "multiply", "scalar"],
                            help="Выбери действие: сравнение (compare), сложение (add), умножение (multiply),"
                                 "умножение на скаляр (scalar)")
        parser.add_argument("--matrix1", type=str, help="Матрица 1 в виде строки (например, '1 2; 3 4')")
        parser.add_argument("--matrix2", type=str, help="Матрица 2 в виде строки (например, '5 6; 7 8')")
        parser.add_argument("--scalar", type=int, help="Число для умножения матриц на скаляр")

        parsed_args = parser.parse_args()
        return func(parsed_args, *args, **kwargs)

    return wrapper
