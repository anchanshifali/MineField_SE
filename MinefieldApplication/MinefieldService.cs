using Minefield.Interfaces;

namespace Minefield
{
    public class MinefieldService
    {
        private readonly IDisplayService _displayService;
        private readonly IMinefieldMovement _minefieldMovementService;
        private readonly IMinefieldBoard _minefieldBoard;
        public bool[,] board;

        public MinefieldService(IDisplayService displayService, IMinefieldMovement minefieldMovement, IMinefieldBoard minefieldBoard)
        {
            _displayService = displayService;
            _minefieldMovementService = minefieldMovement;
            _minefieldBoard = minefieldBoard;
            // Create board with mines
            board = _minefieldBoard.board;
        }
        public int RunAsync(int rows, int cols, int numberOfLives, int numberOfMines)
        {
            int finalScore = 0;
            int livesLeft = numberOfLives;
            try
            {                
                _displayService.InitialDisplayGrid(rows, cols);
                // Use user input to navigate through mines
                (finalScore, livesLeft) = PlayMineField(rows, cols, numberOfLives);
                Console.WriteLine($"-----------------------------------------------------");
                Console.WriteLine($"Final Score: {finalScore}. Lives left: {livesLeft}");
                Console.WriteLine($"-----------------------------------------------------");
            }
            catch { Console.WriteLine("Technical error!!"); }
            return finalScore;
        }

        /// <summary>
        /// Simulates a game of navigating through a minefield. The player starts at the bottom-right corner of the board,
        /// and the goal is to reach the top-right corner without stepping on a mine. The player is given a number of lives, 
        /// and each time a mine is triggered, a life is lost. The game continues until either the player wins by reaching the target 
        /// or loses all lives. The method tracks the number of moves and remaining lives throughout the game.
        /// </summary>
        /// <param name="rows">The number of rows in the minefield grid.</param>
        /// <param name="cols">The number of columns in the minefield grid.</param>
        /// <param name="numberOfLives">The number of lives the player starts with.</param>
        /// <returns>A tuple containing the total number of moves made and the remaining number of lives at the end of the game.</returns>
        public (int,int) PlayMineField(int rows, int cols, int numberOfLives)
        {
            int numberOfMoves = 0, currentRow = 0, currentCol = 0;
            bool isExplosion=false;
            bool hasWon=false;

            while (numberOfLives > 0 && !hasWon)
            {
                try
                {
                    // Use user input to navigate through mines
                    _displayService.Display(numberOfLives, currentRow, currentCol, numberOfMoves);
                    Console.WriteLine("Make a move");
                    isExplosion = false;
                    _minefieldMovementService.Movement(ref currentRow, ref currentCol, rows, cols);
                    numberOfMoves++;
                    if (board[currentRow, currentCol])
                    {
                        numberOfLives--;
                        isExplosion = true;
                        Console.WriteLine("***Explosion***");
                    }
                    _displayService.DisplayGrid(rows, cols, (currentRow, currentCol), isExplosion);
                    if (numberOfLives == 0)
                    {
                        Console.WriteLine($"---------------------------");
                        Console.WriteLine("Better luck next game :)");
                        Console.WriteLine($"---------------------------");
                    }
                    if (currentCol + 1 == cols && currentRow + 1 == rows)
                    {
                        hasWon = true;
                        _displayService.Display(numberOfLives, currentRow, currentCol, numberOfMoves);
                        Console.WriteLine($"---------------------------");
                        Console.WriteLine("Congratulations!!!");
                        Console.WriteLine($"---------------------------");
                    }
                }
                catch
                {
                    Console.WriteLine("Invalid move");
                }
            }
            return (numberOfMoves, numberOfLives);
        }
    }
}
