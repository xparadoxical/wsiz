def list_range(l: list[int]) -> int:
    n = len(l)

    min = l[0]
    max = min

    for i in range(1, n):
        if l[i] > max:
            max = l[i]
        elif l[i] < min:
            min = l[i]

    return max - min


print(list_range([5, 9, -7, 3]))
print(list_range([3]))
print(list_range([-2, 5, 6, 24, -4]))
