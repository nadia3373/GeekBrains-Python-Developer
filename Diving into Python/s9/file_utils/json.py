import json


def save_to_json(func):
    def wrapper(*args, **kwargs):
        """ Декоратор для сохранения результатов вычисления в json. """
        results = {}
        for index, row in enumerate(args):
            results[index] = {
                "arguments": row,
                "result": func(*row)
            }
        with open('data/results.json', 'w') as file:
            json.dump(results, file, ensure_ascii=False, indent=4)

    return wrapper
