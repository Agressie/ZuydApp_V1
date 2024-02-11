import json

with open("Database.json", "r") as file:
    data = json.load(file)

def dijkstra(graph, start, end):

    distance = {node: float('inf') for node in graph}
    distance[start] = 0

    previous = {}
    
    visited = set()
    
    while visited != set(graph):
        min_distance_node = None
        for node in graph:
            if node not in visited and (min_distance_node is None or distance[node] < distance[min_distance_node]):
                min_distance_node = node

        if min_distance_node is None:
            break

        for neighbor, weight in graph[min_distance_node]:
            if neighbor not in distance:
                continue
            if distance[min_distance_node] + weight < distance[neighbor]:
                distance[neighbor] = distance[min_distance_node] + weight
                previous[neighbor] = min_distance_node
            
        visited.add(min_distance_node)
    
    path = []
    current = end
    if current in previous or current == start:  
        while current != start:
            path.insert(0, current)
            current = previous[current]
        path.insert(0, start)

        return path, distance[end]
    else:
        return "No path found", float('inf')
    
def regulier():
    regulierpad = {}
    for node, options in data['Graph_Options'].items():
        if options[0] == 1:  
            if node in data['Graph_Routes']:  
                regulierpad[node] = data['Graph_Routes'][node]

    return regulierpad

def nood(start):
    options = data["Graph_Options"]
    nooduitgangen = [node for node, opties in options.items() if opties[1] == 1]

    kortste_pad = None
    kortste_afstand = float('inf')
    for uitgang in nooduitgangen:
        pad, afstand = dijkstra(data["Graph_Routes"], start, uitgang)
        if afstand < kortste_afstand:
            kortste_pad = pad
            kortste_afstand = afstand

    return kortste_pad, kortste_afstand

def invalide():
    invalide_graph = {}
    for node, options in data['Graph_Options'].items():
        if options[2] == 1:  
            if node in data['Graph_Routes']:  
                invalide_graph[node] = data['Graph_Routes'][node]

    return invalide_graph


start_node = "B3.309"
end_node = "B3.305"
shortest_path, shortest_distance = dijkstra(regulier(), start_node, end_node)

print("Shortest Path:", shortest_path)
print("Shortest Distance:", shortest_distance, " meter")

print(nood("B3.309"))
