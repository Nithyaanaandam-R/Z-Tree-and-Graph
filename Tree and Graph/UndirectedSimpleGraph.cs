public class UndirectedSimpleGraph<T> 
{
    List<T> nodes;
    bool[,] adjacencyMatrix;

    public UndirectedSimpleGraph(int maxNumberOfNodes)
    {
        nodes = new List<T>(maxNumberOfNodes);
        adjacencyMatrix = new bool[maxNumberOfNodes, maxNumberOfNodes];
        for (int i = 0; i < maxNumberOfNodes; i++)
        {
            for (int j = 0; j < maxNumberOfNodes; j++)
            {
                adjacencyMatrix[i, j] = false;
            }
        }
    }

    public void addEdge(T node1, T node2)
    {
        validateNodes(node1, node2);
        setEdge(node1, node2, true);
    }

    public void removeEdge(T node1, T node2)
    {
        validateNodes(node1, node2);
        setEdge(node1, node2, false);
    }

    public void addNode(T node)
    {
        nodes.Add(node);
    }

    public void removeNode(T node)
    {
        nodes.Remove(node);
    }
    public List<T> getNodes()
    {
        return nodes;
    }


    public bool areAdjacents(T node1, T node2)
    {
        validateNodes(node1, node2);
        int row = nodes.IndexOf(node1);
        int col = nodes.IndexOf(node2);
        return adjacencyMatrix[row, col];
    }

    public List<T> adjacentsTo(T node)
    {
        if (!nodes.Contains(node))
        {
            Console.WriteLine("The node is not on the graph");
            return null;
        }
        List<T> adjacents = new List<T>();
        int row = nodes.IndexOf(node);
        for (int i = 0; i < nodes.Count(); i++)
        {
            if (adjacencyMatrix[row, i])
            {
                adjacents.Add(nodes[i]);
            }
        }
        return adjacents;
    }

    private void validateNodes(T node1, T node2)
    {
        if (node1.Equals(node2)) 
            Console.WriteLine("Simple graphs cannot have loops");
        
        else if (!nodes.Contains(node1) || !nodes.Contains(node2))
        {
            throw new Exception("One of the nodes is not on the graph");
        }
    }

    private void setEdge(T node1, T node2, bool value)
    {
        int row = nodes.IndexOf(node1);
        int col = nodes.IndexOf(node2);
        adjacencyMatrix[row, col] = value;
        adjacencyMatrix[col, row] = value;
    }
}



