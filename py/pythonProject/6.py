l = list(range(10))
l[:0] = l[-3:]
l[-3:] = []
print(l)