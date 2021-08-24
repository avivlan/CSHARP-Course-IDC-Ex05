using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using B20_Ex02;

namespace B20_Ex05
{
   public class GameButton : Button
    {
        private BoardSquare m_BoardSquare;

        public GameButton(BoardSquare i_BoardSquare)
        {
            this.m_BoardSquare = i_BoardSquare;
        }

        public BoardSquare BoardSquare
        {
            get
            {
                return m_BoardSquare;
            }
        }

        public void HideText()
        {
            this.Text = string.Empty;
        }

        public void ShowText()
        {
            this.Text = m_BoardSquare.letter.ToString();
        }
    }
}
