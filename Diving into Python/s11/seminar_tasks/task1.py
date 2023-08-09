from time import time


class MyString(str):
    """
    Класс расширяет стандартный класс str и добавляет дополнительные свойства: автор и время создания.
    """

    def __new__(cls, value, author=None):
        """
        Создает новый экземпляр класса MyString.

        :param value: Значение строки.
        :param author: Автор строки (по умолчанию None).
        :return: Экземпляр класса MyString.
        """
        instance = super(MyString, cls).__new__(cls, value)
        instance.author = author
        instance.creation_time = time()
        return instance

    def get_author(self):
        """
        Возвращает автора строки.

        :return: Автор строки.
        """
        return self.author

    def get_creation_time(self):
        """
        Возвращает время создания строки.

        :return: Время создания строки.
        """
        return self.creation_time

    def __str__(self):
        """
        Возвращает строковое представление объекта при вызове функции str().

        :return: Строковое представление объекта.
        """
        return super().__str__()

    def __repr__(self):
        """
        Возвращает строковое представление объекта при вызове функции repr().

        :return: Строковое представление объекта.
        """
        return super().__repr__()


my_string = MyString("Какой-то текст", "Имя автора")

print("Строка: ", my_string)
print("Автор: ", my_string.get_author())
print("Время создания: ", my_string.get_creation_time())
