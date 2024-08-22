using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoverOnMars.Models
{
    public class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Move (int x, int y)
        {
            X += x;
            Y += y;
        }
        public override string ToString()
        {
            return $"{X} {Y}";
        }
    }
}
