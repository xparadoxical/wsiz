print("""Wyznaczanie wartości funkcji

       ┌  2x  dla  x > 0
a(x) = ┤  0   dla  x = 0
       └ -3x  dla  x < 0

b(x) = ┬  x²  dla  x ≥ 1
       └  x   dla  x < 1

       ┌ 2+x  dla  x > 2
c(x) = ┤  8   dla  x = 2
       └ x-4  dla  x < 2
""")

function = input("Wpisz nazwę wybranej funkcji: ")
if function not in ["a", "b", "c"]:
    print("Nieprawidłowa nazwa funkcji.")
    exit(1)

x = float(input("Podaj argument rzeczywisty x: "))


def a(x: float):
    if x > 0:
        return 2 * x
    elif x == 0:
        return 0
    else:
        return -3 * x


def b(x: float):
    if x >= 1:
        return x ** 2
    else:
        return x


def c(x: float):
    if x > 2:
        return 2 + x
    elif x == 2:
        return 8
    else:
        return x - 4


result = None
if function == "a":
    result = a(x)
elif function == "b":
    result = b(x)
elif function == "c":
    result = c(x)

print(f"Wynik to {result}")