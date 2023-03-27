def gcd_recursive(a: int, b: int) -> int:
    a, b = b, a % b
    if b != 0:
        return gcd_recursive(a, b)
    else:
        return a


def gcd_iterative(a: int, b: int) -> int:
    while b != 0:
        a_next = b
        b = a % b
        a = a_next

    return a


print(gcd_iterative(12, 18))
print(gcd_iterative(28, 24))
print()
print(gcd_recursive(12, 18))
print(gcd_recursive(28, 24))
