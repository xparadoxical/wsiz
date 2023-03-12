sample_dict = {
    "name": "Kelly",
    "surname": "Jones",
    "age": 25,
    "salary": 8000,
    "city": "New york"
}

for pair in sample_dict.items():
    print(f"{pair[0]}={pair[1]}")
print()

copy = {}
keys = ["surname", "age", "salary"]
for key in keys:
    if key in sample_dict:
        copy[key] = sample_dict[key]
        del sample_dict[key]

if "Jones" in copy.values():
    print("'Jones' exists in dictionary.")
    print()

sample_dict["location"] = sample_dict["city"]
del sample_dict["city"]

for pair in sample_dict.items():
    print(f"{pair[0]}={pair[1]}")
