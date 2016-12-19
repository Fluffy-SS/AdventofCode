using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_Day3
{
    class Vec3
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Z { get; private set; }

        public Vec3(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}
