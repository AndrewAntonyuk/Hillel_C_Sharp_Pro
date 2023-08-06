using System;
using System.Collections.Generic;

namespace Task_2_Matrix
{
    public class Matrix<T>
    {
        #region internal data
        private T[,] _record;
        private int _lenRow;
        private int _lenCol;
        #endregion

        #region properties
        public T[,] Record
        {
            get => _record;
            set
            {
                CheckRecord(value);
                _record = value;
            }
        }
        public int LenRow { get => _lenRow; }
        public int LenCol { get => _lenCol; }
        #endregion

        #region constructors
        public Matrix() : this(new T[3, 3])
        {
        }

        public Matrix(Matrix<T> matrix) : this(matrix.Record)
        {
        }

        public Matrix(T[,] matrix)
        {
            Record = new T[matrix.GetLength(0), matrix.GetLength(1)];
            Array.Copy(matrix, Record, Record.Length);
        }
        #endregion

        public T this[int indexRow, int indexCol]
        {
            get
            {
                CheckIndex(indexRow, indexCol);
                return Record[indexRow, indexCol];
            }

            set
            {
                CheckIndex(indexRow, indexCol);
                Record[indexRow, indexCol] = value;
            }
        }

        #region public methods
        public static Matrix<T> operator +(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            var retMatrix = new Matrix<T>(matrix1);

            for (var i = 0; i < matrix1.LenRow && i < matrix2.LenRow; i++)
            {
                for (var j = 0; j < matrix1.LenCol && j < matrix2.LenCol; j++)
                {
                    retMatrix[i, j] = (dynamic)matrix2[i, j] + (dynamic)matrix1[i, j];
                }
            }

            return retMatrix;
        }

        public static Matrix<T> operator -(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            var retMatrix = new Matrix<T>(matrix1);

            for (var i = 0; i < matrix1.LenRow && i < matrix2.LenRow; i++)
            {
                for (var j = 0; j < matrix1.LenCol && j < matrix2.LenCol; j++)
                {
                    retMatrix[i, j] = (dynamic)matrix1[i, j] - (dynamic)matrix2[i, j];
                }
            }

            return retMatrix;
        }

        public static Matrix<T> operator *(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            var retMatrix = new Matrix<T>(matrix1);

            for (var i = 0; i < matrix1.LenRow && i < matrix2.LenRow; i++)
            {
                for (var j = 0; j < matrix1.LenCol && j < matrix2.LenCol; j++)
                {
                    retMatrix[i, j] = (dynamic)matrix2[i, j] * (dynamic)matrix1[i, j];
                }
            }

            return retMatrix;
        }

        public static Matrix<T> operator *(Matrix<T> matrix1, T num)
        {
            var retMatrix = new Matrix<T>(matrix1);

            for (var i = 0; i < matrix1.LenRow; i++)
            {
                for (var j = 0; j < matrix1.LenCol; j++)
                {
                    retMatrix[i, j] = (dynamic)num * (dynamic)matrix1[i, j];
                }
            }

            return retMatrix;
        }

        public static bool operator ==(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            for (var i = 0; i < matrix1.LenRow && i < matrix2.LenRow; i++)
            {
                for (var j = 0; j < matrix1.LenCol && j < matrix2.LenCol; j++)
                {
                    if (!matrix1[i, j].Equals(matrix2[i, j]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool operator !=(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            for (var i = 0; i < matrix1.LenRow && i < matrix2.LenRow; i++)
            {
                for (var j = 0; j < matrix1.LenCol && j < matrix2.LenCol; j++)
                {
                    if (matrix1[i, j].Equals(matrix2[i, j]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Matrix<T> matrix))
                return false;
            else
                return this == matrix;
        }

        public override string ToString()
        {
            string val = string.Empty;

            if (Record != null)
            {
                for (int i = 0; i < LenRow; i++)
                {
                    for (int j = 0; j < LenCol; j++)
                    {
                        if (j < LenCol - 1)
                            val += Record[i, j] + ", ";
                        else
                            val += Record[i, j];
                    }
                    val += "\n";
                }
            }

            return val;
        }

        public override int GetHashCode()
        {
            int hashCode = -334772423;
            hashCode = hashCode * -1521134295 + EqualityComparer<T[,]>.Default.GetHashCode(_record);
            hashCode = hashCode * -1521134295 + _lenRow.GetHashCode();
            hashCode = hashCode * -1521134295 + _lenCol.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<T[,]>.Default.GetHashCode(Record);
            hashCode = hashCode * -1521134295 + LenRow.GetHashCode();
            hashCode = hashCode * -1521134295 + LenCol.GetHashCode();
            return hashCode;
        }
        #endregion

        #region internal methods
        private void CheckRecord(T[,] record)
        {
            var underlyingType = Nullable.GetUnderlyingType(record[0, 0].GetType()) ?? record[0, 0].GetType();
            var itNumber = underlyingType.IsPrimitive || underlyingType == typeof(decimal);

            if (!itNumber)
            {
                throw new ArgumentException("Matrix can be just numeric");
            }

            _lenRow = record.GetLength(0);
            _lenCol = record.GetLength(1);
        }

        private void CheckIndex(int indexRow, int indexCol)
        {
            if (indexRow < 0 || indexRow >= LenRow)
            {
                throw new ArgumentOutOfRangeException($"Index of row {indexRow} out of available range: 0 - {LenRow - 1}");
            }

            if (indexCol < 0 || indexCol >= LenCol)
            {
                throw new ArgumentOutOfRangeException($"Index of column {indexCol} out of available range: 0 - {LenCol - 1}");
            }
        }
        #endregion
    }
}
