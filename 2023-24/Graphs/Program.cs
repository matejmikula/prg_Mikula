using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    using System;
    using System.Collections.Generic;

    class UndirectedGraph
    {
        private Dictionary<int, List<int>> graph;
        private int currentVertex;

        public UndirectedGraph()
        {
            graph = new Dictionary<int, List<int>>();
            currentVertex = -1; // No current vertex initially
        }

        public void AddVertex(int vertex)
        {
            if (!graph.ContainsKey(vertex))
            {
                graph[vertex] = new List<int>();
            }
        }


        public void DisplayGraph()
        {
            foreach (var vertex in graph)
            {
                Console.Write($"{vertex.Key}: ");
                Console.WriteLine(string.Join(", ", vertex.Value));
            }
        }

        public void MoveToVertex(int vertex)
        {
            if (graph.ContainsKey(vertex))
            {
                currentVertex = vertex;
                Console.WriteLine($"Moved to vertex {vertex}");
            }
            else
            {
                Console.WriteLine($"Error: Vertex {vertex} does not exist!");
            }
        }

        public void DisplayCurrentVertex()
        {
            if (currentVertex != -1)
            {
                Console.WriteLine($"Current Vertex: {currentVertex}");
            }
            else
            {
                Console.WriteLine("No current vertex selected.");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("enter one of these settings (for seing the number of vertexes chose option: display");
            UndirectedGraph graph = new UndirectedGraph();

            graph.AddVertex(1);
            graph.AddVertex(2);
            graph.AddVertex(3);
            graph.AddVertex(4);

            while (true)
            {
                Console.WriteLine("\nCommands: 'move <vertex>', 'display', 'exit'");
                string input = Console.ReadLine();

                if (input.StartsWith("move"))
                {
                    int vertex;
                    if (int.TryParse(input.Split(' ')[1], out vertex))
                    {
                        graph.MoveToVertex(vertex);
                    }
                    else
                    {
                        Console.WriteLine("Invalid vertex format. Please use 'move <vertex>'.");
                    }
                }
                else if (input == "display")
                {
                    graph.DisplayCurrentVertex();
                    graph.DisplayGraph();
                }
                else if (input == "exit")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid command.");
                }
            }
        }
    }
}