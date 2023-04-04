cache = {0: 1, 1: 1}


def S(n: int) -> int:
    if n < 0:
        raise ValueError(f"Expected n >= 0, got {n}")

    if n < 2:
        return 1

    cached = cache.get(n, None)
    if cached is not None:
        return cached

    result = 2 * S(n - 1) - S(n - 2)
    print(f"cache[{n}] = {result}")
    cache[n] = result
    return result


for _ in range(2):
    for n in range(25):
        print(S(n))
    print()

print(S(-1))
