class ATMException(Exception):
    """ Базовый класс для исключений, связанных с банкоматом. """
    def __init__(self, message="Ошибка работы банкомата."):
        self.message = message
        super().__init__(self.message)


class InvalidAmountException(ATMException):
    """ Исключение для недопустимой суммы. """
    def __init__(self, message="Введена недопустимая сумма."):
        self.message = message
        super().__init__(self.message)


class InsufficientFundsException(ATMException):
    """ Исключение для недостаточного баланса. """
    def __init__(self, message="Недостаточно средств на счету."):
        self.message = message
        super().__init__(self.message)
