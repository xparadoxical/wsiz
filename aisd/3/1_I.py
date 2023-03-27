def gcd(a: int, b: int) -> int:
    while True:
        print(f"a={a} b={b}")
        if a == b:
            return a
        elif a > b:
            a -= b
            print(f"a -= b")
        else:
            b -= a
            print(f"b -= a")


print(gcd(12, 18))
print()
print(gcd(28, 24))
