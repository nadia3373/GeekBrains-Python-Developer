class Rectangle:
    def __init__(self, length, width=None):
        """
        Инициализация экземпляра класса Rectangle.

        :param length: Длина прямоугольника (если width == None, считается, что это квадрат).
        :param width: Ширина прямоугольника (по умолчанию None).
        """
        if width is None:
            self.length = length
            self.width = length
        else:
            self.length = length
            self.width = width

    def perimeter(self):
        """
        Вычисление периметра прямоугольника.

        :return: Периметр прямоугольника.
        """
        return 2 * (self.length + self.width)

    def area(self):
        """
        Вычисление площади прямоугольника.

        :return: Площадь прямоугольника.
        """
        return self.length * self.width

    def __add__(self, other):
        """
        Перегрузка оператора + для сложения прямоугольников.

        :param other: Другой прямоугольник для сложения.
        :return: Новый прямоугольник на основе суммы периметров.
        """
        new_perimeter = self.perimeter() + other.perimeter()
        side_sum = new_perimeter / 4
        return Rectangle(side_sum, side_sum)

    def __sub__(self, other):
        """
        Перегрузка оператора - для вычитания прямоугольников.

        :param other: Другой прямоугольник для вычитания.
        :return: Новый прямоугольник на основе разности периметров.
        """
        new_perimeter = self.perimeter() - other.perimeter()
        side_diff = max(new_perimeter / 4, 0)
        return Rectangle(side_diff, side_diff)

    def __eq__(self, other):
        """
        Перегрузка оператора == для сравнения прямоугольников по площади.

        :param other: Другой прямоугольник для сравнения.
        :return: True, если площади равны, иначе False.
        """
        return self.area() == other.area()

    def __ne__(self, other):
        """
        Перегрузка оператора != для сравнения прямоугольников по площади.

        :param other: Другой прямоугольник для сравнения.
        :return: True, если площади не равны, иначе False.
        """
        return self.area() != other.area()

    def __lt__(self, other):
        """
        Перегрузка оператора < для сравнения прямоугольников по площади.

        :param other: Другой прямоугольник для сравнения.
        :return: True, если площадь текущего прямоугольника меньше, иначе False.
        """
        return self.area() < other.area()

    def __le__(self, other):
        """
        Перегрузка оператора <= для сравнения прямоугольников по площади.

        :param other: Другой прямоугольник для сравнения.
        :return: True, если площадь текущего прямоугольника меньше или равна, иначе False.
        """
        return self.area() <= other.area()

    def __gt__(self, other):
        """
        Перегрузка оператора > для сравнения прямоугольников по площади.

        :param other: Другой прямоугольник для сравнения.
        :return: True, если площадь текущего прямоугольника больше, иначе False.
        """
        return self.area() > other.area()

    def __ge__(self, other):
        """
        Перегрузка оператора >= для сравнения прямоугольников по площади.

        :param other: Другой прямоугольник для сравнения.
        :return: True, если площадь текущего прямоугольника больше или равна, иначе False.
        """
        return self.area() >= other.area()

    def __str__(self):
        return f"Прямоугольник: длина = {self.length}, ширина = {self.width}\n" \
               f"Периметр: {self.perimeter()}, площадь: {self.area()}"

    def __repr__(self):
        return f"Rectangle({self.length}, {self.width})"


rectangle1 = Rectangle(5, 3)
rectangle2 = Rectangle(4)

print(rectangle1, "\n")
print(rectangle2, "\n")

sum_rectangle = rectangle1 + rectangle2
print("Сумма прямоугольников:", sum_rectangle, "\n")

sub_rectangle = rectangle1 - rectangle2
print("Разность прямоугольников:", sub_rectangle, "\n")

print("rectangle1 равен rectangle2 по площади:", rectangle1 == rectangle2)
print("rectangle1 не равен rectangle2 по площади:", rectangle1 != rectangle2)
print("rectangle1 меньше rectangle2 по площади:", rectangle1 < rectangle2)
print("rectangle1 меньше или равен rectangle2 по площади:", rectangle1 <= rectangle2)
print("rectangle1 больше rectangle2 по площади:", rectangle1 > rectangle2)
print("rectangle1 больше или равен rectangle2 по площади:", rectangle1 >= rectangle2)
