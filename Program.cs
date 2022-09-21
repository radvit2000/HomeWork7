double RandRealNumder(int min, int max, int amount)
{
    Random rand = new Random();
    double fractionPart = rand.NextDouble();
    int wholePart = rand.Next(min, max);
    double result = Math.Round(wholePart + fractionPart, amount);
    return result;
}

double[,] RandFractionMatrix(int line, int column, int min, int max, int amount)
{
    double[,] array = new double[line, column];
    for (int i = 0; i < line; i++)
    {
        for (int j = 0; j < column; j++)
        {
            array[i, j] = RandRealNumder(min, max, amount);
        }
    }
    return array;
}

int[,] RandMatrix(int line, int column, int min, int max)
{
    int[,] array = new int[line, column];

    for (int i = 0; i < line; i++)
    {
        for (int j = 0; j < column; j++)
        {
            array[i, j] = new Random().Next(min, max);
        }
    }
    return array;
}

void WriteIntMatrix(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]} ");
        }
        Console.WriteLine();
    }
}

void WriteDoubleMatrix(double[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]} ");
        }
        Console.WriteLine();
    }
}

void Exercise47()
{
    //  Задайте двумерный массив размером m×n, 
    // заполненный случайными вещественными числами.
    Console.WriteLine("Введите количество строк");
    int line = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("Введите количество столбцов");
    int column = Convert.ToInt32(Console.ReadLine());

    double[,] array = RandFractionMatrix(line, column, 10, 99, 1);
    WriteDoubleMatrix(array);
}

int GetElement(int number, int[,] array)
{
    int length = array.GetLength(0) * array.GetLength(1);
    if (number > length)
    {
        Console.WriteLine("Такого элемента нет");
        return -1;
    }
    else
    {
        int i = number / array.GetLength(0);
        int j = (number % array.GetLength(1)) - 1;
        return array[i, j];
    }
}

void Exercise50()
{
    //Напишите программу, которая на вход принимает позиции элемента в двумерном массиве,
    //и возвращает значение этого элемента или же указание, что такого элемента нет.

    int[,] array = RandMatrix(4, 4, 10, 99);
    WriteIntMatrix(array);
    Console.WriteLine("Введите порядковый номер элемента");

    int number = Convert.ToInt32(Console.ReadLine());
    int element = GetElement(number, array);
    if (element == -1)
    {
        Console.WriteLine("Такого элемента нет");
    }
    else
    {
        Console.WriteLine(element);
    }

}

double[] ColumnAverage(int[,] array)
{
    double[] average = new double[array.GetLength(1)];
    for (int i = 0; i < array.GetLength(1); i++)
    {
        int sum = 0;


        for (int j = 0; j < array.GetLength(0); j++)
        {
            sum += array[j, i];

        }
        average[i] = Math.Round(Convert.ToDouble(sum) / array.GetLength(0), 1);
    }
    return average;

}

void WriteDoubleArray(double[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        Console.Write($"{array[i]} ");
    }
    Console.WriteLine();

}

void WriteIntArray(int[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        Console.Write($"{array[i]} ");
    }
    Console.WriteLine();

}

void Exercise52()
{
    //Задайте двумерный массив из целых чисел. 
    //Найдите среднее арифметическое элементов в каждом столбце.
    int[,] array = RandMatrix(5, 6, 0, 10);
    WriteIntMatrix(array);
    double[] average = ColumnAverage(array);
    WriteDoubleArray(average);
}

int[] SortArray(int[] array)
{
    int max = 0;
    int reserv = 0;
    int len = array.Length;
    for (int i = 0; i < len; i++)
    {
        max = i;
        for (int j = i + 1; j < len; j++)
        {
            if (array[max] < array[j])
            {
                max = j;
            }
        }
        reserv = array[i];
        array[i] = array[max];
        array[max] = reserv;
    }
    return array;
}

int[,] SortLineMatrix(int[,] array)
{
    int[] sort = new int[array.GetLength(1)];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            sort[j] = array[i, j];
        }
        sort = SortArray(sort);
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = sort[j];
        }
    }
    return array;
}

void Exercise54()
{
    //Задайте двумерный массив. Напишите программу, 
    //которая упорядочит по убыванию элементы каждой строки
    //двумерного массива.
    int[,] array = RandMatrix(5, 5, 1, 10);
    WriteIntMatrix(array);
    Console.WriteLine();
    array = SortLineMatrix(array);
    WriteIntMatrix(array);
}

int SumArray(int[] array)
{
    int sum = 0;
    for (int i = 0; i < array.Length; i++)
    {
        sum += array[i];
    }
    return sum;
}

int MinSumLines(int[,] array)
{
    int[] sums = new int[array.GetLength(0)];
    int[] line = new int[array.GetLength(1)];

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            line[j] = array[i, j];
        }
        sums[i] = SumArray(line);
    }
    int min = 0;
    for (int i = 0; i < sums.Length; i++)
    {
        if (sums[min] > sums[i])
        {
            min = i;
        }
    }
    return min + 1;
}

void Exercise56()
{
    //Задайте прямоугольный двумерный массив. 
    //Напишите программу, которая будет находить строку
    // с наименьшей суммой элементов.
    int[,] array = RandMatrix(4, 3, 1, 10);
    WriteIntMatrix(array);
    int number = MinSumLines(array);
    Console.WriteLine($"{number} строка");

}

int SumMultiplyArrays(int[] array1, int[] array2)
{
    int sum = 0;
    for (int i = 0; i < array1.Length; i++)
    {
        sum = sum + array1[i] * array2[i];
    }
    return sum;
}

int[,] MatrixMultiply(int[,] matrix1, int[,] matrix2)
{
    int[,] result = new int[matrix1.GetLength(0), matrix1.GetLength(1)];
    int[] line = new int[matrix1.GetLength(1)];
    int[] column = new int[matrix1.GetLength(0)];
    for (int i = 0; i < matrix1.GetLength(0); i++)
    {
        for (int j = 0; j < matrix1.GetLength(1); j++)
        {
            for (int k = 0; k < line.Length; k++)
            {
                line[k] = matrix1[i, k];
            }
            for (int k = 0; k < matrix2.GetLength(0); k++)
            {
                column[k] = matrix2[k, j];
            }
            result[i, j] = SumMultiplyArrays(line, column);
        }
    }
    return result;
}

void Exercise58()
{
    int[,] matrix1 = RandMatrix(3, 3, 1, 9);
    int[,] matrix2 = RandMatrix(3, 3, 1, 9);
    int[,] matrixResult = MatrixMultiply(matrix1, matrix2);

    WriteIntMatrix(matrix1);
    Console.WriteLine();
    WriteIntMatrix(matrix2);
    Console.WriteLine();
    WriteIntMatrix(matrixResult);
    Console.WriteLine();
}

int[,,] RandIntTriblArray(int lvl, int line, int column, int min, int max)
{
    int num = min;
    bool repeat = true;
    int[,,] array = new int[lvl, line, column];
    for (int i = 0; i < lvl; i++)
    {
        for (int j = 0; j < line; j++)
        {
            for (int k = 0; k < column; k++)
            {
                repeat = true;
                while (repeat)
                {
                    num = new Random().Next(min, max);
                    repeat = false;
                    foreach (int l in array)
                    {
                        if (l == num)
                        {
                            repeat = true;
                        }
                    }
                }
                array[i, j, k] = num;
            }
        }
    }
    return array;
}

void WriteTribleArray(int[,,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
            {
                Console.Write($"{array[i, j, k]}({i},{j},{k}) ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}

void Exercise60()
{
    //Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. 
    //Напишите программу, которая будет построчно выводить массив, 
    //добавляя индексы каждого элемента.
    int[,,] array = RandIntTriblArray(4, 4, 4, 10, 100);
    WriteTribleArray(array);
}

string[,] SpiralMatrix(int firstLen, int secondLen)
{
    string[,] array = new string[firstLen, secondLen];
    for (int i = 0; i < firstLen; i++)
    {
        for (int j = 0; j < secondLen; j++)
        {
            array[i, j] = "0";
        }
    }
    int num = 1;
    int line = 0;
    int column = 0;
    int speedLine = 0;
    int speedColumn = 1;
    for (int i = 0; i < firstLen * secondLen; i++)
    {

        if (num < 10)
        {
            array[line, column] = "0" + Convert.ToString(num);
        }
        else
        {
            array[line, column] = Convert.ToString(num);
        }


        if (speedColumn == 1)
        {
            if (column + speedColumn > secondLen - 1)
            {
                speedColumn = 0;
                speedLine = 1;

            }
            else if (array[line, column + speedColumn] != "0")
            {
                speedColumn = 0;
                speedLine = 1;
            }
        }

        else if (speedLine == 1)
        {

            if (line + speedLine > firstLen - 1)
            {
                speedColumn = -1;
                speedLine = 0;
            }
            else if (array[line + speedLine, column] != "0")
            {
                speedColumn = -1;
                speedLine = 0;
            }
        }

        else if (speedColumn == -1)
        {
            if (column + speedColumn < 0)
            {
                speedColumn = 0;
                speedLine = -1;
            }
            else if (array[line, column + speedColumn] != "0")
            {
                speedColumn = 0;
                speedLine = -1;
            }
        }

        else if (speedLine == -1)
        {
            if (line - speedLine < 0)
            {
                speedColumn = 1;
                speedLine = 0;
            }
            else if (array[line + speedLine, column] != "0")
            {
                speedColumn = 1;
                speedLine = 0;
            }
        }
        line += speedLine;
        column += speedColumn;
        num++;
    }
    return array;
}

void WriteStringMatrix(string[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write(array[i, j] + " ");
        }
        Console.WriteLine();
    }
}

void Exercise62()
{
    //Напишите программу, которая заполнит спирально массив 4 на 4.
    string[,] array = SpiralMatrix(20, 20);
    WriteStringMatrix(array);
}

void WriteRange(int num1, int num2)
{
    Console.Write(num1);

    if (num1 < num2)
    {
        for (int i = num1 + 1; i <= num2; i++)
        {
            Console.Write($", {i}");
        }
    }
    else
    {
        for (int i = num2; i >= num1; i--)
        {
            Console.Write($", {i}");
        }
    }
}

void Exercise64()
{
    //Задайте значения M и N. Напишите программу, 
    //которая выведет все натуральные числа в промежутке от M до N.
    int m = 4;
    int n = 8; 
    WriteRange(m, n);
}

void Exercise66()
{
    //Задайте значения M и N. 
    //Напишите программу, которая найдёт сумму натуральных элементов в промежутке от M до N.
    int m = 1;
    int n = 15; 
    int[] array = new int [n - m + 1];
    for (int i = 0; i < array.Length; i++)
    {
        array[i] = m + i;
    }
    Console.WriteLine(SumArray(array));
}

int Akkerman(int number, int argument)
{
    int result = argument;
    if (number == 0)
    {
        return argument + 1;
    }
    
    else if (number > 0 && argument == 0)
    {
        return Akkerman(number - 1, 1);
    }

    else if (number > 0 && argument > 0)
    {
        return Akkerman(number - 1, Akkerman(number, argument - 1));
    }
    else
    {
        return -1;
    }
}

void Exercise68()
{
    //Напишите программу вычисления функции Аккермана с помощью рекурсии. 
    //Даны два неотрицательных числа m и n.
    int m = 2;
    int n = 3; 
    Console.WriteLine(Akkerman(m, n));
}

// Exercise64();
// Exercise66();
Exercise68();