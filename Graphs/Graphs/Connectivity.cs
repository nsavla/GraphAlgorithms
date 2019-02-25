using System;
using System.Collections.Generic;
using System.Text;

namespace Graphs
{
    class Connectivity
    {
        int time = 0;
        public bool isReachable(Graph g, int s, int d)
        {
            bool[] visited = new bool[g.getSize()];
            Queue<int> queue = new Queue<int>();
            visited[s] = true;
            queue.Enqueue(s);

            while (queue.Count != 0)
            {
                s = queue.Dequeue();
                for(int i = 0; i < g.Adj[s].Length; i++)
                {
                    if (g.Adj[s][i] != 0)
                    {
                        if (i == d)
                            return true;
                        if (!visited[i])
                        {
                            visited[i] = true;
                            queue.Enqueue(i);
                        }
                    }
                   
                }
            }

            // If BFS is complete without visited d 
            return false;
        }

        public void ArticulationPoint(Graph g)
        {
            int V = g.getSize();
            bool[] visited = new bool[V];
            int[] disc = new int[V];
            int[] low = new int[V];
            int[] parent = new int[V];
            bool[] ap = new bool[V]; // To store articulation points 

            // Initialize parent and visited, and ap(articulation point) 
            // arrays 
            for (int i = 0; i < V; i++)
            {
                parent[i] = -1;
                visited[i] = false;
                ap[i] = false;
            }

            // Call the recursive helper function to find articulation 
            // points in DFS tree rooted with vertex 'i' 
            for (int i = 0; i < V; i++)
                if (visited[i] == false)
                    APUtil(g, i, visited, disc, low, parent, ap);

            // Now ap[] contains articulation points, print them 
            for (int i = 0; i < V; i++)
                if (ap[i] == true)
                    Console.Write(i + " ");
        }

        private void APUtil(Graph g, int u, bool[] visited, int[] disc, int[] low, int[] parent, bool[] ap)
        {

            // Count of children in DFS Tree 
            int children = 0;

            // Mark the current node as visited 
            visited[u] = true;

            // Initialize discovery time and low value 
            disc[u] = low[u] = ++time;

            // Go through all vertices aadjacent to this 
            for(int v = 0; v < g.Adj[u].Length; v++)
            {
                if (g.Adj[u][v] != 0)
                {
                    if (!visited[v])
                    {
                        children++;
                        parent[v] = u;
                        APUtil(g, v, visited, disc, low, parent, ap);

                        // Check if the subtree rooted with v has a connection to 
                        // one of the ancestors of u 
                        low[u] = Math.Min(low[u], low[v]);

                        // u is an articulation point in following cases 

                        // (1) u is root of DFS tree and has two or more chilren. 
                        if (parent[u] == -1 && children > 1)
                            ap[u] = true;

                        // (2) If u is not root and low value of one of its child 
                        // is more than discovery value of u. 
                        if (parent[u] != -1 && low[v] >= disc[u])
                            ap[u] = true;
                    }

                    // Update low value of u for parent function calls. 
                    else if (v != parent[u])
                        low[u] = Math.Min(low[u], disc[v]);
                }
            }
        }
    }
}
