from ATM.ATM import ATM
from ATM.exceptions import ATMException
from matrix.matrix import Matrix
from matrix.exceptions import MatrixError
from rectangle.rectangle import Rectangle
from rectangle.exceptions import RectangleError


def main():
    """
    Возьмите 1 - 3 задачи из тех, что были на прошлых семинарах или в домашних заданиях.
    Напишите к ним классы исключения с выводом подробной информации. Поднимайте исключения
    внутри основного кода. Например, нельзя создавать прямоугольник со сторонами
    отрицательной длины.
    """
    atm()
    matrix()
    rectangle()


def atm():
    """ Задача про банкомат. """
    try:
        atm_instance = ATM()

        atm_instance.deposit(1500)
        atm_instance.withdraw(1000)
        atm_instance.deposit(3000)
        atm_instance.deposit(2000)
        atm_instance.withdraw(300)
        atm_instance.deposit(2500)
        atm_instance.deposit(5000)
        atm_instance.withdraw(2000)
        atm_instance.withdraw(500)
        atm_instance.deposit(1000)
        atm_instance.deposit(2000)
        atm_instance.withdraw(1200)

        atm_instance.display_balance()
    except ATMException as e:
        print(f"Произошла ошибка: {e}")


def matrix():
    """ Задача про матрицу. """
    try:
        matrix1 = Matrix([[1, 2], [3, 4]])
        matrix2 = Matrix([[5, 6], [7, 8]])

        print("Матрица 1:")
        print(matrix1)

        print("Матрица 2:")
        print(matrix2)

        sum_matrix = matrix1 + matrix2
        print("Сумма матриц:")
        print(sum_matrix)

        scalar = 2
        mul_matrix = matrix1 * scalar
        print("Умножение матрицы на скаляр:")
        print(mul_matrix)

        matrix3 = Matrix([[1, 2, 3], [4, 5, 6]])
        mul_result = matrix1 * matrix3
        print("Умножение матриц:")
        print(mul_result)
    except MatrixError as e:
        print(f"Произошла ошибка: {e}")


def rectangle():
    """ Задача про прямоугольник. """
    try:
        rectangle1 = Rectangle(5, 3)
        rectangle2 = Rectangle(4)

        print(rectangle1, "\n")
        print(rectangle2, "\n")

        sum_rectangle = rectangle1 + rectangle2
        print("Сумма прямоугольников:", sum_rectangle, "\n")

        sub_rectangle = rectangle1 - rectangle2
        print("Разность прямоугольников:", sub_rectangle, "\n")

        print("rectangle1 равен rectangle2 по площади:", rectangle1 == rectangle2)
        print("rectangle1 не равен rectangle2 по площади:", rectangle1 != rectangle2)
        print("rectangle1 меньше rectangle2 по площади:", rectangle1 < rectangle2)
        print("rectangle1 меньше или равен rectangle2 по площади:", rectangle1 <= rectangle2)
        print("rectangle1 больше rectangle2 по площади:", rectangle1 > rectangle2)
        print("rectangle1 больше или равен rectangle2 по площади:", rectangle1 >= rectangle2)
    except RectangleError as e:
        print(f"Произошла ошибка: {e}")


if __name__ == '__main__':
    main()
