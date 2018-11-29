using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_star_search
{
    public class Node
    {
        public int Key { get; private set; }
        public int X_pos { get; set; }
        public int Y_pos { get; set; }
        public List<int> Connections = new List<int>();
        public bool isWalkable { get; set; }
        public double F { get; set; }
        public Node(int key, int x, int y)
        {
            Key = key;
            X_pos = x;
            Y_pos = y;
            isWalkable = false;
        }

      
    }
}
