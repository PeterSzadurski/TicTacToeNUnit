using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeLogic.Interfaces;

namespace TicTacToeLogic.Classes
{
    public class Game : IGame
    {
        private readonly int[,] _GameArray;
        private int _CurrentPlayer;
        private int _RecentValidX;
        private int _RecentValidY;

        public Game()
        {
            _GameArray = new int[3, 3];
            _CurrentPlayer = 1;
            _RecentValidX = 0;
            _RecentValidY = 0;
        }

        public int[,] GetBoard()
        {
            return _GameArray;
        }

        public void SetNextTurn()
        {
            _CurrentPlayer *= -1;
        }

        public bool UpdateSquare(int x, int y)
        {
            bool result = false;
            if (_GameArray[x, y] == 0)
            {
                _GameArray[x, y] = _CurrentPlayer;
                _RecentValidY = y;
                _RecentValidX = x;
                result = true;
            }
            return result;
        }

        public int GetCurrentPlayer()
        {
            return _CurrentPlayer;
        }

        public bool DidLastMoveWin()
        {
            // Horizontal Check
            if (
                _GameArray[0, _RecentValidY] == _CurrentPlayer &&
                _GameArray[1, _RecentValidY] == _CurrentPlayer &&
                _GameArray[2, _RecentValidY] == _CurrentPlayer
                )
            {
                return true;
            }

            // Vertical Check
            if (    
                _GameArray[_RecentValidX, 0] == _CurrentPlayer &&
                _GameArray[_RecentValidX, 1] == _CurrentPlayer &&
                _GameArray[_RecentValidX, 2] == _CurrentPlayer
                )
            {
                return true;
            }

            // Check Top Lef Diagonal
            if (
                _GameArray[0, 0] == _CurrentPlayer &&
                _GameArray[1, 1] == _CurrentPlayer &&
                _GameArray[2, 2] == _CurrentPlayer
                )
            {
                return true;
            }

            if (
                _GameArray[0, 2] == _CurrentPlayer &&
                _GameArray[1, 1] == _CurrentPlayer &&
                _GameArray[2, 0] == _CurrentPlayer
                )
            {
                return true;
            }

            return false;
        }
    }
}

