import unittest

from matrix.matrix import Matrix
from matrix.exceptions import MatrixMultiplicationError, MatrixSizeError


class TestMatrixOperations(unittest.TestCase):
    def test_matrix_equality(self):
        matrix1 = Matrix([[1, 2], [3, 4]])
        matrix2 = Matrix([[1, 2], [3, 4]])
        self.assertEqual(matrix1, matrix2)

    def test_matrix_addition(self):
        matrix1 = Matrix([[1, 2], [3, 4]])
        matrix2 = Matrix([[5, 6], [7, 8]])
        result = matrix1 + matrix2
        expected = Matrix([[6, 8], [10, 12]])
        self.assertEqual(result, expected)

    def test_matrix_multiplication_scalar(self):
        matrix = Matrix([[1, 2], [3, 4]])
        result = matrix * 2
        expected = Matrix([[2, 4], [6, 8]])
        self.assertEqual(result, expected)

    def test_matrix_multiplication_matrix(self):
        matrix1 = Matrix([[1, 2], [3, 4]])
        matrix2 = Matrix([[5, 6], [7, 8]])
        result = matrix1 * matrix2
        expected = Matrix([[19, 22], [43, 50]])
        self.assertEqual(result, expected)

    def test_invalid_matrix_multiplication(self):
        matrix1 = Matrix([[1, 2], [3, 4]])
        matrix2 = Matrix([[1, 2, 3], [4, 5, 6], [7, 8, 9]])
        with self.assertRaises(MatrixMultiplicationError):
            matrix1 * matrix2

    def test_invalid_matrix_addition(self):
        matrix1 = Matrix([[1, 2], [3, 4]])
        matrix2 = Matrix([[5, 6, 7], [8, 9, 10]])
        with self.assertRaises(MatrixSizeError):
            matrix1 + matrix2


if __name__ == '__main__':
    unittest.main()
