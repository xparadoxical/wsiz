print("Obliczanie kwadratów kolejnych liczb całkowitych")
print()

n = int(input("Podaj ilość liczb: "))
if n < 0:
    print("Nieprawidłowa ilość.")
    exit(-1)

l = [[], []]
for i in range(0, n):
    number = i + 1
    l[0].append(number)
    l[1].append(number ** 2)

for i in range(0, len(l[0])):
    number = l[0][i]
    squared = l[1][i]
    print(f"{number}² = {squared}")
