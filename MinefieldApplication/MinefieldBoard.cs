using Minefield.Interfaces;

namespace Minefield
{
    public class MinefieldBoard : IMinefieldBoard
    {
        private readonly int _rows;
        private readonly int _cols;
        private readonly double _numberOfMines;
        private bool[,] _board;

        public MinefieldBoard(int rows, int cols, double numberOfMines)
        {
            _rows = rows;
            _cols = cols;
            _numberOfMines = numberOfMines;
            board = CreateMinefieldBoard();
        }

        public bool[,] board { get { return _board; } private set => _board = value; }

        private bool[,] CreateMinefieldBoard()
        {
            try
            {
                return CreateMines(_rows, _cols, _numberOfMines);
            }
            catch
            {
                Console.WriteLine($"{DateTime.UtcNow} Failed to create the board");
                throw;
            }
        }
        /// <summary>
        /// Places the specified count of mines in random positions inside the board, excluding the top-right and bottom-left corners.
        /// </summary>
        /// <param name="totalRows">The total number of rows in the board.</param>
        /// <param name="totalCols">The total number of columns in the board.</param>
        /// <param name="maxMine">The maximum number of mines to be placed on the board.</param>
        /// <returns>A 2D boolean array representing the board, where true indicates a mine at the corresponding position.</returns>
        private bool[,] CreateMines(int totalRows, int totalCols, double maxMine)
        {
            bool[,] board = new bool[totalRows, totalCols];
            int mine = 0;
            int rows = totalRows - 1;
            int cols = totalCols - 1;
            Random random = new Random();
            List<(int row, int col)> availablePositions = new List<(int, int)>();

            try
            {
                for (int i = 0; i < totalRows - 1; i++)
                {
                    for (int j = 0; j < totalCols - 1; j++)
                    {
                        if (i == 0 && j == 0) { continue; }
                        if (i == totalRows - 1 && j == totalCols - 1) { continue; }
                        availablePositions.Add((i, j));
                    }
                }
                // Shuffle the list of available positions.
                availablePositions = availablePositions.OrderBy(x => random.Next()).ToList();

                // Place mines until we reach the maximum allowed mines.
                foreach (var position in availablePositions.Take((int)maxMine))
                {
                    board[position.row, position.col] = true;
                    mine++;
                    if (mine == maxMine) break;
                }
            }
            catch { throw; }
            return board;
        }
    }
}