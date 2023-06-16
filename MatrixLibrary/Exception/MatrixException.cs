using System;

namespace MatrixLibrary
{
    /// <summary>
    /// 矩阵异常
    /// </summary>
    public class MatrixException : Exception
    {
        public MatrixException(string message) : base(message)
        {
        }
    }
}