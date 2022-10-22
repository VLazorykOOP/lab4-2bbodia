
using System.Text;

public class MatrixUint
{
    private uint[,] _matrix;
    uint _rows, _columns;
    State _code;
    static uint _matrixsCount;

    public MatrixUint() : this(1, 1)
    {

    }
    public MatrixUint(uint rows, uint cols)
    {
        _rows = rows;
        _columns = cols;
        _matrix = new uint[Rows, Columns];
        _code = State.Ok;
        _matrixsCount++;
    }
    public MatrixUint(uint rows, uint cols, uint value)
    {
        _rows = rows;
        _columns = cols;
        _matrix = new uint[Rows, Columns];
        InputMatrix(value);
        _code = State.Ok;
        _matrixsCount++;
    }

    ~MatrixUint()
    {
        _matrixsCount--;
        Console.WriteLine("Matrix Finalizer");
    }

    public void InputMatrixFromKeyboard()
    {
        Console.WriteLine("Input matrix:");
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                Console.Write("Input element [{0},{1}]: ", i, j);
                _matrix[i, j] = uint.Parse(Console.ReadLine());
            }
        }
    }
    public void InputMatrix(uint value)
    {
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                _matrix[i, j] = value;
            }
        }
    }
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Matrix with size [{Rows},{Columns}] : ");
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                sb.Append(_matrix[i,j] + " ");
            }
            sb.AppendLine();
        }
        return sb.ToString();
    }

    public override bool Equals(object? obj)
    {
        if (obj is MatrixUint matrix)
        {
            return this == matrix;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_matrix, Rows, Columns);
    }

    public uint Rows => _rows;
    public uint Columns => _columns;
    public static uint MatrixsCount => _matrixsCount;

    public State CodeError
    {
        get { return _code; }
        private set { _code = value; }
    }

    public uint this[int rowIndex, int colIndex]
    {
        get
        {
            if (rowIndex < Rows && rowIndex >= 0 && colIndex < Columns && colIndex >= 0)
            {
                return _matrix[rowIndex,colIndex];
            }
            else
            {
                CodeError = State.OutOfBound;
                return 0;
            }
        }
        set
        {
            if (rowIndex < Rows && colIndex < Columns)
            {
                _matrix[rowIndex,colIndex] = value;
            }
            else
            {
                CodeError = State.OutOfBound;
            }
        }
    }
    public uint this[int index]
    {
        get
        {
            if (index < Rows * Columns - 1)
            {

                return _matrix[index / Columns,(int)(index % Columns)];
            }
            else
            {
                CodeError = State.OutOfBound;
                return 0;
            }
        }
        set
        {
            if (index < Rows * Columns - 1)
            {
                _matrix[index / Columns,(int)(index % Columns)] = value;
            }
            else
            {
                CodeError = State.OutOfBound;
            }
        }
    }

    public static MatrixUint operator +(MatrixUint matrix, uint value)
    {
        MatrixUint result = new MatrixUint(matrix.Rows, matrix.Columns);
        for (int i = 0; i < matrix.Rows; i++)
        {
            for (int j = 0; j < matrix.Columns; j++)
            {
                result[i,j] = matrix[i,j] + value;
            }
        }
        return result;
    }
    public static MatrixUint operator +(uint value, MatrixUint matrix) => matrix + value;
    public static MatrixUint operator +(MatrixUint matrix1, MatrixUint matrix2)
    {
        if (matrix1.Rows == matrix2.Rows && matrix1.Columns == matrix2.Columns)
        {
            var result = new MatrixUint(matrix1.Rows, matrix1.Columns);

            for (int i = 0; i < result.Rows; i++)
            {
                for (int j = 0; j < result.Columns; j++)
                {
                    result[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }
            return result;
        }
        else
        {
            return matrix1;
        }
    }
    public static MatrixUint operator ++(MatrixUint matrix) => matrix + 1;
    public static MatrixUint operator -(MatrixUint matrix, uint value)
    {
        MatrixUint result = new MatrixUint(matrix.Rows, matrix.Columns);
        for (int i = 0; i < matrix.Rows; i++)
        {
            for (int j = 0; j < matrix.Columns; j++)
            {
                result[i,j] = matrix[i,j] - value;
            }
        }
        return result;
    }
    public static MatrixUint operator -(MatrixUint matrix1, MatrixUint matrix2)
    {
        if (matrix1.Rows == matrix2.Rows && matrix1.Columns == matrix2.Columns)
        {
            var result = new MatrixUint(matrix1.Rows, matrix1.Columns);

            for (int i = 0; i < result.Rows; i++)
            {
                for (int j = 0; j < result.Columns; j++)
                {
                    result[i, j] = matrix1[i, j] - matrix2[i, j];
                }
            }
            return result;
        }
        else
        {
            return matrix1;
        }
    }
    public static MatrixUint operator --(MatrixUint matrix) => matrix - 1;
    public static MatrixUint operator *(MatrixUint matrix, uint value)
    {
        MatrixUint result = new MatrixUint(matrix.Rows, matrix.Columns);
        for (int i = 0; i < matrix.Rows; i++)
        {
            for (int j = 0; j < matrix.Columns; j++)
            {
                result[i, j] = matrix[i,j] * value;
            }
        }
        return result;
    }
    public static MatrixUint operator *(uint value, MatrixUint matrix) => matrix * value;
    public static MatrixUint operator *(MatrixUint matrix, VectorUInt vector)
    {
        if (matrix.Columns == vector.Size)
        {
            MatrixUint result = new MatrixUint(1, matrix.Columns);
            for (int i = 0; i < matrix.Rows; i++)
            {
                uint rowResult = default;
                for (int j = 0; j < matrix.Columns; j++)
                {
                    rowResult += matrix[i, j] * vector[j];
                }
                result[0, i] = rowResult; 
            }
            return result;
        }
        else
        {
            return matrix;
        }

    }
    public static MatrixUint operator *(MatrixUint matrix1, MatrixUint matrix2)
    {
        if (matrix1.Columns == matrix2.Rows)
        {
            MatrixUint result = new MatrixUint(matrix1.Rows, matrix2.Columns);
            for (int i = 0; i < result.Rows; i++)
            {
                for (int j = 0; j < result.Columns; j++)
                {
                    for (int k = 0; k < matrix1.Columns; k++)
                    {
                        result[i, j] += matrix1[i, k] * matrix2[k, j];
                    }
                }
            }
            return result;
        }
        else return matrix1;
    }
    public static bool operator true(MatrixUint matrix)
    {
        if (matrix.Rows != 0 && matrix.Columns != 0)
        {
            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    if (matrix[i,j] != 0) continue;
                    else return false;
                }
            }
            return true;
        }
        return false;
    }
    public static bool operator false(MatrixUint matrix)
    {
        return matrix.Columns == 0 && matrix.Rows == 0;
    }
    public static bool operator !(MatrixUint matrix)
    {
        return matrix.Columns == 0 && matrix.Rows == 0;
    }

    public static bool operator ==(MatrixUint matrix1, MatrixUint matrix2)
    {
        if (matrix1.Rows == matrix2.Rows && matrix1.Columns == matrix2.Columns)
        {
            for (int i = 0; i < matrix1.Rows; i++)
            {
                for (int j = 0; j < matrix1.Columns; j++)
                {
                    if (matrix1[i,j] != matrix2[i,j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        return false;
    }
    public static bool operator !=(MatrixUint matrix1, MatrixUint matrix2) => !(matrix1 == matrix2);

    public static bool operator >(MatrixUint matrix1, MatrixUint matrix2)
    {
        if (matrix1.Rows == matrix2.Rows && matrix1.Columns == matrix2.Columns)
        {
            for (int i = 0; i < matrix1.Rows; i++)
            {
                for (int j = 0; j < matrix1.Columns; j++)
                {
                    if (matrix1[i, j] <= matrix2[i, j])
                        return false;
                }
            }
            return true;
        }
        throw new Exception("Matrixs must be with the same size");
    }

    public static bool operator <(MatrixUint matrix1, MatrixUint matrix2)
    {
        if (matrix1.Rows == matrix2.Rows && matrix1.Columns == matrix2.Columns)
        {
            for (int i = 0; i < matrix1.Rows; i++)
            {
                for (int j = 0; j < matrix1.Columns; j++)
                {
                    if (matrix1[i, j] >= matrix2[i, j])
                        return false;
                }
            }
            return true;
        }
        throw new Exception("Matrixs must be with the same size");
    }

    public static bool operator >=(MatrixUint matrix1, MatrixUint matrix2) => matrix1 < matrix2 ? false : true;
    public static bool operator <=(MatrixUint matrix1, MatrixUint matrix2) => matrix1 > matrix2 ? false : true;

}