using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMatrixClass
{
    class Program
    {


        class MatrixException : Exception
        {
            public MatrixException(int n, int m)
            {
                Console.Write($"Razmernost' matricy: {n} на {m}\n");

            }

        }
        public class Matrix
        {
            private int n;
            private int m;
            private double[,] mat;

            public Matrix(int n, int m)
            {
                this.n = n;
                this.m = m;
                mat = new double[this.n, this.m];
            }


            public int N
            {
                get { return n; }
                set { if (value > 0) n = value; }
            }

            public int M
            {
                get { return m; }
                set { if (value > 0) m = value; }
            }

            public double this[int i, int j]
            {
                get { return mat[i, j]; }
                set { mat[i, j] = value; }
            }



            public void WriteMat()
            {


                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        Console.WriteLine("Vvedite element: {0}:{1}", i + 1, j + 1);

                        try
                        {
                            mat[i, j] = double.Parse(Console.ReadLine());
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Byl vveden simvol");
                            Console.ReadLine();
                            Console.Clear();
                            Main();
                        }

                    }
                }
            }


            public static Matrix Sum(Matrix a, Matrix b)
            {

                Matrix resMat = new Matrix(a.N, a.M);

                Console.WriteLine("Summa: ");
                if (a.M == b.M && a.N == b.N)
                {
                    for (int i = 0; i < a.N; i++)
                    {
                        for (int j = 0; j < b.M; j++)
                        {
                            resMat[i, j] = a[i, j] + b[i, j];
                            Console.Write("  " + resMat[i, j] + "  ");
                        }

                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("Razmernost ne sovpadaet");
                }
                return resMat;
            }

            public static Matrix operator +(Matrix a, Matrix b)
            {


                return Sum(a, b);
            }

            public static Matrix Sub(Matrix a, Matrix b)
            {
                Matrix resMat = new Matrix(a.N, a.M);

                Console.WriteLine("Raznost: ");
                if (a.M == b.M && a.N == b.N)
                {
                    for (int i = 0; i < a.N; i++)
                    {
                        for (int j = 0; j < b.M; j++)
                        {
                            resMat[i, j] = a[i, j] - b[i, j];
                            Console.Write("  " + resMat[i, j] + "  ");
                        }
                        Console.WriteLine();

                    }
                }
                else
                {
                    Console.WriteLine("Razmernosti matric ne sovpadaut!");
                }

                Console.WriteLine();

                return resMat;
            }



            public static Matrix operator -(Matrix a, Matrix b)
            {
                return Sub(a, b);
            }

            public static Matrix Umn(Matrix a, Matrix b)
            {
                Matrix resMat = new Matrix(a.N, b.M);


                Console.WriteLine("Proizvedenie: ");
                double temp = 0;
                if (a.M == b.N)
                {
                    for (int i = 0; i < a.N; i++)
                    {
                        for (int j = 0; j < b.M; j++)
                        {
                            for (int k = 0; k < b.N; k++)
                                temp += a[i, k] * b[k, j];

                            resMat[i, j] = temp;
                            temp = 0;
                            Console.Write("  " + resMat[i, j] + "  ");
                        }
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("Kol-vo strok pervoi ne sovpadaet s kol-vom stolbcov vtoroy");
                }


                return resMat;
            }

            public static Matrix operator *(Matrix a, Matrix b)
            {
                return Umn(a, b);
            }

            public void GetEmpty()
            {

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        mat[i, j] = 0;
                        Console.Write("  " + mat[i, j] + "  ");
                    }
                    Console.WriteLine();

                }
            }




        }


        static void Main()
        {
            try
            {
                Console.WriteLine("Vvedite kol-vo strok pervoi matricy: ");
                int n1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Vvedite kol-vo stolbcov pervoi matricy:  ");
                int m1 = Convert.ToInt32(Console.ReadLine());
                if (n1 < 2 && m1 < 2) throw new MatrixException(n1, m1);


                Console.WriteLine("Vvedite kol-vo strok pervoi matricy: ");
                int n2 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Vvedite kol-vo stolbcov vtoroi matricy::  ");
                int m2 = Convert.ToInt32(Console.ReadLine());
                if (n2 < 2 && m2 < 2) throw new MatrixException(n2, m2);

                Matrix mt1 = new Matrix(n1, m1);
                Matrix mt2 = new Matrix(n2, m2);

                Matrix mt3 = new Matrix(n1, m1);

                mt1.WriteMat();
                mt2.WriteMat();

                Console.WriteLine("Viberite operaciu: (+,-,*,Empty)");
                string str = Console.ReadLine();
                switch (str)
                {
                    case "+":
                        mt3 = mt1 + mt2;
                        break;

                    case "-":
                        mt3 = mt1 - mt2;
                        break;

                    case "*":
                        mt3 = mt1 * mt2;
                        break;

                    case "Empty":
                        Console.WriteLine("Vvedite razmernost stolbcov:  ");
                        int mm = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Vvedite razmernost strok: ");
                        int nn = Convert.ToInt32(Console.ReadLine());
                        Matrix mt = new Matrix(mm, nn);
                        if (nn < 2 && mm < 2) throw new MatrixException(nn, mm);
                        mt.GetEmpty();
                        break;

                    default:
                        Console.WriteLine("Vy nazhali neizvestnuyu bukvu");
                        break;


                }
            }
            catch (MatrixException ex)
            {
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Eto ne chislo\n");
                Console.WriteLine("ERROR: " + ex.Message + "\n\n");
            }
        }
    }
}