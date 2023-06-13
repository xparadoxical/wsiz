def maxpairdiff(l: list[int]) -> (int, int):
    m: (int, int) = None

    for i in range(0, len(l) - 1):
        if m is None:
            m = (l[i], l[i + 1])
        else:
            dm = max(m[0], m[1]) - min(m[0], m[1])
            dnew = max(l[i], l[i + 1]) - min(l[i], l[i + 1])
            if dnew > dm:
                m = (l[i], l[i + 1])

    return m


print(maxpairdiff([2, 5, 3, 7, 1, 4]))
print(maxpairdiff([2, 5, 0, 7, 1, 4]))
