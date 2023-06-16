using System;
using System.Collections.Generic;
using System.Text;

namespace MatrixLibrary.MatrixGroup
{
    public class Row : Matrix
    {
        public Row(int cols) : base(1, cols) { }

        /// <summary>
        /// <para>外部确定下标从1开始，最大是Cols，以更接近于矩阵运算的实际操作。</para>
        /// <para>内部处理的时候是从0开始处理，最大是Cols-1。</para>
        /// </summary>
        /// <param name="colIndex"></param>
        /// <returns></returns>
        public double this[int colIndex]
        {
            get
            {
                return _items[0, colIndex - 1];
            }
            set
            {
                _items[0, colIndex - 1] = value;
            }
        }
    }
}
