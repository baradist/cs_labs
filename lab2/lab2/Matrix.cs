using System;

namespace lab2
{
    class Matrix
    {
        private int Columns { get; }
        private int Rows { get; }
        // размер квадратной матрицы
        public int? Size
        {
            get
            {
                if (IsSquared)
                {
                    return Rows;
                }
                return null;
            }
        }
        //Реализуйте несколько булевых свойств:                       
        // Является ли матрица квадратной
        public bool IsSquared
        {
            get
            {
                return Columns == Rows;
            }
        }
        // Является ли матрица нулевой
        public bool IsEmpty
        {
            get
            {
                for (int i = 0; i < Rows; i++)
                {
                    for (int j = 0; j < Columns; j++)
                    {
                        if (!data[i, j].Equals(0))
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
        }
        // Является ли матрица единичной
        public bool IsUnity
        {
            get
            {
                if (!IsSquared)
                {
                    return false;
                }
                for (int i = 0; i < Rows; i++)
                {
                    for (int j = 0; j < Columns; j++)
                    {
                        if ((i != j && !data[i, j].Equals(0))
                            || (i == j && !data[i, j].Equals(1)))
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
        }
        // Является ли матрица диагональной
        public bool IsDiagonal
        {
            get
            {
                if (!IsSquared)
                {
                    return false;
                }
                for (int i = 0; i < Rows; i++)
                {
                    for (int j = 0; j < Columns; j++)
                    {
                        if (i != j && !data[i, j].Equals(0))
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
        }
        // Является ли матрица симметричной
        public bool IsSymmetric
        {
            get
            {
                if (!IsSquared)
                {
                    return false;
                }
                for (int i = 0; i < Rows; i++)
                {
                    for (int j = 0; j < Columns; j++)
                    {
                        if (i != j && !data[i, j].Equals(data[j, i]))
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
        }

        private double[,] data;

        public Matrix(int width, int height)
        {
            double[,] asdf = new double[1, 2];
            Columns = width;
            Rows = height;
            data = new double[Rows, Columns];
        }

        public Matrix(double[,] data)
        {
            this.data = (double[,])data.Clone() ?? throw new ArgumentNullException(nameof(data));
            Rows = data.GetLength(0);
            Columns = data.GetLength(1);
        }

        public Matrix(Matrix that) : this(that.data) { }

        public double this[int i, int j]
        {
            get
            {
                return data[i, j];
            }
        }

        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            CheckSizesAreTheSame(m1, m2);
            Matrix result = new Matrix(m1);
            for (int i = 0; i < result.Rows; i++)
            {
                for (int j = 0; j < result.Columns; j++)
                {
                    result.data[i, j] += m2.data[i, j];
                }
            }
            return result;
        }

        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            CheckSizesAreTheSame(m1, m2);
            Matrix result = new Matrix(m1);
            for (int i = 0; i < result.Rows; i++)
            {
                for (int j = 0; j < result.Columns; j++)
                {
                    result.data[i, j] -= m2.data[i, j];
                }
            }
            return result;
        }

        public static Matrix operator *(Matrix m1, double d)
        {
            Matrix result = new Matrix(m1);
            for (int i = 0; i < result.Rows; i++)
            {
                for (int j = 0; j < result.Columns; j++)
                {
                    result.data[i, j] *= d;
                }
            }
            return result;
        }

        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            if (m1.Columns != m2.Rows)
            {
                throw new Exception("First matrix's width must be the same as second matrix's height");
            }
            Matrix result = new Matrix(m2.Columns, m1.Rows);
            double n;
            for (int lY = 0; lY < m1.Rows; lY++)
            {
                for (int rX = 0; rX < m2.Columns; rX++)
                {
                    n = 0;
                    for (int i = 0; i < m1.Columns; i++)
                    {
                        n += m1.data[lY, i] * m2.data[i, rX];
                    }
                    result.data[lY, rX] = n;
                }
            }
            return result;
        }

        private static void CheckSizesAreTheSame(Matrix m1, Matrix m2)
        {
            if (m1.Rows != m2.Rows || m1.Columns != m2.Columns)
            {
                throw new Exception("Matrix's sizes must be the same");
            }
        }

        public static explicit operator Matrix(double[,] arr)
        {
            return new Matrix(arr);
        }

        public Matrix Transpose()
        {
            if (!IsSquared)
            {
                throw new Exception("Matrix must be squared");
            }
            double[,] newDate = new double[Columns, Rows];
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    newDate[j, i] = data[i, j];
                }
            }
            return new Matrix(newDate);
        }

        public double Trace()
        {
            if (!IsSquared)
            {
                throw new Exception("Matrix must be squared");
            }
            double result = 0;
            for (int i = 0; i < Columns; i++)
            {
                result += data[i, i];
            }
            return result;
        }

        public override string ToString()
        {
            string result = "Matrix: Rows=" + Rows + ", Columns=" + Columns + "\n";
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    result += data[i, j] + "\t";
                }
                result += "\n";
            }
            return result;
        }

        public static Matrix GetUnity(int Size)
        {
            Matrix result = new Matrix(Size, Size);
            for (int i = 0; i < Size; i++)
            {
                result.data[i, i] = 1;
            }
            return result;
        }
        public static Matrix GetEmpty(int Size)
        {
            return new Matrix(Size, Size);
        }

        public static Matrix Parse(string s)
        {
            Matrix result;
            if (!TryParse(s, out result))
            {
                throw new FormatException("Coluns number must be the same");
            }
            return result;

        }
        public static bool TryParse(string s, out Matrix m)
        {
            m = null;
            string[] rows = s.Split(',');
            int Rows = rows.Length;
            if (Rows == 0)
            {
                m = new Matrix(new double[0, 0]);
                return true;
            }
            string[] firstLine = rows[0].Trim().Split(' ');
            int Columns = firstLine.Length;
            double[,] data = new double[Rows, Columns];
            for (int i = 0; i < Rows; i++)
            {
                string[] vals = rows[i].Trim().Split(' ');
                if (vals.Length != Columns)
                {
                    return false;
                }
                for (int j = 0; j < Columns; j++)
                {
                    if (!double.TryParse(vals[j], out data[i, j]))
                    {
                        return false;
                    }
                }
            }
            m = new Matrix(data);
            return true;
        }
    }
}
