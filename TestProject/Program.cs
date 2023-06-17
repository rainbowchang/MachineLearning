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

            double[] item = new double[4] { 0, 2, 0, 5 };

            Col col = new Col(item);
            Row row = MatrixOperation.Transpose(col);

            Console.WriteLine(col);
            Console.WriteLine(row);

            Matrix matrix = (new UnitMatrix(5)) * (row * col) ;
            Console.WriteLine(matrix);

            Console.ReadKey();
        }
    }
}
