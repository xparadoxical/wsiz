print("Wyznaczanie wartości liczby w danym systemie pozycyjnym")
print()

base = int(input("Podaj podstawę liczby (2 - 10): "))
if not 2 <= base <= 10:
    print("Nieprawidłowa podstawa liczby.")
    exit(1)

digits = ["0", "1", "2", "3", "4", "5", "6", "7", "8", "9"]

number = input(f"Wpisz liczbę o podstawie {base}: ")
if len(number) == 0:
    print("Nie podano liczby.")
    exit(1)

# L - wartość liczby
# n - ilość cyfr
# i - indeks cyfry
# c - cyfra
# p - podstawa liczby
#
# L = sum(n, i = 0, c_i * (p ** i))

sum = 0
i = 0
for digit in reversed(number):
    if not digits[0] <= digit <= digits[base - 1]:
        print(f"Liczba o podstawie {base} może zawierać wyłącznie cyfry od 0 do {digits[base - 1]}.")
        exit(1)

    sum += int(digit) * (base ** i)
    i += 1

print()
print(f"Wartość podanej liczby w systemie dziesiętnym to {sum}.")
