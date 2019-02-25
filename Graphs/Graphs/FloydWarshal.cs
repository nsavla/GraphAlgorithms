using System;
using System.Collections.Generic;
using System.Text;

namespace Graphs
{
    class FloydWarshal
    {
        readonly static int INF = 99999;
        public void floydWarshall(Graph graph)
        {
            int V = graph.getSize();
            int[,] dist = new int[V, V];
            int i, j, k;
            for (i = 0; i < V; i++)
            {
                for (j = 0; j < V; j++)
                {
                    if (graph.Adj[i][j] == 0)
                        dist[i, j] = INF;
                    else dist[i, j] = graph.Adj[i][j];
                }
            }

            for (k = 0; k < V; k++)
            {
                for (i = 0; i < V; i++)
                {
                    for (j = 0; j < V; j++)
                    {
                        if (dist[i, k] != INF && dist[k, j] != INF)
                        {
                            if (dist[i, k] + dist[k, j] < dist[i, j])
                            {
                                dist[i, j] = dist[i, k] + dist[k, j];
                            }
                        }
                    }
                }
            }

            // Print the shortest distance matrix 
            printSolution(dist, V);
        }

        void printSolution(int[,] dist, int V)
        {
            Console.WriteLine("Following matrix shows the shortest " +
                            "distances between every pair of vertices");
            for (int i = 0; i < V; ++i)
            {
                for (int j = 0; j < V; ++j)
                {
                    if (dist[i, j] == INF)
                    {
                        Console.Write("INF ");
                    }
                    else
                    {
                        Console.Write(dist[i, j] + " ");
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
