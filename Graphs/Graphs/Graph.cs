using System;
using System.Collections.Generic;
using System.Text;

namespace Graphs
{
    class Graph
    {
        private int Nodes;
        public int[][] Adj;
        public Graph(int nodes)
        {
            Nodes = nodes;
            Adj = new int[nodes][];
            for (int i = 0; i < nodes; i++)
            {
                Adj[i] = new int[nodes];
            }

        }

        public int getSize()
        {
            return Nodes;
        }

        public void AddEdgeDirected(int u, int v, int weight = 1)
        {
            Adj[u][v] = weight;
        }

        public void AddEdgeUnDirected(int u, int v, int weight = 1)
        {
            Adj[u][v] = weight;
            Adj[v][u] = weight;
        }

        public void BFS()
        {
            bool[] visited = new bool[Nodes];
            Queue<int> Q = new Queue<int>();
            Q.Enqueue(0); // If we dont want to start with 0, have a parameter
            visited[0] = true;
            while (Q.Count != 0)
            {
                int temp = Q.Dequeue();
                Console.Write(temp + " ");
                for (int i = 0; i < Adj[temp].Length; i++)
                {
                    if (Adj[temp][i] == 1)
                        if (!visited[i])
                        {
                            visited[i] = true;
                            Q.Enqueue(i);
                        }
                }
            }
        }

        public void DFSStack()
        {
            bool[] visited = new bool[Nodes];
            Stack<int> stack = new Stack<int>();
            stack.Push(0); // If we dont want to start with 0, have a parameter
            visited[0] = true;
            while (stack.Count != 0)
            {
                int temp = stack.Pop();
                Console.Write(temp + " ");
                for (int i = 0; i < Adj[temp].Length; i++)
                {
                    if (Adj[temp][i] == 1)
                        if (!visited[i])
                        {
                            visited[i] = true;
                            stack.Push(i);
                        }
                }
            }
        }

        public void DFSRec()
        {
            bool[] visited = new bool[Nodes];
            DFSUtil(0, visited);
        }
        public void DFSUtil(int i, bool[] visited)
        {
            if (!visited[i])
            {
                visited[i] = true;
                Console.Write((i + 1) + " ");
                for (int j = 0; j < Adj[i].Length; j++)
                {
                    if (Adj[i][j] == 1)
                    {
                        DFSUtil(j, visited);
                    }

                }
            }
        }

       

    }
}
