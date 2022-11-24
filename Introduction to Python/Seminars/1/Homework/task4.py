def task4(number):
    """
    Напишите программу, которая по заданному номеру четверти, показывает диапазон возможных координат точек в этой четверти (x и y).
    """
    if number == 1: return "x ∈ (0; +∞), y ∈ (0; +∞)"
    elif number == 2: return "x ∈ (-∞; 0), y ∈ (0; +∞)"
    elif number == 3: return "x ∈ (-∞; 0), y ∈ (-∞; 0)"
    elif number == 4: return "x ∈ (0; +∞), y ∈ (-∞; 0)"
    else: return "Нет такой четверти"


print(task4(int(input("Введите номер четверти: "))))