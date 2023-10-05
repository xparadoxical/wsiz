from graph import *

import networkx as nx
import matplotlib.pyplot as plt
import matplotlib
import numpy


def prompt_bool(prompt: str) -> bool:
    v = input(prompt + " (T/N): ").lower()
    if v == "t":
        return True
    elif v == "n":
        return False
    else:
        print("Nieprawidłowe dane.")
        exit(1)


def prompt_node_count() -> int:
    v = input("Podaj liczbę wierzchołków (minimalnie 1): ")
    i = int(v)
    if i < 1:
        print("Nieprawidłowa liczba wierzchołków.")
        exit(1)
    return i


directed = prompt_bool("Graf skierowany?")
weighted = prompt_bool("Graf ważony?")
graph = Graph()

node_count = prompt_node_count()
for id in range(1, node_count + 1):
    graph.add_vertex(id)
print(f"Utworzono {node_count} wierzchołków o numerach od 1 do {node_count}.")

print("Dodawanie krawędzi. Wprowadź pustą wartość zamiast numeru wierzchołka aby zakończyć. Waga musi być różna od zera.")
while True:
    v = input("Krawędź od ")
    if v == "":
        break
    start = int(v)

    v = input("do ")
    if v == "":
        break
    end = int(v)

    if not (0 < start <= node_count and 0 < end <= node_count):
        print("Podano nieprawidłowy wierzchołek.")
        continue

    weight = 0
    if weighted:
        v = input("o wadze ")
        weight = float(v)
        if weight == 0:
            print("Waga musi być różna od zera.")
            continue

    graph.add_edge(start, end, weight)

    if not directed:
        graph.add_edge(end, start, weight)

print()
print("Lista sąsiedztwa:")
for v in graph:
    print(f"{v.get_id()}: {[n.get_id() for n in v.get_neighbors()]}")

print()
print("Macierz sąsiedztwa:")
adjacencyMatrix = numpy.zeros((node_count, node_count))
for v in graph:
    for n in v.get_neighbors():
        w = v.get_weight(n) if weighted else 1
        adjacencyMatrix[v.get_id() - 1, n.get_id() - 1] = w

print(adjacencyMatrix)
print()

G = nx.DiGraph() if directed else nx.Graph()

G.add_nodes_from(graph.get_vertices())

for v in graph:
    for n in v.get_neighbors():
        if weighted:
            w = v.get_weight(n)
            G.add_edge(v.get_id(), n.get_id(), weight=w)
        else:
            G.add_edge(v.get_id(), n.get_id())

is_planar, _ = nx.check_planarity(G)
print(f"Graf {'' if is_planar else 'nie '}jest planarny.")

positions = nx.planar_layout(G) if is_planar else nx.circular_layout(G)
nx.draw_networkx(G, positions, with_labels=True)

if weighted:
    edge_labels = nx.get_edge_attributes(G, "weight")
    nx.draw_networkx_edge_labels(G, positions, edge_labels)

try:
    matplotlib.use('tkagg')
    print("Intepretacja graficzna została wyświetlona w nowym oknie.")
    plt.show()
except ModuleNotFoundError:
    filename = "graph.png"
    plt.savefig(filename, bbox_inches='tight')
    print(f"Intepretacja graficzna została zapisana do pliku '{filename}'.")
