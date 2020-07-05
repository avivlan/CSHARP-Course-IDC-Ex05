using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B20_Ex02
{
  internal class Board
    {
        private BoardSquare[,] m_BoardMatrix;
        private int m_Rows;
        private int m_Cols;

        public Board(int i_NumOfRows, int i_NumOfCols)
        {
            this.m_BoardMatrix = new BoardSquare[i_NumOfRows, i_NumOfCols];
            m_Rows = i_NumOfRows;
            m_Cols = i_NumOfCols;
            populateBoard();
        }

        private void populateBoard()
        {
            char[] randomLetters = shuffleArray(this.m_BoardMatrix.Length);
            int arrayCounter = 0;
            
            // put a letter inside every square in our board
            for (int i = 0; i < m_BoardMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < m_BoardMatrix.GetLength(1); j++)
                {
                    m_BoardMatrix[i, j] = new BoardSquare(randomLetters[arrayCounter], i, j); // add first letter from random letter array
                    arrayCounter += 1;
                }
            }
        }

        private char[] shuffleArray(int length)
        {
            char[] randomLetters = new char[length];
            int letterCounter = 0;

            // create the array
            for (int i = 0; i < randomLetters.Length; i += 2)
            {
                randomLetters[i] = (char)('A' + letterCounter);
                randomLetters[i + 1] = (char)('A' + letterCounter);
                letterCounter += 1;
            }

            Random randGenerator = new Random();

            // shuffle our array for random letter placements
            for (int i = 0; i < randomLetters.Length / 2; i++)
            {
                int randomNum = randGenerator.Next(i, randomLetters.Length);
                char temp = randomLetters[randomNum];
                randomLetters[randomNum] = randomLetters[i];
                randomLetters[i] = temp;
            }

            return randomLetters;
        }

        public void PrintBoard()
        {
            StringBuilder boardString = new StringBuilder();
            string newLine = Environment.NewLine;
            StringBuilder Columns = new StringBuilder();
            BoardSquare currentSquare;

            for (int col = 0; col < m_BoardMatrix.GetLength(1); col++)
            {
               Columns.Append("    " + (char)(col + 'A') + " ");
            }

            boardString.Append(Columns);
            boardString.Append(newLine);
            boardString.Append(lineBorder(Columns.Length));
            boardString.Append(newLine);
            for (int row = 0; row < m_BoardMatrix.GetLength(0); row++)
            {
                int rowNumber = row + 1;
                boardString.Append(rowNumber.ToString() + '|');
                for (int col = 0; col < m_BoardMatrix.GetLength(1); col++)
                {
                    currentSquare = m_BoardMatrix[row, col];
                    if (currentSquare.IsFlipped)
                    {
                        boardString.Append("  " + currentSquare.letter + "  |");
                    }
                    else
                    {
                        boardString.Append("  " + "   |");
                    }
                } 
                
                boardString.Append(newLine);
                boardString.Append(lineBorder(Columns.Length));
                boardString.Append(newLine);
            }

            Console.WriteLine(boardString.ToString());
        }

        private string lineBorder(int length)
        {
            StringBuilder seperator = new StringBuilder();
            for (int i = 0; i <= length + 1; i++)
            {
                seperator.Append("=");
            }

            return seperator.ToString();
        }

        public int RowNumber
        {
            get
            {
                return this.m_Rows;
            }
        }

        public int ColNumber
        {
            get
            {
                return this.m_Cols;
            }
        }

        public BoardSquare[,] BoardAsMatrix
        {
            get
            {
                return this.m_BoardMatrix;
            }
        }
    }
}
