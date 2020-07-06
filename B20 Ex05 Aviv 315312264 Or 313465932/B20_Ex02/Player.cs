using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace B20_Ex02
{
    public class Player
    {
        private string m_PlayerName;
        private bool m_IsComputer;
        private int m_Score;
        private int m_PlayerNum;

        public Player(string i_Name, bool i_IsComputer, int i_PlayerNum)
        {
            this.m_PlayerName = i_Name;
            this.m_IsComputer = i_IsComputer;
            this.m_PlayerNum = i_PlayerNum;
            this.m_Score = 0;
        }

        public bool IsComputer
        {
            get
            {
                return this.m_IsComputer;
            }
        }

        public int Score
        {
            get
            {
                return this.m_Score;
            }
        }

        public void AddScore()
        {
            this.m_Score += 1;   
        }

        public void ResetScore()
        {
            this.m_Score = 0;
        }

        public string Name
        {
            get
            {
                return this.m_PlayerName;
            }

            set
            {
                this.m_PlayerName = value;
            }
        }

        public int PlayerNum
        {
            get
            {
                return m_PlayerNum;
            }
        }
    }
}
