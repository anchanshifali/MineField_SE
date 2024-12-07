using Minefield.Interfaces;

namespace Minefield
{
    public class DisplayService: IDisplayService
    {
        private static DisplayService instance;
        private string[,] grid;

        private static readonly object lockObject = new object();

        private DisplayService()
        {
        }

        public static DisplayService Instance
        {
            get
            {
                // Double-check locking to ensure thread safety
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        if (instance == null)
                        {
                            instance = new DisplayService();
                        }
                    }
                }
                return instance;
            }
        }

        /// <summary>
        /// Initilize the grid with the required number of rows and column and position if the user shown as 'U'
        /// </summary>
        /// <param name="totalRows">The total number of rows in the board.</param>
        /// <param name="totalCols">The total number of columns in the board.</param>
        public void InitialDisplayGrid(int totalRows, int totalCols)
        {
            // Initialize the grid with '.' to represent empty spaces
            grid = new string[totalRows, totalCols];

            for (int i = 0; i < totalRows; i++)
            {
                for (int j = 0; j < totalCols; j++)
                {
                    grid[i, j] = ".";
                }
            }
            grid[0, 0] = "U";

            // Display the grid
            for (int i = totalRows - 1; i >= 0; i--)
            {
                for (int j = 0; j < totalCols; j++)
                {
                    Console.Write(grid[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Display the grid with user position 'U', explosion 'X' and route '*'
        /// </summary>
        /// <param name="totalRows">The total number of rows in the board.</param>
        /// <param name="totalCols">The total number of columns in the board.</param>
        /// <param name="userPosition">user corrent possition</param>
        /// <param name="isExplosion">boolean value to indicate explosion</param>
        public void DisplayGrid(int totalRows, int totalCols, (int userRow, int userCol) userPosition, bool isExplosion)
        {
            for (int i = totalRows - 1; i >= 0; i--)
            {
                for (int j = 0; j < totalCols; j++)
                {
                    if (string.Compare(grid[i, j], "U", true) == 0)
                        grid[i, j] = "*";
                    if (isExplosion)
                        grid[userPosition.userRow, userPosition.userCol] = "X";
                    else
                        grid[userPosition.userRow, userPosition.userCol] = "U";

                    Console.Write(grid[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public void Display(int numberOfLives, int currentRow, int currentCol, int numberOfMoves)
        {
            Console.WriteLine($"------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"Number of lives left: {numberOfLives}\t Number of moves made: {numberOfMoves}\t Your current position [{currentRow + 1}, {currentCol + 1}]");
            Console.WriteLine($"------------------------------------------------------------------------------------------------------------");
        }
    }
}

