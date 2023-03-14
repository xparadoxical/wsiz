import numpy

n = 20
arr = numpy.random.randint(0, 100, n)
print(arr)

i = 0
first = True
min = 0
while i < n:
    current = arr[i]
    if first or current < min:
        first = False
        min = current

    i += 1

print(f"Najmniejsza wartość wynosi {min}")
