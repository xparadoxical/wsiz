def find(l, toFind) -> list[int]:
    indexes = []
    for i in range(len(l)):
        if l[i] == toFind:
            indexes.append(i)

    return indexes


print(find([-3, 5, 6, 1, -3, 6, 5], 6))
