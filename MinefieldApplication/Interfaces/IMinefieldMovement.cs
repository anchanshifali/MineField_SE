using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minefield.Interfaces
{
    public interface IMinefieldMovement
    {
        void Movement(ref int currentRow, ref int currentCol, int maxRow, int maxCol);
    }
}
