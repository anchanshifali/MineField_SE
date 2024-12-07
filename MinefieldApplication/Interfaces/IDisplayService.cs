using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minefield.Interfaces
{
    public interface IDisplayService
    {
        void InitialDisplayGrid(int totalRows, int totalCols);
        void DisplayGrid(int totalRows, int totalCols, (int userRow, int userCol) userPosition, bool isExplosion);
        void Display(int numberOfLives, int currentRow, int currentCol, int numberOfMoves);
    }
}
