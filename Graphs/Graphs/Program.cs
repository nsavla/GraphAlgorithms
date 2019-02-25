using System;
using System.Collections.Generic;

namespace Graphs
{
    class Program
    {
         static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Graph g = makeGraph();
            g.BFS();
            Console.WriteLine();
            g.DFSRec();
            Console.WriteLine();
            g.DFSStack();
            Console.WriteLine();

            Graph g2 = makeWeightedGraph();
            Prim p = new Prim();
            p.primMST(g2);
            Console.WriteLine();

            Kruskal.MakeGraph().KruskalMST();
            Console.WriteLine();

            Djikstra d = new Djikstra();
            d.dijkstra(g2,0);
            Console.WriteLine();

            GraphCycle gc = new GraphCycle();
            if (gc.isCyclicDirected(g))
               Console.WriteLine("The graph is cyclic");
            else Console.WriteLine("The graph is not cyclic");
            Console.WriteLine();

            TopSort ts = new TopSort();
            ts.TopologicalSort(g);
            ts.allTopologicalSorts(g);
            Console.WriteLine();

            FloydWarshal fw = new FloydWarshal();
            fw.floydWarshall(g);
            Console.WriteLine();

            Connectivity c = new Connectivity();
            for(int i = 0; i < g.getSize(); i++)
             if (c.isReachable(g, 5, i)) 
                Console.WriteLine("The path from 1 to " + i + " is reachable");
            else Console.WriteLine("The path from 1 to " + i + " is not reachable");
            c.ArticulationPoint(g2);
            Console.WriteLine();

            Euler e = new Euler();
             if (e.isEulerianCycleUndirected(g)) 
                Console.WriteLine("It is Eulerian cycle");
            else Console.WriteLine("It is not eyulerian cycle");
            Console.WriteLine();

            Console.ReadLine();

        }

        static Graph makeGraph()
        {
            Graph g = new Graph(10);
            g.AddEdgeDirected(0, 1);
            g.AddEdgeDirected(0, 3);
            g.AddEdgeDirected(1, 2);
            g.AddEdgeDirected(1, 5);
            g.AddEdgeDirected(2, 8);
            g.AddEdgeDirected(3, 2);
            g.AddEdgeDirected(3, 4);
            g.AddEdgeDirected(4, 9);
            g.AddEdgeDirected(5, 8);
            g.AddEdgeDirected(6, 7);
            g.AddEdgeDirected(8, 6);
            g.AddEdgeDirected(9, 8);
            return g;
        }

        static Graph makeWeightedGraph()
        {
            Graph g = new Graph(10);
            g.AddEdgeUnDirected(0, 1);
            g.AddEdgeUnDirected(0, 3);
            g.AddEdgeUnDirected(1, 2);
            g.AddEdgeUnDirected(1, 5);
            g.AddEdgeUnDirected(2, 8);
            g.AddEdgeUnDirected(3, 2);
            g.AddEdgeUnDirected(3, 4);
            g.AddEdgeUnDirected(4, 9);
            g.AddEdgeUnDirected(5, 8);
            g.AddEdgeUnDirected(6, 7);
            g.AddEdgeUnDirected(8, 6);
            g.AddEdgeUnDirected(9, 8);
            return g;
        }


    }

   

   
}
