using System;
using System.Collections.Generic;
using System.Text;

namespace Graphs
{
    class Prim
    {

        /*
         * Algorithm
            1) Create a set mstSet that keeps track of vertices already included in MST.
            2) Assign a key value to all vertices in the input graph. Initialize all key values as INFINITE. 
                Assign key value as 0 for the first vertex so that it is picked first.
            3) While mstSet doesn’t include all vertices
                ….a) Pick a vertex u which is not there in mstSet and has minimum key value.
                ….b) Include u to mstSet.
                ….c) Update key value of all adjacent vertices of u. 
                     To update the key values, iterate through all adjacent vertices. 
                     For every adjacent vertex v, if weight of edge u-v is less than the previous key value of v, 
                         update the key value as weight of u-v
         */

        public void primMST(Graph g)
        {
            //Initialization of Values
            int Nodes = g.getSize();
            int[] parent = new int[Nodes];
            int[] key = new int[Nodes];
            bool[] mstVisited = new bool[Nodes];
            for (int i = 0; i < Nodes; i++)
            {
                key[i] = int.MaxValue;
                mstVisited[i] = false;
            }

            key[0] = 0;
            parent[0] = -1;

            for (int count = 0; count < Nodes - 1; count++)
            {
                // Get the minimum node index
                int u = MinKey(key, mstVisited, Nodes);
                mstVisited[u] = true;
                //Update distance of adjacent nodes
                for (int v = 0; v < Nodes; v++)
                    if (g.Adj[u][v] != 0 && mstVisited[v] == false && g.Adj[u][v] < key[v])
                    {
                        parent[v] = u;
                        key[v] = g.Adj[u][v];
                    }
            }
            printMST(g, parent, Nodes);

        }

        // A utility function to find the vertex with minimum key 
        // value, from the set of vertices not yet included in MST 
        private int MinKey(int[] key, bool[] mstVisited, int Nodes)
        {
            // Initialize min value 
            int min = int.MaxValue, min_index = -1;

            for (int v = 0; v < Nodes; v++)
                if (mstVisited[v] == false && key[v] < min)
                {
                    min = key[v];
                    min_index = v;
                }

            return min_index;
        }

        // A utility function to print the constructed MST stored in 
        // parent[] 
        public void printMST(Graph g, int[] parent, int Nodes)
        {
            Console.WriteLine("Edge \tWeight");
            for (int i = 1; i < Nodes; i++)
                Console.WriteLine(parent[i] + " - " + i + "\t" + g.Adj[i][parent[i]]);
        }
    }
}
