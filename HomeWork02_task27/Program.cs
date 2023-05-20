//Задача 27. Напишите программу, которая принимает на вход число и выдаёт сумму цифр в числе.

void Main()
{
    int Num = ReadInt("Введите целое число, сумму цифр которого следует найти: ");
    Console.WriteLine($"Для числа {Num} сумма цифр = {SumOfFigures(Num)}");
}

int SumOfFigures(int number)
{
    int sum = 0;
    int n = Math.Abs(number);
    while (n > 0)
    {
        sum = sum + n % 10;
        n = n / 10;
    };
    return sum;
}
int ReadInt(string text)
{
    System.Console.Write(text);
    return Convert.ToInt32(Console.ReadLine());
}

Main();