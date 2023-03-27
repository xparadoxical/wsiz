recursive_call_count = -1


def wynik(i: int) -> int:
    global recursive_call_count
    recursive_call_count += 1

    if i < 3:
        return 1
    elif i % 2 == 0:
        return wynik(i - 3) + wynik(i - 1) + 1
    else:
        return wynik(i - 1) % 7


for i in range(2, 9):
    recursive_call_count = -1
    print(f"i: {i}    wynik({i}): {wynik(i)}    wywołania funkcji bez wywołania głównego: {recursive_call_count}")
