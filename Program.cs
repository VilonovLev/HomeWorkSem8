// Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит 
// по убыванию элементы каждой строки двумерного массива.
Console.WriteLine("\nЗадача 54");
int[,] array = CreateRanArrInt(10,10);
PrintArrayInt(array);
PrintArrayInt(SortArrToMin(array));

// Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, 
// которая будет находить строку с наименьшей суммой элементов.
Console.WriteLine("\nЗадача 56");
int[,] rectArray = CreateRanArrInt(4,5);
PrintArrayInt(rectArray);
SearchLineMinSum(rectArray);

// Задача 58: Задайте две матрицы. Напишите программу, 
// которая будет находить произведение двух матриц.
Console.WriteLine("\nЗадача 58");
int [,] firstRandomArr = CreateRanArrInt(3,2);
int [,] secondRandomArr = CreateRanArrInt(2,3);
PrintArrayInt(firstRandomArr);
PrintArrayInt(secondRandomArr);
MatrixProduct(firstRandomArr,secondRandomArr);

// Задача 60: Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. 
// Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
Console.WriteLine("\nЗадача 60");
int [,,] array3D = new int[3,3,5];
PrintArray3D(FillArray3D(array3D));

// Задача 62: Заполните спирально массив 4 на 4.
Console.WriteLine("\nЗадача 62");
int[,] spiralArray = new int[4,4];
PrintArrayInt(FillSpiralArray(spiralArray));
// Задачу решал через while. Интересно узнать будет ли код работать быстрее,
// чем c if else, особенно для более крупных массивов [20,20] | [100,100].

//Методы

int Input(string output)
{
    Console.Write(output);
    return Convert.ToInt32(Console.ReadLine());
}

void PrintArrayInt(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for(int j = 0; j < array.GetLength(1); j++)
        {
            if(array[i, j] > -1)
            {
                Console.Write($" {array[i, j]}  ");
            }
            else 
            {
                Console.Write($"{array[i, j]}  ");
            }
        }
        Console.WriteLine();
    }
    Console.WriteLine("--------------------");
}

int[,] CreateRanArrInt(int line, int column)
{
    int[,] array = new int[line,column];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for(int j = 0; j < array.GetLength(1); j++)
        {
            array[i,j] = new Random().Next(-9,10);
        }
    }
    return array;
}

void MatrixProduct(int[,] firstArr, int[,] secondArr )
{
    int[,] resultArr = new int[firstArr.GetLength(0),secondArr.GetLength(1)];
    if(firstArr.GetLength(1) != secondArr.GetLength(0))
    {
        Console.WriteLine("Матрицы нельзя перемножить.");
    }
    else
    {
        for(int i = 0; i < firstArr.GetLength(0); i++)
        {
            for(int j = 0; j < secondArr.GetLength(1); j++)
            {
                int result = 0;
                for(int c = 0; c < secondArr.GetLength(0); c++)
                {
                    result += firstArr[i,c] * secondArr[c,j];
                }
                resultArr[i,j] += result;
            } 
        }
        PrintArrayInt(resultArr);
    }
}

int[,] SortArrToMin(int[,] arr)
{
    for(int i = 0; i < arr.GetLength(1); i++)
    {
        for(int j = 0; j < arr.GetLength(0); j++)
        {
            for(int c = 0; c < arr.GetLength(1) - 1 - i; c++)
            {
                if(arr[j,c] < arr[j,c+1])
                {
                    int temp = arr[j,c];
                    arr[j,c] = arr[j,c+1];
                    arr[j,c+1] = temp;
                } 
            }
        }
    }      
    return arr;
}

void SearchLineMinSum(int[,] arr)
{
    int indexMinRow = 0;
    int minSumRow = int.MaxValue;

    for(int i = 0; i < arr.GetLength(0); i++)
    { 
        int sumLine = 0;
        for(int j = 0; j < arr.GetLength(1); j++)
        {
            sumLine += arr[i,j];
        }
        if (sumLine < minSumRow)
        {
            minSumRow = sumLine;
            indexMinRow = i;
        }
    }
    Console.WriteLine($"Минимальная сумм элементов в строке {indexMinRow + 1}");
}

int[,,] FillArray3D (int[,,] arr)
{
    int num = 10;
    for(int i = 0; i < arr.GetLength(0); i++)
    {
        for(int j = 0; j < arr.GetLength(1); j++)
        {
            for(int c = 0; c < arr.GetLength(2); c++)
            {
                arr[i,j,c] = num++; 
            }
        }      
    }
    return arr;
}

void PrintArray3D(int[,,] arr)
{
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for(int j = 0; j < arr.GetLength(1); j++)
        {
            for(int c = 0; c < arr.GetLength(2); c++)
            {
                Console.Write(arr[i,j,c] + $"[{i},{j},{c}] "); 
            }
            Console.WriteLine();
        }
        Console.WriteLine();      
    }
}

int[,] FillSpiralArray (int[,] arr)
{
    int count = 0;
    int line = 0;
    int column = 0;
    int maxIndx = spiralArray.GetLength(0)-1;
    int minIndex = 0; 

    while(count < spiralArray.Length)
    {
        while (column < maxIndx | count == spiralArray.Length - 1)
        {
            spiralArray[line,column] = ++count;
            column++;
        }
        while (line < maxIndx | count == spiralArray.Length - 1)
        {
            spiralArray[line,column] = ++count;
            line++;
        }
        maxIndx--;
        while (column > minIndex | count == spiralArray.Length - 1) 
        {
            spiralArray[line,column] = ++count;
            column--;
        }
        minIndex++;
        while (line > minIndex | count == spiralArray.Length - 1)
        {
            spiralArray[line,column] = ++count;
            line--;
        }
    }
    return spiralArray;
}