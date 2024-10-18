using System;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;

namespace Arrays
{
    class making_arrays
    {
        private int size;

        public making_arrays(int N)
        {
            size = N;
        }

        public void print_array()
        {
            int[] arr_1 = new int[size];

            for (int i = 0; i < size; i++)
            {
                arr_1[i] = i + 1;
            }

            for (int i = 1; i < size + 1; i++)
            {
                Console.WriteLine(arr_1[^i]);
            }
        }
    }

    class making_matrix_with_zeroes
    {
        private int line, column;

        public making_matrix_with_zeroes(int N, int M)
        {
            line = N;
            column = M;
        }

        public void completing_matrix(int N, int M)
        {
            int[,] arr_m = new int[line, column];

            for (int i = 0; i < line; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    if (i <= j + 1) arr_m[i, j] = 1;
                    else arr_m[i, j] = 0;
                }
            }

            string[] rows = new string[N];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    rows[i] += arr_m[i, j];
                }
            }

            for (int i = 0; i < N; i++)
            {
                Console.WriteLine(rows[i]);
            }
        }
    }

    class making_round_matrix
    {
        private int line, column;

        public making_round_matrix(int N, int M)
        {
            line = N; column = M;
        }

        public void completing_round_matrix(int N, int M)
        {
            int[,] arr_r = new int[line, column];

            int Flag = 0; // индикатор направления

            int counter_lines = 0;
            int counter_columns = 0;

            int counter_row = 0;

            for (int i = 1; i < line * column + 1;i ++)
            {
                int counter_for_flag0 = 1;

                switch (Flag)
                {
                    case 0:
                        if (arr_r[counter_lines, counter_columns] != 0)
                        {
                            counter_lines = counter_lines + 1;
                            counter_columns = counter_columns + 1;
                        }

                        arr_r[counter_lines, counter_columns] = i;
                        counter_columns++;
                        if (counter_columns == column - counter_row - 1)
                        {
                            Flag = 1;
                        }
                        break;

                    case 1:
                        if (arr_r[counter_lines, counter_columns] != 0)
                        {
                            counter_lines = counter_lines - 1;
                            counter_columns = counter_columns - 1;
                        }

                        arr_r[counter_lines, counter_columns] = i;
                        counter_lines++;
                        if (counter_lines == line - counter_row - 1)
                        {
                            Flag = 2;
                        }
                        break;

                    case 2:
                        if (arr_r[counter_lines, counter_columns] != 0)
                        {
                            counter_lines = counter_lines - 1;
                            counter_columns = counter_columns - 1;
                        }

                        arr_r[counter_lines, counter_columns] = i;
                        counter_columns--;
                        if (counter_columns == counter_row)
                        {
                            Flag = 3;
                        }
                        break;

                    case 3:
                        if (arr_r[counter_lines, counter_columns] != 0)
                        {
                            counter_lines = counter_lines + 1;
                            counter_columns = counter_columns + 1;
                        }
                        arr_r[counter_lines, counter_columns] = i;
                        counter_lines--;
                        if (counter_lines == counter_row)
                        {
                            Flag = 0;
                            counter_row++;
                        }
                        break;
                }
            }

            string[] rows = new string[N];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    rows[i] += arr_r[i, j];
                }
            }

            for(int i = 0; i < N; i++)
            {
                Console.WriteLine(rows[i]);
            }

        }
    }

    class Program
    {
        const int N = 5;
        const int M = 4;
        static void Main(string[] args)
        {
            //вывод одномерного массива
            Console.WriteLine("Making array and printing in reverse order: ");
            making_arrays arr = new making_arrays(N);
            arr.print_array();

            //создание квадратного массива с нулями слева
            Console.WriteLine(" ");
            Console.WriteLine("Matrix with zeroes under the diagonal: ");
            making_matrix_with_zeroes matrix = new making_matrix_with_zeroes(N, M);
            matrix.completing_matrix(N, M);

            // создание квадратного или прямоугольного массива с заполнением "по кругу"
            Console.WriteLine("");
            Console.WriteLine("Circle matrix: ");
            making_round_matrix arr_r = new making_round_matrix(N, M);
            arr_r.completing_round_matrix(N, M);
        }
    }
}
