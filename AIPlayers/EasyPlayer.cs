using System;
using System.Collections.Generic;

namespace TicTacToeLibrary
{
    /// <summary>
    /// Executes a random move among possible moves
    /// </summary>
    public class EasyPlayer : IPlayer
    {
        public int Move(Game game)
        {
            var possibleMoves = new List<int>();
            for (int i = 1; i < game.Board.Length; i++)
            {
                if (game.Board[i] == Symbols.Empty)
                    possibleMoves.Add(i);
            }
            if (possibleMoves.Count == 0)
                throw new IndexOutOfRangeException("There are no possible moves to make.");
            int randomIndex = new Random().Next(possibleMoves.Count);
            return possibleMoves[randomIndex];
        }
    }
}
