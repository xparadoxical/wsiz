import numpy as np

size = 5

zeros = np.zeros(shape=(3, 3), dtype='int')
arrays = [zeros.copy() for _ in range(size)]
arrays[0][1:, :2] = 1  # in a:b, b is exlusive!
arrays[1][:, 2] = 1
arrays[2][:2, :] = 1
arrays[3][:2, 0] = 1
arrays[4][:1, :] = 1  # todo

for x in range(5):
    print(arrays[x])
