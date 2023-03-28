cache: dict[(int, int), int] = {}

def binomial(n: int, k: int) -> int:
    if not n >= k >= 0:
        raise ValueError(f"Expected n >= k >= 0, got {n} >= {k} >= 0")

    cached = cache.get((n, k), None)
    if cached is not None:
        return cached

    result: int
    if k == 0 or k == n:
        result = 1
    else:
        result = binomial(n - 1, k) + binomial(n - 1, k - 1)

    print(f"cache[({n},{k})] = {result}")
    cache[(n, k)] = result
    return result


print(binomial(0, 0))
print(binomial(3, 2))
print(binomial(1, 1))
print(binomial(0, 5))
