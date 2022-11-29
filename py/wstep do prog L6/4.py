def printargdict(end="=", **kwargs):
    for pair in kwargs.items():
        (a, b) = pair
        # print(f"{a}={b}", end=end)
        print(f"{a}{end}{b}")


printargdict(a=5, b=8, c="str")
print()
printargdict(end=": ", d=10, alongone=99999)
