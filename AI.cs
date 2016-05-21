using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TresEnRaya
{
    class AI
    {
        Board gameBoard;
        public AI(Board gameBoard)
        {
            this.gameBoard = gameBoard;
        }

        public string nextMove()
        {
            int i=0, j=0, besti=0, bestj=0;
            for (i = 0; i < 3; i++)
            {
                for (j = 0; j < 3; j++)
                {
                    if (gameBoard.getTile(i, j) == Board.TileStates.Empty)
                    {
                        besti = i;
                        bestj = j;
                    }
                }
            }
            return "c" + besti.ToString() + "_" + bestj.ToString();
        }
    }
}
