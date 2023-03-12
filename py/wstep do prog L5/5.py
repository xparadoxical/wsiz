d1 = {"a": -25, "b": 12, "c": 184, "d": -121}
print(d1)
d2 = {"x": 2, "b": -4, "y": 50, "d": 120}
print(d2)

d3 = dict(d1)
for pair in d2.items():
    (k, v) = pair
    if k in d3:
        d3[k] = d3[k] + v
    else:
        d3[k] = v

print(d3)
