def compress(s):
    result = ""
    count = 0
    i = 0
    while i < len(s):
        count = 1
        for j in range(i + 1, len(s)):
            if s[i] != s[j]: break;
            count += 1
        result += str(count) + s[i]
        i += count
    return result


def decompress(s):
    result = ""
    i = 0
    while i < len(s):
        if s[i].isdigit(): result += int(s[i]) * s[i + 1]
        i += 1
    return result