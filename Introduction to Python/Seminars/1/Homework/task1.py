
def task1(day):
    """
    Напишите программу, которая принимает на вход цифру, обозначающую день недели, и проверяет, является ли этот день выходным.
    Пример:
        - 6 -> да
        - 7 -> да
        - 1 -> нет
    """
    answer = "Такого дня недели пока нет"
    if day == 6 or day == 7:
        answer = "Да"
    elif day > 0 and day < 6:
        answer = "Нет"
    return answer


print(task1(int(input("Введите день недели: "))))