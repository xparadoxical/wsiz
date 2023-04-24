cache: list[list[int]] = []  # cache[n][k] = val


def binomial(n: int, k: int) -> int:
    global cache

    if n >= len(cache):
        cache += [[] for x in range(n - len(cache) + 1)]
    if k >= len(cache[n]):
        cache[n] += [0 for x in range(n - len(cache[n]) + 1)]

    if cache[n][k] != 0:
        return cache[n][k]

    result: int
    if k == 0 or k == n:
        result = 1
    else:
        result = binomial(n - 1, k) + binomial(n - 1, k - 1)

    print(f"cache[{n}][{k}] = {result}")
    cache[n][k] = result
    return result


print(binomial(0, 0))
print(binomial(3, 2))
print(binomial(8, 6))

print(binomial(3, 2))
print(binomial(4, 3))

print(binomial(4, 2))
print(binomial(3, 1))
print(binomial(7, 5))
