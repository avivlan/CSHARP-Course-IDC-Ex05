using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        public GameBoardForm(string i_FirstPlayerName, string i_SecondPlayerName, int i_Rows, int i_Cols, bool i_IsComputer)
        {
            r_FirstPlayerName = i_FirstPlayerName;
            r_SecondPlayerName = i_SecondPlayerName;
            r_BoardRows = i_Rows;
            r_BoardCols = i_Cols;
            r_GameManager = new GameManager(i_FirstPlayerName, i_SecondPlayerName, i_Rows, i_Cols, i_IsComputer);
            
            InitializeComponent();
        }
    }
}
