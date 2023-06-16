using MatrixLibrary.MatrixGroup;
using MatrixLibrary.Operation;
using System;

namespace TestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Matrix matrix1 = new Matrix(3, 3);
            matrix1[1, 1] = 3;
            matrix1[1, 2] = 2;
            matrix1[1, 3] = -1;
            matrix1[2, 1] = 2;
            matrix1[2, 2] = 2;
            matrix1[2, 3] = 1;
            matrix1[3, 1] = 1;
            matrix1[3, 2] = 0;
            matrix1[3, 3] = 1;
            Console.WriteLine(matrix1.ToString());

            Determinant determinant1 = new Determinant(matrix1);
            Console.WriteLine(determinant1.GetValue());
            Console.WriteLine(Environment.NewLine);

            Matrix matrix2 = new Matrix(3, 3);
            matrix2[1, 1] = 1;
            matrix2[1, 2] = -1;
            matrix2[1, 3] = 0;
            matrix2[2, 1] = -2;
            matrix2[2, 2] = 2;
            matrix2[2, 3] = 1.5;
            matrix2[3, 1] = 1;
            matrix2[3, 2] = 2;
            matrix2[3, 3] = -2;
            Console.WriteLine(matrix2.ToString());

            Determinant determinant2 = new Determinant(matrix2);
            Console.WriteLine(determinant2.GetValue());
            Console.WriteLine(Environment.NewLine);

            Matrix matrix3 = matrix1 * matrix2;
            Console.WriteLine(matrix3.ToString());
            Determinant determinant3 = new Determinant(matrix3);
            Console.WriteLine(determinant3.GetValue());
            Console.WriteLine(Environment.NewLine);

            Matrix matrix4 = new Matrix(1, 1);
            matrix4[1, 1] = 3;
            Matrix matrix5 = matrix4 * matrix1;
            Console.WriteLine(matrix5.ToString());
            Console.WriteLine(Environment.NewLine);

            Matrix matrix6 = new UnitMatrix(4);
            Matrix matrix7 = (matrix6 * 2) ^ 3;
            Console.WriteLine(matrix7.ToString());

            Console.ReadKey();
        }
    }
}
