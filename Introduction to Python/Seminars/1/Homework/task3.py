def task3(coordinates):
    """
    Напишите программу, которая принимает на вход координаты точки (X и Y), причём X ≠ 0 и Y ≠ 0 и выдаёт номер четверти плоскости, в которой находится эта точка (или на какой оси она находится).
    Пример:
    - x=34; y=-30 -> 4
    - x=2; y=4-> 1
    - x=-34; y=-30 -> 3
    """
    if coordinates[0] != 0 and coordinates[1] != 0:
        if coordinates[0] > 0:
            if coordinates[1] > 0: return 1
            elif coordinates[1] < 0: return 4
        elif coordinates[0] < 0:
            if coordinates[1] > 0: return 2
            elif coordinates[1] < 0: return 3
    elif coordinates[0] == 0 and coordinates[1] == 0: return "Это центр кординатной плоскости"
    elif coordinates[0] == 0: return "Точка находится на оси x"
    else: return "Точка находится на оси y"


print(task3((int(input("Введите x: ")), int(input("Введите y: ")))))