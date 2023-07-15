def main():
    task1()
    task2()


def map_arguments(**kwargs):
    """
    Функция принимает только ключевые параметры и возвращает словарь,
    где ключ — значение переданного аргумента, а значение — имя аргумента.
    Если ключ не хешируем, используется его строковое представление.
    """
    result = {}
    for key, value in kwargs.items():
        try:
            hash(value)
            result[value] = key
        except:
            result[str(value)] = key
    return result


def transpose_matrix(matrix):
    ''' Функция для транспонирования матрицы '''
    return [list(column) for column in zip(*matrix)]


def task1():
    matrix = [[1, 2, 3], [4, 5, 6], [7, 8, 9]]
    transposed_matrix = transpose_matrix(matrix)
    print('Исходная матрица:')
    print(*matrix, sep='\n')
    print('Транспонированная матрица:')
    print(*transposed_matrix, sep='\n')


def task2():
    result = map_arguments(a=[1,2,3,4,5], b='Hello', c=1, d=True, e=12.75)
    print(*(f'Ключ: {k}, значение: {v}' for k, v in result.items()), sep='\n')


if __name__ == '__main__':
    main()
