using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_star_search
{
    class Calculations
    {

        public static double Formula(double h, Node current, Node destination)
        {
            double g = Euclidean(current, destination);
            double f = g + h;
            return f;
        }

        public static double Euclidean(Node current, Node neighbour)
        {
            double x = neighbour.X_pos - current.X_pos;
            double y = neighbour.Y_pos - current.Y_pos;
            double distance_xy = Math.Sqrt(x * x) + Math.Sqrt(y * y);
            return distance_xy;
        }

        public static Node CalculateTheSmallest(List<Node> nodes)
        {
            Node current = nodes[0];
            foreach (Node lowest in nodes)
            {
                if (lowest.F < current.F)
                {
                    current = lowest;
                }
            }
            return current;
        }

    }
}
