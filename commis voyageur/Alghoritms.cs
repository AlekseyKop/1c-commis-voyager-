using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace commis_voyageur
{
    class Alghoritms
    {
        //List<int> DynamicMasN = new List<int>();
        //List<List<int>> DynamicMasNN = new List<List<int>>();
        //


        public void Swap(ref List<int> p, int a, int b)
        {
            int c;
            c = p[a];
            p[a] = p[b];
            p[b] = c;
        }

        public int factorial(int n)
        {
            int result = 1;
            for (int i = 1; i <= n; i++)
                result = result * i;
            return result;
        }

        public bool NextP(ref List<int> p)
        {
            bool result;
            int i;
            int n;
            int j;
            n = p.Count;
            i = n - 1;
            while ((i > 0) && (p[i] < p[i - 1]))
                i--;
            if (i == 1)
                result = false;
            else
            {
                j = n - 1;
                while (p[j] < p[i - 1])
                    j--;
                Swap(ref p, i - 1, j);
                j = 0;
                while (j <= (n - i) / 2 - 1)
                {
                    Swap(ref p, i + j, n - j - 1);
                    j++;
                }
                result = true;
            }
            return result;
        }
        public int GetKm(ref List<int> X, ref int[,] TR)
        {
            int n = X.Count;
            int result = 0;
            for (int i = 0; i <= n - 2; i++)
                result = result + TR[X[i] - 1, X[i + 1] - 1];
            result = result + TR[X[n - 1] - 1, X[0] - 1];
            return result;
        }

        public List<int> GetMinPut(int[,] TR, ref int min)
        {
            int n;
            int tmp;
            n = TR.GetLength(1);
            List<int> X = new List<int>(n);
            for (int i = X.Count; i < n; i++) X.Add(0);
            for (int i = 0; i <= n - 1; i++) X[i] = i + 1;
            List<int> Result = new List<int>(n);
            for (int i = Result.Count; i < n; i++) Result.Add(0);
            min = GetKm(ref X, ref TR);
            do
            {
                tmp = GetKm(ref X, ref TR);
                if (tmp < min)
                {
                    min = tmp;
                    for (int i = 0; i < n; i++)
                        Result[i] = X[i];
                }
            }
            while (NextP(ref X));
            return Result;
        }

        public double Stepen(double a, int b)
        {
            double Result = 0;
            if (b == 0)
                Result = 1;
            else
            {
                Result = 1;
                for (int i = 1; i <= b; i++)
                    Result = Result * a;
            }
            return Result;
        }

        public void dropAnts(ref List<int> M, ref int n)
        {
            Random rand = new Random();
            int k = n;
            int t;
            int i;
            int j;
            List<int> temp = new List<int>(n);
            for (i = temp.Count; i < n; i++) temp.Add(0);
            for (i = 0; i <= k - 1; i++) temp[i] = i + 1;
            for (j = M.Count; j < n + 1; j++) M.Add(0);
            for (j = 1; j <= n; j++) M[j] = -1;
            for (i = 0; i < n; i++)
            {
                do
                {
                    t = rand.Next(n + 1);
                } while (M[t] != -1);
                M[t] = temp[i];
            }
        }

        public void GetPut4OneAnt(ref List<int> X, double[,] r, double[,] NU, int alfa, int beta)
        {
            int p;
            int j;
            int i;
            int k;
            int n;
            SortedSet<int> temp_set = new SortedSet<int>();
            List<double> temp = new List<double>();
            bool ok;
            Random rand = new Random();

            n = X.Count;
            i = X[0];
            temp_set.Add(i);
            for (p = 1; p < n; p++)
            {
                for (k = temp.Count; k < n + 1; k++) temp.Add(0);
                double znam = 0;
                for (j = 1; j <= n; j++)
                    if (!(temp_set.Contains(j)))
                        znam = znam + ((Stepen(r[i - 1, j - 1], alfa)) * Stepen(NU[i - 1, j - 1], beta));
                if (znam == 0)
                    znam = 1;
                for (j = 1; j <= n; j++)
                {
                    if (!(temp_set.Contains(j))) temp[j] = ((Stepen(r[i - 1, j - 1], alfa)) * (Stepen(NU[i - 1, j - 1], beta))) / znam;
                    else temp[j] = 0;
                    temp[j] = temp[j] * 1000000;
                }

                int random = rand.Next(1, 1000000);
                double qq = 0;
                temp[0] = qq;
                for (j = 1; j <= n; j++)
                {
                    qq = qq + temp[j];
                    temp[j] = qq;
                }
                j = 0;
                ok = true;
                while (ok && (j < n))
                {
                    if ((random > temp[j]) && (random < temp[j + 1])) ok = false;
                    else j++;
                }
                if (j < n) j++;
                X[p] = j;
                temp_set.Add(j);
            }
        }





        public List<int> GetMinPutMuravii(ref int[,] D, ref int min)
        {
            Random rand = new Random();
            int alfa, beta, n, k, i, j, t, p, tmax;
            List<int> X = new List<int>();
            List<int> M = new List<int>();
            List<int> L = new List<int>();
            List<int> Result = new List<int>();
            double qq, p_isp;
            n = D.GetLength(1);
            for (i = X.Count; i < n; i++) X.Add(0);
            for (i = 0; i <= n - 1; i++) X[i] = i + 1;
            for (i = Result.Count; i < n; i++) Result.Add(0);
            for (i = 0; i < n; i++) min = GetKm(ref X, ref D);
            for (p = 0; p < n; p++) Result[p] = X[p];
            double[,] NU = new double[n, n];

            for (i = L.Count; i < n + 1; i++) L.Add(0);
            for (i = 0; i <= n - 1; i++)
                for (j = 0; j <= n - 1; j++)
                    if (D[i, j] != 0) NU[i, j] = (1 / Convert.ToDouble(D[i, j]));
                    else NU[i, j] = 0;
            tmax = n * 100;
            alfa = 2;
            beta = 3;
            p_isp = 0.3;
            double[,] r = new double[n, n];
            for (i = 0; i < n; i++)
                for (j = 0; j < n; j++)
                    r[i, j] = 10.0;
            for (t = 1; t < tmax + 1; t++)
            {
                dropAnts(ref M, ref n);
                for (k = 1; k <= n; k++)
                {
                    X[0] = M[k];
                    GetPut4OneAnt(ref X, r, NU, alfa, beta);
                    L[k] = GetKm(ref X, ref D);
                    if (L[k] < min)
                    {
                        min = L[k];
                        for (p = 0; p < n; p++)
                            Result[p] = X[p];
                    }
                }
                qq = 0;
                for (k = 1; k <= n; k++) qq = qq + (Convert.ToDouble(min) / Convert.ToDouble(L[k]));
                for (i = 0; i < n; i++)
                    for (j = 0; j < n; j++)
                        if (i != j) r[i, j] = (1 - p_isp) * r[i, j] + qq;
            }
            return Result;
        }
    }
}
