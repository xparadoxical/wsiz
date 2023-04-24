def range_of_list(l: list[int]) -> int:
    n = len(l)

    min = l[0]
    max = min

    for i in range(1, n):
        if l[i] > max:
            max = l[i]
        elif l[i] < min:
            min = l[i]

    return max - min


print(range_of_list([5, 9, -7, 3]))
print(range_of_list([3]))
print(range_of_list([-2, 5, 6, 24, -4]))
