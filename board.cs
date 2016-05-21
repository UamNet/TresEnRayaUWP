using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TresEnRaya
{
    class Board
    {
        private TileStates[,] boardData = new TileStates[3, 3];
        public enum TileStates { Empty = 0, Player = 1, Enemy = 2 };

        public Board()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    setTile(i, j, TileStates.Empty);
                }
            }
        }

        public void clear()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    boardData[i,j] = TileStates.Empty;
                }
            }
        }

        public void setTile(int x, int y, TileStates value)
        {
            if (boardData[x, y] != TileStates.Empty)
            {
                throw new TileOccupiedException(boardData[x, y]);
            }
            else
            {
                boardData[x, y] = value;
            }
        }

        public void setTile(string name, TileStates value)
        {
            switch (name)
            {
                case "c0_0":
                    this.setTile(0, 0, value);
                    break;
                case "c0_1":
                    this.setTile(0, 1, value);
                    break;
                case "c0_2":
                    this.setTile(0, 2, value);
                    break;
                case "c1_0":
                    this.setTile(1, 0, value);
                    break;
                case "c1_1":
                    this.setTile(1, 1, value);
                    break;
                case "c1_2":
                    this.setTile(1, 2, value);
                    break;
                case "c2_0":
                    this.setTile(2, 0, value);
                    break;
                case "c2_1":
                    this.setTile(2, 1, value);
                    break;
                case "c2_2":
                    this.setTile(2, 2, value);
                    break;

            }
        }

        public TileStates getTile(int x, int y)
        {
            return boardData[x, y];
        }

        public TileStates evaluateBoard()
        {
            for (int i = 0; i < 3; i++) {
                if (boardData[i,0]== boardData[i, 1] && boardData[i, 0] == boardData[i, 2] && boardData[i, 0]!=TileStates.Empty)
                {
                    return boardData[i, 0];
                }
            }
            for (int i = 0; i < 3; i++)
            {
                if (boardData[0,i] == boardData[ 1,i] && boardData[0,i] == boardData[2,i] && boardData[0,i] != TileStates.Empty)
                {
                    return boardData[0,i];
                }
            }
            if (boardData[0, 0] == boardData[1, 1] && boardData[0, 0] == boardData[2, 2] && boardData[0, 0] != TileStates.Empty)
            {
                return boardData[0, 0];
            }
            if (boardData[0, 2] == boardData[1, 1] && boardData[0, 2] == boardData[2, 0] && boardData[0, 2] != TileStates.Empty)
            {
                return boardData[0, 2];
            }
            return TileStates.Empty;
        }

    }
}
