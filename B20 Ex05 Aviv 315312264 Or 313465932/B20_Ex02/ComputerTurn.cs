using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace B20_Ex02
{
    public class ComputerTurn
    {
       private static Random s_RandomMove = new Random();
       private static List<BoardSquare> s_GameMemory;
       private static int[] s_CountLetters;

        public static void BuildMemory(Board i_Board)
        {
            s_CountLetters = new int[i_Board.ColNumber * i_Board.RowNumber / 2];
            s_GameMemory = new List<BoardSquare>();
        }

        public static void UpdateMemory(BoardSquare i_SquareChoice)
        {
            if (!s_GameMemory.Contains(i_SquareChoice))
            {
                s_GameMemory.Add(i_SquareChoice);
                int letterIndex = i_SquareChoice.letter - 'A';
                s_CountLetters[letterIndex] += 1;
            }
        }

        public static List<BoardSquare> MakeComputerTurn(List<BoardSquare> i_ValidMoves, Board io_GameBoard)
        {
            List<BoardSquare> currentTurn = new List<BoardSquare>();
            BoardSquare squareChoice1, squareChoice2;
            bool isSmartChoice = s_RandomMove.Next(2) == 1; // 50% chance for smart choice or random choice to make it fair

            // make a smart choice
            if (isSmartChoice) 
            {
                List<BoardSquare> listOfSquaresWithSameLetter = hiddenSquaresWithSameLetter(i_ValidMoves);

                // did not find squares with same letter in memory
                if (listOfSquaresWithSameLetter.Count == 0)
                {
                    squareChoice1 = getRandomSquareChoice(i_ValidMoves, io_GameBoard);
                    squareChoice2 = getSecondChoice(i_ValidMoves, squareChoice1, io_GameBoard);
                    currentTurn.Add(squareChoice1);
                    currentTurn.Add(squareChoice2);
                }

                // found squares with same letter in memory
                else
                {
                    currentTurn = listOfSquaresWithSameLetter;
                    insertComputerChoicesToBoardGame(currentTurn, io_GameBoard, i_ValidMoves);
                }
            }

            // to make the game fair
            else
            {
                squareChoice1 = getRandomSquareChoice(i_ValidMoves, io_GameBoard);
                squareChoice2 = getRandomSquareChoice(i_ValidMoves, io_GameBoard);
                currentTurn.Add(squareChoice1);
                currentTurn.Add(squareChoice2);
            }

            return currentTurn;
        }

        private static List<BoardSquare> hiddenSquaresWithSameLetter(List<BoardSquare> i_ValidMoves)
        {
            // Look for squares in memory with same letter that are still hidden
            List<BoardSquare> squaresList = new List<BoardSquare>();
            for (int i = 0; i < s_CountLetters.Length; i++)
            {
                if (s_CountLetters[i] == 2)
                {
                    char SquareLetter = (char)('A' + i);
                    BoardSquare square = lookForLetterInMemory(SquareLetter);
                    if (!square.IsFlipped)
                    {
                        squaresList = squaresOfLetter(square.letter);
                        i_ValidMoves.Remove(squaresList[0]);
                        i_ValidMoves.Remove(squaresList[1]);
                        break;
                    }
                }
            }

            return squaresList;
        }

        private static BoardSquare lookForLetterInMemory(char i_Letter)
        {
            BoardSquare letterSquare = null;

            for (int i = 0; i < s_GameMemory.Count; i++)
            {
                BoardSquare currentSquare = s_GameMemory[i];
                if (currentSquare.letter == i_Letter)
                {
                    letterSquare = currentSquare;
                    break;
                }
            }

            return letterSquare;
        }

        private static List<BoardSquare> squaresOfLetter(char i_Letter)
        {
            List<BoardSquare> squaresList = new List<BoardSquare>();

            for (int i = 0; i < s_GameMemory.Count; i++)
            {
                BoardSquare currentSquare = s_GameMemory[i];
                if (currentSquare.letter == i_Letter)
                {
                    squaresList.Add(currentSquare);
                }
            }

            return squaresList;
        }

        private static BoardSquare getRandomSquareChoice(List<BoardSquare> i_ValidMoves, Board io_GameBoard)
        {
            BoardSquare squareChoice;

            if (i_ValidMoves.Count == 1)
            {
                squareChoice = i_ValidMoves.First<BoardSquare>();
            }
            else
            {
                squareChoice = i_ValidMoves[s_RandomMove.Next(0, i_ValidMoves.Count)];
            }

            UpdateMemory(squareChoice);
            i_ValidMoves.Remove(squareChoice);
            io_GameBoard.BoardAsMatrix[squareChoice.RowIndex, squareChoice.ColumnIndex].FlipSquare();

            return squareChoice;
        }

        private static BoardSquare getSecondChoice(List<BoardSquare> i_ValidMoves, BoardSquare i_PreviousChoice, Board io_GameBoard)
        {
            // initaliize square choice as random
            BoardSquare squareChoice = getRandomSquareChoice(i_ValidMoves, io_GameBoard); 
            char prevLetter = i_PreviousChoice.letter;

            foreach (BoardSquare squareIterator in s_GameMemory)
            {
                // if we know who the matching square is
                if (squareIterator.letter.Equals(prevLetter) && !squareIterator.Equals(i_PreviousChoice)) 
                {
                    i_ValidMoves.Add(squareChoice);
                    io_GameBoard.BoardAsMatrix[squareChoice.RowIndex, squareChoice.ColumnIndex].HideSquare();

                    // updating square choice to match square
                    squareChoice = squareIterator;
                    i_ValidMoves.Remove(squareChoice);
                    io_GameBoard.BoardAsMatrix[squareChoice.RowIndex, squareChoice.ColumnIndex].FlipSquare();
                    break; // exit loop once found
                }
            }

            UpdateMemory(squareChoice);

            return squareChoice;
        }

        private static void insertComputerChoicesToBoardGame(List<BoardSquare> i_ComputerTurn, Board io_GameBoard, List<BoardSquare> i_ValidMoves)
        {
            // also deletes computer choices of valid moves
            foreach (BoardSquare squareChoice in i_ComputerTurn)
            {
                i_ValidMoves.Remove(squareChoice);
                io_GameBoard.BoardAsMatrix[squareChoice.RowIndex, squareChoice.ColumnIndex].FlipSquare();
            }
        }
    }
}