using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UI;

namespace General.Coalitions
{
    public partial class IncooperativeGameForm : General.MasterPages.simpleMasterPage
    {
        public IncooperativeGameForm()
        {
            InitializeComponent();
            UI_FirstSetup(3);
            CGStudentProgress.NewSection();
        }

        #region Interface
        List<NumericTextBox> TB = new List<NumericTextBox>();
        int GenerationIteration = 1;
        BackgroundWorker BW;

        #region Before Generation

        /// <summary>
        /// UI Setup
        /// </summary>
        /// <param name="N">Bimatrix game participants number</param>
        void UI_FirstSetup(int N)
        {
            //Alignment
            Database.G.N = N;
            progressBar1.Maximum = 120;

            label1.Text = "Генерирование биматричных игр (1/" +
                (Database.G.N * (Database.G.N - 1) / 2).ToString() + ")";

            UI.TWDNGrid G = new UI.TWDNGrid(D, Database.G.N, Database.G.N);
            G.InitializeHeaders("Выигрыши", "Игрок", "Игрок");
            G.InitializeGrid();
            D.ReadOnly = true;
            D.ForeColor = Color.Black;
            D.Enabled = false;


            outerblocks.Add(AddHeader());
            outerblocks.Add(AddMainContent());

            ControlsAligner GP = new ControlsAligner(GenerationPanel);
            GP.AddElement(label1); GP.AddElement(progressBar1);
            blocks.Add(GP);
            outerblocks.Add(GP);

            AlignForm();
            //Alignment

            statusStrip1.Hide();

            BW = new BackgroundWorker();
            BW.WorkerReportsProgress = true;
            BW.DoWork += new DoWorkEventHandler(FindCombination);
            BW.ProgressChanged += new ProgressChangedEventHandler(StepComplete);
            BW.RunWorkerCompleted += new RunWorkerCompletedEventHandler(UI_SecondSetup);

            BW.RunWorkerAsync();
        }
        
        /// <summary>
        /// Add header label and grid on panel
        /// </summary>
        /// <returns></returns>
        protected override ControlsAligner AddMainContent()
        {
            base.AddMainContent();
            blocks.Last().AddElement(label2);
            blocks.Last().AddElement(D);
            return blocks.Last();
        }

        #endregion

        #region After Generation

        /// <summary>
        /// UI Setup after games are generated
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void UI_SecondSetup(object sender, RunWorkerCompletedEventArgs e)
        {
            #region Set FAQ label Text
            int i = 0, j = 1;
            while (D[i, j].Value.ToString() == D[j, i].Value.ToString())
            {
                j++;
                if (j == Database.G.N)
                {
                    j = 0;
                    if (i == Database.G.N - 1)
                        break;
                    else
                        i++;
                }
            }
            label3.Font = new System.Drawing.Font(label1.Font.Name, 10);
            label3.Text = "Матрица читается построчно.\nНапример: Рассмотрим игру\n Игрока " +
                (i + 1) + " против Игрока " + (j + 1) + ".\n   Выигрыш Игрока " + (i + 1) + " = " + D[j, i].Value +
                "\n   Выигрыш Игрока " + (j + 1) + " = " + D[i, j].Value;
            #endregion

            #region Grid settings
            D.Enabled = true;
            D.CellDoubleClick += new DataGridViewCellEventHandler(UI_OpenGameForm);
            D.CellMouseClick += new DataGridViewCellMouseEventHandler(CellSelected);
            D.MultiSelect = true;
            #endregion

            #region Form alignment
            //Set task content panel
            blocks.Add(new ControlsAligner(taskContentPanel));
            blocks.Last().AddElement(taskLabel);
            blocks.Last().WidthFixed = true;
            
            //Insert task content panel to the header panel            
            outerblocks.blocks[0].AddElement(taskContentPanel,true,"Stretch");
            //Insert FAQ label to the header panel  
            outerblocks.blocks[1].AddElement(label3, false);

            outerblocks.Hide(GenerationPanel.Name);
            outerblocks.Add(AddNavigationBar());

            GenerateTestPanel();
            AlignForm();
            #endregion


            LabelsParser.Parse(taskLabel, taskContentPanel.Width);

            navigationPanel.Show();
            label3.Show();
            taskContentPanel.Show();

            label3.Top += 20; //agjust label a bit
            this.Height -= 26; //no status bar
        }

        /// <summary>
        /// Generate panel with textboxes for user input
        /// </summary>
        void GenerateTestPanel()
        {
            int S = 0;
            Font F = new Font(label1.Font.Name, label1.Font.Size + 3);

            for (int i = 0; i < Database.G.N; i++)
                for (int j = 0; j < Database.G.N; j++)
                    if (i != j)
                        S = Math.Max(S, TextRenderer.MeasureText(D[j, i].Value.ToString(), D.Font).Width);

            blocks.Add(new UI.ControlsAligner(testPanel));

            for (int i = 0; i < Database.G.N + 1; i++)
            {
                Label l = new Label();
                if (i == Database.G.N)
                    l.Text = "v(N) = ";
                else
                    l.Text = "v(" + (i + 1) + ") = ";
                l.Font = F;
                l.ForeColor = label1.ForeColor;
                l.Size = TextRenderer.MeasureText(l.Text, l.Font);


                NumericTextBox t = new NumericTextBox();
                t.Font = new System.Drawing.Font(F.Name, F.Size + 2);
                t.Width = S + 40;
                t.NumericTB.TextAlign = HorizontalAlignment.Center;
                if ((i == 0) || (i == Database.G.N))
                    blocks.Last().AddElement(l);
                else
                    blocks.Last().AddElement(l, false);
                blocks.Last().AddElement(t, false, "HorBind");
                testPanel.Controls.Add(l);
                TB.Add(t);
                testPanel.Controls.Add(t);
            }
            blocks.Last().VerticalInterval *= 2;
            testPanel.Show();

            outerblocks.Add(blocks.Last(), navigationPanel.Name);
        }
        #endregion

        #endregion

        #region Logic

        /// <summary>
        /// Cooperative game generation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void FindCombination(object sender, DoWorkEventArgs e)
        {
            Database.G.GenerateCooperativeGame(BW, progressBar1);
        }

        /// <summary>
        /// Update progressbar and label when step of generation is complete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void StepComplete(object sender, ProgressChangedEventArgs e)
        {
            if (progressBar1.Value < progressBar1.Maximum)
            {
                int half = progressBar1.Maximum / 2,
                    BimatrixGamesNumber = Database.G.N * (Database.G.N - 1) / 2;

                //if (progressBar1.Value != progressBar1.Maximum)
                progressBar1.Value = progressBar1.Value + e.ProgressPercentage;

                //Reset
                if (e.ProgressPercentage < 0)
                {
                    GenerationIteration++;
                    for (int i = 0; i < D.Rows.Count; i++)
                        for (int j = 0; j < D.Columns.Count; j++)
                            D[j, i].Value = null;
                }
                //Generation

                if (progressBar1.Value < half)
                {
                    int current = progressBar1.Value / e.ProgressPercentage + 1;
                    label1.Text = "Генерирование биматричных игр ";
                    if (GenerationIteration > 1)
                        label1.Text += "[#" + GenerationIteration + "] ";
                    label1.Text += "(" + current + "/" + BimatrixGamesNumber + ")";
                    if (progressBar1.Value == 0)
                        label1.Left = progressBar1.Left + (progressBar1.Width - label1.Width) / 2;
                    if (Database.G.SingleGames.Count > 0)
                    {
                        SingleGame G = Database.G.SingleGames.Last();
                        D[G.pl2, G.pl1].Value = G.Ha.ToString("0.00");
                        D[G.pl1, G.pl2].Value = G.Hb.ToString("0.00");
                    }
                }
                //Stability check
                else if (progressBar1.Value < progressBar1.Maximum)
                {
                    label1.Text = "Проверка устойчивости ";
                    if (GenerationIteration > 1)
                        label1.Text += "[#" + GenerationIteration + "] ";

                    int current = (progressBar1.Value - half) / e.ProgressPercentage + 1;
                    label1.Text += "(" + current + "/" + Database.G.CoalitionsCount + ")";
                    label1.Left = progressBar1.Left + (progressBar1.Width - label1.Width) / 2;
                }
                else
                {
                    SingleGame G = Database.G.SingleGames.Last();
                    D[G.pl2, G.pl1].Value = G.Ha.ToString("0.00");
                    D[G.pl1, G.pl2].Value = G.Hb.ToString("0.00");
                    label1.Text = "Сохранение конфигурации";
                    label1.Left = progressBar1.Left + (progressBar1.Width - label1.Width) / 2;
                }

            }
        }

        #endregion


        #region Buttons Interaction

        /// <summary>
        /// Check textboxes and open next form if correct
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FinishButton_Click(object sender, EventArgs e)
        {
            if (CheckIncooperativeGame())
                SkipButton_Click(this, new EventArgs());
        }

        /// <summary>
        /// Finish this step and open next form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SkipButton_Click(object sender, EventArgs e)
        {

        }

        public bool CheckIncooperativeGame()
        {
            //Check fulfillment
            for (int i = 0; i < TB.Count; i++)
            {
                if (TB[i].NumericTB.Text == "")
                {
                    if (i == TB.Count - 1) System.Windows.Forms.MessageBox.Show("Заполните поле целевой функции");
                    else System.Windows.Forms.MessageBox.Show("Поле для " + (i + 1) + " игрока не заполнено.");
                    return false;
                }
            }

            //If not empty
            for (int i = 0; i < TB.Count; i++)
            {
                double value = TB[i].Value(),
                     ActualValue;
                if (i < TB.Count - 1)
                    ActualValue = Database.G.payoffs[i];
                else
                    ActualValue = Database.G.outcome;

                if ((value > 1.1 * ActualValue) || (value < 0.9 * ActualValue))
                {
                    CGStudentProgress.GenerateError("Ошибка при подсчете выражения для " + (i + 1) + " игрока.");
                    return false;
                }
            }

            return true;
        }

        #region Grid Interaction
        /// <summary>
        /// Select 2 cells in matrix onclick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void CellSelected(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                if ((e.ColumnIndex > -1) && (e.RowIndex > -1))
                    D.Rows[e.ColumnIndex].Cells[e.RowIndex].Selected = true;
        }

        /// <summary>
        /// Open single incooperative bimatrix game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void UI_OpenGameForm(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex, j = e.ColumnIndex;
            if (i != j)
            {
                if (i > j)
                {
                    i = e.ColumnIndex;
                    j = e.RowIndex;
                }

                SingleGame G = Database.G.FindGame(sender, i, j);
                ViewSingleGameForm F = new ViewSingleGameForm(G);
                F.StartPosition = FormStartPosition.Manual;
                MultiFormProcessor.FormOpened();
                F.Location = new Point(10, 10);
                F.Show();
                CGStudentProgress.FormsOpened.Add(F);
            }
        }
        #endregion

        #endregion

    }
}
