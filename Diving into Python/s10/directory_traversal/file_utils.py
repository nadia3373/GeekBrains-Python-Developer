import json
import pickle
from csv import DictWriter


class JsonWriter:
    """ Класс для записи JSON-файлов. """
    @staticmethod
    def write(path, items):
        with open(path, "w", encoding="utf-8") as file:
            json.dump(items, file, ensure_ascii=False, indent=4)


class CsvWriter:
    """ Класс для записи CSV-файлов. """
    @staticmethod
    def write(path, items):
        with open(path, "w", encoding="utf-8") as file:
            fieldnames = ["type", "name", "size", "files", "path"]
            csv_writer = DictWriter(file, fieldnames)
            csv_writer.writeheader()
            csv_writer.writerows(items)


class PickleWriter:
    """ Класс для записи pickle-файлов. """
    @staticmethod
    def write(path, items):
        with open(path, "wb") as file:
            pickle.dump(items, file)
