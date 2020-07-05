using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B20_Ex02
{
  public class GameManager
    {
        private Player m_PlayerOne;
        private Player m_PlayerTwo;
        private string m_GameModeStr;
        private Board m_Board;
        private int m_BoardRows;
        private int m_BoardCols;
        private int m_PlayerNum;

        public GameManager(string i_FirstPlayerName, string i_SecondPlayerName, int o_Rows, int o_Cols, bool isComputer)
        {
            m_PlayerNum = 1;
            this.m_PlayerOne = new Player(i_FirstPlayerName, false);
            switch (isComputer)
            {
                case true:
                    {
                        m_PlayerTwo = new Player("Computer", isComputer);
                        break;
                    }

                case false:
                    {
                        m_PlayerNum = 2;
                        m_PlayerTwo = new Player(i_SecondPlayerName, isComputer);
                        break;
                    } 
            }

            startGame(o_Rows, o_Cols);
        }

        private void startGame(int i_Rows, int i_Cols)
        {
            //InputManager.GetBoardSize(ref m_BoardRows, ref m_BoardCols);
            m_Board = new Board(i_Rows, i_Cols);
            ComputerTurn.BuildMemory(m_Board);
            Player currentPlayer = m_PlayerOne;
            bool isGameOver = false;
            bool isPlayerOneTurn = true;
            bool isAnotherGame;
            //m_Board.PrintBoard();

            while (!isGameOver)
            {
                if (isPlayerOneTurn)
                {
                    currentPlayer = m_PlayerOne;
                    isPlayerOneTurn = false;
                    isGameOver = playerTurn(currentPlayer);
                }
                else
                {
                    currentPlayer = m_PlayerTwo;
                    isPlayerOneTurn = true;
                    isGameOver = playerTurn(currentPlayer);
                }
            }

            scoreScreen();
            isAnotherGame = InputManager.GetUserEndgame();
            if (isAnotherGame)
            {
                // reset player scores
                m_PlayerOne.ResetScore();
                m_PlayerTwo.ResetScore();
                startGame(i_Rows, i_Cols);
            }
            else
            {
                Console.WriteLine("Thank you for playing! Goodbye");
                System.Threading.Thread.Sleep(1500);
                Environment.Exit(0);
            }
        }

        private void scoreScreen()
        {
            Console.WriteLine(m_PlayerOne.Name + "'s score is: " + m_PlayerOne.Score);
            Console.WriteLine(m_PlayerTwo.Name + "'s score is: " + m_PlayerTwo.Score);
            if (m_PlayerOne.Score == m_PlayerTwo.Score)
            {
                Console.WriteLine("It's a tie!");
            }
            else if (m_PlayerOne.Score > m_PlayerTwo.Score)
            {
                Console.WriteLine(m_PlayerOne.Name + " Wins!");
            }
            else if (m_PlayerTwo.Score > m_PlayerOne.Score)
            {
                Console.WriteLine(m_PlayerTwo.Name + " Wins!");
            }
        }
        private bool playerTurn(Player i_currentPlayer)
        {
            BoardSquare currentMove;
            BoardSquare previousMove;
            bool isGameOver = false;
            List<BoardSquare> validMoves = new ValidMovesGenerator(m_Board).validMoves;
            if (validMoves.Count == 0)
            {
                isGameOver = true;
            }

            // computer turn
            if (i_currentPlayer.IsComputer && !isGameOver)
            {
                List<BoardSquare> computerTurn = ComputerTurn.MakeComputerTurn(validMoves, this.m_Board);
                
                m_Board.PrintBoard();
                if (checkSuccess(computerTurn[1], computerTurn[0]))
                {
                    Console.WriteLine("Computer's turn");
                    System.Threading.Thread.Sleep(1500);
                    i_currentPlayer.AddScore();
                    playerTurn(i_currentPlayer);
                }
                else
                {
                    Console.WriteLine("Computer's turn");
                    noMatch(computerTurn[1], computerTurn[0], validMoves);
                }
            }

            // human turn
            else if (!isGameOver) 
            {
                currentMove = InputManager.GetPlayerTurn(m_Board, i_currentPlayer);
                ComputerTurn.UpdateMemory(currentMove);
                previousMove = swapMoves(currentMove, validMoves);
                currentMove = InputManager.GetPlayerTurn(m_Board, i_currentPlayer);
                ComputerTurn.UpdateMemory(currentMove);
                m_Board.BoardAsMatrix[currentMove.RowIndex, currentMove.ColumnIndex].FlipSquare();
                validMoves.Remove(currentMove);
                
                m_Board.PrintBoard();
                if (checkSuccess(currentMove, previousMove))
                {
                    i_currentPlayer.AddScore();
                    playerTurn(i_currentPlayer);
                }
                else
                {
                    noMatch(currentMove, previousMove, validMoves);
                }
            }

            return isGameOver;
        }

        private BoardSquare swapMoves(BoardSquare i_CurrentMove, List<BoardSquare> io_ValidMoves)
        {
            BoardSquare previousMove;
            m_Board.BoardAsMatrix[i_CurrentMove.RowIndex, i_CurrentMove.ColumnIndex].FlipSquare();
            io_ValidMoves.Remove(i_CurrentMove);
            
            m_Board.PrintBoard();
            previousMove = i_CurrentMove;
            return previousMove;
        }

        private void noMatch(BoardSquare i_CurrentMove, BoardSquare i_PreviousMove, List<BoardSquare> i_ValidMoves)
        {
            System.Threading.Thread.Sleep(2000);
            m_Board.BoardAsMatrix[i_CurrentMove.RowIndex, i_CurrentMove.ColumnIndex].HideSquare();
            m_Board.BoardAsMatrix[i_PreviousMove.RowIndex, i_PreviousMove.ColumnIndex].HideSquare();
            i_ValidMoves.Add(i_CurrentMove);
            i_ValidMoves.Add(i_PreviousMove);
          
            m_Board.PrintBoard();
        }

        private bool checkSuccess(BoardSquare i_Curr, BoardSquare i_Prev)
        {
            return i_Curr.letter.Equals(i_Prev.letter);
        }
    }
}
