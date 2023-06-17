using System;
using System.Collections.Generic;
using System.Text;

namespace MatrixLibrary.MatrixGroup
{
    public class Col : Matrix
    {

        public Col(int rows) : base(rows, 1) { }

        public Col(double[] items)
        {
            _cols = 1;
            _rows = items.Length;
            _items = new double[_rows, 1];
            for(int i =0; i < _rows; i++)
            {
                _items[i, 0] = items[i];
            }
        }

        /// <summary>
        /// <para>外部确定下标从1开始，最大是Rows，以更接近于矩阵运算的实际操作。</para>
        /// <para>内部处理的时候是从0开始处理，最大是Rows-1。</para>
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        public double this[int rowIndex]
        {
            get
            {
                return _items[rowIndex - 1, 0];
            }
            set
            {
                _items[rowIndex - 1, 0] = value;
            }
        }
    }
}
