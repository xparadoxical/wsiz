import random as rand

a = int(input("a = "))
minR, maxR = None, None
multipliedNegatives = 1
count = 0
print("Wylosowany ciąg 1:", end=" ")
while True:
    r = rand.randint(-a, a)

    print(r, end=" ")
    if r == 0:
        break
    else:
        count += 1

    if minR is None:
        minR = r
    elif r < minR:
        minR = r

    if maxR is None:
        maxR = r
    elif r > maxR:
        maxR = r

    if r < 0:
        multipliedNegatives *= r

print()
print(f"Największa liczba: {maxR}; najmniejsza: {minR}; iloczyn: {multipliedNegatives}")

print("Wylosowany ciąg 2:", end=" ")
sumR = 0
for i in range(count):
    r = rand.randint(-(a//2), -1)
    print(r, end=" ")
    sumR += r

print()
print(f"Średnia: {sumR / (1 if count == 0 else count)}")
