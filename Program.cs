double randRealNumder(int min, int max, int amount)
{
    Random rand = new Random();
    double fractionPart = rand.NextDouble();
    int wholePart = rand.Next(min, max);
    double result = Math.Round(wholePart + fractionPart, amount);
    return result;
}

double[,] randFractionMatrix(int line, int column, int min, int max, int amount)
{
    double[,] array = new double[line, column];
    for (int i = 0; i < line; i++)
    {
        for (int j = 0; j < column; j++)
        {
            array[i, j] = randRealNumder(min, max, amount);
        }
    }
    return array;
}

int[,] randMatrix(int line, int column, int min, int max)
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

void writeIntMatrix(int[,] array)
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

void writeDoubleMatrix(double[,] array)
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

void exercise47()
{
    //  Задайте двумерный массив размером m×n, 
    // заполненный случайными вещественными числами.
    Console.WriteLine("Введите количество строк");
    int line = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("Введите количество столбцов");
    int column = Convert.ToInt32(Console.ReadLine());

    double[,] array = randFractionMatrix(line, column, 10, 99, 1);
    writeDoubleMatrix(array);
}

int getElement(int number, int[,] array)
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

void exercise50()
{
    //Напишите программу, которая на вход принимает позиции элемента в двумерном массиве,
    //и возвращает значение этого элемента или же указание, что такого элемента нет.

    int[,] array = randMatrix(4, 4, 10, 99);
    writeIntMatrix(array);
    Console.WriteLine("Введите порядковый номер элемента");

    int number = Convert.ToInt32(Console.ReadLine());
    int element = getElement(number, array);
    if (element == -1)
    {
        Console.WriteLine("Такого элемента нет");
    }
    else
    {
        Console.WriteLine(element);
    }

}

double[] columnAverage(int[,] array)
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

void writeDoubleArray(double[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        Console.Write($"{array[i]} ");
    }
    Console.WriteLine();

}

void writeIntArray(int[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        Console.Write($"{array[i]} ");
    }
    Console.WriteLine();

}

void exercise52()
{
    //Задайте двумерный массив из целых чисел. 
    //Найдите среднее арифметическое элементов в каждом столбце.
    int[,] array = randMatrix(5, 6, 0, 10);
    writeIntMatrix(array);
    double[] average = columnAverage(array);
    writeDoubleArray(average);
}

int[] sortArray(int[] array)
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

int[,] sortLineMatrix(int[,] array)
{
    int[] sort = new int[array.GetLength(1)];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            sort[j] = array[i, j];
        }
        sort = sortArray(sort);
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = sort[j];
        }
    }
    return array;
}

void exercise54()
{
    //Задайте двумерный массив. Напишите программу, 
    //которая упорядочит по убыванию элементы каждой строки
    //двумерного массива.
    int[,] array = randMatrix(5, 5, 1, 10);
    writeIntMatrix(array);
    Console.WriteLine();
    array = sortLineMatrix(array);
    writeIntMatrix(array);
}

int sumArray(int[] array)
{
    int sum = 0;
    for (int i = 0; i < array.Length; i++)
    {
        sum += array[i];
    }
    return sum;
}

int minSumLines(int[,] array)
{
    int[] sums = new int[array.GetLength(0)];
    int[] line = new int[array.GetLength(1)];

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            line[j] = array[i, j];
        }
        sums[i] = sumArray(line);
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

void exercise56()
{
    //Задайте прямоугольный двумерный массив. 
    //Напишите программу, которая будет находить строку
    // с наименьшей суммой элементов.
    int[,] array = randMatrix(4, 3, 1, 10);
    writeIntMatrix(array);
    int number = minSumLines(array);
    Console.WriteLine($"{number} строка");

}

int sumMultiplyArrays(int[] array1, int[] array2)
{
    int sum = 0;
    for (int i = 0; i < array1.Length; i++)
    {
        sum = sum + array1[i] * array2[i];
    }
    return sum;
}

int[,] matrixMultiply(int[,] matrix1, int[,] matrix2)
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
            result[i, j] = sumMultiplyArrays(line, column);
        }
    }
    return result;
}

void exercise58()
{
    int[,] matrix1 = randMatrix(3, 3, 1, 9);
    int[,] matrix2 = randMatrix(3, 3, 1, 9);
    int[,] matrixResult = matrixMultiply(matrix1, matrix2);

    writeIntMatrix(matrix1);
    Console.WriteLine();
    writeIntMatrix(matrix2);
    Console.WriteLine();
    writeIntMatrix(matrixResult);
    Console.WriteLine();
}

int[,,] randIntTriblArray(int lvl, int line, int column, int min, int max)
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

void writeTribleArray(int[,,] array)
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

void exercise60()
{
    //Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. 
    //Напишите программу, которая будет построчно выводить массив, 
    //добавляя индексы каждого элемента.
    int[,,] array = randIntTriblArray(4, 4, 4, 10, 100);
    writeTribleArray(array);
}

string[,] spiralMatrix(int firstLen, int secondLen)
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

void writeStringMatrix(string[,] array)
{
    for (int i = 0; i < 4; i++)
    {
        for (int j = 0; j < 4; j++)
        {
            Console.Write(array[i, j] + " ");
        }
        Console.WriteLine();
    }
}

void exercise62()
{
    //Напишите программу, которая заполнит спирально массив 4 на 4.
    string[,] array = spiralMatrix(5, 5);
    writeStringMatrix(array);
    // Console.WriteLine($"_{array[2, 3]}_");
}

exercise62();