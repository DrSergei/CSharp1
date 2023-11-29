class Node
{
    public Int32 Value { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }
}

class Tree
{
    public Tree()
    {
        root = null;
    }

    public static Tree FromString(String str)
    {
        var data = str.Split();
        var queue = new Queue<Node>();
        var root = (data[0] == "null") ? null : (new Node() { Value = Int32.Parse(data[0]) });
        queue.Enqueue(root);
        var tree = new Tree();
        tree.root = root;
        var index = 1;
        while (queue.Count > 0)
        {
            var curr = queue.Dequeue();
            if (curr != null)
            {
                Node left = null;
                if (data[index] != "null")
                {
                    left = new Node() { Value = Int32.Parse(data[index]) };
                }
                curr.Left = left;
                queue.Enqueue(left);
                index++;

                Node right = null;
                if (data[index] != "null")
                {
                    right = new Node() { Value = Int32.Parse(data[index]) };
                }
                curr.Right = right;
                queue.Enqueue(right);
                index++;
            }
        }
        return tree;
    }

    public override String ToString()
    {
        var queue = new Queue<Node>();
        queue.Enqueue(root);

        var data = new List<String>();

        while (queue.Count > 0)
        {
            var curr = queue.Dequeue();
            if (curr == null)
            {
                data.Add("null");
            }
            else
            {
                queue.Enqueue(curr.Left);
                queue.Enqueue(curr.Right);
                data.Add(curr.Value.ToString());
            }
        }

        return String.Join(" ", data.ToArray());
    }

    public Node root;
}

class Task3
{
    static void Main(String[] args)
    {
        var node1 = new Node() { Value = 1 };
        var node2 = new Node() { Value = 2 };
        var node3 = new Node() { Value = 3, Left = node1, Right = node2 };
        var node4 = new Node() { Value = 4 };
        var node5 = new Node() { Value = 5, Left = node3, Right = node4 };
        var tree = new Tree();
        tree.root = node5;
        var newTree = Tree.FromString(tree.ToString());
        Console.WriteLine(tree.root.Value);
        Console.WriteLine(tree.root.Left.Value);
        Console.WriteLine(tree.root.Left.Left.Value);
        Console.WriteLine(tree.root.Left.Right.Value);
        Console.WriteLine(tree.root.Right.Value);
    }
}
