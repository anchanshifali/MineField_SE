// See https://aka.ms/new-console-template for more information
using Minefield;
using Minefield.Interfaces;

Console.WriteLine("Minefield");

int rows = 8, cols = 8, lives = 5, mines = 15;

//Console.WriteLine("Enter number of rows greater than 2 (default 8):");
//rows = Convert.ToInt32(Console.ReadLine());
//Console.WriteLine("Enter number of columns greater than 2 (default 8):");
//cols = Convert.ToInt32(Console.ReadLine());
//Console.WriteLine("Enter number of lifes (default 5):");
//lives = Convert.ToInt32(Console.ReadLine());
//Console.WriteLine("Enter number of mines");
//mines = Convert.ToInt32(Console.ReadLine());

//if (rows <= 2) { rows = 8; Console.WriteLine("Default value of 8 is taken as input is invalid"); }
//if (cols <= 2) { cols = 8; Console.WriteLine("Default value of 8 is taken as input is invalid"); }
//if (lives < 1) { lives = 5; Console.WriteLine("Default value of 5 is taken as input is invalid"); }

Console.WriteLine("Instructions");
Console.WriteLine("Press U to move up.");
Console.WriteLine("Press D to move down.");
Console.WriteLine("Press L to move left.");
Console.WriteLine("Press R to move right.");

IDisplayService displayService = DisplayService.Instance;
IMinefieldMovement minefieldMovement = new MinefieldMovement();
IMinefieldBoard minefieldBoard = new MinefieldBoard(rows, cols, mines);
_ = new MinefieldService(displayService, minefieldMovement, minefieldBoard).RunAsync(rows, cols, lives, mines);