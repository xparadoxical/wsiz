from queue1 import Queue


def hotpotato():
    q = Queue()
    q.enqueue("Bill")
    q.enqueue("David")
    q.enqueue("Susan")
    q.enqueue("Jane")
    q.enqueue("Kent")
    q.enqueue("Brad")

    k = 7

    while q.size() > 1:
        for _ in range(k):
            q.enqueue(q.dequeue())

        print(f"{q.dequeue()} is eliminated.")

    print(f"{q.dequeue()} is the last one!")


hotpotato()
