import random

print("Obliczanie przewidywanego zużycia paliwa i kosztów podróży samochodem")

literPrice = 6.5
print(f"Cena za litr paliwa: {literPrice}zł")
print()

distance = None
generateRandomDistance = input("Czy wybrać losowo pokonaną drogę [km]? (tak/nie): ")
if generateRandomDistance.lower() == "tak":
    distance = random.randint(1, 1000)
    print(f"Pokonana droga: {distance}km")
else:
    distance = float(input("Pokonana droga [km]: "))

avgPetrolUsage = float(input("Średnie spalanie [l/100km]: "))

print()
litersUsed = round(distance / 100 * avgPetrolUsage, 3)
print(f"Przewidywane zużycie paliwa: {litersUsed}l")
totalPrice = round(literPrice * litersUsed, 2)
print(f"Szacowane koszta podróży: {totalPrice}zł")