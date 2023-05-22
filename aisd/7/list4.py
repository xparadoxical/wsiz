def insertsorted(sortedlist: list[int], n: int):
    insertat = None
    for i in range(0, len(sortedlist) - 1):
        if sortedlist[i] >= n:
            insertat = i
            break

    sortedlist.insert(insertat, n)


l = [1, 5, 7, 8]
insertsorted(l, 6)
print(l)
