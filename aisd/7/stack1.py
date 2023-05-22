class Stack:
    def __init__(self):
        self.storage = []

    def top(self):
        return self.storage[len(self.storage) - 1]

    def empty(self):
        return len(self.storage) == 0

    def size(self):
        return len(self.storage)

    def push(self, e):
        self.storage.append(e)

    def pop(self):
        self.storage.pop()


# s = Stack()
# print(s.empty())
# s.push(10)
# s.push(5)
# s.pop()
# s.push(15)
# s.push(7)
# s.pop()
# print(s.empty())
# print(f'top: {s.top()}')
# print(f'size: {s.size()}')
# print(f'storage: {s.storage}')
