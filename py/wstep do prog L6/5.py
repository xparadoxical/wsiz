def dodawanie(a, b): return a + b
def odejmowanie(a, b): return a - b
def mnożenie(a, b): return a * b
def dzielenie(a, b):
    if b == 0:
        print("Argument 2 nie może być równy 0 przy dzieleniu.")
        exit(1)

    return a / b


print("Kalkulator")
print()
print("Jaką operację chcesz wykonać?")
print("    1) dodawanie")
print("    2) odejmowanie")
print("    3) mnożenie")
print("    4) dzielenie")

operationIndex = int(input("Wpisz numer operacji: "))
if operationIndex < 1 or operationIndex > 4:
    print("Nieprawidłowy numer operacji.")
    exit(1)

print()
x = float(input("Podaj argument 1: "))
y = float(input("Podaj argument 2: "))

result = {
    1: dodawanie,
    2: odejmowanie,
    3: mnożenie,
    4: dzielenie
}[operationIndex](x, y)

print(f"Wynik: {result}")
