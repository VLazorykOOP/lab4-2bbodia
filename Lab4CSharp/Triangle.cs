class Triangle
{
    protected int _a;
    protected int _b;
    protected int _c;
    protected int _color;

    public Triangle(int a, int b, int c, int color)
    {
        A = a;
        B = b;
        C = c;
        _color = color;
    }

    public override string ToString()
    {
        return $"Triangle: a = {_a}, b = {_b}, c = {_c}, color = {_color}";
    }

    public int GetPerimeter()
    {
        if (this)
        {
            return _a + _b + _c;
        }
        else
        {
            throw new Exception("Doesn`t exist");
        }

    }

    public double GetArea()
    {
        if (this)
        {
            var p = GetPerimeter() / 2;
            return Math.Sqrt(p * (p - _a) * (p - _b) * (p - _c));
        }
        else
        {
            throw new Exception("Doesn`t exist");
        }

    }


    public int A
    {
        get { return _a; }
        set
        {

            if (value <= 0)
            {
                throw new Exception("a must be > 0");
            }
            else
            {
                _a = value;
            }
        }

    }
    public int B
    {
        get { return _b; }
        set
        {

            if (value <= 0)
            {
                throw new Exception("b must be > 0");
            }
            else
            {
                _b = value;
            }
        }

    }
    public int C
    {
        get { return _c; }
        set
        {

            if (value <= 0)
            {
                throw new Exception("c must be > 0");
            }
            else
            {
                _c = value;
            }
        }

    }
    public int Color
    {
        get { return _color; }

    }

    public static void ShowTriangles(IEnumerable<Triangle> triangles)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        foreach (var triangle in triangles)
        {
            Console.WriteLine(triangle.ToString());
            try
            {
                Console.WriteLine($"Perimetr = {triangle.GetPerimeter()}");
                Console.WriteLine($"Area = {triangle.GetArea()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            Console.WriteLine(new String('-', 45));
        }
        Console.ResetColor();
    }

    public int this[int index] => index switch
    {
        0 => _a,
        1 => _b,
        2 => _c,
        3 => _color,
        _ => throw new IndexOutOfRangeException("Index must be 0, 1 or 2")
    };

    public static Triangle operator ++(Triangle t1)
    {
        return new Triangle(t1._a + 1, t1._b + 1, t1._c + 1, t1._color);
    }
    public static Triangle operator --(Triangle t1)
    {
        return new Triangle(t1._a - 1, t1._b - 1, t1._c - 1, t1._color);
    }

    public static bool operator true(Triangle t1)
    {
        int maxSide = new List<int> { t1._a, t1._b, t1._c }.Max();
        int sum = t1._a + t1._b + t1._c - maxSide;
        return sum > maxSide;
    }
    public static bool operator false(Triangle t1)
    {
        int maxSide = new List<int> { t1._a, t1._b, t1._c }.Max();
        int sum = t1._a + t1._b + t1._c - maxSide;
        return !(sum > maxSide);
    }

    public static Triangle operator *(Triangle triangle, int number)
    {
        return new Triangle(triangle._a * number, triangle._b * number, triangle._c * number, triangle._color);
    }

    public static Triangle operator *(int number, Triangle triangle)
    {
        return triangle * number;
    }

    public static implicit operator string(Triangle triangle)
    {
        return $"{triangle.A} {triangle.B} {triangle.C} {triangle.Color}";
    }
    public static explicit operator Triangle(string str)
    {
        var arr = str.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        return new Triangle(int.Parse(arr[0]), int.Parse(arr[1]), int.Parse(arr[2]), int.Parse(arr[3]));
    }
}