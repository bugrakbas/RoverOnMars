using RoverOnMars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoverOnMars.Commands
{
    //The MoveCommand class is responsible for moving the rover
    public class MoveCommand : ICommand
    {
        public void Execute(Rover rover)
        {
            rover.Move();
        }
    }
}
