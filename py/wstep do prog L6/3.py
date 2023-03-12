def printall(*args):
    for x in args:
        print(x)


def max(*args):
    highest = None
    for x in args:
        if highest is None or x > highest:
            highest = x

    return highest


printall(4, 5, 7, 20)
print()
print(f"Wartość maksymalna: {max(-6, -1, -82, -4)}")
print(f"Wartość maksymalna: {max('a', '0', 'asdf', '')}")
