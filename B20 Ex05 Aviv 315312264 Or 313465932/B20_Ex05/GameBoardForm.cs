using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using B20_Ex02;

namespace B20_Ex05
{
    public partial class GameBoardForm : Form
    {
        private readonly string r_FirstPlayerName;
        private readonly string r_SecondPlayerName;
        private readonly int r_BoardRows;
        private readonly int r_BoardCols;
        private readonly GameManager r_GameManager;
        private readonly Color r_FirstPlayerColor = Color.FromArgb(192, 255, 192);
        private readonly Color r_SecondPlayerColor = Color.FromArgb(191, 191, 255);
        private GameButton m_PreviousButtonClicked;



        public GameBoardForm(string i_FirstPlayerName, string i_SecondPlayerName, int i_Rows, int i_Cols, bool i_IsComputer)
        {
            r_FirstPlayerName = i_FirstPlayerName;
            r_SecondPlayerName = i_SecondPlayerName;
            r_BoardRows = i_Rows;
            r_BoardCols = i_Cols;
            r_GameManager = new GameManager(i_FirstPlayerName, i_SecondPlayerName, i_Rows, i_Cols, i_IsComputer);
            
            initComponent();
        }

        private void initComponent()
        {
            this.Text = "Memory Game";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(((r_BoardRows + 2) * 100) + 15, (r_BoardCols + 2) * 100);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            this.currentPlayerLabel = new Label();
            this.currentPlayerLabel.AutoSize = true;
            this.currentPlayerLabel.Top = this.Bottom - 180;
            this.currentPlayerLabel.Left = 12;
            this.currentPlayerLabel.Text = "Current Player: " + r_GameManager.CurrentPlayer.Name;
            this.currentPlayerLabel.BackColor = r_GameManager.CurrentPlayer.PlayerNum == 1 ? r_FirstPlayerColor : r_SecondPlayerColor;

            this.firstPlayerLabel = new Label();
            this.firstPlayerLabel.BackColor = r_FirstPlayerColor;
            this.firstPlayerLabel.AutoSize = true;
            this.firstPlayerLabel.Top = this.Bottom - 150;
            this.firstPlayerLabel.Left = 12;
            this.firstPlayerLabel.Text = r_FirstPlayerName + ": " + r_GameManager.FirstPlayer.Score;
        
            this.secondPlayerLabel = new Label();
            this.secondPlayerLabel.BackColor = r_SecondPlayerColor;
            this.secondPlayerLabel.AutoSize = true;
            this.secondPlayerLabel.Top =this.Bottom - 120;
            this.secondPlayerLabel.Left = 12;
            this.secondPlayerLabel.Text = r_SecondPlayerName + ": " + r_GameManager.SecondPlayer.Score;

            this.Controls.Add(this.currentPlayerLabel);
            this.Controls.Add(this.firstPlayerLabel);
            this.Controls.Add(this.secondPlayerLabel);
            GameButton[,] buttonMatrix = new GameButton[r_BoardRows, r_BoardCols];
            for (int i = 0; i < r_BoardRows; i++)
            {
                for (int j = 0; j < r_BoardCols; j++)
                {
                    buttonMatrix[i, j] = new GameButton(r_GameManager.GameBoard.BoardAsMatrix[i, j]);
                    buttonMatrix[i, j].Name = r_GameManager.GameBoard.BoardAsMatrix[i, j].GetSquareID();
                    buttonMatrix[i, j].Size = new Size(80, 80);
                    buttonMatrix[i, j].Top =(i + 1) * 85;
                    buttonMatrix[i, j].Left = (j + 1) * 85;
                    this.Controls.Add(buttonMatrix[i, j]);
                    buttonMatrix[i, j].Click += new EventHandler(gameButtonClick);
                }
            }
        }

        private void gameButtonClick(object sender, EventArgs e)
        {
            GameButton buttonClicked = sender as GameButton;
            if (buttonClicked.Enabled)
            {
                if (m_PreviousButtonClicked == null && !buttonClicked.BoardSquare.IsFlipped)
                {
                    buttonClicked.BoardSquare.FlipSquare();
                    buttonClicked.ShowText();
                    buttonClicked.BackColor = r_GameManager.CurrentPlayer.PlayerNum == 1 ? r_FirstPlayerColor : r_SecondPlayerColor;
                    m_PreviousButtonClicked = buttonClicked;
                }
                else if (m_PreviousButtonClicked != null && !buttonClicked.BoardSquare.IsFlipped)
                {
                    buttonClicked.BoardSquare.FlipSquare();
                    buttonClicked.ShowText();
                    buttonClicked.BackColor = r_GameManager.CurrentPlayer.PlayerNum == 1 ? r_FirstPlayerColor : r_SecondPlayerColor;
                    buttonClicked.Refresh();
                    disableEnableControls();
                    makeMove(buttonClicked, m_PreviousButtonClicked);
                }
            }
        }

        private void makeMove(GameButton i_ButtonClicked, GameButton i_PreviousButtonClicked)
        {
            if (!r_GameManager.IsGameOver)
            {
                System.Threading.Thread.Sleep(1000);
                currentPlayerLabel.Text = "Current Player: " + r_GameManager.CurrentPlayer.Name;
                currentPlayerLabel.BackColor = r_GameManager.CurrentPlayer.PlayerNum == 1 ? r_FirstPlayerColor : r_SecondPlayerColor;
                if (r_GameManager.PlayHumanTurn(r_GameManager.CurrentPlayer, i_ButtonClicked.BoardSquare, i_PreviousButtonClicked.BoardSquare))
                {
                    if (r_GameManager.CurrentPlayer.PlayerNum == 1)
                    {
                        firstPlayerLabel.Text = r_FirstPlayerName + ": " + r_GameManager.FirstPlayer.Score;
                    }
                    else
                    {
                        secondPlayerLabel.Text = r_SecondPlayerName + ": " + r_GameManager.SecondPlayer.Score;
                    }

                    m_PreviousButtonClicked = null;
                }
                else
                {
                    currentPlayerLabel.Text = "Current Player: " + r_GameManager.CurrentPlayer.Name;
                    currentPlayerLabel.BackColor = r_GameManager.CurrentPlayer.PlayerNum == 1 ? r_FirstPlayerColor : r_SecondPlayerColor;
                    hideCards(i_ButtonClicked, i_PreviousButtonClicked);
                    m_PreviousButtonClicked = null;
                }

                makeComputerMove();
                disableEnableControls();
            }
            else
            {
                gameOver();
            }
        }

        private void makeComputerMove()
        {
            disableEnableControls();
            while (r_GameManager.CurrentPlayer.IsComputer && !r_GameManager.IsGameOver)
            {
                System.Threading.Thread.Sleep(1000);
                currentPlayerLabel.Text = "Current Player: Computer";
                currentPlayerLabel.BackColor = r_SecondPlayerColor;
                currentPlayerLabel.Refresh();
                List<BoardSquare> computerTurn = ComputerTurn.MakeComputerTurn(r_GameManager.ValidMoves, r_GameManager.GameBoard);
                GameButton firstChoice = getButtonBySquare(computerTurn[0].GetSquareID());
                GameButton secondChoice = getButtonBySquare(computerTurn[1].GetSquareID());
                revealCards(firstChoice, secondChoice);
                if (r_GameManager.PlayComputerTurn(firstChoice.BoardSquare, secondChoice.BoardSquare))
                {
                    secondPlayerLabel.Text = "Computer: " + r_GameManager.SecondPlayer.Score;
                    secondPlayerLabel.Refresh();
                }
                else
                {
                    currentPlayerLabel.Text = "Current Player: " + r_GameManager.CurrentPlayer.Name;
                    currentPlayerLabel.BackColor = r_GameManager.CurrentPlayer.PlayerNum == 1 ? r_FirstPlayerColor : r_SecondPlayerColor;
                    hideCards(firstChoice, secondChoice);
                }
            }

            Application.DoEvents(); // fix button clicking when disabled
            disableEnableControls();
        }

        private void hideCards(GameButton i_firstCard, GameButton i_secondCard)
        {
            i_firstCard.BoardSquare.HideSquare();
            i_secondCard.BoardSquare.HideSquare();
            i_firstCard.HideText();
            i_secondCard.HideText();
            i_firstCard.BackColor = Button.DefaultBackColor;
            i_secondCard.BackColor = Button.DefaultBackColor;
        }

        private void revealCards(GameButton i_FirstChoice, GameButton i_SecondChoice)
        {
            i_FirstChoice.BoardSquare.FlipSquare();
            i_FirstChoice.ShowText();
            i_FirstChoice.BackColor = r_SecondPlayerColor;
            i_FirstChoice.Refresh();
            System.Threading.Thread.Sleep(1000);
            i_SecondChoice.BoardSquare.FlipSquare();
            i_SecondChoice.ShowText();
            i_SecondChoice.BackColor = r_SecondPlayerColor;
            i_SecondChoice.Refresh();
            System.Threading.Thread.Sleep(1000);
        }

        private GameButton getButtonBySquare(string i_SquareID)
        {
            GameButton computerChoice = null;
            foreach (Control control in Controls)
            {
                if (control is GameButton)
                {
                    if ((control as GameButton).Name == i_SquareID)
                    {
                        computerChoice = control as GameButton;
                        break;
                    }
                }
            }

            return computerChoice;
        }

        private void gameOver()
        {
            MessageBox.Show("Game Over");
        }

        private void disableEnableControls()
        {
            foreach (Control control in Controls)
            {
                if (control is GameButton)
                    control.Enabled = !control.Enabled;
            }
        }

        private void GameBoardForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
