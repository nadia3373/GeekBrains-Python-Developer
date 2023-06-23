import re

# Класс ошибки для дублирующихся данных
class DuplicateDataError(Exception):
    pass

# Класс ошибки при работе с файлами
class FileError(Exception):
    pass

# Класс ошибки для данных некорректного формата
class IncorrectDataError(Exception):
    pass

# Класс ошибки для недостающих данных
class MissingDataError(Exception):
    pass

# Класс, определяющий все необходимые элементы
class UserData:
    surname: str
    name: str
    patronymic: str
    birthdate: str
    phone_number: str
    gender: str

    def __init__(self, surname: str, name: str, patronymic: str, birthdate: str,
                 phone_number: str, gender: str):
        self.surname = surname
        self.name = name
        self.patronymic = patronymic
        self.birthdate = birthdate
        self.phone_number = phone_number
        self.gender = gender

def main():
    user_input: str = input("Формат элементов данных. ФИО: Фамилия Имя Отчество\n"
                            "Дата рождения: dd.mm.yyyy\n"
                            "Номер телефона: +XXXXXXXXXXX\n"
                            "Пол: f | m\n"
                            "Введите элементы в одну строку через пробел в произвольном порядке: ")
    user_data: UserData = parse_user_data(user_input)
    save_user_data(user_data)
    print("Данные успешно сохранены.")

# Парсинг элементов среди введённых пользователем данных
def parse_user_data(user_input: str) -> UserData:
    data = user_input.split()

    if len(data) != len(UserData.__annotations__):
        raise IncorrectDataError("Некорректное количество элементов")
    
    data_dict = {}
    for item in data:
        if re.match(r"\d{2}\.\d{2}\.\d{4}", item):
            if "birthdate" in data_dict:
                raise DuplicateDataError("Дата рождения указана более, чем 1 раз")
            data_dict["birthdate"] = item
        elif item.startswith("+") and item[1:].isdigit() and len(item) == 12:
            if "phone_number" in data_dict:
                raise DuplicateDataError("Номер телефона указан более, чем 1 раз")
            data_dict["phone_number"] = item
        elif item.isalpha() and len(item) == 1:
            if "gender" in data_dict:
                raise DuplicateDataError("Пол указан более, чем 1 раз")
            if item not in ["f", "m"]:
                raise IncorrectDataError("Пол указан некорректно")
            data_dict["gender"] = item
        elif re.match(r"[A-ZА-Я][a-zа-я]*", item):
            if "surname" not in data_dict:
                data_dict["surname"] = item
            elif "name" not in data_dict:
                data_dict["name"] = item
            elif "patronymic" not in data_dict:
                data_dict["patronymic"] = item
            else:
                raise DuplicateDataError("Фамилия, имя или отчество указаны более, чем 1 раз")
        else:
            raise IncorrectDataError(f"Данные не соответствуют ни одному из требуемых форматов: {item}")

    missing_keys = [key for key in UserData.__annotations__ if key not in data_dict]
    if missing_keys:
        raise MissingDataError(f"Недостающие данные: {', '.join(missing_keys)}")

    return UserData(**data_dict)

# Сохранение записи в файл
def save_user_data(user_data: UserData) -> None:
    filename = f"{user_data.surname}.txt"
    try:
        with open(filename, "a", encoding="utf-8") as file:
            file.write(
                f"{user_data.surname} {user_data.name} {user_data.patronymic} "
                f"{user_data.birthdate} {user_data.phone_number} {user_data.gender}\n"
            )
    except IOError as e:
        raise FileError(f"Ошибка записи в файл: {str(e)}")

if __name__ == "__main__":
    main()
