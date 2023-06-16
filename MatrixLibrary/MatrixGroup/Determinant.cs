using System;
using System.Collections.Generic;
using System.Text;

namespace MatrixLibrary.MatrixGroup
{
    /// <summary>
    /// <para>行列式</para>
    /// <para>作为数字之间组合排列的一种运算符号，本质上是一个数</para>
    /// </summary>
    public class Determinant
    {
        protected readonly int _order;

        public int Order
        {
            get
            {
                return _order;
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
            }
        }

        /// <summary>
        /// 根据方阵生成一个行列式
        /// </summary>
        /// <param name="matrix"></param>
        public Determinant(Matrix matrix)
        {
            if (matrix.Rows != matrix.Cols)
            {
                throw new MatrixException("构造行列式的矩阵应该是方阵！");
            }

            _order = matrix.Rows;

            _items = new double[_order, _order];

            for (int r = 0; r < Order; r++)
            {
                for (int c = 0; c < Order; c++)
                {
                    Items[r, c] = matrix.Items[r, c];
                }
            }
        }

        /// <summary>
        /// 根据维度生成一个初始化的行列式
        /// </summary>
        /// <param name="order"></param>
        public Determinant(int order)
        {
            _order = order;
            _items = new double[_order, _order];
        }


        /// <summary>
        /// <para>外部确定下标从1开始，Order，以更接近于矩阵运算的实际操作。</para>
        /// <para>内部处理的时候是从0开始处理，最大是Order-1。</para>
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

        /// <summary>
        /// 行列式求值
        /// </summary>
        /// <returns></returns>
        public double GetValue()
        {
            if (Order == 1)
            {
                return this[1, 1];
            }
            else if (Order == 2)
            {
                return this[1, 1] * this[2, 2] - this[1, 2] * this[2, 1];
            }
            else
            {
                double result = 0;
                for(int c = 1; c<=Order; c++)
                {
                    result += this[1, c] * GetAlgebraicCofactor(1, c).GetValue() * Math.Pow(-1, (1 + c));
                }
                return result;
            }
        }


        //algebraic cofactor
        public Determinant GetAlgebraicCofactor(int rowId, int colId)
        {
            Determinant reuslt = new Determinant(this.Order - 1);
            int currentRow = 1; // 新行列式的行标
            int currentCol = 1; // 新行列式的列标

            for (int r = 1; r <= Order; r++)
            {
                if (r == rowId)
                {
                    continue;
                }
                else
                {
                    for (int c = 1; c <= Order; c++)
                    {
                        if (c == colId)
                        {
                            continue;
                        }
                        else
                        {
                            reuslt[currentRow, currentCol] = this[r, c];
                            currentCol++;
                        }
                    }
                    currentRow++;
                    currentCol = 1;
                }
            }
            return reuslt;
        }


    }
}
