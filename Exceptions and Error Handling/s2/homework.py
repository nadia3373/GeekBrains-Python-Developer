# Реализуйте метод, который запрашивает у пользователя ввод дробного числа (типа float),
# и возвращает введенное значение. Ввод текста вместо числа не должно приводить к падению приложения,
# вместо этого, необходимо повторно запросить у пользователя ввод данных.

# Разработайте программу, которая выбросит Exception, когда пользователь вводит пустую строку.
# Пользователю должно показаться сообщение, что пустые строки вводить нельзя.


def main():
    print("Введенное число:", get_float_input())
    try:
        print("Введенная строка:", get_string_input())
    except Exception as e:
        print(e)

def get_float_input() -> float:
    while True:
        try:
            return float(input("Введите дробное число: "))
        except ValueError:
            print("Введено не число")

def get_string_input() -> str:
    s: str = input("Введите строку: ").strip()
    if len(s) > 0:
        return s
    raise Exception("Пустые строки вводить нельзя")

if __name__ == "__main__":
    main()
