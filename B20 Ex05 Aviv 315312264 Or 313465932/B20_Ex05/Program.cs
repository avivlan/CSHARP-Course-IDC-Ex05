using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using B20_Ex02;

namespace B20_Ex05
{
    public class Program
    {
        public static void Main()
        {
            Application.EnableVisualStyles();
            GameSettingsForm settingsForm = new GameSettingsForm();
            settingsForm.ShowDialog();
        }
    }
}
