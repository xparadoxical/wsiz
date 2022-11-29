def intersection(a, b):
    common = []
    for x in a:
        if x in b:
            common.append(x)

    return common


a = [2, 5, 4, 7]
b = [7, 1, 0, 4, 6, 5]
print(intersection(a, b))
