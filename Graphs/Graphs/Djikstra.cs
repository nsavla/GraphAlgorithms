using System;
using System.Collections.Generic;
using System.Text;

namespace Graphs
{
    class Djikstra
    {
        /*
         * Algorithm
        1) Create a set sptSet (shortest path tree set) that keeps track of vertices included in shortest path tree, 
            i.e., whose minimum distance from source is calculated and finalized. Initially, this set is empty.
        2) Assign a distance value to all vertices in the input graph. 
            Initialize all distance values as INFINITE. 
            Assign distance value as 0 for the source vertex so that it is picked first.
        3) While sptSet doesn’t include all vertices
            ….a) Pick a vertex u which is not there in sptSet and has minimum distance value.
            ….b) Include u to sptSet.
            ….c) Update distance value of all adjacent vertices of u. 
                To update the distance values, iterate through all adjacent vertices. 
                For every adjacent vertex v, if sum of distance value of u (from source) and weight of edge u-v, 
                    is less than the distance value of v, then update the distance value of v.
         */

        static int V;
        int minDistance(int[] dist,
                        bool[] sptSet)
        {
            // Initialize min value 
            int min = int.MaxValue, min_index = -1;

            for (int v = 0; v < V; v++)
                if (sptSet[v] == false &&
                      dist[v] <= min)
                {
                    min = dist[v];
                    min_index = v;
                }

            return min_index;
        }

        // A utility function to print 
        // the constructed distance array 
        void printSolution(int[] dist, int n)
        {
            Console.Write("Vertex     Distance " +
                                "from Source\n");
            for (int i = 0; i < V; i++)
                Console.Write(i + " \t\t " +
                            dist[i] + "\n");
        }

        // Funtion that implements Dijkstra's  
        // single source shortest path algorithm 
        // for a graph represented using adjacency  
        // matrix representation 
        public void dijkstra(Graph graph, int src)
        {
            V = graph.getSize();
            int[] dist = new int[V]; // The output array. dist[i] 
                                     // will hold the shortest  
                                     // distance from src to i 

            // sptSet[i] will true if vertex 
            // i is included in shortest path  
            // tree or shortest distance from  
            // src to i is finalized 
            bool[] sptSet = new bool[V];

            // Initialize all distances as  
            // INFINITE and stpSet[] as false 
            for (int i = 0; i < V; i++)
            {
                dist[i] = int.MaxValue;
                sptSet[i] = false;
            }

            // Distance of source vertex 
            // from itself is always 0 
            dist[src] = 0;

            // Find shortest path for all vertices 
            for (int count = 0; count < V - 1; count++)
            {
                // Pick the minimum distance vertex  
                // from the set of vertices not yet  
                // processed. u is always equal to  
                // src in first iteration. 
                int u = minDistance(dist, sptSet);

                // Mark the picked vertex as processed 
                sptSet[u] = true;

                // Update dist value of the adjacent  
                // vertices of the picked vertex. 
                for (int v = 0; v < V; v++)

                    // Update dist[v] only if is not in  
                    // sptSet, there is an edge from u  
                    // to v, and total weight of path  
                    // from src to v through u is smaller  
                    // than current value of dist[v] 
                    if (!sptSet[v] && graph.Adj[u][v] != 0 &&
                               dist[u] != int.MaxValue &&
                         dist[u] + graph.Adj[u][v] < dist[v])
                        dist[v] = dist[u] + graph.Adj[u][v];
            }

            // print the constructed distance array 
            printSolution(dist, V);
        }
    }
}
