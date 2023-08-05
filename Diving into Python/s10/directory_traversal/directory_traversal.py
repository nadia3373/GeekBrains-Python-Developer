import os
from dataclasses import dataclass, field
from pathlib import Path

from .file_utils import CsvWriter, JsonWriter, PickleWriter


@dataclass
class File:
    """ Класс, представляющий файл. """
    name: str
    size: int
    parent: 'Directory'
    path: str

    def __str__(self):
        return f"File: {self.parent}/{self.name}\n" \
               f"Size: {self.size}\n"

    def __dict__(self):
        return {
            "type": "file",
            "name": self.name,
            "size": self.size,
            "path": f'{self.path}'
        }


@dataclass
class Directory:
    """Класс, представляющий директорию. """
    name: str
    parent: 'Directory'
    path: str
    size: int = 0
    files: list = field(default_factory=list)
    subdirectories: list = field(default_factory=list)

    def __str__(self):
        return f"Directory: {self.parent}/{self.name}\n" \
               f"Size: {self.size}\n" \
               f"File count: {len(self.files)}\n" \
               f"Subdirectory count: {len(self.subdirectories)}\n"

    def to_dict(self):
        return {
            "type": "directory",
            "name": self.name,
            "size": self.size,
            "files": [file.__dict__() for file in self.files],
            "path": f'{self.path}'
        }

    def calculate(self):
        for directory in self.subdirectories:
            self.size += directory.size


@dataclass
class DirectoryManager:
    """ Класс для управления директориями. """
    directories = {}
    path: Path

    def traverse(self):
        """ Рекурсивный обход директории. """
        for dirpath, dirnames, filenames in os.walk(self.path):
            if dirpath not in self.directories.keys():
                directory = Directory(os.path.basename(dirpath), None, dirpath)
            else:
                directory = self.directories[dirpath]

            for filename in filenames:
                file_path = os.path.join(dirpath, filename)
                file_size = os.path.getsize(file_path)
                file = File(filename, file_size, directory, dirpath)
                directory.files.append(file)
                directory.size += file_size

            for dirname in dirnames:
                sub_directory = Directory(dirname, directory, dirpath)
                directory.subdirectories.append(sub_directory)
                self.directories[os.path.join(dirpath, dirname)] = sub_directory
            self.directories[dirpath] = directory

        for directory in self.directories.values():
            directory.calculate()

    def write_files(self, output_directory):
        """ Запись результатов обхода директории в файл. """
        self.traverse()
        output_directory = Path(output_directory)
        os.makedirs(output_directory, exist_ok=True)

        directories = [d.to_dict() for d in self.directories.values()]
        JsonWriter.write(output_directory / "directory.json", directories)
        CsvWriter.write(output_directory / "directory.csv", directories)
        PickleWriter.write(output_directory / "directory.pickle", directories)
