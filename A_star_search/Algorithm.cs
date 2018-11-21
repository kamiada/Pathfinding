using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_star_search
{
    class Algorithm
    {


        //public static void DijkstraSearch(List<Node> caves)
        //{
        //    List<Node> OpenList = new List<Node>();
        //    List<Node> ClosedList = new List<Node>();

        //    List<double> costSoFar = new List<double>();
        //    List<Node> cameFrom = new List<Node>();


        //    Node start = caves[0];
        //    Node goal = caves[caves.Count() - 1];
        //    OpenList.Add(start);
        //    costSoFar.Add(start.F);

        //    if (OpenList.Count > 0)
        //    {
        //        Node current = Calculations.CalculateTheSmallest(OpenList);
        //        //WIN CASE
        //        if (current == goal)
        //        {
        //            //print the path
        //        }
        //        OpenList.Remove(current);
        //        ClosedList.Add(current);
        //    }

        //}



        public static void Test(List<Node> caves)
        {
            Node start = caves[0];
            Node destination = caves[caves.Count() - 1];
            var OpenList = new Queue<Node>();
            OpenList.Enqueue(start);
            var visited = new HashSet<Node>();
            var Cost = new List<int>();
            visited.Add(start);

            while (OpenList.Count > 0)
            {
                var current = OpenList.Dequeue();
                if (current == destination)
                {
                    //foreach (Node n in visited)
                    //{ Console.WriteLine(n.Key); }
                }

                //Console.WriteLine("Visiting {0}", current.Key);
                Console.WriteLine("Node " + current.Key + ": " + current.X_pos + "," + current.Y_pos);
                for (int i = 1; i < current.Connections.Count(); i++)
                {
                    Node next = caves[i];
                    int tunnel = 1;
                    //int tunnel = next.Connections[i];
                    //int pos = Array.IndexOf(next.Connections, tunnel);
                    if (next.Connections[i]== 1)
                    {
                        //Node neighbour = caves[pos];
                        if (!visited.Contains(next))
                        {
                            OpenList.Enqueue(next);
                            visited.Add(next);
                        }
                    }
                }

            }
        }

        public static void Breadth_First_Search(List<Node> caves)
        {
            Node start = caves[0];
            var OpenList = new Queue<Node>();
            List<Node> path = new List<Node>();
            OpenList.Enqueue(start);
            var visited = new HashSet<Node>();
            visited.Add(start);
            Node destination = caves[caves.Count() - 1];
            while (OpenList.Count > 0)
            {
                var current = OpenList.Dequeue();

                if(current == destination)
                {
                    //foreach (Node n in visited)
                    //{ Console.WriteLine(n.Key); }
                }

                Console.WriteLine("Visiting {0}", current.Key);
                for (int i = 0; i < current.Connections.Count(); i++)
                {
                    int tunnel = current.Connections[i];

                    Node neighbour = caves[tunnel-1];
                    if (!visited.Contains(neighbour))
                    {
                        OpenList.Enqueue(neighbour);
                        visited.Add(neighbour);
                    }
                }
            }
        }


        public static void A_start(List<Node>caves)
        {
            Node start = caves[0];
            Node destination = caves[caves.Count() - 1];

            var OpenList = new Queue<Node>();
            var visited = new HashSet<Node>();
            var g_score = new List<double>();
            double h = 0;
            visited.Add(start);
            start.F = 0;
            g_score.Add(start.F);
            OpenList.Enqueue(start);

            while (OpenList.Count>0)
            {
                Node x = Calculations.CalculateTheSmallest(OpenList);
                if(x == destination)
                {
                    //coś tam coś, powinno być, ale tym się zajmę później
                }
                x = OpenList.Dequeue();
                visited.Add(x);

                foreach(Node y in OpenList)
                {
                    if(visited.Contains(y))
                    {
                        continue;
                    }

                    //g_score.Add(Calculations.Formula(h, x, destination));
                    g_score.Add(Calculations.Euclidean(x, y));
                    if (!OpenList.Contains(y))
                    {
                        OpenList.Enqueue(y);
                    }



                }
            }
        }

        public static void Path(List<Node> CameFrom, Node current)
        {
            if(CameFrom.Contains(current))
            {

            }
        }

    }
}
