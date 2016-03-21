using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;




namespace General
{
    struct Database
    {
        public static CooperativeGame G = new CooperativeGame();
    }

    struct MultiFormProcessor
    {
        private static int Forms = 1;
        public static void FormClosed()
        {
            Forms--;
            if (Forms == 0)
                Application.Exit();
        }

        public static void FormOpened()
        {
            Forms++;
        }
    }

    struct CGStudentProgress
    {
        public static bool Finished = false;

        public static List<Form> FormsOpened = new List<Form>();

        public static int ErrorsNumber = 0;

        public static int CurrentSection = 0;
        private static string[] Sections = { "Определение функции выигрыша некооперативной игры",
                                           "Заполнение модели кооперативной игры",
                                           "Применение отношения доминирования",
                                           "Графическое решение биматричной задачи (опционально)",
                                           "Определение дележа выигрыша и существенности игры",
                                           "Выделение существенных игр"};
        private static List<int> Errors = new List<int>();

        public static int DistributionType = 0;//0 = contribution in a coalition price; 1 = incooperative payoff
        public static void NewSection()
        {
            Errors.Add(0);
            CurrentSection++;
        }

        public static void GenerateError(string ErrorText)
        {
            //Errors[1][Errors.Count - 1] = CGStudentProgress.Errors.Last() + 1;
            ErrorsNumber++;
            System.Windows.Forms.MessageBox.Show(ErrorText + "\nКоличество ошибок: " + ErrorsNumber,
                Sections[Errors.Count - 1]);
        }

        public static double ReadValue(string s)
        {
            double value = -1;
            try
            {
                value = Convert.ToDouble(s);
            }
            catch (FormatException)
            {
                System.Windows.Forms.MessageBox.Show("Не все поля заполнены");
            }
            return value;
        }
    }
}
