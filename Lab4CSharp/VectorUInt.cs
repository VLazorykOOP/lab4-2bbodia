
public class VectorUInt
{
    private uint[] _vector;
    private uint _size;
    private State _codeError;
    private static uint _vectorCount;

    public VectorUInt() : this(1)
    {
    }
    public VectorUInt(uint size)
    {
        _size = size;
        _vector = new uint[size];
        _vectorCount++;
        _codeError = State.Ok;
    }
    public VectorUInt(uint size, uint value)
    {
        _size = size;
        _vector = new uint[size];
        InputVector(value);
        _vectorCount++;
        _codeError = State.Ok;
    }

    ~VectorUInt()
    {
        _vectorCount--;
        Console.WriteLine("Vector finalizer");
    }

    public void InputVectorFromKeyboard()
    {
        Console.WriteLine("Input vector");
        for (int i = 0; i < _vector.Length; i++)
        {
            Console.Write("Input element {0}: ", i);
            _vector[i] = uint.Parse(Console.ReadLine()!);
        }
    }
    public void InputVector(uint value)
    {
        for (int i = 0; i < _vector.Length; i++)
        {
            _vector[i] = value;
        }
    }
    public override string ToString()
    {
        return $"Vector with size - {_size} : {string.Join(", ", _vector)}";
    }

    public override bool Equals(object? obj)
    {
        if (obj is VectorUInt vector)
        {
            return this == vector;
        }
        else
        {
            return false;

        }
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_vector, Size);
    }

    public static uint VectorsCount => _vectorCount;
    public uint Size => _size;

    public State CodeError
    {
        get { return _codeError; }
        private set { _codeError = value; }
    }

    public uint this[int index]
    {
        get
        {
            if (index < 0 || index > Size - 1)
            {
                CodeError = State.OutOfBound;
                return 0;
            }
            else
            {
                return _vector[index];
            }
        }
        set
        {
            if (index < 0 || index > Size - 1)
            {
                CodeError = State.OutOfBound;
            }
            else
            {
                _vector[index] = value;
            }
        }
    }

    public static VectorUInt operator ++(VectorUInt vector) => vector + 1;
    public static VectorUInt operator --(VectorUInt vector) => vector - 1;
    public static VectorUInt operator +(VectorUInt vector, int number)
    {
        var tmp = new VectorUInt(vector.Size);
        for (int i = 0; i < tmp.Size; i++)
        {
            tmp[i] = (uint)(vector[i] + number);
        }
        return tmp;
    }
    public static VectorUInt operator +(int number, VectorUInt vector) => vector + number;
    public static VectorUInt operator +(VectorUInt vector1, VectorUInt vector2)
    {
        if (vector1.Size != vector2.Size)
        {
            return vector1.Size > vector2.Size ? vector1 : vector2;
        }
        VectorUInt result = new VectorUInt(vector2.Size);
        for (int i = 0; i < vector2.Size; i++)
        {
            result[i] = vector1[i] + vector2[i];
        }
        return result;
    }
    public static VectorUInt operator -(VectorUInt vector, int number) => vector + (-number);
    public static VectorUInt operator -(VectorUInt vector1, VectorUInt vector2)
    {
        if (vector1.Size != vector2.Size)
        {
            return vector1.Size > vector2.Size ? vector1 : vector2;
        }
        VectorUInt result = new VectorUInt(vector2.Size);
        for (int i = 0; i < vector2.Size; i++)
        {
            result[i] = vector1[i] - vector2[i];
        }
        return result;
    }
    public static VectorUInt operator *(VectorUInt vector, int number)
    {
        var result = new VectorUInt(vector.Size);
        for (int i = 0; i < result.Size; i++)
        {
            result[i] = (uint)(vector[i] * number);
        }
        return result;
    }
    public static VectorUInt operator *(int number, VectorUInt vector) => vector * number;
    public static uint operator *(VectorUInt vector1, VectorUInt vector2)
    {
        if (vector1.Size != vector2.Size)
        {
            throw new Exception("Size of vectors must be equal");
        }
        uint result = default;
        for (int i = 0; i < vector1.Size; i++)
        {
            result += vector1[i] * vector2[i];
        }
        return result;
    }
    public static bool operator ==(VectorUInt vector1, VectorUInt vector2)
    {
        if (vector1.Size != vector2.Size)
        {
            return false;
        }
        for (int i = 0; i < vector1.Size; i++)
        {
            if (vector1[i] != vector2[i])
            {
                return false;
            }
        }
        return true;
    }
    public static bool operator !=(VectorUInt vector1, VectorUInt vector2) => !(vector1 == vector2);
    public static bool operator >(VectorUInt vector1, VectorUInt vector2)
    {
        if (vector1.Size != vector2.Size)
        {
            throw new Exception("Size of vectors must be equal");
        }
        for (int i = 0; i < vector1.Size; i++)
        {
            if (vector1[i] <= vector2[i])
            {
                return false;
            }
        }
        return true;
    }
    public static bool operator <(VectorUInt vector1, VectorUInt vector2)
    {
        if (vector1.Size != vector2.Size)
        {
            throw new Exception("Size of vectors must be equal");
        }
        for (int i = 0; i < vector1.Size; i++)
        {
            if (vector1[i] >= vector2[i])
            {
                return false;
            }
        }
        return true;
    }

    public static bool operator >=(VectorUInt vector1, VectorUInt vector2) => vector1 < vector2 ? false : true;
    public static bool operator <=(VectorUInt vector1, VectorUInt vector2) => vector1 > vector2 ? false : true;

    public static bool operator true(VectorUInt vector)
    {
        if (vector.Size != 0)
        {
            for (int i = 0; i < vector.Size; i++)
            {
                if (vector[i] != 0)
                {
                    return true;
                }
            }
        }
        return false;
    }
    public static bool operator false(VectorUInt vector) => vector.Size == 0;
    public static bool operator !(VectorUInt vector) => vector.Size == 0;
}
