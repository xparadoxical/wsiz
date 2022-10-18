print("Cena biletu")
print()

age = int(input("Wprowadź wiek klienta: "))

price = None
if age < 0:
    print("Nieprawidłowy wiek.")
    exit(1)
elif age < 4:
    price = 0
elif age <= 18:
    price = 10
else:
    price = 20

if price == 0:
    print("Wstęp jest bezpłatny.")
else:
    print(f"Cena biletu: {price}zł")
