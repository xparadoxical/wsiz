import math


def solvequadraticformula(a, b=0, c=0):
    delta = b**2 - 4 * a * c
    if delta > 0:
        sqrtdelta = math.sqrt(delta)
        return [(-b - sqrtdelta) / (2 * a), (-b + sqrtdelta) / (2 * a)]
    elif delta == 0:
        return [-b / (2 * a)]
    else:
        return []


print(solvequadraticformula(4, 5, 1))
print(solvequadraticformula(1, -2, 1))
print(solvequadraticformula(4, 0, 7))
