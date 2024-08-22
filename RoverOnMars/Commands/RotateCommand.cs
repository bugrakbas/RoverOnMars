using RoverOnMars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RoverOnMars.Commands
{
    //The RotateCommand class is responsible for rotating the rover
    public class RotateCommand :ICommand
    {
        private readonly char _direction;
        
        public RotateCommand(char direction)
        {
            _direction = direction;
        }

        public void Execute(Rover rover)
        {
            rover.Rotate(_direction);
        }
    }
}
