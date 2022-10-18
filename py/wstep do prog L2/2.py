print("Sprawdzanie wielkości litery")
print()

s = input("Wprowadź literę: ")
if len(s) != 1:
    print("Wprowadzono więcej niż jeden znak.")
    exit(1)
# elif not s.isalpha():
elif not (("a" <= s <= "z") or ("A" <= s <= "Z")):
    print("Wprowadzono znak inny niż litera łacińska.")
    exit(1)

print(f"Litera jest {'mała' if 'a' <= s <= 'z' else 'duża'}.")
