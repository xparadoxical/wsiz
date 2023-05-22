def removenodeat(l: list, i: int):
    if i <= 0:
        return

    l.pop(i - 1)


l = [5, 6, 2]
removenodeat(l, 2)
print(l)
