using System;
using MathNet.Numerics.LinearAlgebra.Double;


namespace MathNetTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var x = new DenseVector(new double[]{ 4.0,4.0,4.0});
            // Create a 3 by 5 matrix with 2.0 in every entry.
            var A = new DenseMatrix(5, 3, new double[] { 2.0 ,2.0, 2.0, 2.0, 2.0, 2.0, 2.0, 2.0, 2.0, 2.0, 2.0, 2.0, 2.0, 2.0, 2.0 });
            // Multiply the matrix and the vector.
            DenseVector y = x * A;
            Console.WriteLine(A);



        }
    }
}
