using System;
using System.Collections.Generic;
using System.Text;

namespace Graphs
{

    //This Class definition is pre-defined. No Change
    public class Node
    {
        public int val;
        public IList<Node> neighbors;

        public Node() { }
        public Node(int _val, IList<Node> _neighbors)
        {
            val = _val;
            neighbors = _neighbors;
        }
    }
    public class CloneGraph
    {
        public Node MakeExampleGraph()
        {
            Node n1 = new Node(1, new List<Node>());
            Node n2 = new Node(2, new List<Node>());
            Node n3 = new Node(3, new List<Node>());
            Node n4 = new Node(4, new List<Node>());
            n1.neighbors.Add(n2);
            n1.neighbors.Add(n4);
            n2.neighbors.Add(n1);
            n2.neighbors.Add(n3);
            n3.neighbors.Add(n2);
            n3.neighbors.Add(n4);
            n4.neighbors.Add(n1);
            n4.neighbors.Add(n3);
            return n1;
        }

        public Node Clone(Node node)
        {
            var m = new Dictionary<int, Node>();
            return CloneGraphUtil(node, m);
        }

        public Node CloneGraphUtil(Node node, Dictionary<int, Node> m)
        {
            if (node == null) return null;
            if (m.ContainsKey(node.val))
            {
                return m[node.val];
            }
            Node root = new Node(node.val, new List<Node>());
            m[node.val] = root;
            if (m[node.val] != null)
            {
                foreach (Node n in node.neighbors)
                {
                    root.neighbors.Add(CloneGraphUtil(n, m));
                }
            }
            return root;
        }

        public void Print(Node n)
        {
            Queue<Node> Q = new Queue<Node>();
            List<Node> visited = new List<Node>();
            visited.Add(n);
            Console.WriteLine("Node value : " + n.val + " and address is " + n.GetHashCode());
            Q.Enqueue(n);
            while (Q.Count != 0)
            {
                Node temp = Q.Dequeue();
                foreach (Node tempNode in temp.neighbors)
                {
                    if (!visited.Contains(tempNode))
                    {
                        visited.Add(tempNode);
                        Console.WriteLine("Node value : " + tempNode.val + " and address is " + tempNode.GetHashCode());
                        Q.Enqueue(tempNode);
                    }
                }
            }
        }
    }
}
