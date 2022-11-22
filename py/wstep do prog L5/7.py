print("Kalkulator")
print()

x = float(input("Podaj argument 1: "))
y = float(input("Podaj argument 2: "))

print("Jaką operację chcesz wykonać?")
print("    1) dodawanie")
print("    2) odejmowanie")
print("    3) mnożenie")
print("    4) dzielenie")
print("    5) potęgowanie")

result = {
    1: x + y,
    2: x - y,
    3: x * y,
    4: x / y,
    5: x ** y
}

operationIndex = int(input("Wpisz numer operacji: "))
if operationIndex < min(result.keys()) or operationIndex > max(result.keys()):
    print("Nieprawidłowy numer operacji.")
    exit(1)

print()

print(f"Wynik: {result.get(operationIndex)}")
