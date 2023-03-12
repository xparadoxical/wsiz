keys = ["ten", "twenty", "thirty"]
values = [10, 20, 30]

d1 = dict(zip(keys, values))

# d1 = {}
# for i in range(len(values)):
#     d1[keys[i]] = values[i]

# d1 = { keys[i]: values[i] for i in range(len(values)) }

print(d1)

d2 = dict(ten=10, twenty=20, thirty=30)

sumKeys = list(d1.keys()) + list(d2.keys())
sumValues = list(d1.values()) + list(d2.values())
print(dict(zip(sumKeys, sumValues)))
