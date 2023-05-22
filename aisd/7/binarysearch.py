def binarysearch(l: list, x) -> int:
    left = 0
    right = len(l) - 1

    if right == -1:
        return -1

    while right - left > 0:
        length = right - left + 1
        middle = left + length // 2
        if x < l[middle]:
            right = middle - 1
        else:  # x >= l[middle]
            left = middle

    assert left == right, f"{left} != {right}"
    if l[left] == x:
        return left

    return -1


l = [1, 3, 6, 9, 10, 11, 14, 16, 27]
print(binarysearch(l, 1))
print(binarysearch(l, 3))
print(binarysearch(l, 6))
print(binarysearch(l, 9))
print(binarysearch(l, 10))
print(binarysearch(l, 11))
print(binarysearch(l, 14))
print(binarysearch(l, 16))
print(binarysearch(l, 27))
