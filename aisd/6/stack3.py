from stack1 import Stack


def validate_parentheses(s: str) -> bool:
    stack = Stack()

    for c in s:
        if c in ['(', '[', '{']:
            stack.push(c)
        elif c in [')', ']', '}']:
            if stack.empty():
                return False

            top = stack.top()
            stack.pop()

            if (c == ')' and top != '(') \
                    or (c == ']' and top != '[') \
                    or (c == '}' and top != '{'):
                return False

    return stack.empty()


print(validate_parentheses("([](){}[])"))
print(validate_parentheses("[({()})]"))
print(validate_parentheses("{()[[{}]()]}"))
print(validate_parentheses("({[[({())"))
print(validate_parentheses("{}])"))
print(validate_parentheses("[(){}[()"))
