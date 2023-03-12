def chars(s: str) -> dict[str, int]:
    counts = {}
    for c in s:
        counts[c] = counts.get(c, 0) + 1

    return counts


result = chars("znaki napisu")
print(result)

for k in sorted(result):
    print(f"{k}: {result[k]}")
