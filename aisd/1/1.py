import math

print("Pierwiastki równania kwadratowego")

a = int(input("A: "))
b = int(input("B: "))
c = int(input("C: "))
delta = b ** 2 - 4 * a * c

if delta > 0:
    x1 = (-b - math.sqrt(delta)) / (2 * a)
    x2 = (-b + math.sqrt(delta)) / (2 * a)
    print(f"x1 = {x1}")
    print(f"x2 = {x2}")
elif delta == 0:
    x = -b / (2 * a)
    print(f"x = {x}")
else:
    print("Brak rozwiązań w zbiorze liczb rzeczywistych")
