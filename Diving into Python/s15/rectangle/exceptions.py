class RectangleError(Exception):
    """Базовый класс исключений для прямоугольников."""

    def __init__(self, message="Ошибка при действиях над прямоугольниками. "):
        self.message = message
        super().__init__(self.message)


class InvalidRectangleError(RectangleError):
    def __init__(self, length, width):
        self.message = f"Неверные размеры прямоугольника: длина = {length}, ширина = {width}"
        super().__init__(self.message)


class NegativeSizeError(InvalidRectangleError):
    def __init__(self, size_type, size_value):
        self.message = f"Размер {size_type} не может быть отрицательным: {size_value}"
        super().__init__(size_value, size_value)


class InvalidOperationError(RectangleError):
    def __init__(self, operation):
        self.message = f"Недопустимая операция с прямоугольниками: {operation}"
        super().__init__(self.message)


class RectangleArgumentsError(RectangleError):
    def __init__(self, message='Некорректное количество аргументов'):
        self.message = message
        super().__init__(self.message)
