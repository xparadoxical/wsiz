print("Zmiana wielkości litery na przeciwną")
print()

char = input("Wpisz literę: ")
if len(char) != 1:
    print("Nie wpisano dokładnie jednej litery łacińskiej.")
    exit(1)
elif not ("a" <= char <= "z" or "A" <= char <= "Z"):
    print("To nie jest litera łacińska.")
    exit(1)

# ord("a") ^ ord("A") == 32
# chr(ord(c) ^ 32) == c.upper() if c.islower() else c.lower()
print(f"Litera o zmienionej wielkości: {chr(ord(char) ^ 32)}")
