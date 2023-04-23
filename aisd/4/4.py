def sum(input: list[int]) -> int:
    if len(input) == 1:
        return input[0]
    else:
        middle = len(input) // 2
        return sum(input[:middle]) + sum(input[middle:])


print(sum([2, 3, 6, 2, -3]))
