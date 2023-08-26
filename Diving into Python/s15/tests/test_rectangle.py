import pytest
from rectangle.rectangle import Rectangle
from rectangle.exceptions import NegativeSizeError, InvalidOperationError


def test_rectangle_initialization_square():
    square = Rectangle(5)
    assert square.length == 5
    assert square.width == 5


def test_rectangle_initialization():
    rectangle = Rectangle(4, 6)
    assert rectangle.length == 4
    assert rectangle.width == 6


def test_negative_length():
    with pytest.raises(NegativeSizeError):
        Rectangle(-2)


def test_negative_width():
    with pytest.raises(NegativeSizeError):
        Rectangle(4, -6)


def test_rectangle_perimeter_square():
    square = Rectangle(5)
    assert square.perimeter() == 20


def test_rectangle_perimeter():
    rectangle = Rectangle(4, 6)
    assert rectangle.perimeter() == 20


def test_rectangle_area_square():
    square = Rectangle(5)
    assert square.area() == 25


def test_rectangle_area():
    rectangle = Rectangle(4, 6)
    assert rectangle.area() == 24


def test_rectangle_addition():
    rectangle1 = Rectangle(6, 4)
    rectangle2 = Rectangle(5, 3)
    result = rectangle1 + rectangle2
    expected = Rectangle(9)
    assert result == expected


def test_rectangle_subtraction():
    rectangle1 = Rectangle(7, 9)
    rectangle2 = Rectangle(3, 5)
    result = rectangle1 - rectangle2
    expected = Rectangle(4)
    assert result == expected


def test_rectangle_comparison():
    rectangle1 = Rectangle(3, 4)
    rectangle2 = Rectangle(2, 6)
    assert (rectangle1 > rectangle2) is False
    assert (rectangle2 < rectangle1) is False
    assert (rectangle1 >= rectangle2) is True
    assert (rectangle2 <= rectangle1) is True
    assert (rectangle1 != rectangle2) is False


def test_rectangle_str_representation():
    rectangle = Rectangle(5, 7)
    expected_str = "Прямоугольник: длина = 5, ширина = 7\nПериметр: 24, площадь: 35"
    assert str(rectangle) == expected_str


def test_rectangle_repr_representation():
    rectangle = Rectangle(5, 7)
    expected_repr = "Rectangle(5, 7)"
    assert repr(rectangle) == expected_repr


if __name__ == '__main__':
    pytest.main()
