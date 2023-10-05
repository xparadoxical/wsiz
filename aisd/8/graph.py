class Vertex:
    def __init__(self, key: str | int):
        self.id = key
        self.neighbors: dict[Vertex, float] = {}  # { vertex: weight }

    def add_neighbor(self, nbr, weight: float = 0):
        self.neighbors[nbr] = weight

    def __str__(self):
        return f"{str(self.id)} connected to: {[n.id for n in self.neighbors]}"

    def get_neighbors(self):
        return self.neighbors.keys()

    def get_id(self):
        return self.id

    def get_weight(self, nbr):
        return self.neighbors[nbr]


class Graph:
    def __init__(self):
        self.vertices: dict[str | int, Vertex] = {}
        self.count = 0

    def add_vertex(self, key: str | int):
        self.count += 1
        new_vertex = Vertex(key)
        self.vertices[key] = new_vertex
        return new_vertex

    def get_vertex(self, key: str | int):
        if key in self.vertices:
            return self.vertices[key]
        else:
            return None

    def __contains__(self, key: str | int):  # key in graph
        return key in self.vertices

    def add_edge(self, from_: str | int, to: str | int, cost: float = 0):
        if from_ not in self.vertices:
            self.add_vertex(from_)
        if to not in self.vertices:
            self.add_vertex(to)
        self.vertices[from_].add_neighbor(self.vertices[to], cost)

    def get_vertices(self):
        return list(self.vertices.keys())

    def __iter__(self):
        return iter(self.vertices.values())

# g = Graph()
# for i in range(6):
#     g.add_vertex(i)
#     print(g.get_vertices())
#
# g.add_edge(0, 1, 5)
# g.add_edge(0, 5, 2)
# g.add_edge(1, 2, 4)
# g.add_edge(2, 3, 9)
# g.add_edge(3, 4, 7)
# g.add_edge(3, 5, 3)
# g.add_edge(4, 0, 1)
# g.add_edge(5, 4, 8)
# g.add_edge(5, 2, 1)
#
# for v in g:
#     for neigh in v.get_neighbors():
#         print("(%s, %s)" % (v.get_id(), neigh.get_id()))
