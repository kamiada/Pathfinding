using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_star_search
{
    class Algorithm
    {
        public static void SearchAlgorithm(List<Node> Locations)
        {
            var shortestPath = new List<Node>();
            Node start = Locations[0];
            Node destination = Locations[Locations.Count() - 1];
            //BuildThePath(shortestPath, destination);
            shortestPath.Reverse();
        }

        private void BuildThePath(List<Node> path, Node current, Node goal)
        {

        }

        public static void DijkstraSearch(List<Node> caves)
        {
            List<Node> OpenList = new List<Node>();
            List<Node> ClosedList = new List<Node>();

            List<double> costSoFar = new List<double>();
            List<Node> cameFrom = new List<Node>();


            Node start = caves[0];
            Node goal = caves[caves.Count() - 1];
            OpenList.Add(start);
            costSoFar.Add(start.F);

            if (OpenList.Count > 0)
            {
                Node current = Calculations.CalculateTheSmallest(OpenList);
                //WIN CASE
                if (current == goal)
                {
                    //print the path
                }
                OpenList.Remove(current);
                ClosedList.Add(current);
            }

        }



        public static IEnumerable<int> total_path = new List<int>();


        public static void A_star_Search(List<Node>caves)
        {
            Dictionary<int, Node> path = new Dictionary<int, Node>();
            List<int> answer = new List<int>();
            Node start = caves[0];
            Node test = caves[1];
            Node destination = caves[caves.Count() - 1];
            var OpenList = new Queue<Node>();
            OpenList.Enqueue(start);
            var visited = new HashSet<Node>();
            visited.Add(start);
            while (OpenList.Count > 0)
            {
                var current = OpenList.Dequeue();
                answer.Add(current.Key);
                //Console.WriteLine("Visiting {0}", current.Key);
                if (current == destination)
                {
                    foreach(Node n in visited)
                    { Console.WriteLine(n.Key); }
                }


                for (int i = 0; i < current.Connections.Count(); i++)
                {
                    int tunnel = current.Connections[i];

                    if (tunnel == 1)
                    {
                        Node neighbour = caves[i];
                        if (!visited.Contains(neighbour))
                        {
                            OpenList.Enqueue(neighbour);
                            visited.Add(neighbour);
                            answer.Add(current.Key);
                        }
                    }

                    

                }
            }
        }

        public static void Breadth_First_Search(List<Node> caves)
        {
            Node start = caves[0];
            var OpenList = new Queue<Node>();
            OpenList.Enqueue(start);
            var visited = new HashSet<Node>();
            visited.Add(start);

            while (OpenList.Count > 0)
            {
                var current = OpenList.Dequeue();
                Console.WriteLine("Visiting {0}", current.Key);
                for (int i = 0; i < current.Connections.Count(); i++)
                {
                    int tunnel = current.Connections[i];

                    if (tunnel == 1)
                    {
                        Node neighbour = caves[i];
                        if (!visited.Contains(neighbour))
                        {
                            OpenList.Enqueue(neighbour);
                            visited.Add(neighbour);
                        }
                    }
                }
            }
        }
    }
}
