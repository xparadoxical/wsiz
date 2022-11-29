def reverse(s):
    reversed = ""
    for i in range(len(s) - 1, -1, -1):
        reversed += s[i]

    return reversed


print(f"1. {reverse('asdf')}")
print(f"2. {reverse('')}")
