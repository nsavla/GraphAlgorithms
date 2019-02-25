using System;
using System.Collections.Generic;
using System.Text;

namespace Graphs
{
    class GraphCycle
    {
        private bool isCyclicUtilDirected(Graph graph, bool[] visited, bool[] recStack, int i)
        {
            // Mark the current node as visited and
            // part of recursion stack 
            if (recStack[i])
                return true;

            if (visited[i])
                return false;

            visited[i] = true;

            recStack[i] = true;

            // Loop for all children
            for (int c = 0; c < graph.Adj[i].Length; c++)
            {
                if (graph.Adj[i][c] == 1)
                {
                    if (isCyclicUtilDirected(graph, visited, recStack, c))
                        return true;
                }
               
            }

            recStack[i] = false;

            return false;
        }

        public bool isCyclicDirected(Graph graph)
        {

            // Mark all the vertices as not visited and 
            // not part of recursion stack 
            bool[] visited = new bool[graph.getSize()];
            bool[] recStack = new bool[graph.getSize()];


            // Call the recursive helper function to 
            // detect cycle in different DFS trees 
            for (int i = 0; i < graph.getSize(); i++)
                if (isCyclicUtilDirected(graph, visited, recStack, i))
                    return true;

            return false;
        }

        public bool isCyclicUndirected(Graph graph)
        {

            bool[] visited = new bool[graph.getSize()];
            for (int i = 0; i < graph.getSize(); i++)
                visited[i] = false;

            for (int i = 0; i < graph.getSize(); i++)
                if (!visited[i])
                {
                    if (isCyclicUtilUndirected(graph, i, visited, -1))
                        return true;
                }


            return false;
        }

        private bool isCyclicUtilUndirected(Graph graph, int v, bool[] visited, int parent)
        {
            visited[v] = true;
            // Loop for all children
            for (int c = 0; c < graph.Adj[v].Length; c++)
            {
                if ( graph.Adj[v][c] == 1)
                {
                    if (!visited[c])
                    {
                        if (isCyclicUtilUndirected(graph, c, visited, v))
                            return true;
                    }
                    else if (c != parent)
                        return true;
                }
            }
            return false;
        }

    }
}
