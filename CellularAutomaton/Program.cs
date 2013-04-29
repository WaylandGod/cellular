using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CellularAutomaton
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        /// 

        internal static Form1 mainFrm;
        internal static Form2 settingFrm;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            mainFrm = new Form1();
            settingFrm = new Form2();
            Application.Run(mainFrm);
        }
    }
}
