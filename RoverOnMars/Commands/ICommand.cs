using RoverOnMars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoverOnMars.Commands
{
    public interface ICommand
    {
        void Execute(Rover rover);
    }
}
