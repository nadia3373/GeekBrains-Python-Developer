from typing import List
import random


def main():
    arr1 = [random.randint(1, 10) for _ in range(5)]
    arr2 = [random.randint(1, 10) for _ in range(5)]

    print("Первый массив:", arr1)
    print("Второй массив:", arr2)
    
    try:
        subtracted: List[int] = subtract_arrays(arr1, arr2)
        print("Разность массивов:", subtracted)
        
        divided: List[float] = divide_arrays(arr1, arr2)
        print("Частное массивов:", divided)
    
    except (IndexError):
        raise RuntimeError("Индекс выходит за пределы массива")
    except (ZeroDivisionError):
        raise RuntimeError("Ошибка деления на 0")
    except (ValueError, TypeError):
        raise RuntimeError("Неправильные типы массивов или элементов массивов")
    except (ArrayLengthError):
        raise RuntimeError("Длины массивов не равны")


class ArrayLengthError(Exception):
    def __init__(self, message):
        super().__init__(message)
        self.message = message


def subtract_arrays(arr1: List[int], arr2: List[int]) -> List[int]:
    if len(arr1) != len(arr2):
        raise ArrayLengthError()
    return [arr1[i] - arr2[i] for i in range(len(arr1))]


def divide_arrays(arr1: List[int], arr2: List[int]) -> List[float]:
    if len(arr1) != len(arr2):
        raise ArrayLengthError()
    return [arr1[i] / arr2[i] for i in range(len(arr1))]


if __name__ == "__main__":
    main()
