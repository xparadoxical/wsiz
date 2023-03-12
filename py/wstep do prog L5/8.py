d = {
    "ser": 14.29,
    "ziemniak": 1.51,
    "masło": 7.19,
    "pomidor": 9.73,
    "chleb": 6.42
}

for pair in d.items():
    (k, v) = pair
    print(f"{k}: {v}zł")

avgPrice = sum(d.values()) / len(d)
print(f"Średnia cena to {avgPrice}zł")

(newK, newV) = ("cebula", 3.55)
d[newK] = newV
print(f"Dodano {newK} w cenie {newV}zł")

#todo avg diff
avgPrice = sum(d.values()) / len(d)
print(f"Średnia cena to teraz {avgPrice}zł")