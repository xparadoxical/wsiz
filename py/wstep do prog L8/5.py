print("Kalkulator")
print()


def addition(a, b): return a + b
def subtraction(a, b): return a - b
def multiplication(a, b): return a * b
def division(a, b):
    if b == 0:
        print("Dzielnik nie może wynosić 0.")
        exit(1)
    return a / b


operations = {
    "+": addition,
    "-": subtraction,
    "*": multiplication,
    "/": division
}


input1 = float(input("Liczba A: "))
operation = input("Operacja (+, -, *, /): ")
input2 = float(input("Liczba B: "))
print(f"{input1} {operation} {input2} = {operations[operation](input1, input2)}")
