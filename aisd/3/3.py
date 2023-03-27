def f(n: int) -> float:
    if n == 1:
        return 4
    elif n >= 2:
        return 1 / (1 - f(n - 1))


def test(n: int):
    print(f"f({n}) = {f(n)}")


test(8)
test(9)
test(10)
test(100)
