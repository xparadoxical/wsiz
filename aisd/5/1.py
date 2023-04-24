cache = [0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181]


def fibonacci(n: int) -> int:
    if n < len(cache):
        return cache[n]

    result: int
    if n < 2:
        result = n
    else:
        result = fibonacci(n - 1) + fibonacci(n - 2)

    cache.append(result)
    return result


for n in [*range(25)]:
    print(fibonacci(n))
