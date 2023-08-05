from dataclasses import dataclass
from random import randint

TRIANGLES_LOWER = 1
TRIANGLES_UPPER = 10


@dataclass
class Triangle:
    """ Класс, представляющий треугольник. """
    _a: int = randint(TRIANGLES_LOWER, TRIANGLES_UPPER)
    _b: int = randint(TRIANGLES_LOWER, TRIANGLES_UPPER)
    _c: int = randint(TRIANGLES_LOWER, TRIANGLES_UPPER)

    @property
    def a(self):
        return self._a

    @property
    def b(self):
        return self._b

    @property
    def c(self):
        return self._c

    def check(self):
        """
        Определение типа треугольника
        """
        if not all([self.a < self.b + self.c, self.b < self.a + self.c, self.c < self.a + self.b]):
            print('Треугольника не существует')
        if self.a == self.b == self.c:
            print('Равносторонний')
        elif self.a == self.b or self.b == self.c or self.c == self.a:
            print('Равнобедренный')
        else:
            print('Разносторонний')

    def __str__(self):
        return f'Сторона a: {self.a}, сторона b: {self.b}, сторона c: {self.c}'
