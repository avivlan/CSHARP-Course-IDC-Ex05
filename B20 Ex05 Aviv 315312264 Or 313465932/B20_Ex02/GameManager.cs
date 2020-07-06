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
        private Player m_CurrentPlayer;
        BoardSquare m_CurrentMove;
        BoardSquare m_PreviousMove;
        private List<BoardSquare> m_ValidMoves;
        private bool m_IsGameOver;

        public GameManager(string i_FirstPlayerName, string i_SecondPlayerName, int o_Rows, int o_Cols, bool isComputer)
        {
            m_PlayerNum = 1;
            this.m_PlayerOne = new Player(i_FirstPlayerName, false, 1);
            switch (isComputer)
            {
                case true:
                    {
                        m_PlayerTwo = new Player("Computer", isComputer, 2);
                        break;
                    }

                case false:
                    {
                        m_PlayerNum = 2;
                        m_PlayerTwo = new Player(i_SecondPlayerName, isComputer, 2);
                        break;
                    } 
            }

            startGame(o_Rows, o_Cols);
        }

        private void startGame(int i_Rows, int i_Cols)
        {
            m_BoardRows = i_Rows;
            m_BoardCols = i_Cols;
            m_Board = new Board(i_Rows, i_Cols);
            m_ValidMoves = new ValidMovesGenerator(m_Board).validMoves;
            ComputerTurn.BuildMemory(m_Board);
            m_CurrentPlayer = m_PlayerOne;
            m_IsGameOver = false;
            bool isPlayerOneTurn = true;
            bool isAnotherGame;
        }

        public void RestartGame()
        {
            m_PlayerOne.ResetScore();
            m_PlayerTwo.ResetScore();
            startGame(m_BoardRows, m_BoardCols);
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

        private BoardSquare swapMoves(BoardSquare i_CurrentMove, List<BoardSquare> io_ValidMoves)
        {
            BoardSquare previousMove;
            m_Board.BoardAsMatrix[i_CurrentMove.RowIndex, i_CurrentMove.ColumnIndex].FlipSquare();
            io_ValidMoves.Remove(i_CurrentMove);
            
            m_Board.PrintBoard();
            previousMove = i_CurrentMove;
            return previousMove;
        }

        public void NoMatch(BoardSquare i_CurrentMove, BoardSquare i_PreviousMove, List<BoardSquare> i_ValidMoves)
        {
            //System.Threading.Thread.Sleep();
            m_Board.BoardAsMatrix[i_CurrentMove.RowIndex, i_CurrentMove.ColumnIndex].HideSquare();
            m_Board.BoardAsMatrix[i_PreviousMove.RowIndex, i_PreviousMove.ColumnIndex].HideSquare();
            i_ValidMoves.Add(i_CurrentMove);
            i_ValidMoves.Add(i_PreviousMove);
          
            m_Board.PrintBoard();
        }

        public bool CheckSuccess(BoardSquare i_Curr, BoardSquare i_Prev)
        {
            return i_Curr.letter.Equals(i_Prev.letter) && !i_Curr.Equals(i_Prev);
        }

        public bool PlayComputerTurn(BoardSquare i_ComputerFirstMove, BoardSquare i_ComputerSecondMove)
        {
            bool isSuccess = false;
            if (m_ValidMoves.Count == 0)
            {
                m_IsGameOver = true;
            }

            if (!m_IsGameOver)
            {
                m_Board.PrintBoard();
                if (CheckSuccess(i_ComputerFirstMove, i_ComputerSecondMove))
                {
                    m_PlayerTwo.AddScore();
                    isSuccess = true;
                }
                else
                {
                    NoMatch(i_ComputerFirstMove, i_ComputerSecondMove, m_ValidMoves);
                    m_CurrentPlayer = m_PlayerOne;
                    isSuccess = false;
                }
            }
            return isSuccess;
        }

        public bool PlayHumanTurn(Player i_CurrentPlayer, BoardSquare i_CurrentMove, BoardSquare i_PreviousMove)
        {
            bool isSuccess = false;
            if (m_ValidMoves.Count == 0)
            {
                m_IsGameOver = true;
            }

            if (!m_IsGameOver)
            {
                ComputerTurn.UpdateMemory(i_CurrentMove);
                ComputerTurn.UpdateMemory(i_PreviousMove);
                m_ValidMoves.Remove(i_CurrentMove);
                m_ValidMoves.Remove(i_PreviousMove);
                if (CheckSuccess(i_CurrentMove, i_PreviousMove))
                {
                    i_CurrentPlayer.AddScore();
                    isSuccess = true;
                    m_CurrentPlayer = i_CurrentPlayer;
                }
                else
                {
                    NoMatch(i_CurrentMove, i_PreviousMove, m_ValidMoves);
                    isSuccess = false;
                    m_CurrentPlayer = i_CurrentPlayer == m_PlayerOne ? m_PlayerTwo : m_PlayerOne;
                }
            }

            return isSuccess;
        }

        public Player FirstPlayer
        {
            get
            {
                return m_PlayerOne;
            }
        }

        public Player SecondPlayer
        {
            get
            {
                return m_PlayerTwo;
            }
        }

        public Player CurrentPlayer
        {
           get
            {
                return m_CurrentPlayer;
            }
        }

        public Board GameBoard
        {
            get
            {
                return m_Board;
            }
        }

        public BoardSquare CurrentMove
        {
            get
            {
                return m_CurrentMove;
            }

            set
            {
                m_CurrentMove = value;
            }
        }

        public BoardSquare PreviousMove
        {
            get
            {
                return m_PreviousMove;
            }

            set
            {
                m_PreviousMove = value;
            }
        }
        
        public bool IsGameOver
        {
            get
            {
                return m_IsGameOver;
            }
        }

        public List<BoardSquare> ValidMoves
        {
            get
            {
                return m_ValidMoves;
            }
        }
    }
}
