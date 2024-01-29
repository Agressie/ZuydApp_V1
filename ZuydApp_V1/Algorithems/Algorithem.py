import json

with open("Database.json", "r") as file:
    data = json.load()

<<<<<<< Updated upstream
def kortsteroute(van, naar, nood=False, handicap=False):
    pass
=======
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
>>>>>>> Stashed changes


kortsteroute("", "")