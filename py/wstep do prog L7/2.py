import numpy as np

size = 5
count = size ** 2

randlist = np.random.randint(0, count + 1, size=(5, 5))
print(randlist)

print(f"Maksymalna wartość: {randlist.max()}")
print(f"Maksymalne wartości z każdej kolumny: {randlist.max(axis=0)}")
print(f"Maksymalne wartości z każdego wiersza: {randlist.max(axis=1)}")

print(f"Suma: {randlist.sum()}")
print(f"Sumy kolumn: {randlist.sum(axis=0)}")
print(f"Sumy wierszy: {randlist.sum(axis=1)}")
