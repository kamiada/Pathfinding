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
            //List<int> caves = FindAndReadFile(input).OfType<int>().ToList();
            int[] caves = FindAndReadFile(input);
            int N = caves[0];
            int cave_numb = 1;
            int numbCoord = N * 2;


            SetCoordinatesAndConnections(caves, N, numbCoord, nodes);
            Algorithm.BF_Search(nodes);
            //Algorithm.DijkstraSearch(nodes);
            //PrintDebugConnections(nodes);
            Console.ReadKey();
        }



        //private void Astar(List<Node> nodes)
        //{
        //    Node Start = nodes[0];
        //    Node destination = nodes[nodes.Count() - 1];
        //    var OpenList = new List<Node>();

        //    OpenList.Add(Start);


        //    while(OpenList.Count>0)
        //    {
        //        Node current;
        //    }
           
        //}
        private static void PrintDebugConnections(List<Node>nodes)
        {
            Console.Write("\n\n");
            //TO PRINT CONNETIONS
            for (int i = 0; i < nodes.Count; i++)
            {
                Console.Write(string.Join(" ", nodes[i].Connections));
                Console.Write("\n");
            }
            Console.WriteLine();
        }

        private static int[] FindAndReadFile(string filepath)
        {
            string line = File.ReadAllText(filepath);
            string[] data = Regex.Split(line, ",");
            return Array.ConvertAll(data, int.Parse);
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
            for (int i = 0; i < N; i++)
            {
                connections = new int[N];
                Array.Copy(caves, numbConn, connections, 0, N);
                nodes[i].AllConnections(connections);
                numbConn += N;
            }
        }
    }
}