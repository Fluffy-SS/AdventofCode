using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_Day3
{
    class Line
    {

        private List<int> positions = new List<int>();

        public Line(int x, int y, int z)
        {
            positions.Add(x);
            positions.Add(y);
            positions.Add(z);
        }

        public int Get(int pos)
        {
            return positions[pos];
        }
    }
}
