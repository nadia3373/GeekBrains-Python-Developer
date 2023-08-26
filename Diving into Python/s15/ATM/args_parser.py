import argparse


def parse_args(func):
    def wrapper(*args, **kwargs):
        parser = argparse.ArgumentParser(description="Действия с банкоматом")
        parser.add_argument("--transaction", choices=["deposit", "withdraw", "balance"],
                            help="Выберите действие: deposit (внести), withdraw (снять), balance (отобразить баланс)")
        parser.add_argument("--amount", type=float, help="Количество")

        parsed_args = parser.parse_args()
        return func(parsed_args, *args, **kwargs)

    return wrapper
