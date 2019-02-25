using System;
using System.Collections.Generic;
using System.Text;

namespace Graphs
{
    class Euler
    {
        private int[] inEdge;
        public bool isEulerianCycle(Graph g)
        {
            inEdge = new int[g.getSize()];
            for (int i = 0; i < g.getSize(); i++)
            {
                for (int j = 0; j < g.Adj[i].Length; j++)
                {
                    if (g.Adj[i][j] != 0)
                    {
                        inEdge[i]++;
                    }
                }
            }

            // Check if all non-zero degree vertices are connected 
            if (isSC(g) == false)
                return false;

            // Check if in degree and out degree of every vertex is same 
            for (int i = 0; i < g.getSize(); i++)
            {
                int count = 0;
                for (int j = 0; j < g.Adj[i].Length; j++)
                {
                    if (g.Adj[i][j] == 1) count++;
                }
                if (count != inEdge[i]) return false;
            }

            return true;
        }

        private bool isSC(Graph g)
        {
            // Step 1: Mark all the vertices as not visited (For 
            // first DFS) 
            bool[] visited = new bool[g.getSize()];
            for (int i = 0; i < g.getSize(); i++)
                visited[i] = false;

            // Step 2: Do DFS traversal starting from first vertex. 
            DFSUtil(g, 0, visited);

            // If DFS traversal doesn't visit all vertices, then return false. 
            for (int i = 0; i < g.getSize(); i++)
                if (visited[i] == false)
                    return false;

            // Step 3: Create a reversed graph 
            Graph gr = getTranspose(g);

            // Step 4: Mark all the vertices as not visited (For second DFS) 
            for (int i = 0; i < g.getSize(); i++)
                visited[i] = false;

            // Step 5: Do DFS for reversed graph starting from first vertex. 
            // Staring Vertex must be same starting point of first DFS 
            DFSUtil(g, 0, visited);

            // If all vertices are not visited in second DFS, then 
            // return false 
            for (int i = 0; i < g.getSize(); i++)
                if (visited[i] == false)
                    return false;

            return true;
        }

        private void DFSUtil(Graph g, int i, bool[] visited)
        { 
            visited[i] = true;
            for (int j = 0; j < g.Adj[i].Length; j++)
            {
                if (g.Adj[i][j] != 0)
                {
                    if(!visited[j])
                    DFSUtil(g, j, visited);
                }

            }
            
        }

        Graph getTranspose(Graph g)
        {
            Graph g2 = new Graph(g.getSize());
            //Graph g = new Graph(V);
            for (int v = 0; v < g2.getSize(); v++)
            {
                for (int j = 0; j < g2.Adj[v].Length; j++)
                {
                    if (g2.Adj[v][j] != 0)
                    {
                        inEdge[v]++;
                    }
                }
            }
            return g2;
        }

        public int isEulerianCycleUndirectedUtil(Graph g)
        {
            // Check if all non-zero degree vertices are connected 
            if (isConnected(g) == false)
                return 0;

            // Count vertices with odd degree 
            int odd = 0;
            for (int i = 0; i < g.getSize(); i++)
            {
                int count = 0;
                for (int j = 0; j < g.Adj[i].Length; j++)
                {
                    if (g.Adj[i][j] == 1) count++;
                }
                if (count % 2 != 0)
                    odd++;
            }
               

            // If count is more than 2, then graph is not Eulerian 
            if (odd > 2)
                return 0;

            // If odd count is 2, then semi-eulerian. 
            // If odd count is 0, then eulerian 
            // Note that odd count can never be 1 for undirected graph 
            return (odd == 2) ? 1 : 2;
        }

        private bool isConnected(Graph g)
        {
            // Mark all the vertices as not visited 
            bool[] visited = new bool[g.getSize()];
            int i;
            for (i = 0; i < g.getSize(); i++)
                visited[i] = false;

            // Find a vertex with non-zero degree 
            for (i = 0; i < g.getSize(); i++)
                if (g.Adj[i].Length != 0)
                    break;

            // If there are no edges in the graph, return true 
            if (i == g.getSize())
                return true;

            // Start DFS traversal from a vertex with non-zero degree 
            DFSUtil(g, i, visited);

            // Check if all non-zero degree vertices are visited 
            for (i = 0; i < g.getSize(); i++)
                if (visited[i] == false && g.Adj[i].Length > 0)
                    return false;

            return true;
        }

        public bool isEulerianCycleUndirected(Graph g)
        {
            int res = isEulerianCycleUndirectedUtil(g);
            if (res == 0)
            {
                Console.WriteLine("It does not has a euler path");
                return false;
            }
            else if (res == 1)
            {
                Console.WriteLine("It has a euler path");
                    return true;
            }
             else
            {
                Console.WriteLine("It has a euler cycle");
                    return true;
            }
        }
    }
}

