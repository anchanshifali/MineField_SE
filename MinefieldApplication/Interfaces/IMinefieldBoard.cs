using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minefield.Interfaces
{
    public interface IMinefieldBoard
    {
        bool[,] board {  get; }
        //bool[,] CreateMinefieldBoard();
    }
}
