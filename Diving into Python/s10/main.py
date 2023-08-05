from pathlib import Path

from animals.animals import AnimalFactory, Cat, Dog, Fish
from ATM.atm import ATM
from directory_traversal.directory_traversal import DirectoryManager
from triangles.triangles import Triangle


def task1():
    """
    Доработаем задачи 5-6. Создайте класс-фабрику.
    ○ Класс принимает тип животного (название одного из созданных классов) и параметры для этого типа.
    ○ Внутри класса создайте экземпляр на основе переданного типа и верните его из класса-фабрики.
    """
    cat = AnimalFactory.create(Cat, "Карамелька", "Maine Coon")
    dog = AnimalFactory.create(Dog, "Шарик", "Beagle")
    fish = AnimalFactory.create(Fish, "Немо", 3)

    cat.attack()
    dog.voice()
    fish.extract_oxygen()


def task2():
    """
    Возьмите 1 - 3 любые задачи из прошлых семинаров(например сериализация данных),
    которые вы уже решали. Превратите функции в методы класса, а параметры в свойства.
    Задачи должны решаться через вызов методов экземпляра.
    """
    triangles()
    atm()
    directory_traversal()


def triangles():
    """ Задача про треугольники. """
    print(triangle := Triangle())
    triangle.check()


def atm():
    """ Задача про банкомат. """
    atm_instance = ATM()

    atm_instance.deposit(1500)
    atm_instance.withdraw(1000)
    atm_instance.deposit(3000)
    atm_instance.deposit(2000)
    atm_instance.withdraw(300)
    atm_instance.deposit(2500)
    atm_instance.deposit(5000)
    atm_instance.withdraw(2000)
    atm_instance.withdraw(500)
    atm_instance.deposit(1000)
    atm_instance.deposit(2000)
    atm_instance.withdraw(1200)

    atm_instance.display_balance()


def directory_traversal():
    """ Задача на рекурсивный обход директории. """
    manager = DirectoryManager(Path.cwd() / "directory_traversal/test_dir")
    manager.write_files(Path.cwd() / "directory_traversal/output")


if __name__ == '__main__':
    task1()
    task2()
