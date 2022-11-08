print("Kolejne liczby")
print()
print("Mniejsza liczba całkowita to początek, większa to koniec.")

a = int(input("Pierwsza liczba: "))
b = int(input("Druga liczba: "))
(start, stop) = (a, b)
if start > stop:
    (start, stop) = (stop, start)

first = True
while start <= stop:
    if first:
        print(start, end="")
        first = False
    else:
        print(f", {start}", end="")

    start += 1
