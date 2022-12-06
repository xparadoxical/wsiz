import numpy as np

weights = np.array([2 ** x for x in reversed(range(0, 8))])  # range(7, -1, -1)
print(f"Wagi bitów: {weights}")

binnumber = np.random.randint(0, 2, size=8)
print(f"Liczba binarna: {binnumber}")

multiplied = weights * binnumber
print(f"Wartości bitów w liczbie: {multiplied}")

number = sum(multiplied)
print(f"Liczba dziesiętna: {number}")
