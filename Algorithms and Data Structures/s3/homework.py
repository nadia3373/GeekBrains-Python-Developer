import random


# Необходимо реализовать метод разворота связного списка (двухсвязного или односвязного на выбор).
# (Необязательное)* попробуйте вывести n-е число с конца односвязного списка, предварительно не узнавая его размер(за 1 цикл while)
def main():
    lst = LinkedList()
    for _ in range(100):
        lst.push(random.randint(0, 99))

    print("Список до разворота:")
    lst.print()
    lst.reverse()
    print("Список после разворота:")
    lst.print()

    n: int = 5
    nth_backwards(lst.head, n)


class Node:
    def __init__(self, value: int) -> None:
        self.value = value
        self.next: Node = None


class LinkedList:
    def __init__(self) -> None:
        self.head: Node = None

    def print(self) -> None:
        current: Node = self.head
        print("[", end="")
        while current:
            if current.next is not None:
                print(f"{current.value}, ", end="")
            else:
                print(f"{current.value}", end="")
            current = current.next
        print("]", end="\n\n")

    def push(self, value: int) -> None:
        new: Node = Node(value)
        if self.head is None:
            self.head = new
        else:
            current: Node = self.head
            while current.next is not None:
                current = current.next
            current.next = new

    def reverse(self) -> None:
        current: Node = self.head
        previous: Node = None
        while current:
            next = current.next
            current.next = previous
            previous = current
            current = next
        self.head = previous


def nth_backwards(head: Node, n: int) -> int:
    if head is None:
        return 0
    i: int = nth_backwards(head.next, n) + 1
    if i == n:
        print(f"{n}-ый элемент с конца списка: {head.value}")
    return i


if __name__ == "__main__":
    main()
