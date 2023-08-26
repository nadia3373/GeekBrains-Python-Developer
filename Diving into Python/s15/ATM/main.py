from args_parser import parse_args
from ATM import ATM


@parse_args
def main(args):
    atm = ATM()

    if args.transaction == "deposit":
        atm.deposit(args.amount)
    elif args.transaction == "withdraw":
        atm.withdraw(args.amount)
    elif args.transaction == "balance":
        atm.display_balance()


if __name__ == "__main__":
    main()
