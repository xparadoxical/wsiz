cache = {
    0: 0,
    1: 1,
    2: 1,
    3: 2,
    4: 3,
    5: 5,
    6: 8,
    7: 13,
    8: 21,
    9: 34,
    10: 55,
    11: 89,
    12: 144,
    13: 233,
    14: 377,
    15: 610,
    16: 987,
    17: 1597,
    18: 2584,
    19: 4181
}

# def lookup_getorset(n: int) -> int:
#     lookup_table_len = len(lookup_table)
#     if 0 <= n < lookup_table_len:
#         lookup = lookup_table[n]
#         if lookup >= 0:
#             return lookup


def fibonacci(n: int) -> int:
    if n < 0:
        raise ValueError("The Fibonacci sequence starts at 0.")

    cached = cache.get(n, None)
    if cached is not None:
        return cached

    result: int
    if n < 2:
        result = n
    else:
        result = fibonacci(n - 1) + fibonacci(n - 2)

    print(f"cache[{n}] = {result}")
    cache[n] = result
    return result


for n in [*range(25), -1]:
    print(fibonacci(n))
