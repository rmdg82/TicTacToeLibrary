using System;
using System.Collections.Generic;

namespace TicTacToeLibrary
{
    public class MediumPlayer : IPlayer
    {
        /// <summary>
        /// Algorithm used:
        /// <list type="number">
        /// <item>
        /// <description>Check if current player can win in 1 move;</description>
        /// </item>
        /// <item>
        /// <description>Check if the opponent can win in 1 move and block it;</description>
        /// </item>
        /// <item>
        /// <description>Pick a random corner cell;</description>
        /// </item>
        /// <item>
        /// <description>Pick the central cell if available;</description>
        /// </item>
        /// <item>
        /// <description>Pick another random cell.</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        public int Move(Game game)
        {
            // 1- Make a copy of the game using a cloning constructor 
            var copiedGame = new Game(game);

            // 2- Save the playingSymbol ('X' or 'O') and the oppositeSymbol
            var playingSymbol = copiedGame.GetPlayingSymbol();
            var oppositeSymbol = (playingSymbol == Symbols.X) ? Symbols.O : Symbols.X;

            // 3- For all available moves, place the playingSymbol and CheckWinner. Then reset checked cells to empty.
            for (int i = 1; i < copiedGame.Board.Length; i++)
            {
                if (copiedGame.Board[i] == Symbols.Empty)
                {
                    copiedGame.Board[i] = playingSymbol;
                    if (copiedGame.CheckWinner(playingSymbol))
                        return i;
                    else
                        copiedGame.Board[i] = Symbols.Empty;
                }
            }

            // 4- For all available moves, switch playingSymbol and CheckWinner. Idem
            for (int i = 1; i < copiedGame.Board.Length; i++)
            {
                if (copiedGame.Board[i] == Symbols.Empty)
                {
                    copiedGame.Board[i] = oppositeSymbol;
                    if (copiedGame.CheckWinner(oppositeSymbol))
                        return i;
                    else
                        copiedGame.Board[i] = Symbols.Empty;
                }
            }

            // 5- If available pick a random corner cell
            var cornerAvailableMoves = new List<int>();
            var corners = new List<int>() { 1, 3, 7, 9 };
            for (int i = 1; i < copiedGame.Board.Length; i++)
            {
                if (copiedGame.Board[i] == Symbols.Empty && corners.Contains(i))
                    cornerAvailableMoves.Add(i);
            }
            if (cornerAvailableMoves.Count > 0)
            {
                int randomIndex = new Random().Next(cornerAvailableMoves.Count);
                return cornerAvailableMoves[randomIndex];
            }

            // 6- If available pick the central cell
            if (copiedGame.Board[5] != Symbols.Empty)
                return 5;

            // 7- Pick a random cell among available/not corners/ not central
            var remainingAvailableMoves = new List<int>();
            var notCorners = new List<int>() { 2, 4, 6, 8 };
            for (int i = 1; i < copiedGame.Board.Length; i++)
            {
                if (copiedGame.Board[i] == Symbols.Empty && notCorners.Contains(i))
                    remainingAvailableMoves.Add(i);
            }
            if (remainingAvailableMoves.Count > 0)
            {
                int randomIndex = new Random().Next(remainingAvailableMoves.Count);
                return remainingAvailableMoves[randomIndex];
            }
            return -1;
        }
    }
}
