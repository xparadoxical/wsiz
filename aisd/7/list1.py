def indexof(l: list, value):
    for i in range(0, len(l)):
        current = l[i]
        if current == value:
            return i

    return -1


l = [1, 5, 2, -1, "e", 0.6]
print(indexof(l, "e"))
