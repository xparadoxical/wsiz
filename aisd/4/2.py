def merge(l: int, m: int, r: int, A: list[int], B: list[int]):
    """
    :param l: left index of the first sorted sublist in A; the end index is m-1
    :param m: left index of the second sorted sublist in A
    :param r: right index of the second sorted sublist in A
    :param A: input
    :param B: output list of the size of A
    :return:
    """

    i = k = l
    j = m

    left_last = m - 1
    right_last = r

    while True:
        a = A[i]
        b = A[j]

        if i < left_last and j < right_last:
            if a >= b:
                B.append(a)
                i += 1
            if a <= b:
                B.append(b)
                j += 1

        elif i < left_last:
            B += A[i:left_last + 1]
            i = left_last
        elif j < right_last:
            B += A[j:right_last + 1]
            j = right_last
        else:
            break

B = []
merge(0, 5, 9, [1,35,42,65,68,25,55,59,70,79], B)
print(B)
