using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace B20_Ex02
{
    internal class InputManager
    {
        private const int k_MaxBoardSize = 6;
        private const int k_MinBoardSize = 4;

        public static string GetPlayerName(int i_PlayerNum)
        {
            string playerName = string.Empty;
            bool isValid = false;
            while (!isValid)
            {
                System.Console.WriteLine("Hello Player " + i_PlayerNum + "! please enter your name:");
                playerName = Console.ReadLine();

                // The players can choose any name they want.
                if (playerName != null && playerName.Length >= 1)
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again");
                    continue;
                }
            }
            
            return playerName;
        }

        public static string GetGameMode()
        {
            Console.WriteLine("Enter 1 if you want to play vs the computer, or 2 if you want to play vs another player");
            string gameMode = Console.ReadLine();

            while (!int.TryParse(gameMode, out int gameModeInt) || ((gameModeInt != 1) && (gameModeInt != 2)))
            {
                Console.WriteLine("You can only enter 1 or 2, try again please:");
                gameMode = Console.ReadLine();
            }

            return gameMode;
        }

        public static void GetBoardSize(ref int io_Rows, ref int io_Cols)
        {
            bool isValid = false;
            bool isHeightInput = true;
            uint boardHeight = 0;
            uint boardWidth = 0;
            Console.WriteLine("Please note, the size of the board must be even");
            while (!isValid)
            {
                 boardHeight = getSize(isHeightInput);
                 boardWidth = getSize(!isHeightInput);
                if ((boardHeight * boardWidth) % 2 != 0)
                {
                    Console.WriteLine("The size of the board is not even, please try again");
                    continue;
                }
                else
                {
                    isValid = true;
                }
            }

            io_Rows = (int)boardHeight;
            io_Cols = (int)boardWidth;
        }

        private static uint getSize(bool i_IsHeight)
        {
            bool isValid = false;
            uint size = 0;
            while (!isValid)
            {
                if (i_IsHeight)
                {
                    Console.WriteLine("Please enter height size for board between " + k_MinBoardSize + " and " + k_MaxBoardSize);
                }
                else
                {
                    Console.WriteLine("Please enter width size for board between " + k_MinBoardSize + " and " + k_MaxBoardSize);
                }

                string sizeInput = Console.ReadLine();
                if (!uint.TryParse(sizeInput, out size))
                {
                    Console.WriteLine("Please enter a valid number");
                    continue;
                }
                else if (size < k_MinBoardSize || size > k_MaxBoardSize)
                {
                    Console.WriteLine("Please enter a number between " + k_MinBoardSize + " and " + k_MaxBoardSize);
                    continue;
                }

                isValid = true;
            }

            return size;
        }

        public static BoardSquare GetPlayerTurn(Board i_Board, Player i_CurrentPlayer)
        {
            bool isValid = false;
            string userInput;
            char userRowChar;
            char userColChar;
            int userRowInt = 0;
            int userColInt = 0;
            BoardSquare playerTurn;

            while (!isValid)
            {
                Console.WriteLine(i_CurrentPlayer.Name + "'s turn");
                Console.WriteLine("Choose a hidden square from the board");
                Console.WriteLine("Enter Q to exit the game");
                userInput = Console.ReadLine();

                if (userInput.Equals("Q"))
                {
                    Console.WriteLine("Goodbye");
                    System.Threading.Thread.Sleep(500);
                    Environment.Exit(0);
                }
                else if (userInput.Length != 2)
                {
                    Console.WriteLine("Input must be 2 characters long. Please use the format: ColumnLetterRowNumber");
                    continue;
                }

                userColChar = userInput[0];
                userRowChar = userInput[1];
                if (!char.IsDigit(userRowChar))
                {
                    Console.WriteLine("Row Number invalid");
                    continue;
                }

                if (!char.IsUpper(userColChar))
                {
                    Console.WriteLine("Column Letter invalid");
                    continue;
                }

                userRowInt = (int)(userRowChar - '1');
                if (userRowInt < 0 || userRowInt >= i_Board.RowNumber)
                {
                    Console.WriteLine("Row number out of bounds");
                    continue;
                }
                
                userColInt = (int)(userColChar - 'A');
                if (userColInt < 0 || userColInt >= i_Board.ColNumber)
                {
                    Console.WriteLine("Column number out of bounds");
                    continue;
                }

                playerTurn = i_Board.BoardAsMatrix[userRowInt, userColInt];
                if (playerTurn.IsFlipped)
                {
                    Console.WriteLine("This square is already taken");
                    continue;
                }

                isValid = true;
            }

            playerTurn = i_Board.BoardAsMatrix[userRowInt, userColInt];

            return playerTurn;
        }

        public static bool GetUserEndgame()
        {
            string userInput;

            Console.WriteLine("Enter Y if you wish to play another game. Enter any other key to exit");
            userInput = Console.ReadLine();

            return userInput.Equals("Y");
        }
    }
}