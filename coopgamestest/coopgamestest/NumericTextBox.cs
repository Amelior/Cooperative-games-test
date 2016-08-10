using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace General
{
    public partial class NumericTextBox : UserControl
    {
        public NumericTextBox()
        {
            InitializeComponent();
        }

        private bool isNumber(char key)
        {
            switch (key)
            {
                case '-':
                    if (NumericTB.Text.Length > 0)
                        return false;
                    return true;
                case '.':
                case ',':
                    {
                        if (NumericTB.Text.Length > 0)
                        {
                            if (NumericTB.Text[NumericTB.Text.Length - 1] == '-')
                                return false;
                        }
                        else
                            return false;
                        for (int i = 0; i < NumericTB.Text.Length; i++)
                            if ((NumericTB.Text[i] == '.') || (NumericTB.Text[i] == ','))
                                return false;
                        return true;
                    }
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    return true;
                case (char)Keys.Enter:
                case (char)Keys.Back:
                    return true;
                default:
                    return false;                    
            }

        }

        private void NumericTB_Validated(object sender, EventArgs e)
        {
            if (NumericTB.Text.Length > 0)
            {
                if (!char.IsDigit(NumericTB.Text.Last()))
                {
                    NumericTB.Text = NumericTB.Text.Substring(0, NumericTB.Text.Length - 1);
                    System.Windows.Forms.MessageBox.Show("Последний символ не может быть десятичной запятой");
                }
            }
        }


        private void NumericTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            string value = NumericTB.Text;
            if (!isNumber(e.KeyChar))
            {
                e.Handled = true;
                System.Windows.Forms.MessageBox.Show("Неправильный символ");
            }
        }

        private void NumericTextBox_SizeChanged(object sender, EventArgs e)
        {
            NumericTB.Size = this.Size;
            this.Height = NumericTB.Height;
        }
    }
}
