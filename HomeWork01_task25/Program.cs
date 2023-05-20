//Задача 25: Напишите цикл, который принимает на вход два числа (A и B) 
//и возводит число A в натуральную степень B.
void Main()
{
    int Abase = ReadInt("Введите число, которое будем возводить в степень: ");
    int BDegree = ReadInt("Введите степень (натуральное положительное число): ");
    if (BDegree <= 0)
    {
        Console.WriteLine($"{BDegree} - недопустимая степень: степень должна быть положительным целым числом");
    }
    else
    {
        Console.WriteLine($"{Abase} в степени {BDegree} = {IntInIntDegree(Abase, BDegree)}");
    }
}

int IntInIntDegree(int a, int b)
{
    int product = 1;
    if (b <= 0)
    {
        Console.WriteLine($"{b}  - недопустимая степень");
    }
    else
    {
        for (int i = 1; i <= b; i++)
        {
            product *= a;
            //prod=prod*a;
        }
    };
    return product;
}
int ReadInt(string text)
{
    System.Console.Write(text);
    return Convert.ToInt32(Console.ReadLine());
}

Main();