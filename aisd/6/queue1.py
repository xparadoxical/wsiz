class Queue:
    def __init__(self):
        self.storage = []

    def enqueue(self, item):
        self.storage.insert(0, item)

    def dequeue(self):
        return self.storage.pop()

    def isempty(self):
        return len(self.storage) == 0

    def size(self):
        return len(self.storage)


# q = Queue()
# print(q.isempty())
# q.enqueue(4)
# q.enqueue("dog")
# q.enqueue(True)
# print(q.size())
# print(q.isempty())
# q.enqueue(8.4)
# print(q.dequeue())
# print(q.dequeue())
# print(q.size())
