import os


class File:
    def __init__(self, name, size, parent, path):
        self.name = name
        self.size = size
        self.parent = parent
        self.path = path

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


class Directory:
    def __init__(self, name, parent, path):
        self.name = name
        self.size = 0
        self.files = []
        self.subdirectories = []
        self.parent = parent
        self.path = path

    def __str__(self):
        return f"Directory: {self.parent}/{self.name}\n" \
               f"Size: {self.size}\n" \
               f"File count: {len(self.files)}\n" \
               f"Subdirectory count: {len(self.subdirectories)}\n"

    def __dict__(self):
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


def traverse(path):
    directories = {}

    for dirpath, dirnames, filenames in os.walk(path):

        if dirpath not in directories.keys():
            directory = Directory(os.path.basename(dirpath), None, dirpath)
        else:
            directory = directories[dirpath]

        for filename in filenames:
            file_path = os.path.join(dirpath, filename)
            file_size = os.path.getsize(file_path)
            file = File(filename, file_size, directory, dirpath)
            directory.files.append(file)
            directory.size += file_size

        for dirname in dirnames:
            sub_directory = Directory(dirname, directory, dirpath)
            directory.subdirectories.append(sub_directory)
            directories[os.path.join(dirpath, dirname)] = sub_directory
        directories[dirpath] = directory

    return directories
