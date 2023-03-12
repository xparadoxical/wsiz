def printName(name, age=20):
    """
    Prints name and age.
    :param name: Name.
    :param age: Age, default 20.
    """
    print(f"{name}, lat {age}")


print(printName.__doc__)
printName("Jan")
printName("Krzysztof", 30)
