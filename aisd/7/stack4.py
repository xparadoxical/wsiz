from stack1 import Stack

def parse_rpn(s: str) -> int:
    stack = Stack()

    for c in s:
        if '0' <= c <= '9':
            stack.push(int(c))
            continue
        elif c == "=":
            return stack.top()

        b = stack.top()
        stack.pop()
        a = stack.top()
        stack.pop()

        if c == "+":
            stack.push(a + b)
        elif c == "-":
            stack.push(a - b)
        elif c == "*":
            stack.push(a * b)
        elif c == "/":
            stack.push(a / b)
        elif c == "^":
            stack.push(a ** b)

    raise ArithmeticError("Input must end with =")


print(parse_rpn("73+52-2^*="))
