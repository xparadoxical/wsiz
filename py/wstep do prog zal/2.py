encryptStr = input("1=szyfruj, 2=odszyfruj: ")
assert encryptStr in ["1", "2"]
encrypt = True if encryptStr == "1" else False

k = int(input("k = "))
assert 1 <= k <= 25

s = input("Tekst do zaszyfrowania lub odszyfrowania: ")

encryption = {}
decryption = {}

alphabetCount = ord('z') - ord('a') + 1
for i in range(alphabetCount):
    key = chr(ord('a') + i)
    val = chr(ord('a') + ((k + i) % alphabetCount))

    encryption[key] = val
    decryption[val] = key

if encrypt:
    encrypted = ""
    for c in s:
        if 'a' <= c <= 'z':
            encrypted += encryption[c]
        else:
            encrypted += c

    print(f"Zaszyfrowany tekst: {encrypted}")
elif not encrypt:
    decrypted = ""
    for c in s:
        if 'a' <= c <= 'z':
            decrypted += decryption[c]
        else:
            decrypted += c

    print(f"Odszyfrowany tekst: {decrypted}")

print("Złożoność: O(3n)")
