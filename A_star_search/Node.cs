using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_star_search
{
    class Node
    {
        public int Key { get; private set; }
        public int X_pos { get; set; }
        public int Y_pos { get; set; }
        public int[] Connections { get; set; }
        public bool isWalkable { get; set; }
        public double F { get; set; }
        public Node(int key, int x, int y)
        {
            Key = key;
            X_pos = x;
            Y_pos = y;
            isWalkable = false;
        }
        public void AllConnections(int[] conn)
        {
            Connections = conn;
        }
        public Node parent;
    }
}
