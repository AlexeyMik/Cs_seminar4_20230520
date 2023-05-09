//Задача: на входе дан буквенный стринг из букв, включающий пробелы, 
// причем буквы могут быть и строчные, и заглавные. 
//Следует определить, является ли стринг палиандром по звучанию, то есть проигнорировать пробелы и UpCase / LoCase букв
//Предварительно проверить, все ли буквы являются звучащими буквами русского алфавита, то есть не 'ь', 'Ъ'
// Аврора -> нет,   75антон -> нет
// Аврорва -> да, Алла -> да, "А роза упала на лапу Азора" -> да 
string ReadString(string text) //проглатывает в стринг строку символов =вводимую последовательность символов, 
// включая пробелы, тоже считаемые вводимые символами 
{
    System.Console.WriteLine(text);
    return Console.ReadLine();
}
int IsIt(char ChSourse)
//Проверяет, является ли данный символ допустимым  IsTheLetterSoundingLetterOfRussianAlphabet
//-1 == не является, 1 == является
{
    string Acceptables = "абвгдеёжзиклмнопрстуфхцшщйэюя";
    // SoundingLetters{'а...
    int Place = -1;
    int ResI = -1;
    for (int i = 0; i < Acceptables.Length; i++)
    {
        if ((ChSourse) == Acceptables[i]) { Place = i; ResI = 1; break; };
    };
    return ResI;
}
int CountNotAcceptable(string text) //для данного на входе стринга находит число "недопустимых" букв
// то есть не входящих в эталонный стринг =алфавит
{
    int CountAliens = 0;
    if (text.Length > 0)
    {
        for (int i = 0; i < text.Length; i++)
        {
            if (IsIt(text[i]) <= 0 && text[i] !=' ')
            {
                CountAliens++;
            }
        }
    }
    System.Console.WriteLine($" недопустимых символов {CountAliens}");
    return CountAliens;
}
// int CountDifTwins(string text) //для данного на входе стринга находит число пар "близнецов":
// // символ на i-м месте с начала совпадает с символом на i-м месте с конца 
// {
//     int CountDif = 0;
//     if (text.Length > 0)
//     {
//         int Last = text.Length - 1;
//         int centre = text.Length / 2 - 1;
//         int IndFirst = 0;
//         int IndLast = text.Length - 1;
//         for (int i = 0; i <= centre; i++)
//         {
//             //System.Console.Write($" {i}-й слева символ   {text[i]}   VS");
//             //System.Console.WriteLine($" {i}-й справа символ   {text[Last - i]}");
//             if (text[i] != text[Last - i])
//             {
//                 CountDif++;
//             }
//         }
//     }
//     //System.Console.WriteLine($" разных пар символов {CountDif}");
//     return CountDif;
// }

string Word = ReadString("Введите текст (от 1 до 128 символов):");
if (Word.Length > 0)
{
    if (Word.Length > 128)
    {
        System.Console.WriteLine("Warning: Вводимая фраза слишком длинная (более 128 символов)");
    };
    int CountNA = CountNotAcceptable(Word);
    if (CountNotAcceptable(Word) == 0)
    {
        System.Console.WriteLine($" введенный текст:");
        System.Console.WriteLine(Word);
        System.Console.WriteLine($" является допустимым");
    }
    else { System.Console.WriteLine($" введенный текст содержит недопустимые буквы"); }
    // int CountDif = CountDifTwins(Word);
    // if (CountDifTwins(Word) == 0)
    // {
    //     System.Console.WriteLine($" введенный текст:");
    //     System.Console.WriteLine(Word);
    //     System.Console.WriteLine($" является допустимым")
    //     //System.Console.WriteLine($" является палиандром");
    // }
    // else { System.Console.WriteLine($" введенный текст не является палиандром"); }
}
else
{
    System.Console.WriteLine(" Вы ввели пустой стринг. Повторите ввод.");
}

