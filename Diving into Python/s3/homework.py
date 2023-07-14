from collections import Counter
from itertools import combinations
from pprint import pprint
import random
import re


BACKPACK_MAX_LOAD = 15.0
MIN_ITEM_WEIGHT = 0.1
MAX_ITEM_WEIGHT = 5.0
MIN_ITEMS_COUNT = 3
FRIENDS_NAMES = ('Вася', 'Петя', 'Миша', 'Ваня', 'Даня')
HIKING_THINGS = ('нож', 'ложка', 'тарелка', 'хлеб', 'вилка', 'бургер', 'вода')
HIKING_THINGS_WEIGHT = {
    name: round(random.uniform(MIN_ITEM_WEIGHT, MAX_ITEM_WEIGHT), 2) for name in HIKING_THINGS
}

def main():
    task8()
    task1()
    task2()
    task3()

def calculate_weight(combo):
    """
    Подсчёт веса комплектации
    """
    return round(sum(HIKING_THINGS_WEIGHT.get(c, 0) for c in combo), 2)

def generate_things():
    """
    Генерация набора вещей
    """
    length = random.randint(MIN_ITEMS_COUNT, len(HIKING_THINGS))
    return {HIKING_THINGS[random.randint(0, len(HIKING_THINGS) - 1)] for _ in range(length)}

def task8():
    '''
    Задание №8 (с семинара)
    ✔ Три друга взяли вещи в поход. Сформируйте словарь, где ключ — имя друга, а значение — кортеж вещей.
    Ответьте на вопросы:
    ✔ Какие вещи взяли все три друга
    ✔ Какие вещи уникальны, есть только у одного друга
    ✔ Какие вещи есть у всех друзей кроме одного и имя того, у кого данная вещь отсутствует
    ✔ Для решения используйте операции с множествами. Код должен расширяться на любое большее количество друзей.
    '''

    # Составление словаря из кортежей вещей для каждого участника похода
    belongings = {name: tuple(generate_things()) for name in FRIENDS_NAMES}

    # Подсчёт количества каждой взятой вещи.
    item_counts = {}
    for values in belongings.values():
        for item in values:
            item_counts.setdefault(item, 0)
            item_counts[item] += 1

    # Множество всех вещей
    all_things = set().union(*belongings.values())
    # Множество вещей, которые есть у каждого
    common_things = all_things.copy()
    # Множество вещей, которые есть у всех, кроме одного
    missing = {}
    # Множество уникальных вещей
    unique_things = set()
    for key, values in belongings.items():
        exc = all_things.copy() - set(values)
        unique = set(values)
        common_things &= set(values)
        for v in belongings.values():
            if v != values:
                exc &= set(v)
                unique -= set(v)
        if exc:
            missing[key] = exc
        unique_things |= unique
    
    print('ЗАДАНИЕ 8')
    pprint(belongings)
    print(f'Все взятые вещи:', *all_things)
    print(f'Вещи, которые есть у каждого:', *common_things)
    print(f'Уникальные вещи:', *unique_things)
    print(f'Вещи, которые есть у всех, кроме одного: ')
    for name, item in missing.items():
        print(f"{name} – ", end='')
        print(*item, sep=', ')
    print()
 
def task1():
    '''
    Дан список повторяющихся элементов. Вернуть список с дублирующимися элементами.
    В результирующем списке не должно быть дубликатов.
    '''
    elements = [5, 2, 5, 'hello', 0.14, 'hello', 0.07, 'hello', True, True, False, 0.07, 15]
    elements_count = Counter(elements)
    duplicates = {item for item, count in elements_count.items() if count > 1}

    print('ЗАДАНИЕ 1')
    print('Список элементов: ', *elements)
    print('Дублирующиеся элементы: ', *duplicates)
    print()

def task2():
    '''
    ✔ В большой текстовой строке подсчитать количество встречаемых слов и вернуть 10 самых частых.
    Не учитывать знаки препинания и регистр символов. За основу возьмите любую статью
    из википедии или из документации к языку.
    '''
    text = '''If a name is declared global, then all references and assignments go directly to the next-to-last
    scope containing the module’s global names. To rebind variables found outside of the innermost scope,
    the nonlocal statement can be used; if not declared nonlocal, those variables are read-only (an attempt to
    write to such a variable will simply create a new local variable in the innermost scope, leaving the
    identically named outer variable unchanged). Usually, the local scope references the local names of the
    (textually) current function. Outside functions, the local scope references the same namespace as the global
    scope: the module’s namespace. Class definitions place yet another namespace in the local scope.
    It is important to realize that scopes are determined textually: the global scope of a function defined in
    a module is that module’s namespace, no matter from where or by what alias the function is called. On the other
    hand, the actual search for names is done dynamically, at run time — however, the language definition is
    evolving towards static name resolution, at “compile” time, so don’t rely on dynamic name resolution! (In fact,
    local variables are already determined statically.) A special quirk of Python is that – if no global or
    nonlocal statement is in effect – assignments to names always go into the innermost scope. Assignments do not
    copy data — they just bind names to objects. The same is true for deletions: the statement del x removes the
    binding of x from the namespace referenced by the local scope. In fact, all operations that introduce new names
    use the local scope: in particular, import statements and function definitions bind the module or function
    name in the local scope. The global statement can be used to indicate that particular variables live in the
    global scope and should be rebound there; the nonlocal statement indicates that particular variables live in
    an enclosing scope and should be rebound there.'''
    # Очистка текста от знаков препинания и приведение к нижнему регистру
    text = re.sub(r'[^\w\s]', '', text.lower())
    # Разделение на слова и подсчёт вхождений каждого слова
    words = text.split()
    words_count = Counter(words)

    print('ЗАДАНИЕ 2')
    for word, count in words_count.most_common(10):
        print(f'{word}: {count}')
    print()

def task3():
    '''
    ✔ Создайте словарь со списком вещей для похода в качестве ключа и их массой в качестве значения.
    Определите какие вещи влезут в рюкзак передав его максимальную грузоподъёмность.
    Достаточно вернуть один допустимый вариант.
    ✔ *Верните все возможные варианты комплектации рюкзака.
    '''
    # Составление всех возможных комплектаций рюкзака
    combos = {}
    for i in range(1, len(HIKING_THINGS_WEIGHT) + 1):
        for combo in combinations(HIKING_THINGS_WEIGHT, i):
            weight = calculate_weight(combo)
            # Добавляются только комплектации, вес которых в пределах вместимости рюкзака
            if weight < BACKPACK_MAX_LOAD:
                combos[combo] = weight
    # Сортировка комплектаций по весу
    combos = {k: v for k, v in sorted(combos.items(), key=lambda x: x[1])}

    print('ЗАДАНИЕ 3')
    for item, weight in HIKING_THINGS_WEIGHT.items():
        print(f"Предмет: {item}, вес: {weight} кг")
    print()
    print(f'Вместимость рюкзака: {BACKPACK_MAX_LOAD} кг')
    print()
    for combo, weight in combos.items():
        print(f"Комплектация: {combo}, вес: {weight} кг")

if __name__ == '__main__':
    main()
