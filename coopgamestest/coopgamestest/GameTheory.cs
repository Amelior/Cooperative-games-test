using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.IO;
using System.Threading;
using System.Runtime.CompilerServices;


namespace General
{
    struct Matrix
    {
        public static List<List<Double>> Transp(List<List<Double>> M)
        {
            List<List<Double>> R = new List<List<double>>();

            int m = M.Count,
                n = M[0].Count;

            for (int i = 0; i < n; i++)
            {
                R.Add(new List<double>());
                for (int j = 0; j < m; j++)
                    R[i].Add(M[j][i]);
            }
            return R;
        }
    }

    public class SingleGame
    {
        public SingleGame(List<List<double>> M1, List<List<double>> M2)
        {
            A = M1;
            B = M2;
        }

        public SingleGame() {}

        public int pl1;
        public int pl2;

        public string FirstPlayer;
        public string SecondPlayer;

        public readonly List<List<double>> A = new List<List<double>>();
        //{
        //    get
        //    {
        //        return A;
        //    }
        //    private set
        //    {
        //        A = value;
        //    }
        //}
        private List<List<double>> Ac = new List<List<double>>();
        private List<List<double>> A1 = new List<List<double>>();

        public readonly List<List<double>> B = new List<List<double>>();

        private List<List<double>> Bc = new List<List<double>>();
        private List<List<double>> B1 = new List<List<double>>();

        public List<double> x = new List<double>();
        public List<double> y = new List<double>();

        public double Ha = 0;
        public double Hb = 0;

        //private
        private int n, m;
        private List<List<String>> P = new List<List<string>>();
        private List<List<String>> Q = new List<List<string>>();

        private List<double> Xo = new List<double>();
        private List<double> Yo = new List<double>();
        private int r1, c1r2, c2;
        private List<int> OptimalCombination = new List<int>(2);
        private List<double> La = new List<double>();
        private List<double> Lb = new List<double>();

        private bool solved = false;

        public SingleGame Dominate(List<int> RowIndexes = null, List<int> ColumnIndexes = null)
        {
            if (RowIndexes != null)
            {
                for (int i = 0; i<A.Count; i++)
                    RowIndexes.Add(i);
                for (int j = 0; j < A[0].Count; j++)
                    ColumnIndexes.Add(j);
            }

            List<List<Double>> Ad = new List<List<double>>();
            List<List<Double>> Bd = new List<List<double>>();
            for (int i = 0; i < A.Count; i++)
            {
                Ad.Add(new List<double>());
                Bd.Add(new List<double>());
                for (int j = 0; j < A[0].Count; j++)
                {
                    Ad[i].Add(A[i][j]);
                    Bd[i].Add(B[i][j]);
                }
            }
            //List<int> DominatedStrategies = new List<int>();
            bool Dominated = true;

            while (Dominated)
            {
                Dominated = false;
                for (int i = 0; i < Ad.Count; i++)
                {
                    if (!Dominated)
                        for (int ii = 0; ii < Ad.Count; ii++)
                            if ((ii != i) && (!Dominated))
                            {
                                bool dominated = true;
                                for (int j = 0; j < Ad[i].Count; j++)
                                {
                                    if (Ad[ii][j] > Ad[i][j])
                                    {
                                        dominated = false;
                                        break;
                                    }
                                }
                                if (dominated)
                                {
                                    Dominated = true;
                                    Ad.RemoveAt(ii);
                                    Bd.RemoveAt(ii);

                                    if (RowIndexes != null)
                                        RowIndexes.Remove(ii);
                                }
                            }
                }
                if (!Dominated)
                    for (int j = 0; j < Bd[0].Count; j++)
                    {
                        if (!Dominated)
                            for (int jj = 0; jj < Bd[0].Count; jj++)
                            {
                                if ((jj != j) && (!Dominated))
                                {
                                    bool dominated = true;
                                    for (int i = 0; i < Bd.Count; i++)
                                    {
                                        if (Bd[i][jj] > Bd[i][j])
                                        {
                                            dominated = false;
                                            break;
                                        }
                                    }
                                    if (dominated)
                                    {
                                        if (RowIndexes != null)
                                            ColumnIndexes.Remove(jj);
                                        Dominated = true;
                                        for (int i = 0; i < Bd.Count; i++)
                                        {
                                            Ad[i].RemoveAt(jj);
                                            Bd[i].RemoveAt(jj);
                                        }
                                    }
                                }
                            }
                    }
            }

            return (new SingleGame(Ad, Bd));
        }


        public bool Solve()
        {
            List<int> RowIndexes = new List<int>();
            List<int> ColumnIndexes = new List<int>();
            if (!solved)
            {
                double d = VariablesInitialization(RowIndexes, ColumnIndexes);
                bool Operating = true;
                //Stable2 = false;

                while (Operating)
                {
                    for (int i = 0; i < m; i++)
                        Yo[i] = 0;
                    for (int i = 0; i < n; i++)
                        Xo[i] = 0;

                    FormInitialVectors();
                    FormSymbolicArrays(c1r2, r1, c2);

                    if (StabilityAchieved())
                    {
                        Xo[c1r2] = 1;
                        Yo[r1] = 1;
                        x = Xo;
                        y = Yo;
                        Ha = A[RowIndexes[c1r2]][ColumnIndexes[r1]];
                        Hb = B[RowIndexes[c1r2]][ColumnIndexes[r1]];
                        Operating = false;
                    }
                    else
                    {
                        //if (CheckStability_v2())
                        //    Stable2 = true;

                        //transform basises
                        TransformBasises();

                        if (StabilityAchieved())
                        {
                            int xi = OptimalCombination[0],
                                yi = OptimalCombination[1];
                            double Sx = 0, Sy = 0;
                            for (int j = 0; j < n; j++)
                            {
                                x.Add(Xo[j] + Lb[xi] * B1[xi][m + j]);
                                Sx += x[j];
                            }
                            for (int j = 0; j < m; j++)
                            {
                                y.Add(Yo[j] + La[yi] * A1[yi][n + j]);
                                Sy += y[j];
                            }

                            for (int j = 0; j < n; j++)
                                x[j] /= Sx;
                            for (int j = 0; j < m; j++)
                                y[j] /= Sy;

                            Ha = d - 1 / Sy;
                            Hb = d - 1 / Sx;
                            Operating = false;
                        }
                        else
                        {
                            //if (CheckStability_v2())
                            //    Stable2 = true;
                            //if (Stable2)
                            //    System.Windows.Forms.MessageBox.Show("!");
                            //else
                            if (r1 < Ac.Count - 1)
                                r1++;
                            else
                                return false;
                        }

                    }
                }
                solved = true;
                if (RowIndexes != null)
                {
                    List<double> xx = new List<double>();
                    List<double> yy = new List<double>();
                    for (int i = 0; i < A.Count; i++)
                        xx.Add(0);
                    for (int j = 0; j < A[0].Count; j++)
                        yy.Add(0);
                    for (int i = 0; i < x.Count; i++)
                        xx[RowIndexes[i]] = x[i];
                    for (int j = 0; j < y.Count; j++)
                        yy[ColumnIndexes[j]] = y[j];

                    x = xx;
                    y = yy;
                }
            }
            return true;
        }

        private double VariablesInitialization(List<int> RowIndexes, List<int> ColumnIndexes)
        {
            SingleGame D = this.Dominate(RowIndexes, ColumnIndexes);
            n = D.A.Count;
            m = D.A[0].Count;
            //Duplicating to save data
            for (int i = 0; i < n; i++)
            {
                Ac.Add(new List<double>());
                Bc.Add(new List<double>());
                for (int j = 0; j < m; j++)
                {
                    Ac[i].Add(D.A[i][j]);
                    Bc[i].Add(D.B[i][j]);
                }
            }

            //Finding max element
            double d = Ac[0][0];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    d = Math.Max(d, Ac[i][j]);
                    d = Math.Max(d, Bc[i][j]);
                }
            d++;

            //Creating modified arrays
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    Ac[i][j] = d - Ac[i][j];
                    Bc[i][j] = d - Bc[i][j];
                }
            Ac = Matrix.Transp(Ac);

            for (int i = 0; i < n; i++)
            {
                Xo.Add(0);
                Lb.Add(0);
                P.Add(new List<string>());
                for (int j = 0; j < n; j++)
                {
                    P[i].Add("");
                    if (i == j)
                        Bc[i].Add(1);
                    else
                        Bc[i].Add(0);
                }
            }
            for (int i = 0; i < m; i++)
            {
                Yo.Add(0);
                La.Add(0);
                Q.Add(new List<string>());
                for (int j = 0; j < m; j++)
                {
                    Q[i].Add("");
                    if (i == j)
                        Ac[i].Add(1);
                    else
                        Ac[i].Add(0);
                }
            }
            return d;
        }

        private bool CheckStability_v2()
        {
            for (int i = 0; i < m; i++)
            {
                double mult1 = 0, mult2 = 0;
                for (int j = 0; j < m; j++)
                    mult1 += Ac[i][n + j] * Yo[j];
                for (int j = 0; j < n; j++)
                    mult2 += Bc[j][i] * Xo[j];

                if (mult1 * (mult2 - 1) != 0)
                    return false;
            }

            for (int i = 0; i < n; i++)
            {
                double mult1 = 0, mult2 = 0;
                for (int j = 0; j < n; j++)
                    mult1 += Bc[i][m + j] * Xo[j];
                for (int j = 0; j < m; j++)
                    mult2 += Ac[j][i] * Yo[j];

                if (mult1 * (mult2 - 1) != 0)
                    return false;
            }
            return true;
        }

        private void FormInitialVectors()
        {
            c1r2 = 0;
            c2 = 0; //indexes for matrixes A & B (c = column; r = row)
            if (r1 == Ac.Count)
                r1 = 0;
            double a = Ac[r1][0];
            for (int j = 1; j < n; j++)
            {
                if (Ac[r1][j] < a) c1r2 = j;
                a = Math.Min(a, Ac[r1][j]);
            }
            double b = Bc[c1r2][0];
            for (int j = 1; j < m; j++)
            {
                if (Bc[c1r2][j] < b) c2 = j;
                b = Math.Min(b, Bc[c1r2][j]);
            }

            Yo[r1] = 1 / a;
            Xo[c1r2] = 1 / b;
        }

        private void FormSymbolicArrays(int c1r2, int r1, int c2)
        {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    P[i][j] = "f" + j;

            for (int i = 0; i < n; i++)
                P[i][c1r2] = "b" + c2.ToString();


            for (int i = 0; i < m; i++)
                for (int j = 0; j < m; j++)
                    Q[i][j] = "e" + j;

            for (int i = 0; i < m; i++)
                Q[i][r1] = "a" + c1r2.ToString();
        }

        private void AlternativeStabilityCheck()
        {
        }
        
        private bool StabilityAchieved()
        {
            //Looking for match combination
            for (int Pi = 0; Pi < n; Pi++)
                for (int Qi = 0; Qi < m; Qi++)
                {
                    List<bool> AF = new List<bool>();
                    List<bool> BE = new List<bool>();
                    for (int i = 0; i < n; i++)
                        AF.Add(false);
                    for (int i = 0; i < m; i++)
                        BE.Add(false);


                    for (int j = 0; j < n; j++)
                    {
                        int index = Convert.ToInt32(P[Pi][j][1] - '0');
                        if (P[Pi][j][0] == 'b')
                            BE[index] = true;
                        if (P[Pi][j][0] == 'f')
                            AF[index] = true;
                    }

                    for (int j = 0; j < m; j++)
                    {
                        int index = Convert.ToInt32(Q[Qi][j][1] - '0');
                        if (Q[Qi][j][0] == 'a')
                            AF[index] = true;
                        if (Q[Qi][j][0] == 'e')
                            BE[index] = true;
                    }
                    bool match = true;
                    for (int i = 0; i < m; i++)
                        if (BE[i] == false)
                        {
                            match = false;
                            break;
                        }
                    if (match)
                        for (int i = 0; i < n; i++)
                            if (AF[i] == false)
                            {
                                match = false;
                                break;
                            }

                    if (match)
                    {
                        OptimalCombination.Add(Pi);
                        OptimalCombination.Add(Qi);
                        return true;
                    }
                }
            return false;
        }
        
        private void TransformBasises()
        {
            A1 = ElementaryBasisTransformation(Ac, r1, c1r2);
            B1 = ElementaryBasisTransformation(Bc, c1r2, c2);

            List<Double> epsilon_A = CalculateEpsilon(Ac, Yo);
            List<Double> epsilon_B = CalculateEpsilon(Bc, Xo);

            List<int> basis_A = new List<int>();
            List<int> basis_B = new List<int>();
            for (int i = 0; i < A1.Count; i++)
                basis_A.Add(-1);
            for (int i = 0; i < B1.Count; i++)
                basis_B.Add(-1);

            La = CalculateLambda(A1, epsilon_A, Yo, basis_A, r1);
            Lb = CalculateLambda(B1, epsilon_B, Xo, basis_B, c1r2);

            for (int i = 0; i < basis_B.Count; i++)
                if (basis_B[i] != -1)
                {
                    if (basis_B[i] >= m)
                        P[i][i] = "f" + (basis_B[i] - m).ToString();
                    else
                        P[i][i] = "b" + basis_B[i].ToString();
                }
            for (int i = 0; i < basis_A.Count; i++)
                if (basis_A[i] != -1)
                {
                    if (basis_A[i] >= n)
                        Q[i][i] = "e" + (basis_A[i] - n).ToString();
                    else
                        Q[i][i] = "a" + basis_A[i].ToString();
                }
        }

        private List<List<Double>> ElementaryBasisTransformation(List<List<Double>> I, int r, int s)
        {
            List<List<Double>> O = new List<List<double>>();

            for (int i = 0; i < I.Count; i++)
            {
                O.Add(new List<double>());
                for (int j = 0; j < I[0].Count; j++)
                    O[i].Add(I[i][j]);
            }

            double del = O[r][s];

            for (int i = 0; i < I.Count; i++)
                for (int j = 0; j < I[0].Count; j++)
                {
                    if (i == r) O[i][j] /= del;
                    else O[i][j] -= I[r][j] * I[i][s] / del;
                }

            return O;
        }

        private List<Double> CalculateEpsilon(List<List<Double>> I, List<Double> Vector)
        {
            List<Double> E = new List<double>();
            for (int i = 0; i < I[0].Count - I.Count; i++)
            {
                E.Add(0);
                for (int j = 0; j < I.Count; j++)
                    E[i] += I[j][i] * Vector[j];
            }
            return E;
        }

        private List<Double> CalculateLambda(List<List<Double>> M, List<Double> E,
            List<Double> Vector, List<int> Basis, int i_star)
        {//M - 2-d array; E - epsilon vector; Basis(Basis) indicates which element makes contribution;
            //i_star - index of compared element in Vector
            double Lmax, Lmin, element = 0, threshold = 1000000000;
            List<Double> CoalitionsInText = new List<double>();

            int mid = M[0].Count - M.Count;
            for (int i = 0; i < M.Count; i++)
            {
                Lmax = 0;
                Lmin = threshold;
                for (int j = 0; j < mid; j++)
                {
                    if (M[i][j] != 0)
                    {
                        element = (1 - E[j]) / M[i][j];

                        if ((M[i][j] > 0) && (element != 0))
                        {
                            if (element > Lmax)
                            {
                                Basis[i] = j;
                                Lmax = element;
                            }
                        }

                        if ((M[i][j] < 0) && (element != 0))
                        {
                            if (element < Lmin)
                            {
                                Basis[i] = j;
                                Lmin = element;
                            }
                        }
                    }
                }

                element = -Vector[i_star] / M[i][mid + i_star];
                if ((M[i][mid + i_star] < 0) && (element < Lmin))
                {
                    Lmin = element;
                    Basis[i] = mid + i_star;
                }
                if ((M[i][mid + i_star] > 0) && (element > Lmax))
                {
                    Lmax = element;
                    Basis[i] = mid + i_star;
                }

                if (Lmin != threshold) CoalitionsInText.Add(Lmin);
                else CoalitionsInText.Add(Lmax);
            }
            return CoalitionsInText;
        }
    }

    public class BimatrixGame
    {
        public int N;
        public double outcome;
        public List<double> payoffs = new List<double>();
        public List<int> S = new List<int>();
        public List<SingleGame> SingleGames = new List<SingleGame>();
        public SingleGame FindGame(object sender, int pl1, int pl2)
        {
            //if ((pl1 >= 0) && (pl1 < Database.G.N - 1) && (pl2 > 0) && (pl2 < Database.G.N) && (pl1 < pl2))
            //{
                for (int i = 0; i < SingleGames.Count; i++)
                    if ((SingleGames[i].pl1 == pl1) && (SingleGames[i].pl2 == pl2))
                        return SingleGames[i];
            //}
            System.Windows.Forms.MessageBox.Show(pl1 + " vs " + pl2 + ". Sender: " + sender);
            return new SingleGame();
        }

        //Solve Game
        public bool SolveBimatrixGame()
        {
            payoffs.Clear();
            outcome = 0;
            for (int i = 0; i < N; i++)
                payoffs.Add(0);
            for (int i = 0; i < SingleGames.Count; i++)
            {
                if (SingleGames[i].Solve())
                {
                    payoffs[SingleGames[i].pl1] += SingleGames[i].Ha;
                    payoffs[SingleGames[i].pl2] += SingleGames[i].Hb;
                }
                else
                    return false;
            }
            for (int i = 0; i < N; i++)
                outcome += payoffs[i] / (N - 1);
            return true;
        }

        //Random-Game Generator
        private int SleepTime = 10,
            MinValue = 1,
            MaxValue = 40,
            MinStratCount = 3,
            MaxStratCount = 5;

        public void Generate(System.ComponentModel.BackgroundWorker W, 
            int SleepTime, int MinValue, int MaxValue, int ProgressBarLength)
        {
            this.SleepTime = SleepTime;
            this.MinValue = MinValue;
            this.MaxValue = MaxValue;

            Generate(W, ProgressBarLength);
        }
        public void Generate(System.ComponentModel.BackgroundWorker W, int ProgressBarLength)
        {
            int Step = ProgressBarLength / (N * (N - 1) / 2);
            GenerateStrategiesNumbers();
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                    if (i < j)
                    {
                        GenerateSingleGame(i, j);
                        W.ReportProgress(Step);
                    }
            }
        }
        public void Generate(int n)
        {
            N = n;
            GenerateStrategiesNumbers();
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                    if (i < j)
                        GenerateSingleGame(i, j);
        }

        private void GenerateStrategiesNumbers()
        {
            Random R = new Random((int)DateTime.Now.Ticks);
            for (int i = 0; i < N; i++)
            {
                S.Add(R.Next(MinStratCount, MaxStratCount + 1));
                Thread.Sleep(SleepTime);
            }
        }

        private void GenerateSingleGame(int pl1, int pl2)
        {
            bool Solvable = false;
            SingleGame G = new SingleGame();

            while (!Solvable)
            {
                Random R = new Random((int)DateTime.Now.Ticks);

                int InD = R.Next(2, S[pl1]);
                Thread.Sleep(SleepTime);
                List<List<double>> A = GenerateMatrix(S[pl1], S[pl2], InD);

                InD = R.Next(2, S[pl2]);
                Thread.Sleep(SleepTime);
                //List<List<Double>> T = GenerateMatrix(Database.G.S[pl2], Database.G.S[pl1], InD);
                List<List<double>> B = Matrix.Transp(GenerateMatrix(S[pl2], S[pl1], InD));

                G = new SingleGame(A, B);
                G.pl1 = pl1;
                G.FirstPlayer = pl1.ToString();
                G.pl2 = pl2;
                G.SecondPlayer = pl2.ToString();
                Solvable = G.Solve();
            }
            SingleGames.Add(G);
        }

        private List<List<Double>> GenerateMatrix(int n, int m, int InD)
        {
            List<List<Double>> M = new List<List<double>>();
            int D = 0;
            for (int i = 0; i < n; i++)
            {
                M.Add(new List<double>());
                for (int j = 0; j < m; j++)
                    M[i].Add(GenerateNumber());
                if ((D != InD) && (i > 0))
                {
                    while (!CheckDomination(M))
                        M.Last()[0] = GenerateNumber();
                    Shuffle(M, "columns");
                }
            }
            Shuffle(M, "rows");

            return M;
        }

        private Double GenerateNumber()
        {
            Random R = new Random((int)DateTime.Now.Ticks);
            int val = R.Next(MinValue, MaxValue + 1);
            Thread.Sleep(SleepTime);
            return (val);
        }

        private bool CheckDomination(List<List<Double>> M)
        {
            for (int i = 0; i < M.Count - 1; i++)
            {
                int bigger = 0;
                for (int j = 0; j < M[0].Count; j++)
                    if (M[i][j] > M.Last()[j])
                        bigger++;
                if (bigger == M[0].Count)
                    return false;
            }
            return true;
        }

        private void Shuffle(List<List<Double>> M, string type)
        {
            Random R = new Random((int)DateTime.Now.Ticks);
            if (type == "columns")
            {
                for (int j = 0; j < M[0].Count; j++)
                {
                    int k = R.Next(0, M[0].Count);
                    Thread.Sleep(SleepTime);
                    for (int i = 0; i < M.Count; i++)
                    {
                        M[i].Insert(k, M[i][j]);
                        if (j < k)
                            M[i].RemoveAt(j);
                        else
                            M[i].RemoveAt(j + 1);
                    }
                }
            }
            else
            {
                for (int i = 0; i < M.Count; i++)
                {
                    int k = R.Next(0, M.Count);
                    Thread.Sleep(SleepTime);
                    M.Insert(k, M[i]);
                    if (i < k)
                        M.RemoveAt(i);
                    else
                        M.RemoveAt(i + 1);
                }
            }
        }
    }

    public class CooperativeGame : BimatrixGame
    {
        private List<List<int>> Coalitions = new List<List<int>>();
        public List<List<string>> CoalitionsInText = new List<List<string>>();
        public int CoalitionsCount = 0;
        private List<bool> CoalitionsSufficiency = new List<bool>();

        List<BimatrixGame> BimatrixGames = new List<BimatrixGame>();

        public void GenerateCooperativeGame(System.ComponentModel.BackgroundWorker W, ProgressBar P)
        {
            bool unstable = true;
            GenerateCoalitions();
            while (unstable)
            {
                Generate(W, P.Maximum / 2);
                for (int i = 0; i < N; i++)
                    payoffs.Add(0);
                outcome = 0;
                for (int i = 0; i < SingleGames.Count; i++)
                {
                    payoffs[SingleGames[i].pl1] += SingleGames[i].Ha / (N - 1);
                    payoffs[SingleGames[i].pl2] += SingleGames[i].Hb / (N - 1);
                }
                for (int i = 0; i < N; i++)
                    outcome += payoffs[i];

                Thread.Sleep(1000);
                if (SolveCooperativeGame(W, P.Maximum / 2))
                    unstable = false;
                else
                {
                    W.ReportProgress(-P.Value);
                    SingleGames.Clear();
                    S.Clear();
                    BimatrixGames.Clear();
                    this.payoffs.Clear();
                }
            }
            Thread.Sleep(1000);
        }

        public List<List<string>> GenerateCoalitions()
        {
            CoalitionsInText.Add(new List<string>());
            if (N == 3)
            {
                CoalitionsInText[0].Add("{1,2} <-> {3}");
                CoalitionsInText[0].Add("{1,3} <-> {2}");
                CoalitionsInText[0].Add("{2,3} <-> {1}");
                CoalitionsCount = 3;
            }
            else
            {
                for (int i = 0; i < 3; i++)
                    CoalitionsInText.Add(new List<string>());
                CoalitionsInText[0].Add("{1,2} - {3,4}");
                CoalitionsInText[0].Add("{1,3} - {2,4}");
                CoalitionsInText[0].Add("{1,4} - {2,3}");

                CoalitionsInText[1].Add("{1,2} - {3} - {4}");
                CoalitionsInText[1].Add("{1,3} - {2} - {4}");
                CoalitionsInText[1].Add("{1,4} - {2} - {3}");
                CoalitionsInText[1].Add("{2,3} - {1} - {4}");
                CoalitionsInText[1].Add("{2,4} - {1} - {3}");
                CoalitionsInText[1].Add("{3,4} - {1} - {2}");

                CoalitionsInText[2].Add("{1,2,3} - {4}");
                CoalitionsInText[2].Add("{1,2,4} - {3}");
                CoalitionsInText[2].Add("{1,3,4} - {2}");
                CoalitionsInText[2].Add("{2,3,4} - {1}");

                CoalitionsCount = 13;
            }

            for (int i = 0; i < CoalitionsInText.Count; i++)
                for (int j = 0; j < CoalitionsInText[i].Count; j++)
                {
                    Coalitions.Add(new List<int>());
                    for (int k = 0; k < CoalitionsInText[i][j].Length; k++)
                    {
                        if (CoalitionsInText[i][j][k] == '-')
                            Coalitions.Last().Add(-1);
                        else if ((CoalitionsInText[i][j][k] >= '0') && (CoalitionsInText[i][j][k] <= '9'))
                            Coalitions.Last().Add(Convert.ToInt32(CoalitionsInText[i][j][k] - '0') - 1);
                    }
                }
            return CoalitionsInText;
        }

        public BimatrixGame FindGame(string Key)
        {
            int it = 0;
            for (int i = 0; i < CoalitionsInText.Count; i++)
            {
                for (int j = 0; j < CoalitionsInText[i].Count; j++)
                    if (CoalitionsInText[i][j] == Key)
                        return BimatrixGames[it];
                    else
                        it++;
            }
            return null;
        }

        public bool SolveCooperativeGame()
        {
            for (int i = 0; i < Coalitions.Count; i++)
            {
                FormCoalitionBimatrixGame(Coalitions[i]);
                if (!BimatrixGames.Last().SolveBimatrixGame())
                    return false;
            }
            return true;
        }

        public bool SolveCooperativeGame(System.ComponentModel.BackgroundWorker W, int ProgressBarLength)
        {
            for (int i = 0; i < Coalitions.Count; i++)
            {
                FormCoalitionBimatrixGame(Coalitions[i]);
                if (BimatrixGames.Last().SolveBimatrixGame())
                    W.ReportProgress(ProgressBarLength / Coalitions.Count);                   
                else
                    return false;
            }
            return true;
        }

        private void FormCoalitionBimatrixGame(List<int> CurrentCoalition)
        {
            List<List<int>> PlayerDivision = new List<List<int>>();
            PlayerDivision.Add(new List<int>());

            for (int i = 0; i < CurrentCoalition.Count; i++)
            {
                if (CurrentCoalition[i] == -1)
                    PlayerDivision.Add(new List<int>());
                else
                    PlayerDivision.Last().Add(CurrentCoalition[i]);
            }

            BimatrixGame G = new BimatrixGame();
            G.N = PlayerDivision.Count;
            for (int i = 0; i<PlayerDivision.Count; i++)
            {
                G.S.Add(1);
                for (int j = 0; j < PlayerDivision[i].Count; j++)
                    G.S[i] *= this.S[PlayerDivision[i][j]];
            }
            for (int i = 0; i < PlayerDivision.Count; i++)
                for (int j = i + 1; j < PlayerDivision.Count; j++)
                    G.SingleGames.Add(FormCoalitionsSingleGame(PlayerDivision[i], PlayerDivision[j], i, j));

            BimatrixGames.Add(G);
        }

        private SingleGame FormCoalitionsSingleGame(List<int> C1, List<int> C2,
            int Player1Index, int Player2Index)
        {
            SingleGame G = new SingleGame();
            G.FirstPlayer = "{";
            for (int i = 0; i < C1.Count; i++)
            {
                G.FirstPlayer += (C1[i] + 1);
                if (i != C1.Count - 1)
                    G.FirstPlayer += ",";
                else
                    G.FirstPlayer += "}";
            }
            G.SecondPlayer = "{";
            for (int i = 0; i < C2.Count; i++)
            {
                G.SecondPlayer += (C2[i] + 1);
                if (i != C2.Count - 1)
                    G.SecondPlayer += ",";
                else
                    G.SecondPlayer += "}";
            }
            G.pl1 = Player1Index;
            G.pl2 = Player2Index;
            int n = 1, m = 1;
            for (int pl1 = 0; pl1 < C1.Count; pl1++)
                n *= S[C1[pl1]];
            for (int pl2 = 0; pl2 < C2.Count; pl2++)
                m *= S[C2[pl2]];

            List<List<int>> index = new List<List<int>>();
            index.Add(new List<int>());
            index.Add(new List<int>());
            for (int i = 0; i < C1.Count; i++)
                index[0].Add(0);
            for (int i = 0; i < C2.Count; i++)
                index[1].Add(0);

            for (int i = 0; i < n; i++)
            {
                G.A.Add(new List<double>());
                G.B.Add(new List<double>());

                for (int j = 0; j < m; j++)
                {
                    double vA = 0, vB = 0;
                    for (int p = 0; p < C1.Count; p++)
                        for (int q = 0; q < C2.Count; q++)
                        {
                            if (C1[p] > C2[q])
                            {
                                vA += FindGame(this, C2[q], C1[p]).A[index[1][q]][index[0][p]];
                                vB += FindGame(this, C2[q], C1[p]).B[index[1][q]][index[0][p]];
                            }
                            else
                            {
                                vA += FindGame(this, C1[p], C2[q]).A[index[0][p]][index[1][q]];
                                vB += FindGame(this, C1[p], C2[q]).B[index[0][p]][index[1][q]];
                            }
                        }
                    G.A[i].Add(vA);
                    G.B[i].Add(vB);
                    IncrementIndexes(index[1], C2);
                }
                for (int j = 0; j < C2.Count; j++)
                    index[1][j] = 0;
                IncrementIndexes(index[0], C1);

            }
            return G;
        }

        private void IncrementIndexes(List<int> index, List<int> players)
        {
            bool incremented = false;
            int ind = index.Count - 1;
            while (!incremented)
            {
                index[ind]++;
                if ((index[ind] == S[players[ind]]) && (ind > 0))

                    index[ind--] = 0;
                else
                    incremented = true;
            }
        }
    }
}

