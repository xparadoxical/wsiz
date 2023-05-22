def merge(a: list[int], b: list[int]) -> list[int]:
    result = []

    while True:
        if len(a) > 0 and len(b) > 0:
            ia = a[0]
            ib = b[0]
            if ia < ib:
                result.append(a.pop(0))
            elif ia > ib:
                result.append(b.pop(0))
            else:
                result += [a.pop(0), b.pop(0)]
        elif len(a) > 0 and len(b) == 0:
            result.append(a.pop(0))
        elif len(a) == 0 and len(b) > 0:
            result.append(b.pop(0))
        else:
            break

    return result


l1 = [0, 2, 3, 6]
l2 = [4, 4, 6, 7]
print(merge(l1, l2))
