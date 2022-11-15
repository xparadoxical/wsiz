import random


def getrandomlist(length: int) -> list[int]:
    randlist = []
    for i in range(0, length):
        randlist.append(random.randint(0, 100))

    return randlist


def sortmerge(__a: list[int], __b: list[int]) -> list[int]:
    a = __a[:]
    b = __b[:]

    result = []
    while True:
        lenA = len(a)
        lenB = len(b)

        if lenA > 0 and lenB > 0:
            ia = a[0]
            ib = b[0]
            if ia < ib:
                result.append(a.pop(0))
            elif ia > ib:
                result.append(b.pop(0))
            else:
                result += [a.pop(0), b.pop(0)]
        elif lenA > 0 and lenB == 0:
            result.append(a.pop(0))
        elif lenA == 0 and lenB > 0:
            result.append(b.pop(0))
        else:
            break

    return result


print("Sortowanie i scalanie dwóch list")
print()

lengthA = int(input("Długość pierwszej listy: "))
if lengthA < 0:
    print("Nieprawidłowa długość.")
    exit(-1)
lengthB = int(input("Długość drugiej listy: "))
if lengthB < 0:
    print("Nieprawidłowa długość.")
    exit(-1)

print()

list1 = getrandomlist(lengthA)
list1.sort()
print(f"Lista pierwsza: {list1}")

list2 = getrandomlist(lengthB)
list2.sort()
print(f"Lista druga: {list2}")
print()

merged = sortmerge(list1, list2)
print(f"Posortowana i scalona lista o długości {len(merged)}:")
print(merged)
