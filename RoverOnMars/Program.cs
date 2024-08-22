using RoverOnMars.Commands;
using RoverOnMars.Models;

try
{
    Plateau plateau = InitializePlateau();
    List<Rover> rovers = InitializeRovers(plateau);
    List<string> roversList = new List<string>();

    foreach (var rover in rovers)
    {
        var roverString = rover.roverPosition; 
        rover.ExecuteCommands(ParseCommands(roverString));
        roversList.Add(roverString + " => " + rover.roverPosition);
    }
    roversList.ForEach(Console.WriteLine);
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred: {ex.Message}");
}

//Determines the upper right corner points of the rectangle plateau
static Plateau InitializePlateau()
{
    Console.WriteLine("Enter the upper-right coordinates of the plateau (e.g., '5 5'):");
    var plateauInput = Console.ReadLine().Split();

    int maxX = int.Parse(plateauInput[0]);
    int maxY = int.Parse(plateauInput[1]);

    return new Plateau(maxX, maxY);
}

//Determines the location of the robot and the direction it is facing
static List<Rover> InitializeRovers(Plateau plateau)
{
    List<Rover> rovers = new List<Rover>();

    while (true)
    {
        Console.WriteLine("Enter the initial position and direction of the rover (e.g., '1 2 N'):");
        var initialPosition = Console.ReadLine().Split();
        int x = int.Parse(initialPosition[0]);
        int y = int.Parse(initialPosition[1]);
        char direction = char.Parse(initialPosition[2]);

        Rover rover = new Rover(plateau, x, y, direction);
        rovers.Add(rover);

        Console.WriteLine("Do you want to add another rover? (y/n):");
        if (Console.ReadLine().ToLower() != "y")
        {
            break;
        }
    }

    return rovers;
}

//Parses the movement commands for the rover
static List<ICommand> ParseCommands(string rover)
{
    Console.WriteLine("Enter the movement commands for {0} (e.g., 'LMLMLMLMM'):", rover);
    string commandInput = Console.ReadLine();
    List<ICommand> commands = new List<ICommand>();

    foreach (char c in commandInput)
    {
        if (c == 'M')
        {
            commands.Add(new MoveCommand());
        }
        else if (c == 'L' || c == 'R')
        {
            commands.Add(new RotateCommand(c));
        }
    }

    return commands;
}