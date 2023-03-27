towers = {
    "A": [5, 4, 3, 2, 1],
    "B": [],
    "C": []
}


def hanoi(count_to_move: int, source: str, target: str, auxiliary: str):
    if count_to_move > 0:
        hanoi(count_to_move - 1, source, auxiliary, target)

        towers[target].append(towers[source].pop())

        print(f"{source}->{target}")

        hanoi(count_to_move - 1, auxiliary, target, source)


hanoi(len(towers["A"]), source="A", target="B", auxiliary="C")
# print(towers)
