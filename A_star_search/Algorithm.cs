using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_star_search
{
    class Algorithm
    {
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
                    foreach (Node n in visited)
                    { Console.WriteLine(n.Key); }
                }
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


        public static void Dijkstra(List<Node>caves)
        {
            Node start = caves[0];
            Node destination = caves[caves.Count() - 1];

            var OpenList = new Queue<Node>();
            var visited = new HashSet<Node>();
            var g_score = new List<double>();

            Dictionary<int, Node> cameFrom = new Dictionary<int, Node>();

            double h = 0;
            visited.Add(start);
            start.F = Calculations.Euclidean(start, destination);
            g_score.Add(start.F);
            OpenList.Enqueue(start);

            while (OpenList.Count>0)
            {

                Node x = Calculations.Priority(OpenList);
                if(x == destination)
                {
                    Path(x, destination, cameFrom);
                    break;
                }
                x = OpenList.Dequeue();
                visited.Add(x);
                for (int i = 0; i < x.Connections.Count(); i++)
                {
                    int tunnel = x.Connections[i];
                    Node neighbour = caves[tunnel - 1];

                    if (visited.Contains(neighbour))
                    {
                        continue;
                    }
                    double new_cost = Calculations.Formula(x.F, x, neighbour);
                    if(neighbour.F == 0 || neighbour.F > new_cost)
                    {
                        h = Calculations.Formula(h, x, destination);
                        OpenList.Enqueue(neighbour);
                        neighbour.F = Calculations.Formula(h, x, destination);
                        visited.Add(neighbour);
                    }
                    cameFrom.Add(neighbour.Key, x);
                }
            }
        }



        public static void Path(Node current, Node destination, Dictionary<int, Node> cameFrom)
        {
            Console.WriteLine(destination.Key);
            while (cameFrom.ContainsKey(current.Key))
            {
                List<Node> path = new List<Node>();
                current = cameFrom[current.Key];
                path.Add(current);
                foreach (Node n in path)
                {
                    Console.WriteLine(path.Last().Key);

                }
            }
        }
    }
}
