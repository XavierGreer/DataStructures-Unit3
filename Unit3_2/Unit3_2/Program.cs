using System;
using System.Collections.Generic;
using System.Linq;

namespace Unit3_2
{
    class Graph
    {
        int vertex;
        public List<int[]> list;
        char[] name = { 'a', 'b', 'c', 'd', 'e', 'z' };

        public Graph(int v)
        {
            this.vertex = v;
            this.list = new List<int[]>();
        }
        
        void Print(int[] dist)
        {
            Console.WriteLine("   Array Displayed\n-----------------------");
            Console.WriteLine(string.Join(Environment.NewLine, this.list.Select(x => string.Join(" , ", x))));
            Console.WriteLine("-----------------------");
            
            Console.Write("Vertex    Distance from vertex 'a'\n");
            for (int i = 0; i < this.vertex; i++)
                Console.Write(name[i] + " \t\t " + dist[i] + "\n");
             
            Console.WriteLine("The Shortest distance between 'a' and 'z' is " + dist[this.vertex - 1]);
        }

        public void Add(int[] x)
        {
            this.vertex++;
            int[] y = x;
            this.list.Add(y);
        }

        int minDistance(int[] dist, bool[] sptSet)
        {
            int min = int.MaxValue, min_index = -1;

            for (int v = 0; v < vertex; v++)
                if (sptSet[v] == false && dist[v] <= min)
                {
                    min = dist[v];
                    min_index = v;
                }
            return min_index;
        }

        void dijkstra(int[,] graph, int src)
        {
            int[] dist = new int[vertex]; 
            bool[] sptSet = new bool[vertex];

            for (int i = 0; i < vertex; i++)
            {
                dist[i] = int.MaxValue;
                sptSet[i] = false;
            }

            dist[src] = 0;

            for (int count = 0; count < vertex - 1; count++)
            {
                int u = minDistance(dist, sptSet);
               
                sptSet[u] = true;

                for (int v = 0; v < vertex; v++)
                    if (!sptSet[v] && graph[u,v] != 0 &&
                     dist[u] != int.MaxValue && dist[u] + graph[u, v] < dist[v])
                        dist[v] = dist[u] + graph[u, v];
            }
            this.Print(dist);
        }

        
        public static void Main()
        {
            Graph graph = new Graph(0);

            //graph.list.Add(new int[] { 1, 2, 3, 4, 5, 6 });

            graph.Add(new int[] { 0, 4, 2, 0, 0, 0 });
            graph.Add(new int[] { 4, 0, 1, 5, 0, 0 });
            graph.Add(new int[] { 2, 1, 0, 8, 10, 0 });
            graph.Add(new int[] { 0, 5, 8, 0, 2, 6 });
            graph.Add(new int[] { 0, 0, 10, 2, 0, 5 });
            graph.Add(new int[] { 0, 0, 0, 6, 5, 0 });

            static T[,] CreateRectangularArray<T>(IList<T[]> arrays)
            {
                int minorLength = arrays[0].Length;
                T[,] ret = new T[arrays.Count, minorLength];
                for (int i = 0; i < arrays.Count; i++)
                {
                    var array = arrays[i];
                    if (array.Length != minorLength)
                    {
                        throw new ArgumentException
                            ("All arrays must be the same length");
                    }
                    for (int j = 0; j < minorLength; j++)
                    {
                        ret[i, j] = array[j];
                    }
                }
                return ret;
            }
            graph.dijkstra(CreateRectangularArray(graph.list), 0);
        }
    }
}