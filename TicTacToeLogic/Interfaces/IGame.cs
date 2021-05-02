using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeLogic.Interfaces
{
    public interface IGame
    {
        int[,] GetBoard();
        bool UpdateSquare(int x, int y);
        void SetNextTurn();
        bool DidLastMoveWin();
        int GetCurrentPlayer();
    }
}
