print("Wyznaczanie ilości liczb ujemnych w ciągu")

n = None
while True:
    n = int(input('Ilość liczb: '))
    if n > 0:
        break

negatives = 0
i = 0

while i < n:
    a = int(input("Liczba: "))
    if a < 0:
        negatives += 1

    i += 1

print(f"Jest {negatives} liczb ujemnych.")
