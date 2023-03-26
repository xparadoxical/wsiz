def reversed(l: list[int]) -> list[int]:
    count = len(l)
    if count > 2:
        return [*reversed(l[1:]), l[0]]
    elif count == 2:
        return [l[1], l[0]]
    else:
        return l


print(reversed([1, 2, 3, 4, 5]))
print(reversed([1, 2]))
print(reversed([1]))
print(reversed([]))
