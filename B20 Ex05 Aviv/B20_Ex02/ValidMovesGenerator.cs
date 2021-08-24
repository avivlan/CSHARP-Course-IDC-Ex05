using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B20_Ex02
{
    internal class ValidMovesGenerator
    {
        private Board m_CurrentBoard;
        private List<BoardSquare> m_ValidMoves;

        public ValidMovesGenerator(Board i_CurrentBoard)
        {
            this.m_CurrentBoard = i_CurrentBoard;
            BoardSquare currentSquare;
            BoardSquare[,] currentBoardAsArray = m_CurrentBoard.BoardAsMatrix;
            m_ValidMoves = new List<BoardSquare>(currentBoardAsArray.Length);
            foreach (BoardSquare squareIterator in currentBoardAsArray)
            {
                currentSquare = squareIterator;
                if (!currentSquare.IsFlipped)
                {
                    validMoves.Add(currentSquare);
                }
            }  
        }

        public List<BoardSquare> validMoves
        {
            get
            {
                return this.m_ValidMoves;
            }
        }
    }
}
