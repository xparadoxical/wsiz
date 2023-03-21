def compare_lexicographic(left: int, right: int) -> int:
    """
    Compares left to right lexicographically (based on digits, going from left).
    :return: An integer indicating the sort order relation. -1 if left&lt;right, 0 if left==right, 1 if left&gt;right
    """
    if left == right:
        return 0

    s_left = str(left)
    s_right = str(right)

    i = 0
    while True:
        l = ord(s_left[i]) if i < len(s_left) else 0
        r = ord(s_right[i]) if i < len(s_right) else 0

        if l == r:
            i += 1
            continue
        elif l > r:
            return 1
        elif l < r:
            return -1


def sorted_lexicographic(l_: list[int]) -> list[int]:
    l = list(l_)

    for i in range(len(l) - 1, 0, -1):
        for j in range(0, i):
            if compare_lexicographic(l[j], l[j + 1]) > 0:  # b>a: b,a -> a,b
                l[j], l[j + 1] = l[j + 1], l[j]

    return l


print("Sortowanie liczb naturalnych leksykograficznie")

numbers = []

while True:
    input_ = input("Liczba naturalna: ")
    if input_ == "":
        break

    a = int(input_)
    if a < 1:
        print(f"{a} nie jest liczbą naturalną.")
        exit(1)

    numbers.append(a)

if len(numbers) == 0:
    print("Nie podano przynajmniej jednej liczby.")
    exit(1)

print(sorted_lexicographic(numbers))
