def sum_of_values(d):
    s = None
    for v in d.values():
        if s is None:
            s = v
        else:
            s += v

    return s


print(sum_of_values({"a": 3, "b": -8, "c": 1}))
