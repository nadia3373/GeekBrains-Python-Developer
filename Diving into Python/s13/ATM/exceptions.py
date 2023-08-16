class ATMException(Exception):
    """ Базовый класс для исключений, связанных с банкоматом. """
    pass


class InvalidAmountException(ATMException):
    """ Исключение для недопустимой суммы. """
    pass


class InsufficientFundsException(ATMException):
    """ Исключение для недостаточного баланса. """
    def __init__(self, message="Недостаточно средств на счету."):
        self.message = message
        super().__init__(self.message)
