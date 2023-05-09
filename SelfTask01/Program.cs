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
int IsItAcceptable(char ChSourse)
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
int CountNotAcceptable(string text)
//для данного на входе стринга находит число "недопустимых" букв, 
// то есть не входящих в эталонный стринг =алфавит, за исключением пробелов
// и запоминает их положение (индекс) в исходном стринге
{
    int[] PositionOfBlanks = new int[128];
    int[] PositionOfNonAcceptables = new int[128];
    int CountBlanks = 0; PositionOfBlanks[0] = 0;
    int CountAliens = 0;
    if (text.Length > 0)
    {
        for (int i = 0; i < text.Length; i++)
        {
            if (IsItAcceptable(text[i]) <= 0)
            {
                if (text[i] != ' ')
                {
                    PositionOfNonAcceptables[CountAliens] = i;
                    CountAliens++;
                }
                else //(text[i] == ' ')
                {
                    CountBlanks++;
                    PositionOfBlanks[0] = CountBlanks;//в нулевую ячейку массива PositionOfBlanks пишем число пробелов
                    PositionOfBlanks[CountBlanks] = i;
                }
            }
        }
        // блок контрольной печати результатов
        System.Console.WriteLine($" недопустимых символов {CountAliens}");
        if (CountAliens > 0)
        {
            for (int i = 0; i < CountAliens; i++)
            {
                int j = PositionOfNonAcceptables[i];
                System.Console.WriteLine($" {i}: недопустимая буква: {text[j]}  на позиции {PositionOfNonAcceptables[i]},");
            };
        };

        System.Console.WriteLine($" пробелов {CountBlanks} = {PositionOfBlanks[0]}");
        for (int i = 1; i <= CountBlanks; i++)
        {
            System.Console.WriteLine($" пробел номер {i} на позиции {PositionOfBlanks[i]}, ");
        };
    };
    return CountAliens;
}
int CountDifTwins(string text) //для данного на входе стринга находит число пар "близнецов":
// символ на i-м месте с начала совпадает с символом на i-м месте с конца 
{
    int CountDif = 0;
    if (text.Length > 0)
    {
        int centre = text.Length / 2 - 1;
        // int IndFirst = 0;
        int Last = text.Length - 1;
        for (int i = 0; i <= centre; i++)
        {
            //System.Console.Write($" {i}-й слева символ   {text[i]}   VS");
            //System.Console.WriteLine($" {i}-й справа символ   {text[Last - i]}");
            if (text[i] != text[Last - i])
            {
                CountDif++;
            }
        }
    }
    //System.Console.WriteLine($" разных пар символов {CountDif}");
    return CountDif;
}

string Word = ReadString("Введите текст (от 1 до 128 символов):");
if (Word.Length > 0)
{
    if (Word.Length > 128)
    {
        System.Console.WriteLine("Warning: Вводимая фраза слишком длинная (более 128 символов)");
    };
    int CountNA = CountNotAcceptable(Word);
    if (CountNA == 0)
    {
        System.Console.WriteLine($" введенный текст:");
        System.Console.WriteLine(Word);
        System.Console.WriteLine($" является допустимым");
    }
    else { System.Console.WriteLine($" введенный текст содержит недопустимые буквы"); }
    int CountDif = CountDifTwins(Word);
    if (CountDifTwins(Word) == 0)
    {
        System.Console.WriteLine($" введенный текст:");
        System.Console.WriteLine(Word);
        //System.Console.WriteLine($" является допустимым");
        System.Console.WriteLine($" является палиандром");
    }
    else { System.Console.WriteLine($" введенный текст не является палиандром"); }
}
else
{
    System.Console.WriteLine(" Вы ввели пустой стринг. Повторите ввод.");
};

