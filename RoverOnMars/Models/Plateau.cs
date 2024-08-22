using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoverOnMars.Models
{
    public class Plateau
    {
        public Coordinate UpperRight { get; private set; }
        public Plateau (int maxX, int maxY)
        {
            UpperRight = new Coordinate(maxX, maxY); //Determines the upper right corner points of the rectangle plateau
        }
        //Determines if the rover is within the plateau bounds
        public bool IsWithinBounds(Coordinate coordinate)
        {
            return coordinate.X >= 0 && coordinate.X <= UpperRight.X && coordinate.Y >= 0 && coordinate.Y <= UpperRight.Y;
        }
    }
}
