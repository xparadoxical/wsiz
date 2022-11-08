print("y = 2x² - 5x - 8, x ∈ [-4, 4]")
x = -4.0
step = 0.5
end = 4.0
while x <= end:
    print(f"x={x}: {2 * (x ** 2) - 5 * x - 8}")
    x += step
