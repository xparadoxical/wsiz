def factorial(n: int) -> int:
    if n == 0:
        return 1
    elif n >= 1:
        return n * factorial(n - 1)
    elif n < 0:
        raise ValueError(f"Expected n to be non-negative, was {n}.")


for n in range(15, -2, -1):
    print(f"{n}! = {factorial(n)}")
