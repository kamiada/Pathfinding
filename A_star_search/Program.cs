using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace A_star_search
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "40213297_A*search algorithm implementation with use of C# Lists";
            List<Node> nodes = new List<Node>();
            string input = Console.ReadLine();
            int[] caves = FindAndReadFile(input);
            int N = caves[0];
            int numbCoord = N * 2;


            SetCoordinatesAndConnections(caves, N, numbCoord, nodes);
            Algorithm.Breadth_First_Search(nodes);
            //Algorithm.Test(nodes);
            //Algorithm.DijkstraSearch(nodes);
            //PrintDebugConnections(nodes);
            Console.ReadKey();
        }

        private static int[] FindAndReadFile(string filepath)
        {
            string line = File.ReadAllText(filepath);
            string[] data = Regex.Split(line, ",");
            return Array.ConvertAll(data, int.Parse);
        }




        private static void PrintDebugConnections(List<Node> nodes)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                Console.Write(string.Join(" ", nodes[i].Connections));
                Console.Write("\n");
            }
            Console.WriteLine();

            for (int i = 0; i < nodes.Count; i++)
            {
                Console.Write("Node " + nodes[i].Key + ", index " + i + ": " + nodes[i].X_pos + "," + nodes[i].Y_pos+ " Connections: " + string.Join(" ", nodes[i].Connections));
                Console.Write("\n");
            }
        }


        private static void SetCoordinatesAndConnections(int[]caves, int N, int numbCoord, List<Node> nodes)
        {
            N = caves[0];
            numbCoord = N * 2;
            int no = 1;
            int[] connections;
            for (int i = 1; i < numbCoord; i += 2)
            {
                Node node = new Node(no, caves[i], caves[i + 1]);
                nodes.Add(node);
                no++;
            }
            int numbConn = numbCoord + 1;



            //for (int i = 0; i < N; i++)
            //{
            //    connections = new int[N];
            //    Array.Copy(caves, numbConn, connections, 0, N);
            //    nodes[i].AllConnections(connections);
            //    numbConn += N;
            //}

            int first = 1;
            int second = 1;
            for (int i = 1; i < N*N; i++)
            {
                if(first > N)
                {
                    first = 1;
                    second++;
                }
                if(caves[numbConn] == 1)
                {
                    if (first != second)
                    {
                        nodes[first - 1].Connections.Add(second);
                    }
                }
                first++;
                numbConn++;
            }

            //List<Node> temp = new List<Node>(nodes);
            //for (int i = 0; i < N; i++)
            //{
            //    for (int j = 0; j < N; j++)
            //    {
            //        nodes[j].Connections[i] = temp[i].Connections[j];
            //    }
            //}
        }
    }
}
