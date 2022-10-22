#region Task1

Triangle[] triangles = new[]
  {
    new Triangle(3, 4, 5,1),
    new Triangle(5, 12, 13,2),
    new Triangle(10, 1, 1,1)
};

Triangle.ShowTriangles(triangles);
Console.WriteLine("Changing some parameters of the triangles...");
triangles[0]++;
triangles[1]--;
triangles[2] = triangles[2] * 2;
Triangle.ShowTriangles(triangles);

Console.WriteLine("Read triangle data using indexer");
Console.WriteLine($"Triangle 1: {triangles[0][0]}, {triangles[0][1]}, {triangles[0][2]}");

Console.WriteLine("Converting triangle to string:");
Console.WriteLine(triangles[0]);
Console.WriteLine("Converting string to triangle:");
Triangle triangle = (Triangle)"10 10 10 1";
Console.WriteLine(triangle);

Console.WriteLine("Press button to continue...");
Console.ReadKey();
Console.Clear();
#endregion

#region Task2

VectorUInt vectorUint1 = new VectorUInt(5, 4);
Console.WriteLine(vectorUint1);
VectorUInt vectorUint2 = new VectorUInt(5);
vectorUint2.InputVectorFromKeyboard();
Console.WriteLine(vectorUint2);
Console.WriteLine($"Current vectors count:{VectorUInt.VectorsCount}");
Console.WriteLine();
Console.WriteLine("operator ++ for vector1:");
vectorUint1++;
Console.WriteLine(vectorUint1);
Console.WriteLine();
Console.WriteLine("Adding vector1 and vector2:");
var res = vectorUint1 + vectorUint2;
Console.WriteLine(res);
Console.WriteLine();
Console.WriteLine("Adding vector1 and 5:");
res = vectorUint1 + 5;
Console.WriteLine(res);

Console.WriteLine();
Console.WriteLine("Multiplying vector1 and 5:");
res = vectorUint1 * 5;
Console.WriteLine(res);

Console.WriteLine();
Console.WriteLine("Creating 2 equal vectors and equaling them:");
VectorUInt vectorUint3 = new VectorUInt(5, 4);
VectorUInt vectorUint4 = new VectorUInt(5, 4);
Console.WriteLine(vectorUint3);
Console.WriteLine(vectorUint4);
Console.WriteLine($"vector3 == vector4:{vectorUint3 == vectorUint4}");

Console.WriteLine();
Console.WriteLine("Using operator -- for vector3:");
vectorUint3--;
Console.WriteLine(vectorUint3);
Console.WriteLine(vectorUint4);
Console.WriteLine($"vector3 > vector4:{vectorUint3 > vectorUint4}");
Console.WriteLine($"vector3 < vector4:{vectorUint3 < vectorUint4}");


Console.WriteLine();
Console.WriteLine("Using indexer for vector4:");
Console.WriteLine($"vectorUint4[0] = {vectorUint4[0]}");

Console.WriteLine("Press button to continue...");
Console.ReadKey();
Console.Clear();

#endregion

#region Task3
MatrixUint matrix1 = new MatrixUint(5, 4,4);
Console.WriteLine(matrix1);
MatrixUint matrix2 = new MatrixUint(5,4);
matrix2.InputMatrixFromKeyboard();
Console.WriteLine(matrix2);
Console.WriteLine($"Current matrix count:{MatrixUint.MatrixsCount}");
Console.WriteLine();
Console.WriteLine("operator ++ for matrix1:");
matrix1++;
Console.WriteLine(matrix1);
Console.WriteLine();
Console.WriteLine("Adding matrix1 and matrix2:");
var matrixResult = matrix1 + matrix2;
Console.WriteLine(matrixResult);
Console.WriteLine();
Console.WriteLine("Adding matrix1 and 5:");
matrixResult = matrix1 + 5;
Console.WriteLine(matrixResult);

Console.WriteLine();
Console.WriteLine("Multiplying matrix1 and 5:");
matrixResult = matrix1 * 5;
Console.WriteLine(matrixResult);


Console.WriteLine();
Console.WriteLine("Creating 2 equal matrixs and equaling them:");
MatrixUint matrix3 = new MatrixUint(5, 5,4);
MatrixUint matrix4 = new MatrixUint(5, 5,4);
Console.WriteLine(matrix3);
Console.WriteLine(matrix4);
Console.WriteLine($"matrix3 == matrix4:{matrix3 == matrix4}");

Console.WriteLine();
Console.WriteLine("Using operator -- for matrix3:");
matrix3--;
Console.WriteLine(matrix3);
Console.WriteLine(matrix4);
Console.WriteLine($"matrix3 > matrix4:{matrix3 > matrix4}");
Console.WriteLine($"matrix3 < matrix4:{matrix3 < matrix4}");


Console.WriteLine();
Console.WriteLine("Using indexer for matrix3:");
Console.WriteLine($"matrix[0,0] = {matrix3[0, 0]}");


Console.WriteLine();
Console.WriteLine("Multiplying matrix3 and vector:");
Console.WriteLine(matrix3);
Console.WriteLine(vectorUint2);
var multres = matrix3 * vectorUint2;
Console.WriteLine(multres);
Console.WriteLine("Press button to continue...");
Console.ReadKey();
Console.Clear();

#endregion