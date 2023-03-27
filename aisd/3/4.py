def decimal_to_binary(n: int) -> int:
    if n <= 0:
        return 0
    else:
        return 10 * decimal_to_binary(n // 2) + (n % 2)


print(decimal_to_binary(4))
print(decimal_to_binary(7))
print(decimal_to_binary(96))
