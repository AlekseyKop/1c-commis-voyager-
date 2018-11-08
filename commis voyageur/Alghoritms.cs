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


        public void Swap(int a, int b)
        {
            int c;
            c = a;
            a = b;
            b = c;
        }

        public int factorial(int n)
        {
            int result=1;
            for (int i=1; i <= n; i++)
                result = result * i;
            return result;
        }

        public bool NextP(List<int> p)
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
                Swap(p[i - 1], p[j]);
                j = 0;
                while (j <= (n - i) / 2 - 1)
                {
                    Swap(p[i + j], p[n - j - 1]);
                    j++;
                }
                result = true;
            }
            return result;
        }
        //fromsgtodynamicmas
        public int GetKm(List<int> X, int[,] TR)
        {
            int n = X.Count;
            int result = 0;
            for (int i = 0; i <= n - 2; i++)
                result = result + TR[X[i] - 1, X[i + 1] - 1];
            result = result + TR[X[n - 1] - 1, X[0] - 1];
            return result;
        }

        public List<int> GetMinPut(int[,] TR, int min)
        {
            int n;
            int tmp;
            n = TR.Length;
            List<int> X = new List<int>(n);
            for (int i = X.Count; i < n; i++) X.Add(0);
            List<int> Result = new List<int>(n);
            for (int i = Result.Count; i < n; i++) X.Add(0);
            min = GetKm(X, TR);
            do
            {
                tmp = GetKm(X, TR);
                if (tmp < min)
                {
                    min = tmp;
                    for (int i = 0; i < n; i++)
                        Result[i] = X[i];
                }
            }
            while (!NextP(X));
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
        }

        public void dropAnts(List<int> M, int n)
        {
            Random rand = new Random();
            int k;
            int t;
            k = n;
            int i;
            int j;
            List<int> temp = new List<int>(n);
            for (i = temp.Count; i < n; i++) temp.Add(0);
            for (i = 0; i < k; i++) temp[i] = i + 1;
            for (j = M.Count; j < n; j++) M.Add(0);
            for (j = 1; i <= n; i++) M[j] = -1;
            for (j = 0; j < n; j++)
            {
                do
                {
                    t = rand.Next(1, n);
                } while (M[t] == temp[i]);
            }

        }
        public void GetPut4OneAnt(List<int>X, double[,] r, double[,] NU,int alfa,int beta)
        {

        }
        public List<int> GetMinPutMuravii(int min)
        {

        }
    }
}
