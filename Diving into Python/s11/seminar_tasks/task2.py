class Archive:
    """
    Класс позволяет хранить пару свойств (число и строку) для каждого экземпляра.
    Старые данные сохраняются в архивах, а архивы сами являются свойствами экземпляра.
    """

    def __init__(self, number, string):
        """
        Инициализирует экземпляр класса Archive.

        :param number: Число для хранения.
        :param string: Строка для хранения.
        """
        self.number = number
        self.string = string
        self.number_archive = []
        self.string_archive = []

    def update(self, new_number, new_string):
        """
        Обновляет текущие значения числа и строки, добавляя старые в архивы.

        :param new_number: Новое число.
        :param new_string: Новая строка.
        """
        self.number_archive.append(self.number)
        self.string_archive.append(self.string)
        self.number = new_number
        self.string = new_string

    def get_number(self):
        """
        Возвращает текущее число.

        :return: Текущее число.
        """
        return self.number

    def get_string(self):
        """
        Возвращает текущую строку.

        :return: Текущая строка.
        """
        return self.string

    def get_number_archive(self):
        """
        Возвращает архив чисел.

        :return: Архив чисел.
        """
        return self.number_archive

    def get_string_archive(self):
        """
        Возвращает архив строк.

        :return: Архив строк.
        """
        return self.string_archive

    def __str__(self):
        """
        Возвращает строковое представление объекта при вызове функции str().

        :return: Строковое представление объекта.
        """
        return f"Текущее число: {self.number}\nТекущая строка: {self.string}\n" \
               f"Архив чисел: {self.number_archive}\nАрхив строк: {self.string_archive}"

    def __repr__(self):
        """
        Возвращает строковое представление объекта при вызове функции repr().

        :return: Строковое представление объекта.
        """
        return f"Archive(number={self.number}, string='{self.string}')"


archive = Archive(5, "Hello")
archive.update(10, "World")
archive.update(4, "test")

print(archive)
