using Minefield.Interfaces;

namespace Minefield
{
    public class MinefieldMovement : IMinefieldMovement
    {
        /// <summary>
        /// Handles movement input and updates the current position based on the given direction (Up, Down, Left, Right).If an invalid movement is made (e.g., moving out of bounds), an exception is thrown.
        /// </summary>
        /// <param name="currentRow">The current row position, which will be updated after a valid move.</param>
        /// <param name="currentCol">The current column position, which will be updated after a valid move.</param>
        /// <param name="maxRow">The maximum row boundary for movement.</param>
        /// <param name="maxCol">The maximum column boundary for movement.</param>
        public void Movement(ref int currentRow, ref int currentCol, int maxRow, int maxCol)
        {
            int result = 0;
            char movement = Convert.ToChar(Console.ReadLine());
            switch (movement)
            {
                case 'U':
                case 'u':
                    result = MoveUp(currentRow, maxRow);
                    if (result < 0) throw new Exception("Invalid move");
                    else currentRow = result;
                    break;
                case 'D':
                case 'd':
                    result = MoveDown(currentRow, maxRow);
                    if (result < 0) throw new Exception("Invalid move");
                    else currentRow = result;
                    break;
                case 'L':
                case 'l':
                    result = MoveLeft(currentCol, maxCol);
                    if (result < 0) throw new Exception("Invalid move");
                    else currentCol = result;
                    break;
                case 'R':
                case 'r':
                    result = MoveRight(currentCol, maxCol);
                    if (result < 0) throw new Exception("Invalid move");
                    else currentCol = result;
                    break;
                default:
                    throw new Exception("Invalid move");
            }
        }
        private int MoveRight(int currentRow, int MaxRow)
        {
            if (currentRow == MaxRow) return -1;
            return ++currentRow;
        }

        private int MoveLeft(int currentRow, int MaxRow)
        {
            if (currentRow == 0) return -1;
            return --currentRow;
        }

        private int MoveUp(int currentCol, int MaxCol)
        {
            if (currentCol == MaxCol) return -1;
            return ++currentCol;
        }

        private int MoveDown(int currentCol, int MaxCol)
        {
            if (currentCol == 0) return -1;
            return --currentCol;
        }
    }
}
