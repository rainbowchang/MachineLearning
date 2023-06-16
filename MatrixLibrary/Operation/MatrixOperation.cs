using MatrixLibrary.MatrixGroup;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatrixLibrary.Operation
{
    public class MatrixOperation
    {
        public static Matrix Transpose(Matrix matrix)
        {
            Matrix result = new Matrix(matrix.Cols, matrix.Rows);
            for (int row = 1; row <= matrix.Rows; row++)
                for (int col = 1; col <= matrix.Cols; col++)
                {
                    result[col, row] = matrix[row, col];
                }
            return result;
        }

        public static Col Transpose(Row row)
        {
            Col result = new Col(row.Cols);
            for (int i = 1; i <= row.Cols; i++)
            {
                result[i] = row[i];
            }
            return result;
        }

        public static Row Transpose(Col col)
        {
            Row result = new Row(col.Rows);
            for (int i = 1; i <= col.Rows; i++)
            {
                result[i] = col[i];
            }
            return result;
        }

    }
}
