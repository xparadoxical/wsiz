import numpy as np

matrix = np.zeros(shape=(5, 5))
matrix[0, :] = matrix[:, 0] = matrix[-1, :] = matrix[:, -1] = 1
print(matrix)


def negate(_m: np.ndarray) -> np.ndarray:
    m = _m.copy()
    for row in range(m.shape[0]):
        for column in range(m.shape[1]):
            m[row, column] = 0 if m[row, column] == 1 else 1

    return m


print(negate(matrix))
