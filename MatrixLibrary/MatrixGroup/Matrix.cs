using System;
using System.Collections.Generic;
using System.Text;

namespace MatrixLibrary.MatrixGroup
{
    public class Matrix
    {
        protected int _rows;
        /// <summary>
        /// 矩阵的行数
        /// </summary>
        public virtual int Rows
        {
            get
            {
                return _rows;
            }

        }
        protected int _cols;
        /// <summary>
        /// 矩阵的列数
        /// </summary>
        public virtual int Cols
        {
            get
            {
                return _cols;
            }
        }


        protected double[,] _items;

        /// <summary>
        /// 下标从0开始
        /// </summary>
        public double[,] Items
        {
            get
            {
                return _items;
            }

            protected internal set
            {
                _items = value;
                _rows = _items.GetLength(0);
                _cols = _items.GetLength(1);
            }
        }

        protected internal Matrix() { }

        public Matrix(int rows, int cols)
        {
            _rows = rows;
            _cols = cols;
            _items = new double[_rows, _cols];
        }

        /// <summary>
        /// 创建一个和源矩阵维度相同的矩阵
        /// </summary>
        /// <param name="matrix"></param>
        public Matrix(Matrix matrix)
        {
            _rows = matrix.Rows;
            _cols = matrix.Cols;
            _items = new double[_rows, _cols];
        }

        public Matrix(double[,] items)
        {
            this._items = items;
            _rows = this._items.GetLength(0);
            _cols = this._items.GetLength(1);
        }

        /// <summary>
        /// <para>外部确定下标从1开始，最大是Rows, Cols，以更接近于矩阵运算的实际操作。</para>
        /// <para>内部处理的时候是从0开始处理，最大是Rows-1, Cols-1。</para>
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <param name="colIndex"></param>
        /// <returns></returns>
        public double this[int rowIndex, int colIndex]
        {
            get
            {
                return _items[rowIndex - 1, colIndex - 1];
            }
            set
            {
                _items[rowIndex - 1, colIndex - 1] = value;
            }
        }

        public static Matrix operator +(Matrix matrixA, Matrix matrixB)
        {
            if ((matrixA.Rows != matrixB.Rows) || (matrixA.Cols != matrixB.Cols))
            {
                throw new MatrixException("相加的两个矩阵的维度不一样");
            }

            Matrix result = new Matrix(matrixA.Rows, matrixA.Cols);
            for (int r = 1; r <= matrixA.Rows; r++)
                for (int c = 1; c <= matrixA.Cols; c++)
                {
                    result[r, c] = matrixA[r, c] + matrixB[r, c];
                }
            return result;
        }

        public static Matrix operator -(Matrix matrixA, Matrix matrixB)
        {
            if ((matrixA.Rows != matrixB.Rows) || (matrixA.Cols != matrixB.Cols))
            {
                throw new MatrixException("相减的两个矩阵的维度不一样");
            }

            Matrix result = new Matrix(matrixA.Rows, matrixA.Cols);
            for (int r = 1; r <= matrixA.Rows; r++)
                for (int c = 1; c <= matrixA.Cols; c++)
                {
                    result[r, c] = matrixA[r, c] - matrixB[r, c];
                }
            return result;
        }

        public static Matrix operator *(double A, Matrix matrix)
        {
            Matrix result = new Matrix(matrix);
            for (int r = 1; r <= matrix.Rows; r++)
                for (int c = 1; c <= matrix.Cols; c++)
                {
                    result[r, c] = A * matrix[r, c];
                }
            return result;
        }

        public static Matrix operator *(Matrix matrix, double A)
        {
            return A * matrix;
        }


        public static Matrix operator *(Matrix matrixA, Matrix matrixB)
        {
            if (matrixA.Rows == 1 && matrixA.Cols == 1)  //维度1的方阵作为数字处理
            {
                return matrixA[1, 1] * matrixB;
            }

            if (matrixB.Rows == 1 && matrixB.Cols == 1)
            {
                return matrixB[1, 1] * matrixA;
            }

            if (matrixA.Cols != matrixB.Rows)
            {
                throw new MatrixException("相乘的两个矩阵的维度不匹配");
            }

            Matrix result = new Matrix(matrixA.Rows, matrixB.Cols);

            for (int r = 1; r <= matrixA.Rows; r++)
            {
                for (int c = 1; c <= matrixB.Cols; c++)
                {
                    double item = 0;
                    for (int i = 1; i <= matrixA.Cols; i++)
                    {
                        item += matrixA[r, i] * matrixB[i, c];
                    }
                    result[r, c] = item;
                }
            }
            return result;
        }

        public static Matrix operator ^(Matrix matrix, int p)
        {
            if (p == 1)
            {
                return matrix;
            }

            if (p > 1)
            {
                Matrix result = matrix;
                for (int i = 2; i <= p; i++)
                {
                    result = result * matrix;
                }
                return result;
            }

            if (p == -1)
            {

            }

            throw new MatrixException("指数不支持");

        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            for (int r = 1; r <= Rows; r++)
            {
                for (int c = 1; c <= Cols; c++)
                {
                    builder.Append(String.Format("{0:0.0000}", this[r, c])).Append(c == Cols ? ";" : ",");
                }
                builder.Append(Environment.NewLine);
            }
            return builder.ToString();
        }



    }
}
