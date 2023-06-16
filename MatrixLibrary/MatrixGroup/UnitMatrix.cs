using System;
using System.Collections.Generic;
using System.Text;

namespace MatrixLibrary.MatrixGroup
{
    /// <summary>
    /// 单位矩阵
    /// </summary>
    public class UnitMatrix : Matrix
    {
        public UnitMatrix(int rank) : base(rank, rank)
        {
            for (int r = 0; r < rank; r++)
            {
                for (int c = 0; c < rank; c++)
                {
                    if (r == c)
                    {
                        _items[r, c] = 1;
                    }
                    else
                    {
                        _items[r, c] = 0;
                    }
                }
            }
        }

        public new double this[int rowIndex, int colIndex]
        {
            get
            {
                return _items[rowIndex - 1, colIndex - 1];
            }
        }


    }
}
