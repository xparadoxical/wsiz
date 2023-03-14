import numpy

rows = 4
cols = 5
arr = numpy.random.randint(0, 100, (rows, cols))
print(arr)

if rows * cols == 0:
    print("Tablica jest pusta")
    exit(1)

for ri in range(0, rows):
    row = arr[ri]

    minIdx = -1
    for ci in range(0, cols):
        if minIdx < 0:
            minIdx = 0

        cell = row[ci]
        if cell < row[minIdx]:
            minIdx = ci

    (row[0], row[minIdx]) = (row[minIdx], row[0])

print()
print(arr)
