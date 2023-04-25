from stack1 import Stack


def validate_parentheses(s: str) -> bool:
    stack = Stack()

    for c in s:
        if c == "(":
            stack.push(c)
        elif c == ")":
            if stack.empty():
                return False
            stack.pop()

    return stack.empty()


print(validate_parentheses("(()()()())"))
print(validate_parentheses("(((())))"))
print(validate_parentheses("(()((())()))"))
print(validate_parentheses("((((((())"))
print(validate_parentheses("()))"))
print(validate_parentheses("(()()(()"))
