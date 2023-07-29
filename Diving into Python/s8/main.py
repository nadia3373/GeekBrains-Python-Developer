import os
from pathlib import Path

from directory_traversal import traverse
from file_utils import write_csv, write_json, write_pickle


def main():
    """
    1. Решить задания, которые не успели решить на семинаре.
    2. Напишите функцию, которая получает на вход директорию и рекурсивно обходит её
    и все вложенные директории. Результаты обхода сохраните в файлы json, csv и pickle.
    3. Для дочерних объектов указывайте родительскую директорию.
    4. Для каждого объекта укажите файл это или директория.
    5. Для файлов сохраните его размер в байтах, а для директорий размер файлов в ней с учётом
    всех вложенных файлов и директорий.
    6. Соберите из созданных на уроке и в рамках домашнего задания функций пакет для работы
    с файлами разных форматов.
    """
    directories = [d.__dict__() for d in traverse(str(Path.cwd() / "test_dir")).values()]

    output_directory = "output"
    output_json = os.path.join(output_directory, "directory.json")
    output_csv = os.path.join(output_directory, "directory.csv")
    output_pickle = os.path.join(output_directory, "directory.pickle")
    os.makedirs(output_directory, exist_ok=True)

    write_csv(output_csv, directories)
    write_json(output_json, directories)
    write_pickle(output_pickle, directories)


if __name__ == '__main__':
    main()
