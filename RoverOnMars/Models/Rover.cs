using RoverOnMars.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoverOnMars.Models
{
    public class Rover
    {
        private readonly Plateau _plateau;
        public Coordinate Coordinate { get; private set; }
        public string roverPosition { get { return Coordinate.ToString() + " " + Direction; } }
        public char Direction { get; private set; }
        private static readonly char[] Directions = { 'N', 'E', 'S', 'W' };

        public Rover(Plateau plateau,int x,int y,char direction)
        {
            _plateau = plateau;
            Coordinate = new Coordinate(x, y);
            Direction = direction;
        }
        //The ExecuteCommands method is responsible for executing the commands
        public void ExecuteCommands(List<ICommand> commands)
        {
            foreach (var command in commands)
            {
                command.Execute(this);

                if (!_plateau.IsWithinBounds(Coordinate))
                {
                    throw new InvalidOperationException("Rover has moved out of the plateau bounds.");
                }
            }
        }
        public void Move()
        {
            int x = 0, y = 0;
            switch (Direction)
            {
                case 'N':
                    y = 1;
                    break;
                case 'E':
                    x = 1;
                    break;
                case 'S':
                    y = -1;
                    break;
                case 'W':
                    x = -1;
                    break;
            }
            Coordinate.Move(x, y);
        }
        public void Rotate(char direction)
        {
            int index = Array.IndexOf(Directions, Direction);
            if (direction == 'L')
            {
                index = (index - 1 + Directions.Length) % Directions.Length;
            }
            else
            {
                index = (index + 1) % Directions.Length;
            }
            Direction = Directions[index];
        }

    }
}
