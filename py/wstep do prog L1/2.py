import random

print("Obliczanie przewidywanego zużycia paliwa i kosztów podróży samochodem")

literPrice = 6.5
print(f"Cena za litr paliwa: {literPrice}zł")
print()

generateRandomDistance = input("Czy wylosować pokonaną drogę? [tak/nie]: ")#TODO

distance = float(input("Pokonana droga [km]: "))
avgPetrolUsage = float(input("Średnie spalanie [l/100km]: "))

liters = distance / 100 * avgPetrolUsage
print(f"Przewidywane zużycie paliwa: {liters}l")
totalPrice = literPrice * liters
print(f"Szacowane koszta podróży: {totalPrice}zł")