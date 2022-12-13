def power(numbers: list, powers: list):
    if len(numbers) != len(powers):
        return []

    l = []
    for i in range(len(numbers)):
        l.append(numbers[i] ** powers[i])

    return l


print(power([1], [1, 2]))
print(power([-12, -4, -1, 2, 17, 23], [2, 5, 1, 3, 3, 2]))
