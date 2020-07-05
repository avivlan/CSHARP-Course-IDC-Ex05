using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B20_Ex02
{
   internal class BoardSquare
    {
        private char m_Letter;
        private bool m_IsFlipped;
        private int m_RowIndex;
        private int m_ColumnIndex;

        public BoardSquare(char letter, int i_RowIndex, int i_ColumnIndex)
        {
            this.m_Letter = letter;
            this.m_RowIndex = i_RowIndex;
            this.m_ColumnIndex = i_ColumnIndex;
            this.m_IsFlipped = false;
        }

        public char letter
        {
            get
            {
                return this.m_Letter;
            }
        }

        public bool IsFlipped
        {
            get
            {
                return this.m_IsFlipped;
            }
        }

        public void FlipSquare()
        {
            this.m_IsFlipped = true;
        }

        public void HideSquare()
        {
            this.m_IsFlipped = false;
        }

        public int RowIndex
        {
            get
            {
                return this.m_RowIndex;
            }
        }

        public int ColumnIndex
        {
            get
            {
                return this.m_ColumnIndex;
            }
        }

        public bool Equals(BoardSquare i_Other)
        {
            return this.letter == i_Other.letter && this.RowIndex == i_Other.RowIndex && this.ColumnIndex == i_Other.ColumnIndex;
        }
    }
}
