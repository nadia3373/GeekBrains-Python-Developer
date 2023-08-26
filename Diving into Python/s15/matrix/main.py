from args_parser import parse_args
from matrix import Matrix
from exceptions import MatrixArgumentsError


@parse_args
def main(args):
    matrix1 = Matrix([[float(num) for num in row.split()] for row in args.matrix1.split(";")])
    matrix2 = Matrix([[float(num) for num in row.split()] for row in args.matrix2.split(";")]) \
        if args.matrix2 is not None else None

    if args.action == "compare":
        if matrix2 is None:
            raise MatrixArgumentsError("Нужны две матрицы для сравнения.")
        matrix1 == matrix2
    elif args.action == "add":
        if matrix2 is None:
            raise MatrixArgumentsError("Нужны две матрицы для сложения.")
        matrix1 + matrix2
    elif args.action == "multiply":
        if matrix2 is None:
            raise MatrixArgumentsError("Нужны две матрицы для этого типа умножения.")
        matrix1 * matrix2
    elif args.action == "scalar":
        if args.scalar is None:
            raise MatrixArgumentsError("Нужно число, на которое будет умножена матрица.")
        matrix1 * args.scalar


if __name__ == "__main__":
    main()
