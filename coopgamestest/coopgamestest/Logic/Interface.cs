using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Drawing;
using System.IO;

namespace UI
{
    /// <summary>
    /// class that aligns all the content of the container within its borders with flexible adjustment
    /// </summary>
    public class ControlsAligner
    {
        public Control container;
        public List<List<Control>> controls;
        private List<List<string>> position;

        private Size FormBorderSize = new Size(18, 39 + 26); //26 = status bar height

        public int Left = 15;
        public int Right = 15;
        public int Top = 15;
        public int Bottom = 15;

        public int HorizontalInterval = 30;
        public int VerticalInterval = 15;

        private int MaximumRowWidth = 0,
            ExtraSpace = 0;

        public bool WidthFixed = false;

        public ControlsAligner(Control container)
        {
            this.container = container;
            controls = new List<List<Control>>();
            position = new List<List<string>>();
        }


        /// <summary>
        /// Add new control element that requires alignment
        /// </summary>
        /// <param name="c">Current element</param>
        /// <param name="AlignmentMode">"Left", "Middle", "Right", "Stretch" or "HorBind"</param>
        /// <param name="NewLevel">Indicates that the current control is on the different height level</param>
        /// <param name="accociate">Previously added control with which current is binded</param>
        public void AddElement(Control c, bool NewLevel = true, string AlignmentMode = "Middle")
        {            
            if (NewLevel)
            {
                controls.Add(new List<Control>());
                position.Add(new List<string>());
            }
            controls.Last().Add(c);
            position.Last().Add(AlignmentMode);
        }

        public void Align(bool ZeroPadding = false)
        {
            if (controls.Count > 0)
            {
                if (ZeroPadding)
                {
                    Left = 0;
                    Right = 0;
                    Top = 0;
                    Bottom = 0;
                }
                MaximumRowWidth = PlaceElements(WidthFixed);
                AlignRows();

                int MaxHeight = 0;
                for (int j = 0; j < controls.Last().Count; j++)
                    MaxHeight = Math.Max(MaxHeight, controls.Last()[j].Bottom);

                container.Height = MaxHeight + Bottom;
                if (container is Form)
                    container.Height += FormBorderSize.Height;
            }
        }


        private int PlaceElements(bool WidthFixed)
        {
            int MaximumRowWidth = 0;
            for (int i = 0; i < controls.Count; i++)
                for (int j = 0; j < controls[i].Count; j++)
                {
                    if (i == 0)
                        controls[i][j].Top = Top;
                    else
                    {
                        int b = controls[i-1][0].Bottom;
                        for (int k = 1; k < controls[i - 1].Count; k++)
                            b = Math.Max(b, controls[i - 1][k].Bottom);
                        controls[i][j].Top = b + VerticalInterval;
                    }

                    if (j == 0)
                        controls[i][j].Left = Left;
                    else
                    {
                        controls[i][j].Left = controls[i][j - 1].Right;
                        if (position[i][j] != "HorBind")
                            controls[i][j].Left += HorizontalInterval;
                        else
                            controls[i][j].Top = controls[i][j - 1].Top +
                                (controls[i][j - 1].Height - controls[i][j].Height) / 2;
                    }

                    if ((!WidthFixed) && (position[i][j] != "Stretch"))
                        MaximumRowWidth = Math.Max(MaximumRowWidth, controls[i][j].Right);
                }

            if (WidthFixed)
                MaximumRowWidth = container.Width - Right;
            else
            {
                container.Width = MaximumRowWidth + Right;
                if (container is Form)
                    container.Width += FormBorderSize.Width;
            }

            return MaximumRowWidth;
        }

        private void AlignRows()
        {
            for (int i = 0; i < controls.Count; i++)
            {
                ExtraSpace = MaximumRowWidth - controls[i].Last().Right;
                if ((ExtraSpace != 0) && (CheckAlignment(i)))
                    for (int j = 0; j < controls[i].Count; j++)
                    {
                        if (position[i][j] == "Stretch")
                        {
                            Stretch(i, j);
                            break;
                        }
                        if (position[i][j] == "Middle")
                        {
                            Center(i, j);
                            break;
                        }
                        if (position[i][j] == "VertBind")
                            controls[i][j].Left = (controls[i][j].Tag as Control).Left +
                                ((controls[i][j].Tag as Control).Width - controls[i][j].Width) / 2;
                    }
            }

            //Right
            for (int i = 0; i < controls.Count; i++)
            {
                if (position[i].Last() == "Right")
                    controls[i].Last().Left = MaximumRowWidth - controls[i].Last().Width;
            }

            if ((controls.Last().Count > 1) && (position.Last().Last() == "Right")) // Last one is button
            {
                Control b = controls.Last().Last(),
                    previous = controls.Last()[controls.Last().Count - 2];
                b.Top = previous.Top + (previous.Height - b.Height) / 2;
            }
        }

        private bool CheckAlignment(int i)
        {
            for (int j = 0; j < controls[i].Count; j++)
            {
                if (position[i][j] == null)
                    return true;
                else if ((position[i][j] == "Stretch") || (position[i][j] == "Middle")||(position[i][j] == "VertBind"))
                    return true;
            }
            return false;
        }

        private void Stretch(int i, int j)
        {
            if (controls[i].Count == 1)
            {
                controls[i][j].Width = MaximumRowWidth - Left;
                if (controls.Count == 1)
                    controls[i][j].Height = container.Height;
            }
            else
            {
                int ElementsCount = 1,
                    SummaryWidth = controls[i][j].Width;

                for (int p = j + 1; p < controls[i].Count; p++)
                    if (position[i][p] == "Stretch")
                    {
                        ElementsCount++;
                        SummaryWidth += controls[i][p].Width;
                    }


                for (int p = j; p < j + ElementsCount; p++)
                {
                    if (p > 0)
                        controls[i][p].Left = controls[i][p - 1].Right + HorizontalInterval;
                    if (position[i][p] == "Stretch")
                        controls[i][p].Width += (controls[i][p].Width / SummaryWidth) * ExtraSpace;
                }
                for (int p = j + ElementsCount; p < controls[i].Count; p++)
                    controls[i][p].Left += ExtraSpace;
            }
        }

        private void Center(int i, int j)
        {
            if (controls[i].Count == 1)
                controls[i][j].Left = (MaximumRowWidth + Right - controls[i][j].Width) / 2;
            else
            {
                int ElementsCount = 1;

                for (int p = j + 1; p < controls[i].Count; p++)
                    if ((position[i][p] == "Middle"))
                        ElementsCount++;

                int interval = ExtraSpace / (ElementsCount + 1) + HorizontalInterval;
                for (int p = j; p < controls[i].Count; p++)
                {
                    if (position[i][p] == "Middle")
                    {
                        if (p == 0)
                            controls[i][p].Left = ExtraSpace / (ElementsCount + 1) + Left;
                        else
                            controls[i][p].Left = controls[i][p - 1].Right + interval;
                    }
                    else if (position[i][p] == "HorBind")
                        controls[i][p].Left = controls[i][p - 1].Right;
                    else
                        controls[i][p].Left = controls[i][p - 1].Right + HorizontalInterval;
                }
            }
        }
    }

    public static class LabelsParser
    {
        private static string input, result;
        private static Font f;

        public static void Parse(Label l, int size)
        {
            input = l.Text;
            result = input;
            f = l.Font;
            while (FindFirstSymbol('\n'))
                RemoveSymbol('\n');

            while (FindFirstSymbol('\r'))
                RemoveSymbol('\r');
            input = result;
            result = "";
            for (int i = 0; i<input.Length; i++)
            {
                if (TextRenderer.MeasureText(result + input[i], f).Width > size)
                    result = result.Substring(0, FindLastSymbol(i - 1, ' ')) + ' ' + Environment.NewLine + result.Split(' ').Last();
                result += input[i];
            }
            l.Text = result;
            l.Left = (size - l.Width) / 2;
        }

        private static int FindLastSymbol(int pos, char symb)
        {
            for (int i = pos; i >= 0; i--)
                if (result[i] == symb)
                    return i;
            return -1;
        }

        private static bool FindFirstSymbol(char symb)
        {
            for (int i = 0; i < result.Length; i++)
                if (result[i] == symb)
                    return true;
            return false;
        }

        private static void RemoveSymbol(char symb)
        {
            for (int i = 0; i < result.Length; i++)
                if (result[i] == symb)
                    result = result.Split(symb)[0] + result.Split(symb)[1];
        }
    }

    /// <summary>
    /// Controls Aligner array
    /// Note: all blocks have to be at the same level (no inner blocks)
    /// </summary>
    public class PageContentBlocks
    {
        int widthAdjustment = 0;

        public List<ControlsAligner> blocks = new List<ControlsAligner>();
        
        public void Add(ControlsAligner block, string nextItem = "")
        {
            if (nextItem == "")
                blocks.Add(block);
            else
            {
                for (int i = 0; i<blocks.Count; i++)
                {
                    if (blocks[i].container.Name == nextItem)
                    {
                        blocks.Insert(i, block);
                        break;
                    }
                }
            }
        }

        public int MaxWidth()
        {
            int maxWidthFixed = 0,
                maxWidth = 0;
            foreach (ControlsAligner block in blocks)
            {
                maxWidth = Math.Max(maxWidth, block.container.Width + block.Left + block.Right + widthAdjustment);
                if (block.WidthFixed)
                    maxWidthFixed = Math.Max(maxWidthFixed, block.container.Width + block.Left + block.Right);
            }
            //return (maxWidthFixed == 0 ? maxWidth : maxWidthFixed);
            return maxWidth;
        }

        public void Align()
        {
            int formContentWidth = MaxWidth();
            foreach (ControlsAligner block in blocks)
            {
                block.container.Width = formContentWidth;
                if (block.WidthFixed)
                    block.Align();
                else
                {
                    block.WidthFixed = true;
                    block.Align();
                    block.WidthFixed = false;
                }
            }
        }

        public bool Hide(String elementName)
        {
            foreach (ControlsAligner block in blocks)
                if (block.container.Name == elementName)
                {
                    block.container.Hide();
                    blocks.Remove(block);
                    return true;
                }
                else
                {
                    for (int i = 0; i < block.controls.Count; i++)
                        for (int j = 0; j < block.controls[i].Count; j++)
                            if (block.controls[i][j].Name == elementName)
                            {
                                block.controls[i][j].Hide();
                                block.controls[i].Remove(block.controls[i][j]);
                                if (block.controls[i].Count == 0)
                                    block.controls.RemoveAt(i);
                                return true;
                            }
                }
            return false;
        }
    }
    
    #region Grids
    class Grid
    {        
        protected DataGridView D;
        protected int RowsCount, ColumnsCount;

        protected Font font = new Font("Book Antiqua", 12);
        protected Size cellsize = new Size(30, 30);

        protected string TopLeftHeaderCellText = "";
        private int DefaultRowsWidth = 0;
        private int DefaultColumnsWidth = 0;
        public int RowHeaderAlignSize = 0;
        public readonly Size MaximumSize = new Size(500, 500);
        public bool LimitedSize = false;
        //HeaderColors
        private Color ColumnHeaderBackColor = Color.White;
        private Color ColumnHeaderForeColor = Color.Black;
        private Color RowHeaderBackColor = Color.White;
        private Color RowHeaderForeColor = Color.Black;

        public Grid(DataGridView D, int RowsCount, int ColumnsCount)
        {
            this.D = D;
            if (RowsCount > 0)
                this.RowsCount = RowsCount;
            else
            {
                Exception e = new Exception("Ненатуральное количество строк в матрице: " + RowsCount);
                throw e;
            }
            if (ColumnsCount > 0)
                this.ColumnsCount = ColumnsCount;
            else
            {
                Exception e = new Exception("Ненатуральное количество столбцов в матрице: " + RowsCount);
                throw e;
            }
        }        
        public Grid(DataGridView D, int RowsCount, int ColumnsCount, Size cellsize)
        {
            this.D = D;
            this.cellsize = cellsize;
            if (RowsCount > 0)
                this.RowsCount = RowsCount;
            else
            {
                Exception e = new Exception("Ненатуральное количество строк в матрице: " + RowsCount);
                throw e;
            }
            if (ColumnsCount > 0)
                this.ColumnsCount = ColumnsCount;
            else
            {
                Exception e = new Exception("Ненатуральное количество столбцов в матрице: " + RowsCount);
                throw e;
            }
        }

        public void SetHeadersColors(Color ColumnHeaderBackColor,
            Color ColumnHeaderForeColor, Color RowHeaderBackColor, Color RowHeaderForeColor)
        {
            this.ColumnHeaderBackColor = ColumnHeaderBackColor;
            this.ColumnHeaderForeColor = ColumnHeaderForeColor;
            this.RowHeaderBackColor = RowHeaderBackColor;
            this.RowHeaderForeColor = RowHeaderForeColor;
        }

        public void InitializeHeaders(string TopLeftHeaderCellText)
        {
            this.TopLeftHeaderCellText = TopLeftHeaderCellText;
        }
        public void InitializeHeaders(string TopLeftHeaderCellText, int DefaultRowsWidth, int DefaultColumnsWidth)
        {
            InitializeHeaders(TopLeftHeaderCellText);
            this.DefaultColumnsWidth = DefaultColumnsWidth;
            this.DefaultRowsWidth = DefaultRowsWidth;
        }

        public void InitializeGrid()
        {
            CreateTable();
            CreateHeaders();
        }
        public void InitializeGrid(List<int> M)
        {
            CreateTable();
            for (int i = 0; i < M.Count; i++)
                try
                {
                    D[i, 0].Value = M[i];
                }
                catch (ArgumentOutOfRangeException)
                {
                    System.Windows.Forms.MessageBox.Show("Выход за границы массива при создании матрицы", D.Name);
                }
            CreateHeaders();
        }
        public void InitializeGrid(List<List<Double>> M)
        {
            CreateTable();
            for (int i = 0; i<M.Count; i++)
                for (int j = 0; j < M[0].Count; j++)
                {
                    try
                    {
                        D[j, i].Value = M[i][j];
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        System.Windows.Forms.MessageBox.Show("Выход за границы массива при создании матрицы", D.Name);
                    }
                }
            CreateHeaders();
        }

        protected virtual void CreateTable()
        {
            D.EnableHeadersVisualStyles = false;
            D.Rows.Clear();
            D.Columns.Clear();
            D.Font = font;

            D.AutoGenerateColumns = false;
            D.AllowUserToAddRows = false;

            DataGridViewTextBoxColumn c1;
            for (int cind = 0; cind < ColumnsCount; cind++)
            {
                c1 = new DataGridViewTextBoxColumn();
                c1.Width = cellsize.Width;
                D.Columns.Add(c1);
            }
            DataGridViewRow row;
            for (int rind = 0; rind < RowsCount; rind++)
            {
                row = new DataGridViewRow();
                DataGridViewCell[] Cells = new DataGridViewCell[ColumnsCount];
                for (int cind = 0; cind < ColumnsCount; cind++)
                    Cells[cind] = new DataGridViewTextBoxCell();

                row.Cells.AddRange(Cells);

                D.Rows.Add(row);
                D.Rows[rind].Height = cellsize.Height;
                D.Rows[rind].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void CreateHeaders()
        {
            FillHeaders();
            CorrectSizes();
        }

        protected virtual void FillHeaders()
        {
            D.TopLeftHeaderCell.Value = TopLeftHeaderCellText;
            if (TopLeftHeaderCellText != "")
            {
                D.TopLeftHeaderCell.Style.Font = new Font(font.Name, font.Size, System.Drawing.FontStyle.Bold);
                D.TopLeftHeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void CorrectSizes()
        {
            //Columns
            D.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            D.ColumnHeadersHeight = cellsize.Height;
            for (int i = 0; i < ColumnsCount; i++)
            {
                D.Columns[i].HeaderCell.Style.Font = new Font(font.Name, font.Size, System.Drawing.FontStyle.Bold);
                D.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                D.Columns[i].HeaderCell.Style.BackColor = ColumnHeaderBackColor;
                D.Columns[i].HeaderCell.Style.ForeColor = ColumnHeaderForeColor;
                D.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

                if (DefaultColumnsWidth == 0)
                {
                    int width = (TextRenderer.MeasureText(D.Columns[i].HeaderCell.Value.ToString(), font)).Width;
                    for (int j = 0; j < RowsCount; j++)
                        if (D.Rows[j].Cells[i].Value != null)
                            width = Math.Max(width, (TextRenderer.MeasureText
                                (D.Rows[j].Cells[i].Value.ToString(), font).Width));
                    D.Columns[i].Width = Math.Max(width + 12, cellsize.Width);
                }
                else
                    D.Columns[i].Width = DefaultRowsWidth;
            }

            //Rows
            int Hwidth = 0;
            if (D.TopLeftHeaderCell.Value != null)
                Hwidth = TextRenderer.MeasureText(D.TopLeftHeaderCell.Value.ToString(),
                    D.TopLeftHeaderCell.Style.Font).Width;
            for (int i = 0; i < RowsCount; i++)
            {
                D.Rows[i].HeaderCell.Style.Font = new Font(font.Name, font.Size, System.Drawing.FontStyle.Bold);
                D.Rows[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                D.Rows[i].HeaderCell.Style.BackColor = RowHeaderBackColor;
                D.Rows[i].HeaderCell.Style.ForeColor = RowHeaderForeColor;

                if (DefaultRowsWidth == 0)
                    if (D.Rows[i].HeaderCell.Value != null)
                        Hwidth = Math.Max((TextRenderer.MeasureText(D.Rows[i].HeaderCell.Value.ToString(),
                            D.Rows[i].HeaderCell.Style.Font)).Width, Hwidth);

            }
            if (DefaultRowsWidth == 0)
                D.RowHeadersWidth = Math.Max(Hwidth + RowHeaderAlignSize, cellsize.Width);
            else
                D.RowHeadersWidth = DefaultRowsWidth;
            D.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            for (int i = 0; i < D.Rows.Count; i++)
                D.Rows[i].Height = cellsize.Height;

            //Grid
            int Height = D.TopLeftHeaderCell.Size.Height + 5, Width = 2 + D.TopLeftHeaderCell.Size.Width;
            for (int i = 0; i < D.Rows.Count; i++)
                Height += D.Rows[i].Height;
            for (int i = 0; i < D.Columns.Count; i++)
                Width += D.Columns[i].Width;

            if (LimitedSize)
            {
                bool scroll = false;
                if (Height > MaximumSize.Height)
                {
                    D.Height = MaximumSize.Height;
                    scroll = true;
                }
                else
                    D.Height = Height;

                if (Width > MaximumSize.Width)
                {
                    D.Width = MaximumSize.Width;
                    D.Height += 17;
                }
                else
                    D.Width = Width;

                if (scroll)
                    D.Width += 17;
            }
            else
            {
                D.Height = Height;
                D.Width = Width;
            }
        }


        public void BeginEdit(DataGridViewRowHeaderCell c)
        {
            int ind = c.RowIndex;
            int Top = D.ColumnHeadersHeight;
            for (int i = 0; i < ind; i++)
                Top += D.Rows[i].Height;

            TextBox t = new TextBox();
            t.Left = 1;
            t.Width = D.RowHeadersWidth;
            t.Top = Top;
            t.Font = new Font(D.Font.Name, D.Font.Size + 2);
            t.LostFocus += new EventHandler(EditHeader);
            t.PreviewKeyDown += new PreviewKeyDownEventHandler(TextBoxKeyDown);
            t.Tag = c;
            if (c.Value != null)
                t.Text = c.Value.ToString();
            D.Controls.Add(t);
            t.Focus();
        }
        public void BeginEdit(DataGridViewColumnHeaderCell c)
        {            
            int ind = c.ColumnIndex;
            int Left = D.RowHeadersWidth;
            for (int i = 0; i < ind; i++)
                Left +=D.Columns[i].Width;

            TextBox t = new TextBox();
            t.Left = Left;
            t.Width = D.Columns[ind].Width;
            t.Top = 1;
            t.Font = new Font(D.Font.Name, D.Font.Size + 2);
            t.LostFocus += new EventHandler(EditHeader);
            t.PreviewKeyDown += new PreviewKeyDownEventHandler(TextBoxKeyDown);
            t.Tag = c;
            t.Text = c.Value.ToString();
            D.Controls.Add(t);
            //c.fo
            t.Focus();
        }

        void TextBoxKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                if ((sender as TextBox).Tag is DataGridViewRowHeaderCell)
                {
                    ((sender as TextBox).Tag as DataGridViewRowHeaderCell).Value = (sender as TextBox).Text;
                    D.Controls[D.Controls.Count - 1].Dispose();
                    if (((sender as TextBox).Tag as DataGridViewRowHeaderCell).RowIndex < RowsCount - 1)
                        BeginEdit(D.Rows
                            [((sender as TextBox).Tag as DataGridViewRowHeaderCell).RowIndex + 1].HeaderCell);
                    else
                        BeginEdit(D.Columns[0].HeaderCell);
                }
                else
                {
                    ((sender as TextBox).Tag as DataGridViewColumnHeaderCell).Value = (sender as TextBox).Text;
                    D.Controls[D.Controls.Count - 1].Dispose();
                    if (((sender as TextBox).Tag as DataGridViewColumnHeaderCell).ColumnIndex < ColumnsCount - 1)
                        BeginEdit(D.Columns
                            [((sender as TextBox).Tag as DataGridViewColumnHeaderCell).ColumnIndex + 1].HeaderCell);
                    else
                        BeginEdit(D.Rows[0].HeaderCell);
                }
            }
        }

        void EditHeader(object sender, EventArgs e)
        {
            if ((sender as TextBox).Tag is DataGridViewRowHeaderCell)
                ((sender as TextBox).Tag as DataGridViewRowHeaderCell).Value = (sender as TextBox).Text;
            else
                ((sender as TextBox).Tag as DataGridViewColumnHeaderCell).Value = (sender as TextBox).Text;
            D.Controls[D.Controls.Count - 1].Dispose();
        }
    }

    class StrategiesGrid:Grid
    {
        private List<string> RowLetters = new List<string>();
        private List<string> ColumnLetters = new List<string>();
        private List<List<int>> StrategiesNumber = new List<List<int>>();
        private string[] Letters = { "x", "y", "z", "v", "w"};

        public StrategiesGrid(DataGridView D, int RowsCount, int ColumnsCount) : base(D, RowsCount, ColumnsCount) { }
        public StrategiesGrid(DataGridView D, int RowsCount, int ColumnsCount, Size cellsize)
            : base(D, RowsCount, ColumnsCount, cellsize) { }
        public void InitializeHeaders(string TopLeftHeaderCellText, string pl1, string pl2, List<int> StrategiesCount)
        {
            base.InitializeHeaders(TopLeftHeaderCellText);
            StrategiesNumber.Add(new List<int>());
            StrategiesNumber.Add(new List<int>());
            if (pl1.Length == 1)
            {
                RowLetters.Add(Letters[Convert.ToInt32(pl1)]);
                StrategiesNumber[0].Add(StrategiesCount[Convert.ToInt32(pl1)]);
            }
            else
            {
                for (int i = 0; i < pl1.Length; i++)
                {
                    switch (pl1[i])
                    {
                        case '0':
                        case '1':
                        case '2':
                        case '3':
                        case '4':
                        case '5':
                        case '6':
                            {
                                RowLetters.Add(Letters[Convert.ToInt32(pl1[i] - '1')]);
                                StrategiesNumber[0].Add(StrategiesCount[Convert.ToInt32(pl1[i] - '1')]);
                            }
                            break;
                    }
                }
            }
            if (pl2.Length == 1)
            {
                ColumnLetters.Add(Letters[Convert.ToInt32(pl2)]);
                StrategiesNumber[1].Add(StrategiesCount[Convert.ToInt32(pl2)]);
            }
            else
            {
                for (int i = 0; i < pl2.Length; i++)
                {
                    switch (pl2[i])
                    {
                        case '0':
                        case '1':
                        case '2':
                        case '3':
                        case '4':
                        case '5':
                        case '6':
                            {
                                ColumnLetters.Add(Letters[Convert.ToInt32(pl2[i] - '1')]);
                                StrategiesNumber[1].Add(StrategiesCount[Convert.ToInt32(pl2[i] - '1')]);
                            }
                            break;
                    }
                }
            }

        }
        public void InitializeHeaders(string TopLeftHeaderCellText, string[] Strategies, string pl1,
            List<int>StrategiesCount, string pl2)
        {
            base.InitializeHeaders(TopLeftHeaderCellText);
            StrategiesNumber.Add(new List<int>());
            StrategiesNumber.Add(new List<int>());
            if (pl1.Length == 1)
            {
                RowLetters.Add(Strategies[Convert.ToInt32(pl1)]);
                StrategiesNumber[0].Add(StrategiesCount[Convert.ToInt32(pl1)]);
            }
            else
            {
                for (int i = 0; i < pl1.Length; i++)
                {
                    switch (pl1[i])
                    {
                        case '1':
                        case '2':
                        case '3':
                        case '4':
                        case '5':
                        case '6':
                            {
                                RowLetters.Add(Strategies[Convert.ToInt32(pl1[i])]);
                                StrategiesNumber[0].Add(StrategiesCount[Convert.ToInt32(pl1[i])]);
                            }
                            break;
                    }
                }
            }
            if (pl2.Length == 1)
            {
                ColumnLetters.Add(Strategies[Convert.ToInt32(pl2)]);
                StrategiesNumber[1].Add(StrategiesCount[Convert.ToInt32(pl2)]);
            }
            else
            {
                for (int i = 0; i < pl2.Length; i++)
                {
                    switch (pl2[i])
                    {
                        case '1':
                        case '2':
                        case '3':
                        case '4':
                        case '5':
                        case '6':
                            {
                                ColumnLetters.Add(Strategies[Convert.ToInt32(pl2[i])]);
                                StrategiesNumber[1].Add(StrategiesCount[Convert.ToInt32(pl2[i])]);
                            }
                            break;
                    }
                }
            }
        }

        protected override void FillHeaders()
        {
            base.FillHeaders();
            List<List<int>> Index = new List<List<int>>();
            Index.Add(new List<int>());
            Index.Add(new List<int>());
            for (int i = 0; i < RowLetters.Count; i++)
                Index[0].Add(0);
            for (int i = 0; i < ColumnLetters.Count; i++)
                Index[1].Add(0);

            for (int i = 0; i < RowsCount; i++)
            {
                for (int j = 0; j<RowLetters.Count; j++)
                    D.Rows[i].HeaderCell.Value += RowLetters[j].ToString() + (Index[0][j] + 1).ToString();
                IncrementIndexes(Index[0],StrategiesNumber[0]);
            }

            for (int i = 0; i < ColumnsCount; i++)
            {
                for (int j = 0; j < ColumnLetters.Count; j++)
                    D.Columns[i].HeaderCell.Value += ColumnLetters[j].ToString() + (Index[1][j] + 1).ToString();
                IncrementIndexes(Index[1], StrategiesNumber[1]);
            }

            RowHeaderAlignSize = 30;
        }

        private void IncrementIndexes(List<int> index, List<int> S)
        {
            bool incremented = false;
            int ind = index.Count - 1;
            while (!incremented)
            {
                index[ind]++;
                if ((index[ind] == S[ind]) && (ind > 0))

                    index[ind--] = 0;
                else
                    incremented = true;
            }
        }
    }

    class TWDNGrid : Grid
    {
        private string ColumnHeadersText = "";
        private string RowHeadersText = "";
        private bool RowsHaveNumbers = true;
        private bool ColumnsHaveNumbers = true;

        public TWDNGrid(DataGridView D, int RowsCount, int ColumnsCount) : base(D, RowsCount, ColumnsCount) { }
        public TWDNGrid(DataGridView D, int RowsCount, int ColumnsCount, Size cellsize)
            : base(D, RowsCount, ColumnsCount, cellsize) { }

        public void InitializeHeaders(string TopLeftHeaderCellText,
            string RowHeadersText, string ColumnHeadersText)
        {
            base.InitializeHeaders(TopLeftHeaderCellText);
            this.ColumnHeadersText = ColumnHeadersText;
            this.RowHeadersText = RowHeadersText;
        }

        public void InitializeHeaders(string TopLeftHeaderCellText, string RowHeadersText,
            string ColumnHeadersText, bool RowsHaveNumbers, bool ColumnsHaveNumbers)
        {
            InitializeHeaders(TopLeftHeaderCellText, RowHeadersText, ColumnHeadersText);
            this.RowsHaveNumbers = RowsHaveNumbers;
            this.ColumnsHaveNumbers = ColumnsHaveNumbers;
        }

        protected override void FillHeaders()
        {
            RowHeaderAlignSize = 25;
            base.FillHeaders();
            for (int i = 0; i < ColumnsCount; i++)
            {
                D.Columns[i].HeaderText = ColumnHeadersText;
                if (ColumnsHaveNumbers)
                    D.Columns[i].HeaderText += " " + (i + 1).ToString();
            }

            for (int i = 0; i < RowsCount; i++)
            {
                D.Rows[i].HeaderCell.Value = RowHeadersText;
                if (RowsHaveNumbers)
                    D.Rows[i].HeaderCell.Value += " " + (i + 1).ToString();
            }

        }
    }

    //class ComboboxGrid : Grid
    //{
    //    public ComboboxGrid(DataGridView D, int RowsCount, int ColumnsCount) : base(D, RowsCount, ColumnsCount) { }
    //    public ComboboxGrid(DataGridView D, int RowsCount, int ColumnsCount, Size cellsize)
    //        : base(D, RowsCount, ColumnsCount, cellsize) { }
    //    protected override void CreateTable()
    //    {
    //        D.EnableHeadersVisualStyles = false;
    //        D.Rows.Clear();
    //        D.Columns.Clear();
    //        D.Font = font;

    //        D.AutoGenerateColumns = false;
    //        D.AllowUserToAddRows = false;

    //        DataGridViewComboBoxColumn c1;
    //        for (int cind = 0; cind < ColumnsCount; cind++)
    //        {
    //            c1 = new DataGridViewComboBoxColumn();
    //            c1.Width = cellsize.Width;
    //            D.Columns.Add(c1);
    //        }
    //        DataGridViewRow row;
    //        for (int rind = 0; rind < RowsCount; rind++)
    //        {
    //            row = new DataGridViewRow();
    //            DataGridViewCell[] Cells = new DataGridViewCell[ColumnsCount];
    //            for (int cind = 0; cind < ColumnsCount; cind++)
    //                Cells[cind] = new DataGridViewComboBoxCell();

    //            row.Cells.AddRange(Cells);

    //            D.Rows.Add(row);
    //            D.Rows[rind].Height = cellsize.Height;
    //            D.Rows[rind].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
    //        }
    //    }
    //}
    #endregion
}