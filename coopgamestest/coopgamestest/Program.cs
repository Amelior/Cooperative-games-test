using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace General
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //TestSelectionForm F = new TestSelectionForm();
            Coalitions.IncooperativeGameForm F = new Coalitions.IncooperativeGameForm();
            //Shapley.ShapleyTask F = new Shapley.ShapleyTask();
            //StudentInitializationForm F = new StudentInitializationForm();
            //Coalitions.IncooperativeGame F = new Coalitions.IncooperativeGame();
            //Coalitions.ViewCooperativeGameForm F = new Coalitions.ViewCooperativeGameForm();
            F.StartPosition = FormStartPosition.CenterScreen;
            //Coalitions.CoalitionChooseForm F = new Coalitions.CoalitionChooseForm();
            //BimatrixGame F = new BimatrixGame();
            //F.StartPosition = FormStartPosition.CenterScreen;
            F.Show();
            //F.Top = 50;
            Application.Run();
        }
    }
}
