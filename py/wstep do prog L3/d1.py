print("Sprawdzanie poprawności nawiasowania i znajdowanie maksymalnego poziomu zagnieżdżenia nawiasów")
print()


def fail():
    print("NIE")
    exit(1)


length = int(input("Podaj długość ciągu (min. 1, maks. 100): "))
if not 1 <= length <= 100:
    print("Długość nie mieści się w podanym zakresie.")
    exit(1)

s = input(f"Wpisz ciąg nawiasów o długości {length}: ")
if len(s) != length:
    print(f"Ciąg ma długość {len(s)} zamiast podanej {length}.")
    exit(1)
for c in s:
    if c not in ["(", ")", "{", "}", "[", "]"]:
        print(f"Ciąg zawiera znak '{c}'. Może zawierać wyłącznie te znaki: (){{}}[]")
        exit(1)

if length % 2 == 1:
    fail()

opened = []
maxLevel = 0
for c in s:
    if c in ["(", "{", "["]:
        opened += c
    elif c in [")", "}", "]"]:
        if len(opened) == 0:
            fail()
        toMatch = opened.pop()
        if (c == ")" and toMatch != "(") or (c == "}" and toMatch != "{") or (c == "]" and toMatch != "["):
            fail()

    maxLevel = len(opened) if len(opened) > maxLevel else maxLevel

if len(opened) > 0:
    fail()

print(maxLevel)
