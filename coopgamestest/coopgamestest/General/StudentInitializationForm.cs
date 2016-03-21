using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace General
{
    public partial class StudentInitializationForm : Form
    {
        public StudentInitializationForm()
        {
            InitializeComponent();
        }

        private void StartBTN_Click(object sender, EventArgs e)
        {
            TestSelectionForm TSF = new TestSelectionForm();
            TSF.StartPosition = FormStartPosition.Manual;
            TSF.Location = new Point(this.Left + TSF.Width/2, this.Top);
            MultiFormProcessor.FormOpened();
            TSF.Show();
            this.Close();
        }

        private void InitializationForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MultiFormProcessor.FormClosed();
        }
    }
}
