from abc import ABC, abstractmethod
from dataclasses import dataclass


@dataclass
class Animal(ABC):
    _name: str

    @abstractmethod
    def attack(self):
        pass

    @abstractmethod
    def move(self):
        pass

    @abstractmethod
    def voice(self):
        pass

    @property
    def name(self):
        return self._name

    @name.setter
    def name(self, name):
        self._name = name


@dataclass
class Cat(Animal):
    _breed: str
    _legs: int = 4

    def attack(self):
        print(f"{self.name} выпускает когти и шипит")

    def move(self):
        print(f"{self.name} бесшумно крадётся")

    def voice(self):
        print(f"{self.name} мяукает")

    def clean_coat(self):
        print(f"{self.name} ухаживает за шёрсткой")

    @property
    def breed(self):
        return self._breed

    @breed.setter
    def breed(self, breed):
        self._breed = breed


@dataclass
class Dog(Animal):
    _breed: str
    _legs: int = 4

    def attack(self):
        print(f"{self.name} прыгает и сбивает с ног")

    def move(self):
        print(f"{self.name} радостно бежит")

    def voice(self):
        print(f"{self.name} лает")

    def track(self):
        print(f"{self.name} берёт след")

    @property
    def breed(self):
        return self._breed

    @breed.setter
    def breed(self, breed):
        self._breed = breed


@dataclass
class Fish(Animal):
    _gills: int

    def attack(self):
        print(f"{self.name} выпускает ядовитые шипы")

    def move(self):
        print(f"{self.name} плывёт")

    def voice(self):
        print(f"{self.name} булькает")

    def extract_oxygen(self):
        print(f"{self.name} поглощает кислород из воды")

    @property
    def gills(self):
        return self._gills

    @gills.setter
    def gills(self, gills):
        self._gills = gills


class AnimalFactory:
    @classmethod
    def create(cls, animal_class, name, *args, **kwargs):
        if issubclass(animal_class, Animal):
            return animal_class(name, *args, **kwargs)
        else:
            raise ValueError("Неверный класс животного")
