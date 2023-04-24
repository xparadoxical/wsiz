cache = [1, 1]


def S(n: int) -> int:
    if n < len(cache):
        return cache[n]

    result = 2 * S(n - 1) - S(n - 2)
    cache.append(result)
    return result


for n in range(10):
    print(S(n))
