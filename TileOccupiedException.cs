using System;

namespace TresEnRaya
{
    internal class TileOccupiedException : Exception
    {
        private Board.TileStates tileStates;

        public TileOccupiedException()
        {
        }

        public TileOccupiedException(string message) : base(message)
        {
        }

        public TileOccupiedException(Board.TileStates tileStates)
        {
            this.tileStates = tileStates;
        }

        public TileOccupiedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}