from dataclasses import dataclass


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
        if amount % 50 != 0:
            print("Сумма пополнения должна быть кратной 50 у.е.")
            return

        self._balance += amount
        self._operation_count += 1
        if self._operation_count % 3 == 0:
            self._balance = self._apply_interest(self._balance)

        print(f"Внесено {amount} у.е.")
        self.display_balance()

    def withdraw(self, amount):
        if amount % 50 != 0:
            print("Сумма снятия должна быть кратной 50 у.е.")
            return

        tax = self._calculate_tax(self._balance)
        if tax > 0:
            self._balance -= tax

        withdrawal_fee = self._calculate_withdrawal_fee(amount)
        self._balance -= amount + withdrawal_fee

        print(f"Снято {amount} у.е. С комиссией {withdrawal_fee} у.е.")
        self.display_balance()

    def display_balance(self):
        print(f"На вашем счете {self._balance} у.е.\n")
