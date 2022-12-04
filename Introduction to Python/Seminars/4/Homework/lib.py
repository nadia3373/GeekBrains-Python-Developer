import random


def generate_polynomials(k):
    s = []
    for i in range(k + 1): s.append(get_power(i, k))
    return s


def generate_sequence():
    return [random.randint(-10, 10) for i in range(random.randint(5, 15))]


def get_power(index, length):
    if length - index >= 2: return [random.randint(-100, 100), f"x^{length - index}"]
    elif length - index == 1: return [random.randint(-100, 100), "x"]
    else: return [random.randint(-10, 10)]


def normalize(lst):
    for i in range(len(lst)):
        if len(lst[i]) != 2:
            if lst[i][0].startswith("-x"):
                lst[i].insert(0, -1)
                lst[i][1] = lst[i][1][1:]
            elif lst[i][0].startswith("+x"):
                lst[i].insert(0, 1)
                lst[i][1] = lst[i][1][1:]
            elif lst[i][0].startswith("x"): lst[i].insert(0, 1)


def save_to_file(eq, filename):
    s = ""
    for i in range(len(eq)):
        # Добавить + перед числом, если оно положительное, и элемент не первый в строке
        if int(eq[i][0]) > 0 and len(s) > 0: s += "+"
        # Если коэффициент не равен -1, 0 или 1, либо коэффициент равен -1 или 1, и элемент последний, записать его
        if ((eq[i][0] == -1 or eq[i][0] == 1) and len(eq) - i == 1) or eq[i][0] not in (-1, 0, 1): s += str(eq[i][0])
        # Если коэффициент равен -1 и элемент не последний, записать -
        elif eq[i][0] == -1 and len(eq) - i != 1: s += "-"
        # Если коэффициент не раен 0, записать x в соответствующей степени
        if eq[i][0] != 0:
            if len(eq) - i - 1 == 1:
                if abs(eq[i][0]) > 1: s += "*x "
                else: s+= "x "
            elif len(eq) - i - 1 > 1:
                if abs(eq[i][0]) > 1: s += f"*x^{len(eq) - i - 1} "
                else: s += f"x^{len(eq) - i - 1} "
    s += " = 0"
    with open(f"{filename}.txt", "w") as f: f.write(s)


def sum_polynomials(eq1, eq2):
    # Суммирование всех элементов со степенями, присутствующими в обоих уравнениях
    for i in range(len(eq1)):
        for j in range(len(eq2)):
            eq1[i][0] = int(eq1[i][0])
            eq2[j][0] = int(eq2[j][0])
            if len(eq1[i]) == 2 and len(eq2[j]) == 2:
                if eq1[i][1] in eq2[j]:
                    eq1[i][0] = eq1[i][0] + eq2[j][0]
                    eq2.remove(eq2[j])
                    break
            else:
                if len(eq1[i]) == 1 and len(eq2[j]) == 1:
                    eq1[i][0] = eq1[i][0] + eq2[j][0]
                    eq2.remove(eq2[j])
                    break
    # Добавление в уравнение всех элементов, оставшихся во втором уравнении
    for j in range(len(eq2)):
        if len(eq2[j]) == 1: eq1.append(eq2[j])
        else:
            try: power = int(eq2[j][1].split("^")[1])
            except:
                if "x" in eq2[j][1]: power = 1
                else: power = 0
            for i in range(len(eq1)):
                if len(eq1[i]) == 2:
                    try: first_power = int(eq1[i][1].split("^")[1])
                    except: first_power = 1
                else: first_power = 0
                if power > first_power:
                    eq1.insert(i, eq2[j])
                    break


def unique_elements(lst):
    return [lst[i] for i in range(len(lst)) if lst.count(lst[i]) == 1]