import re


MIN_YEAR = 1
MAX_YEAR = 9999
MIN_MONTH = 1
MAX_MONTH = 12
MIN_DAY = 1
DAYS_COUNT = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31]


def check_date(date_input: str) -> bool:
    """
    Функция проверки даты.
    """
    if re.match(r'\d{2}\.\d{2}\.\d{4}', date_input):
        day, month, year = (int(i) for i in date_input.split('.'))
        if year < MIN_YEAR or year > MAX_YEAR:
            return False

        if month < MIN_MONTH or month > MAX_MONTH or day < MIN_DAY:
            return False

        days = DAYS_COUNT
        days[1] += _is_leap_year(year)

        if day > days[month - 1]:
            return False

    return True


def _is_leap_year(year: int) -> bool:
    """Проверка года на високосность."""
    if year % 4 == 0 and (year % 100 != 0 or year % 400 == 0):
        return True
    return False
