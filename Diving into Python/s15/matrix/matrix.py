import logging

from exceptions import MatrixMultiplicationError, MatrixSizeError

logging.basicConfig(filename='matrix.log', level=logging.INFO, format='%(asctime)s - %(levelname)s - %(message)s')


def log_calculation(func):
    def wrapper(self, *args, **kwargs):
        try:
            result = func(self, *args, **kwargs)
            logging.info(f"Действие: {func.__name__},\n"
                         f"операнд 1:\n"
                         f"{self},\n"
                         f"операнд 2:\n"
                         f"{args[0]},\n"
                         f"результат:\n"
                         f"{result}")
            return result
        except Exception as e:
            logging.error(f"Ошибка в функции {func.__name__}: {e}")
            raise

    return wrapper


class Matrix:
    def __init__(self, data):
        """
        Инициализация экземпляра класса Matrix.

        :param data: Список списков, представляющий матрицу.
        """
        self.rows = len(data)
        self.columns = len(data[0])
        self.data = data

    @log_calculation
    def __eq__(self, other):
        """
        Перегрузка оператора == для сравнения матриц.

        :param other: Другая матрица для сравнения.
        :return: True, если матрицы равны, иначе False.
        """
        return self.data == other.data

    @log_calculation
    def __add__(self, other):
        """
        Перегрузка оператора + для сложения матриц.

        :param other: Другая матрица для сложения.
        :return: Новая матрица с результатом сложения.
        """
        if self.rows != other.rows or self.columns != other.columns:
            raise MatrixSizeError()

        result_data = [[self.data[i][j] + other.data[i][j] for j in range(self.columns)] for i in range(self.rows)]
        return Matrix(result_data)

    @log_calculation
    def __mul__(self, other):
        """
        Перегрузка оператора * для умножения матриц.

        :param other: Другая матрица или число для умножения.
        :return: Новая матрица с результатом умножения.
        """
        if isinstance(other, Matrix):
            if self.columns != other.rows:
                raise MatrixMultiplicationError("Количество столбцов первой матрицы должно быть равно "
                                                "количеству строк второй")
            result_data = [
                [sum(self.data[i][k] * other.data[k][j] for k in range(self.columns))
                 for j in range(other.columns)] for i in range(self.rows)]
            return Matrix(result_data)
        elif isinstance(other, (int, float)):
            result_data = [[self.data[i][j] * other for j in range(self.columns)] for i in range(self.rows)]
            return Matrix(result_data)
        else:
            raise MatrixMultiplicationError("Умножение на значение данного типа не поддерживается")

    def __str__(self):
        """
        Возвращает строковое представление матрицы при вызове функции str().

        :return: Строковое представление матрицы.
        """
        return "\n".join([str(row) for row in self.data])

    def __repr__(self):
        """
        Возвращает строковое представление матрицы при вызове функции repr().

        :return: Строковое представление матрицы.
        """
        return f"Matrix({self.data})"
