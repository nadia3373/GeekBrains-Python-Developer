def bin(n):
    if n > 0: bin(n // 2)
    else: return
    print(n % 2, end = "")


def fib(n):
    if n in (0, 1): return n
    if n < 0: return int((-1)**(n + 1)) * fib(-n)
    else: return fib(n - 1) + fib(n - 2)