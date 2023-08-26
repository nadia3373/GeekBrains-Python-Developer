from args_parser import parse_args

from exceptions import RectangleArgumentsError
from rectangle import Rectangle


@parse_args
def main(args):

    rectangle1 = Rectangle(args.l1, args.w1)
    rectangle2 = Rectangle(args.l2, args.w2)

    if args.action == "add":
        if rectangle1 and rectangle2:
            rectangle1 + rectangle2
        else:
            raise RectangleArgumentsError("Нужны два треугольника для сложения")
    elif args.action == "subtract":
        if rectangle1 and rectangle2:
            rectangle1 - rectangle2
        else:
            raise RectangleArgumentsError("Нужны два треугольника для вычитания")
    elif args.action == "compare":
        if rectangle1 and rectangle2:
            rectangle1 == rectangle2
        else:
            raise RectangleArgumentsError("Нужны два треугольника для сравнения")


if __name__ == "__main__":
    main()
