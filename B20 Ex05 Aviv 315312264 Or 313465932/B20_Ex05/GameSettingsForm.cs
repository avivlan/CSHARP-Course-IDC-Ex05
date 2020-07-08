using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace B20_Ex05
{
    public partial class GameSettingsForm : Form
    {
        private static readonly string[] sr_BoardSizes = {"4 x 4", "4 x 5", "4 x 6", "5 x 4", "5 x 6", "6 x 4",
                                                          "6 x 5", "6 x 6"};
        private static int s_SizeIndex = 0;

        public GameSettingsForm()
        {
            InitializeComponent();
        }

        private void firstPlayerText_TextChanged(object sender, EventArgs e)
        {

        }

        private void isComputerButton_Click(object sender, EventArgs e)
        {

            secondPlayerText.Enabled = !secondPlayerText.Enabled;
            if (secondPlayerText.Enabled)
            {
                secondPlayerText.Text = string.Empty;
                isComputerButton.Text = "Against computer";
            }
            else
            {
                secondPlayerText.Text = "-computer-";
                isComputerButton.Text = "Against a Friend";
            }
        }

        private void boardSizeButton_Click(object sender, EventArgs e)
        {
            s_SizeIndex++;
            if (s_SizeIndex == sr_BoardSizes.Length)
            {
                s_SizeIndex = 0;
            }
            boardSizeButton.Text = sr_BoardSizes[s_SizeIndex];
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            this.FormClosing -= GameSettingsForm_FormClosing;
            this.Close();
            bool isComputer = !secondPlayerText.Enabled;
            GameBoardForm gameBoardFrom = new GameBoardForm(FirstPlayerName, SecondPlayerName, BoardRows, BoardCols, isComputer);
            gameBoardFrom.ShowDialog();
        }

        private void GameSettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
                startButton_Click(sender, e);
        }

        public string FirstPlayerName
        {
            get
            {
                return firstPlayerText.Text;
            }
        }

        public string SecondPlayerName
        {
            get
            {
                return secondPlayerText.Text;
            }
        }
        
        public int BoardRows
        {
            get
            {
                return sr_BoardSizes[s_SizeIndex][0] - '0';
            }
        }

        public int BoardCols
        {
            get
            {
                return sr_BoardSizes[s_SizeIndex][4] - '0';
            }
        }

    }
}
