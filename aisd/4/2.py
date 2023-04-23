def merge(l: int, m: int, r: int, A: list[int], B: list[int]):
    """
    :param l: (left) first index of the first sorted sublist in A; the last index is m-1
    :param m: (middle) first index of the second sorted sublist in A
    :param r: (right) last index of the second sorted sublist in A
    :param A: input list where l:m and m:(r+1) are two sorted sublists
    :param B: output - the two sublists merged and sorted
    """

    i = k = l
    j = m

    while i < m or j <= r:

        if i < m and j <= r:
            a = A[i]
            b = A[j]

            if a <= b:
                B.append(a)
                i += 1
            if b <= a:
                B.append(b)
                j += 1

        elif i < m:
            B += A[i:m]
            i = m
        elif j <= r:
            B += A[j:r + 1]
            j = r + 1


# dwie połowy tablicy - [0..4], [5..9] - powinny być posortowane rosnąco
A = [1,35,42,65,68,25,55,59,70,79]
B = []
merge(0, 5, 9, A, B)
print(B)
