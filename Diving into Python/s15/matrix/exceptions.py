class MatrixError(Exception):
    """ Базовый класс исключений для матрицы. """

    def __init__(self, message="Ошибка при действиях над матрицами. "):
        self.message = message
        super().__init__(self.message)


class MatrixSizeError(MatrixError):
    """ Исключение для некорректных размеров матриц. """

    def __init__(self, message="Матрицы должны иметь одинаковые размеры для сложения"):
        self.message = message
        super().__init__(self.message)


class MatrixMultiplicationError(MatrixError):
    """ Исключение при умножении матриц. """

    def __init__(self, message="Ошибка при умножении матриц. "):
        self.message = message
        super().__init__(self.message)


class MatrixArgumentsError(MatrixError):
    """ Исключение при некорректном количестве аргументов. """

    def __init__(self, message="Некорректное количество аргументов."):
        self.message = message
        super().__init__(self.message)
