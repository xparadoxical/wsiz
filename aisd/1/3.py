print("Szukanie liczby w podanym ciągu")

read = None
numbers = []
while True:
    read = input("Podaj następną liczbę lub naciśnij enter: ")
    if len(read) == 0:
        break

    numbers.append(int(read))

n = len(numbers)

if n == 0:
    print("Ciąg jest pusty")
    exit(0)

toFind = int(input("Jakiej liczby szukasz? "))

i = 0
while True:
    if numbers[i] == toFind:
        print(f"Liczba {toFind} to liczba nr {i + 1}")
        exit(0)

    i += 1
    if i >= n:
        print(f"Liczba {toFind} nie występuje w podanym ciągu")
        exit(1)
