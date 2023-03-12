s = input("Wpisz ciąg znaków do zliczenia: ")

chars = {}
for c in s:
    chars[c] = chars.get(c, 0) + 1

print(chars)
