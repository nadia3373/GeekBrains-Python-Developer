import json
import pickle
from csv import DictWriter


def write_csv(path, items):
    with open(path, "w", encoding="utf-8") as file:
        fieldnames = ["type", "name", "size", "files", "path"]
        csv_writer = DictWriter(file, fieldnames)
        csv_writer.writeheader()
        csv_writer.writerows(items)


def write_json(path, items):
    with open(path, "w", encoding="utf-8", ) as file:
        json.dump(items, file, ensure_ascii=False, indent=4)


def write_pickle(path, items):
    with open(path, "wb") as file:
        pickle.dump(items, file)
