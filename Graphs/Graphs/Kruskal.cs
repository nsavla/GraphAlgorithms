using System;
using System.Collections.Generic;
using System.Text;

namespace Graphs
{
    /*
     * Algorithm
     * 
     1. Sort all the edges in non-decreasing order of their weight.
     2. Pick the smallest edge. Check if it forms a cycle with the spanning tree formed so far. 
        If cycle is not formed, include this edge. Else, discard it.
     3. Repeat step#2 until there are (V-1) edges in the spanning tree.
     */

    class Edge : IComparable
    {
        public int src, dest, weight;

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Edge otherEdge = obj as Edge;
            if (otherEdge != null)
                return this.weight.CompareTo(otherEdge.weight);
            else
                throw new ArgumentException("Object is not an Edge");
        }
    };

    class subset
    {
        public int parent, rank;
    };

    class Kruskal
    {
        public int V, E;    // V-> no. of vertices & E->no.of edges 
        public Edge[] edge; // collection of all edges 

        // Creates a graph with V vertices and E edges 
        public Kruskal(int v, int e)
        {
            V = v;
            E = e;
            edge = new Edge[E];
            for (int i = 0; i < e; ++i)
                edge[i] = new Edge();
        }

        int Find(subset[] subsets, int i)
        {
            // find root and make root as parent of i (path compression) 
            if (subsets[i].parent != i)
                subsets[i].parent = Find(subsets, subsets[i].parent);

            return subsets[i].parent;
        }

        void Union(subset[] subsets, int x, int y)
        {
            int xroot = Find(subsets, x);
            int yroot = Find(subsets, y);

            // Attach smaller rank tree under root of high rank tree 
            // (Union by Rank) 
            if (subsets[xroot].rank < subsets[yroot].rank)
                subsets[xroot].parent = yroot;
            else if (subsets[xroot].rank > subsets[yroot].rank)
                subsets[yroot].parent = xroot;

            // If ranks are same, then make one as root and increment 
            // its rank by one 
            else
            {
                subsets[yroot].parent = xroot;
                subsets[xroot].rank++;
            }
        }

        public void KruskalMST()
        {
            Edge[] result = new Edge[V];  // Tnis will store the resultant MST 
            int e = 0;  // An index variable, used for result[] 
            int i = 0;  // An index variable, used for sorted edges 
            for (i = 0; i < V; ++i)
                result[i] = new Edge();

            // Step 1:  Sort all the edges in non-decreasing order of their 
            // weight.  If we are not allowed to change the given graph, we 
            // can create a copy of array of edges 
            Array.Sort(edge);

            // Allocate memory for creating V ssubsets 
            subset[] subsets = new subset[V];
            for (i = 0; i < V; ++i)
                subsets[i] = new subset();

            // Create V subsets with single elements 
            for (int v = 0; v < V; ++v)
            {
                subsets[v].parent = v;
                subsets[v].rank = 0;
            }

            i = 0;  // Index used to pick next edge 

            // Number of edges to be taken is equal to V-1 
            while (e < V - 1)
            {
                // Step 2: Pick the smallest edge. And increment  
                // the index for next iteration 
                Edge next_edge = new Edge();
                next_edge = edge[i++];

                int x = Find(subsets, next_edge.src);
                int y = Find(subsets, next_edge.dest);

                // If including this edge does't cause cycle, 
                // include it in result and increment the index  
                // of result for next edge 
                if (x != y)
                {
                    result[e++] = next_edge;
                    Union(subsets, x, y);
                }
                // Else discard the next_edge 
            }

            // print the contents of result[] to display 
            // the built MST 
            Console.WriteLine("Following are the edges in " +
                                            "the constructed MST");
            for (i = 0; i < e; ++i)
                Console.WriteLine((result[i].src + 1) + " -- " +
                    (result[i].dest + 1) + " == " + result[i].weight);
        }

        public static Kruskal MakeGraph()
        {
            int V = 15;  // Number of vertices in graph 
            int E = 19;  // Number of edges in graph 
            Kruskal graph = new Kruskal(V, E);

            // add edge 0-1 
            graph.edge[0].src = 0;
            graph.edge[0].dest = 1;
            graph.edge[0].weight = 6;

            // add edge 0-3 
            graph.edge[1].src = 0;
            graph.edge[1].dest = 3;
            graph.edge[1].weight = 2;

            // add edge 1-2
            graph.edge[2].src = 1;
            graph.edge[2].dest = 2;
            graph.edge[2].weight = 4;

            // add edge 1-5 
            graph.edge[3].src = 1;
            graph.edge[3].dest = 5;
            graph.edge[3].weight = 3;

            // add edge 2-8 
            graph.edge[4].src = 2;
            graph.edge[4].dest = 8;
            graph.edge[4].weight = 4;

            // add edge 3-4 
            graph.edge[5].src = 3;
            graph.edge[5].dest = 4;
            graph.edge[5].weight = 23;

            // add edge 4-11 
            graph.edge[6].src = 4;
            graph.edge[6].dest = 11;
            graph.edge[6].weight = 6;

            // add edge 6-7 
            graph.edge[7].src = 6;
            graph.edge[7].dest = 7;
            graph.edge[7].weight = 20;

            // add edge 7-13
            graph.edge[8].src = 7;
            graph.edge[8].dest = 13;
            graph.edge[8].weight = 18;

            // add edge 8-11
            graph.edge[9].src = 8;
            graph.edge[9].dest = 11;
            graph.edge[9].weight = 5;

            // add edge 8-6
            graph.edge[10].src = 8;
            graph.edge[10].dest = 6;
            graph.edge[10].weight = 2;

            // add edge 8-9
            graph.edge[11].src = 8;
            graph.edge[11].dest = 9;
            graph.edge[11].weight = 2;

            // add edge 8-10
            graph.edge[12].src = 8;
            graph.edge[12].dest = 10;
            graph.edge[12].weight = 1;

            // add edge 9-10
            graph.edge[13].src = 9;
            graph.edge[13].dest = 10;
            graph.edge[13].weight = 9;

            // add edge 9-13
            graph.edge[14].src = 9;
            graph.edge[14].dest = 13;
            graph.edge[14].weight = 3;

            // add edge 10-11
            graph.edge[15].src = 10;
            graph.edge[15].dest = 11;
            graph.edge[15].weight = 4;

            // add edge 10-12
            graph.edge[16].src = 10;
            graph.edge[16].dest = 12;
            graph.edge[16].weight = 1;

            // add edge 11-12
            graph.edge[17].src = 11;
            graph.edge[17].dest = 12;
            graph.edge[17].weight = 6;

            // add edge 13-14
            graph.edge[18].src = 13;
            graph.edge[18].dest = 14;
            graph.edge[18].weight = 7;

            return graph;
        }

    };

}

