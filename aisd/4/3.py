def max(input: list[int]) -> int:
    if len(input) == 1:
        return input[0]
    else:
        middle = len(input) // 2
        a = max(input[:middle])
        b = max(input[middle:])
        return a if a > b else b


print(max([5, -2, 4, 5, 6, 0]))
