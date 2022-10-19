print("Wyznaczanie zapisu liczby dziesiętnej w danym systemie pozycyjnym")
print()

number = int(input(f"Wpisz liczbę dziesiętną: "))
if number < 0:
    print("Liczba musi być nieujemna.")
    exit(1)

base = int(input("Podaj podstawę, do której przekonwertować liczbę (2 - 10 lub 16): "))
if not (2 <= base <= 10 or base == 16):
    print("Nieprawidłowa podstawa liczby.")
    exit(1)

digits = {
    0: "0", 1: "1", 2: "2", 3: "3", 4: "4",
    5: "5", 6: "6", 7: "7", 8: "8", 9: "9",
    10: "A", 11: "B", 12: "C", 13: "D", 14: "E", 15: "F"
}

# Dzielenie przez podstawę dopóki nie zostanie 0.
# Reszty z dzieleń to cyfry liczby wyjściowej.

remaining = number
converted = ""
while remaining > 0:
    digitValue = remaining % base
    remaining = remaining // base

    converted = digits[digitValue] + converted

print()
print(f"Liczba dziesiętna {number} w systemie o podstawie {base} to {converted}.")
