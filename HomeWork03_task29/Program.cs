// Задача 29: Напишите программу, которая задаёт массив из 8 элементов и выводит их на экран.
// Подсказки: Приём массива с терминала (одной строкой)
//int[] ArrToBeFilled = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
//
// Console.WriteLine("[" + string.Join(", ", ArrayToPrint) + "]");// Вывод массива через заданный разделитель
void Task29()
{
    int ArrayLen = ReadInt("Задайте длину массива чисел: ");
    int[] ArrayF = new int[ArrayLen];
    
    // PrintArray(ArrayF); // сначала массив заполнен нулями
    //     заполняем с использованием генерации случайных чисел
    System.Console.WriteLine($"заполняем с использованием генерации случайных чисел от нуля до 9: ");
    ArrayF = FillArrayByRandomInteger(ArrayLen, 0, 10);
    PrintArray(ArrayF);
    //
    // заполняем с использованием функции ввода с консоли
    ArrayF = FillArrayFromConsole(ArrayLen);
    PrintArray(ArrayF);
        // заполняем без использования функции. 
    // Оказывается больше введенной ранее длины массива - можно и длина переопределяется, меньше - ругается  
    // System.Console.WriteLine($"Введите через пробелы {ArrayF.Length} целых чисел: ");
    // ArrayF = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
    // PrintArray(ArrayF);
}
int ReadInt(string text) // запрашивает число для ввода с консоли и возвращает его после проглатывания с консоли
{
    System.Console.Write(text);
    return Convert.ToInt32(Console.ReadLine());
}
void PrintArray(int[] ArrayToPrint) //печатает на консоль элементы массива в строку с разделителями ", "
{
    System.Console.WriteLine("[" + String.Join(", ", ArrayToPrint) + "]");
}
int[] FillArrayFromConsole(int LenOfArray)
{
    int[] ArrayToBeFilled = new int[LenOfArray];
    System.Console.WriteLine($"Введите через пробелы {ArrayToBeFilled.Length} целых чисел: ");
    ArrayToBeFilled = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
    return ArrayToBeFilled;
}
int[] FillArrayByRandomInteger(int LenOfArray, int LowLimit, int UpBoundary)
{
    int[] ArrayToBeFilled = new int[LenOfArray];
    if (UpBoundary > LowLimit)
    {
        /// ???? int Rand = new Random().Next(LowLimit,UpBoundary);
        for (int i = 0; i < LenOfArray; i++)
        {
            ArrayToBeFilled[i] = new Random().Next(LowLimit, UpBoundary);
        }
    }
    return ArrayToBeFilled;
}

Task29();
