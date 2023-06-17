using System;
using System.Collections.Generic;
using System.Text;

namespace MatrixLibrary.MatrixGroup
{
    public class SquareMatrix : Matrix
    {
        protected int _order;

        /// <summary>
        /// 矩阵的行数
        /// </summary>
        public virtual int Rows
        {
            get
            {
                return _order;
            }

        }
        /// <summary>
        /// 矩阵的列数
        /// </summary>
        public virtual int Cols
        {
            get
            {
                return _order;
            }
        }

        public virtual int Order
        {
            get
            {
               return  _order;
            }
        }

        protected internal SquareMatrix() { }

        public SquareMatrix(int order)
        {
            _rows = order;
            _cols = order;
            _order = order;
            _items = new double[_order, _order];
        }

        public SquareMatrix(Matrix matrix)
        {
            if(matrix.Rows != matrix.Cols)
            {
                throw new MatrixException("矩阵不是方阵");
            }
            _rows = matrix.Rows;
            _cols = matrix.Rows;
            _order = matrix.Rows;
            _items = matrix.Items;

        }

        public SquareMatrix(double[,] items)
        {
            if(items.GetLength(0) != items.GetLength(1))
            {
                throw new MatrixException("矩阵不是方阵");
            }
            this._items = items;
            _rows = this._items.GetLength(0);
            _cols = this._items.GetLength(0);
            _order = this._items.GetLength(0);
            _items = items;
        }

        /// <summary>
        /// 获取逆阵
        /// </summary>
        /// <returns></returns>
        public SquareMatrix GetInverseMatrix()
        {
            Determinant determinantA = new Determinant(this);
            double v = determinantA.GetValue();
            if (v == 0)
            {
                throw new MatrixException("矩阵的行列式等于于0");
            }
            if (-0.0001220703125 < v && v < 0.0001220703125)//如果矩阵的行列式极度靠近0的话，给一个警告退出
            {
                throw new MatrixException("矩阵的行列式接近于0");
            }
            SquareMatrix result;
            if (this.Order == 1)
            {
                result = new SquareMatrix(1);
                result[1, 1] = 1 / this[1, 1];
                return result;
            }
            Matrix matrix = (1 / v) * this.GetCompanionMatrix();
            return new SquareMatrix(matrix);

        }

        /// <summary>
        /// 获取伴随阵
        /// </summary>
        /// <returns></returns>
        public SquareMatrix GetCompanionMatrix()
        {
            SquareMatrix result = new SquareMatrix(this.Order);

            for (int r = 1; r<=this.Order; r++)
            {
                for(int c=1; c<=this.Order; c++)
                {
                    SquareMatrix algebraicCofactorMatrix = GetAlgebraicCofactor(r, c);
                    Determinant determinant = new Determinant(algebraicCofactorMatrix);
                    result[c, r] = Math.Pow(-1, (r + c)) * determinant.GetValue();
                }
            }
            return result;
        }



        /// <summary>
        /// 计算余子式
        /// </summary>
        /// <param name="rowId"></param>
        /// <param name="colId"></param>
        /// <returns></returns>
        public SquareMatrix GetAlgebraicCofactor(int rowId, int colId)
        {
            SquareMatrix reuslt = new SquareMatrix(this.Order - 1);
            int currentRow = 1; // 新行列式的行标
            int currentCol = 1; // 新行列式的列标

            for (int r = 1; r <= Rows; r++)
            {
                if (r == rowId)
                {
                    continue;
                }
                else
                {
                    for (int c = 1; c <= Cols; c++)
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
