internal class Program
{
    private static void Main(string[] args)
    {
        UndirectedSimpleGraphExample();
        
        BinaryTreeExample();
               
    }

    public static void BinaryTreeExample()
    {
        Console.Clear();
        BinaryTree binaryTree = new BinaryTree();

        binaryTree.Insert(1);
        binaryTree.Insert(2);
        binaryTree.Insert(7);
        binaryTree.Insert(3);
        binaryTree.Insert(10);
        binaryTree.Insert(5);
        binaryTree.Insert(8);

        Node node = binaryTree.Find(5);
        int depth = binaryTree.GetTreeDepth();

        Console.WriteLine("PreOrder Traversal:");
        binaryTree.TraversePreOrder(binaryTree.Root);
        Console.WriteLine();

        Console.WriteLine("InOrder Traversal:");
        binaryTree.TraverseInOrder(binaryTree.Root);
        Console.WriteLine();

        Console.WriteLine("PostOrder Traversal:");
        binaryTree.TraversePostOrder(binaryTree.Root);
        Console.WriteLine();

        binaryTree.Remove(7);
        binaryTree.Remove(8);

        Console.WriteLine("PreOrder Traversal After Removing Operation:");
        binaryTree.TraversePreOrder(binaryTree.Root);
        Console.WriteLine();

        Console.ReadLine();
    }

    public static void UndirectedSimpleGraphExample()
    {
        UndirectedSimpleGraph<string> graph = new UndirectedSimpleGraph<string>(3);
        graph.addNode("city1");
        graph.addNode("city2");
        graph.addNode("city3");

        graph.addEdge("city1", "city2");
        Console.WriteLine(graph.areAdjacents("city1", "city2"));
        graph.removeEdge("city1", "city2");
        Console.WriteLine(graph.areAdjacents("city1", "city2"));
        graph.addEdge("city1", "city2");
        graph.addEdge("city1", "city3");
        List<String> adjacents = graph.adjacentsTo("city1");
        Console.WriteLine("city1 adjacents count: " + adjacents.Count);
        foreach (string city in adjacents)
        {
            Console.WriteLine(city);
        }

        Console.ReadLine();
    }
}



