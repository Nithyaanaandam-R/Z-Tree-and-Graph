public class Node
{
    public Node LeftNode { get; set; }
    public Node RightNode { get; set; }
    public int Data { get; set; }
}
public class BinaryTree
{
    public Node Root { get; set; }

    public bool Insert(int value)
    {
        Node before = null, after = this.Root;

        while (after != null)
        {
            before = after;
            if (value < after.Data) //Is new node in left tree? 
                after = after.LeftNode;
            else if (value > after.Data) //Is new node in right tree?
                after = after.RightNode;
            else
            {
                //Exist same value
                return false;
            }
        }

        Node newNode = new Node();
        newNode.Data = value;

        if (this.Root == null)//Tree ise empty
            this.Root = newNode;
        else
        {
            if (value < before.Data)
                before.LeftNode = newNode;
            else
                before.RightNode = newNode;
        }

        return true;
    }

    public Node Find(int value)
    {
        return this.Search(value, this.Root);
    }

    private Node Search(int value, Node parent)
    {
        if (parent != null)
        {
            if (value == parent.Data) return parent;
            if (value < parent.Data)
                return Search(value, parent.LeftNode);
            else
                return Search(value, parent.RightNode);
        }

        return null;
    }
    public void Remove(int value)
    {
        this.Root = Delete(this.Root, value);
    }

    private Node Delete(Node parent, int key)
    {
        if (parent == null) return parent;

        if (key < parent.Data) 
            parent.LeftNode = Delete(parent.LeftNode, key);
        else if (key > parent.Data)
            parent.RightNode = Delete(parent.RightNode, key);

        // if value is same as parent's value, then this is the node to be deleted  
        else
        {
            // node with only one child or no child  
            if (parent.LeftNode == null)
                return parent.RightNode;
            else if (parent.RightNode == null)
                return parent.LeftNode;

            // node with two children: Get the inorder successor (smallest in the right subtree)  
            parent.Data = MinValue(parent.RightNode);

            // Delete the inorder successor  
            parent.RightNode = Delete(parent.RightNode, parent.Data);
        }

        return parent;
    }

    private int MinValue(Node node)
    {
        int minv = node.Data;

        while (node.LeftNode != null)
        {
            minv = node.LeftNode.Data;
            node = node.LeftNode;
        }

        return minv;
    }


    public int GetTreeDepth()
    {
        return this.GetTreeDepth(this.Root);
    }

    private int GetTreeDepth(Node parent)
    {
        return parent == null ? 0 : Math.Max(GetTreeDepth(parent.LeftNode), GetTreeDepth(parent.RightNode)) + 1;
    }

    public void TraversePreOrder(Node parent)
    {
        if (parent != null)
        {
            Console.Write(parent.Data + " ");
            TraversePreOrder(parent.LeftNode);
            TraversePreOrder(parent.RightNode);
        }
    }

    public void TraverseInOrder(Node parent)
    {
        if (parent != null)
        {
            TraverseInOrder(parent.LeftNode);
            Console.Write(parent.Data + " ");
            TraverseInOrder(parent.RightNode);
        }
    }

    public void TraversePostOrder(Node parent)
    {
        if (parent != null)
        {
            TraversePostOrder(parent.LeftNode);
            TraversePostOrder(parent.RightNode);
            Console.Write(parent.Data + " ");
        }
    }
}