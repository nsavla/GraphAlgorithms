using System;
using System.Collections.Generic;
using System.Text;

namespace Graphs
{
    class TopSort
    {
        private void topologicalSortUtil(Graph g, int v, bool[] visited, Stack<int> stack)
        {
            // Mark the current node as visited. 
            visited[v] = true;
           
            for(int i = 0; i < g.Adj[v].Length; i++)
            {
                if (g.Adj[v][i] == 1)
                {
                    if (!visited[i])
                        topologicalSortUtil(g, i, visited, stack);
                }
              
            }

            // Push current vertex to stack which stores result 
            stack.Push(v);
        }

        // The function to do Topological Sort. It uses 
        // recursive topologicalSortUtil() 
        public void TopologicalSort(Graph g)
        {
            Stack<int> stack = new Stack<int>(); 
            bool[] visited = new bool[g.getSize()];
            for (int i = 0; i < g.getSize(); i++)
                visited[i] = false;

            for (int i = 0; i < g.getSize(); i++)
                if (visited[i] == false)
                    topologicalSortUtil(g, i, visited, stack);

            // Print contents of stack 
            while (stack.Count != 0)
                Console.Write(stack.Pop() + " ");
        }

        // The function does all Topological Sort. 
        // It uses recursive alltopologicalSortUtil() 
        public void allTopologicalSorts(Graph g)
        {
            // Mark all the vertices as not visited 
            bool[] visited = new bool[g.getSize()];
            int[] indegree = new int[g.getSize()];

            for (int i = 0; i < g.getSize(); i++)
            {
                for (int var = 0; var < g.Adj[i].Length; var++)
                {
                    if(g.Adj[i][var] == 1)
                        indegree[var]++;
                }
            }

           Stack<int> stack = new Stack<int>();

            allTopologicalSortsUtil(g , visited, indegree, stack);
        }

        private void allTopologicalSortsUtil(Graph g , bool[] visited, int[] indegree, Stack<int> stack)
        {

            bool flag = false;
            for (int i = 0; i < g.getSize(); i++)
            {
                if (!visited[i] && indegree[i] == 0)
                {
                    visited[i] = true;
                    stack.Push(i);
                    for (int j = 0; j < g.Adj[i].Length; j++)
                    {
                        if(g.Adj[i][j] == 1)
                            indegree[j]--;
                    }
                    allTopologicalSortsUtil(g, visited, indegree, stack);

                    visited[i] = false;
                    stack.Pop();
                    for (int j = 0; j < g.Adj[i].Length; j++)
                    {
                        if (g.Adj[i][j] == 1)
                            indegree[j]++;
                    }

                    flag = true;
                }
            }
            // We reach here if all vertices are visited. 
            // So we print the solution here 
            if (!flag)
            {
                printStack(stack);
                Console.WriteLine();
            }

        }

        private void printStack(Stack<int> stack)
        {
            int[] arr = stack.ToArray();
            for (int i = arr.Length- 1 ; i >= 0; i--)
                Console.Write(arr[i] + " ");
        }

        public List<int> TopologicalSortInList(Graph g)
        {
            Stack<int> stack = new Stack<int>();
            bool[] visited = new bool[g.getSize()];
            for (int i = 0; i < g.getSize(); i++)
                visited[i] = false;

            for (int i = 0; i < g.getSize(); i++)
                if (visited[i] == false)
                    topologicalSortUtil(g, i, visited, stack);

            List<int> list = new List<int>();
            // Print contents of stack 
            while (stack.Count != 0)
                list.Add(stack.Pop());

            return list;
        }

       
    }
}
