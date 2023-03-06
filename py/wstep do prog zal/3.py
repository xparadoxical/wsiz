import numpy as np


def create(dim = 1, shape = 10, a = 1, b = 10, operation = "sum"):
    arrays = [ np.random.randint(a, b + 1, shape) for _ in range(dim) ]

    if operation == "sum":
        op = []
        for a in arrays:
            op.append(a.sum())
        return (arrays, op)
    elif operation == "max":
        op = []
        for a in arrays:
            op.append(a.max())
        return (arrays, op)
    elif operation == "average":
        op = []
        for a in arrays:
            op.append(a.sum() / a.size)
        return (arrays, op)
