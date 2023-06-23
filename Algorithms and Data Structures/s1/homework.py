from random import randint
import time


# Делаем проверку скорости сортировки для массива из 10000 элементов обоими способами.
def main():
    lst = [randint(1, 9) for i in range(10000)]
    
    start = time.time()
    bubble_sort(lst.copy())
    b_end = time.time() - start

    start = time.time()
    quick_sort(lst.copy(), 0, len(lst) - 1)
    q_end = time.time() - start

    print(f"Время выполнения пузырьковой сортировки: {b_end:.2f}сек, время выполнения быстрой сортировки: {q_end:.2f}сек")
    print(f"Индекс искомого элемента: {binary_search([1, 3, 5, 7, 8, 9], 7)}")


# Реализуем простой алгоритм сортировки (любой или несколько)
def bubble_sort(lst):
    length = len(lst) - 1
    for i in range(length):
        swapped = False
        for j in range(length - i):
            if lst[j] > lst[j + 1]: lst[j], lst[j + 1] = lst[j + 1], lst[j]
            swapped = True
        if not swapped: break
    return lst


# Реализуем быструю сортировку массива.
def partition(lst, l, r):
    pivot = lst[r]
    i = l - 1
    for j in range(l, r):
        if lst[j] <= pivot:
            i = i + 1
            lst[i], lst[j] = lst[j], lst[i]
    lst[i + 1], lst[r] = lst[r], lst[i + 1]
    return i + 1 
 

def quick_sort(lst, l, r):
    while l < r:
        p = partition(lst, l, r)
        if p - l < r - p:
            quick_sort(lst, l, p - 1)
            l = p + 1
        else:
            quick_sort(lst, p + 1, r)
            r = p - 1
    return lst


# Реализуем бинарный поиск
def binary_search(lst, target):
    low = 0
    high = len(lst) - 1

    while low <= high:
        mid = (low + high) // 2
        if lst[mid] == target: return mid
        elif lst[mid] < target: low = mid + 1
        else: high = mid - 1

    return -1


if __name__ == "__main__": main()