print("Dodawanie dwóch liczb naturalnych")
print()


def inputnumber(index: int) -> str:
    s = input(f"Wpisz liczbę nr {index}: ")
    if not s.isnumeric():
        print("Nie podano prawidłowej liczby naturalnej.")
        exit(1)

    return s


a = inputnumber(1)
b = inputnumber(2)

operand1 = list(a)
operand2 = list(b)

result = []
carry: str = ""
digitIndex = 1
while len(operand1) > 0 or len(operand2) > 0 or len(carry) > 0:
    tempSum = 0
    if len(operand1) > 0:
        tempSum += int(operand1.pop())
    if len(operand2) > 0:
        tempSum += int(operand2.pop())
    if len(carry) > 0:
        tempSum += int(carry)
        carry = ""

    assert tempSum <= 19, f"tempSum should be at most 9+9+1=19 but was {tempSum}"

    tempSumStr = str(tempSum)
    if tempSum > 9:
        result.insert(0, tempSumStr[1])
        carry = tempSumStr[0]
    else:
        result.insert(0, tempSumStr)

sum = "".join(result)

print(f"{a} + {b} = {sum}")
