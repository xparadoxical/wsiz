print("Kalkulator")
print()
print("Jaką operację chcesz wykonać?")
print("    1) dodawanie")
print("    2) odejmowanie")
print("    3) mnożenie")
print("    4) dzielenie")
print("    5) potęgowanie")

operationIndex = int(input("Wpisz numer operacji: "))
if operationIndex < 1 or operationIndex > 5:
    print("Nieprawidłowy numer operacji.")
    exit(1)

print()
x = float(input("Podaj argument 1: "))
y = float(input("Podaj argument 2: "))

result = None
if operationIndex == 1:
    result = x + y
if operationIndex == 2:
    result = x - y
if operationIndex == 3:
    result = x * y
if operationIndex == 4:
    if y == 0:
        print("Argument 2 nie może być równy 0 przy dzieleniu.")
        exit(1)
    else:
        result = x / y
if operationIndex == 5:
    result = x ** y

print(f"Wynik: {result}")
