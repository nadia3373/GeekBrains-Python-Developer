from dataclasses import dataclass
from .exceptions import InsufficientFundsException, InvalidAmountException


@dataclass
class ATM:
    """ Класс, представляющий банкомат. """
    _balance: float = 0
    _operation_count: int = 0

    def _calculate_tax(self, amount):
        if self._balance >= 5_000_000:
            return amount * 0.10
        return 0

    def _calculate_withdrawal_fee(self, amount):
        withdrawal_fee = amount * 0.015
        return max(30, min(600, withdrawal_fee))

    def _apply_interest(self, amount):
        return amount + amount * 0.03

    def deposit(self, amount):
        """
        Пополнение баланса на указанную сумму.

        >>> atm = ATM()
        >>> atm.deposit(100)
        Внесено 100 у.е.
        На вашем счету 100 у.е.
        <BLANKLINE>

        >>> atm.deposit(150)
        Внесено 150 у.е.
        На вашем счету 250 у.е.
        <BLANKLINE>
        """
        if amount % 50 != 0:
            raise InvalidAmountException("Сумма пополнения должна быть кратной 50 у.е.")

        self._balance += amount
        self._operation_count += 1
        if self._operation_count % 3 == 0:
            self._balance = self._apply_interest(self._balance)

        print(f"Внесено {amount} у.е.")
        self.display_balance()

    def withdraw(self, amount):
        """
        Снятие указанной суммы со счёта.

        >>> atm = ATM()
        >>> atm.deposit(500)
        Внесено 500 у.е.
        На вашем счету 500 у.е.
        <BLANKLINE>

        >>> atm.withdraw(200)
        Снято 200 у.е. С комиссией 30 у.е.
        На вашем счету 270 у.е.
        <BLANKLINE>
        """
        if amount % 50 != 0:
            raise InvalidAmountException("Сумма снятия должна быть кратной 50 у.е.")

        tax = self._calculate_tax(self._balance)
        if tax > 0:
            self._balance -= tax

        withdrawal_fee = self._calculate_withdrawal_fee(amount)
        total_withdrawal = amount + withdrawal_fee

        if total_withdrawal > self._balance:
            raise InsufficientFundsException()

        self._balance -= total_withdrawal

        print(f"Снято {amount} у.е. С комиссией {withdrawal_fee} у.е.")
        self.display_balance()

    def display_balance(self):
        """
        Вывод текущего баланса на экран.

        >>> atm = ATM()
        >>> atm.deposit(300)
        Внесено 300 у.е.
        На вашем счету 300 у.е.
        <BLANKLINE>

        >>> atm.display_balance()
        На вашем счету 300 у.е.
        <BLANKLINE>
        """
        print(f"На вашем счету {self._balance} у.е.\n")
