using System;

namespace Task_2_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                #region header data
                Matrix<int> matrix1 = new Matrix<int>(new int[,] { { 45, 58, 68 }, { 100, 587, 475 } });
                Matrix<int> matrix2 = new Matrix<int>(new int[,] { { 45, 58, 68 }, { 100, 587, 475 } });
                Matrix<int> matrix3 = new Matrix<int>(new int[,] { { 2, 2, 2 }, { 2, 2, 2 } });
                Matrix<int> matrix4 = new Matrix<int>(new int[2, 3]);

                Matrix<int>[] arr = new Matrix<int>[] { matrix1, matrix2, matrix3, matrix4 };

                Console.WriteLine("Base data: \n");
                for (int i = 0; i < arr.Length; i++)
                {
                    Console.WriteLine($"Matrix {i + 1}: \n" + arr[i]);
                }
                Console.WriteLine("================================");
                #endregion

                #region sum of matrix
                arr[3] = arr[0] + arr[2];
                Console.WriteLine("Sum of matrix: \n" + arr[3]);
                #endregion

                #region dif of matrix
                arr[3] = arr[0] - arr[2];
                Console.WriteLine("Dif of matrix: \n" + arr[3]);
                #endregion

                #region mul of matrix
                arr[3] = arr[0] * arr[2];
                Console.WriteLine("Mul of matrix: \n" + arr[3]);
                #endregion

                #region mul of matrix bu number
                arr[3] = arr[0] * 3;
                Console.WriteLine("Mul of matrix: \n" + arr[3]);
                #endregion

                #region equals
                Console.WriteLine("Equals tests:");
                Console.WriteLine($"Matrix 1.Equals(Matrix 2):" + (arr[0].Equals(arr[1])));
                Console.WriteLine($"Matrix 2.Equals(Matrix 3):" + (arr[1].Equals(arr[2])));
                Console.WriteLine($"Matrix 1 == Matrix 2:" + (arr[0] == arr[1]));
                Console.WriteLine($"Matrix 1 == Matrix 3:" + (arr[0] == arr[2]));
                Console.WriteLine($"Matrix 2 != Matrix 3:" + (arr[1] != arr[2]));
                Console.WriteLine();
                #endregion

                #region test with failure
                Console.WriteLine("Test with failure:");
                Console.WriteLine($"Matrix1 [100,100] = " + arr[0][100, 100]);
                Console.WriteLine();
                #endregion
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.ReadLine();
        }
    }
}
