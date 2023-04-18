def sum_of_every_second() -> int:
    n = int(input("n: "))

    sum = 0
    for i in range(0, n):
        a = int(input("a: "))

        if i % 2 == 0:
            sum += a

    return sum


print(sum_of_every_second())
