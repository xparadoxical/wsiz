def stringstats(s):
    """
    Counts uppercase, lowercase and other characters.
    :param s: The string whose chars to analyze.
    :return: A tuple containing the count of uppercase letters,
    the count of lowercase letters and the count of other characters.
    """
    uppercase = 0
    lowercase = 0
    other = 0
    for c in s:
        if 'A' <= c <= 'Z':
            uppercase += 1
        elif 'a' <= c <= 'z':
            lowercase += 1
        else:
            other += 1

    return (uppercase, lowercase, other)


s = "AhBwoh#(*% NH(O*"
(up, low, other) = stringstats(s)
print(f'The string "{s}" contains {up} uppercase letters, {low} lowercase letters and {other} other characters.')
