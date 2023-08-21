from .exceptions import MatrixMultiplicationError, MatrixSizeError


class Matrix:
    def __init__(self, data):
        """
        Инициализация экземпляра класса Matrix.

        :param data: Список списков, представляющий матрицу.
        """
        self.rows = len(data)
        self.columns = len(data[0])
        self.data = data

    def __eq__(self, other):
        """
        Перегрузка оператора == для сравнения матриц.

        :param other: Другая матрица для сравнения.
        :return: True, если матрицы равны, иначе False.
        """
        return self.data == other.data

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
