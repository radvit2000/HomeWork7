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
    double[,] array = new double [line, column];
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
    int[,] array = new int [line, column];
    
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
    for (int i = 0; i < array.GetLength(0) ; i++)
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
    for (int i = 0; i < array.GetLength(0) ; i++)
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

    double [,] array = randFractionMatrix(line, column, 10, 99, 1);
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

void exercise52()
{
    //Задайте двумерный массив из целых чисел. 
    //Найдите среднее арифметическое элементов в каждом столбце.
    int[,] array = randMatrix(5, 6, 0, 10);
    writeIntMatrix(array);
    double[] average = columnAverage(array);
    writeDoubleArray(average);
}
// exercise47();
// exercise50();
exercise52();