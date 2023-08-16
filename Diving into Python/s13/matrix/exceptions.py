class MatrixError(Exception):
    """Базовый класс исключений для матрицы."""


class MatrixSizeError(MatrixError):
    def __init__(self, message="Матрицы должны иметь одинаковые размеры для сложения"):
        self.message = message
        super().__init__(self.message)


class MatrixMultiplicationError(MatrixError):
    pass
