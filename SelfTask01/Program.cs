//Задача: на входе дан буквенный стринг из букв, включающий пробелы, 
// пока буквы могут быть только строчными, потом доделаем - и строчные, и заглавные. 
//Следует определить, является ли стринг палиандром по звучанию, 
//то есть проигнорировать символы не из звукового алфавита
//в том числе пробел, 'ь', 'Ъ', запятая
// Аврора -> нет,   75антон -> нет
// Аврорва -> да, Алла -> да, "А роза упала на лапу Азора" -> да 
string ReadString(string text) //проглатывает в стринг строку символов =вводимую последовательность символов, 
// включая пробелы, тоже считаемые вводимые символами 
{
    System.Console.WriteLine(text);
    return Console.ReadLine();
}
int FindPositionInString(char ChSource, string word)
//Находит на какой позиции символ ChSource стоит в стринге и возвращает номер этой позиции (от 0 до string.lenth-1)
//возвращает -1, если симвод не найден
{
    int Position = -1;
    if (word.Length > 0)
    {
        for (int i = 0; i < word.Length; i++)
        {
            if (ChSource == word[i]) { Position = i; break; };
        };
    };
    return Position;
}

int IsItAcceptable(char ChSource, string Acceptables)
//Проверяет, является ли данный символ допустимым  IsTheLetterSoundingLetterOfRussianAlphabet
//-1 == не является, 1 == является
{
    //string Acceptables = "абвгдеёжзиклмнопрстуфхцшщйэюя";
    // SoundingLetters{'а...
    int Place = FindPositionInString(ChSource, Acceptables);
    int ResI = -1;
    if (Place >= 0)
    {
        ResI = 1;
    };
    return ResI;
}
int CountAcceptablesAndRemoveNonAcceptables(string text, string Acceptables, char[] CharArray)
//для данного на входе стринга находит число "недопустимых" букв, 
// то есть не входящих в эталонный стринг Acceptabl, остальные символы в т.ч проелы - игнорирует.
// ?? и запоминает их положения (индексы) в исходном стринге
{
    int[] PositionOfAcceptables = new int[128];
    int[] PositionOfNonAcceptables = new int[128];
    int CountAliens = 0;
    int CountAcceptables = 0;
    if (text.Length > 0)
    {
        for (int i = 0; i < text.Length; i++)
        {
            if (IsItAcceptable(text[i], Acceptables) <= 0)
            {  //(text[i] содержит игноранта
                PositionOfNonAcceptables[CountAliens] = i;
                CountAliens++;
            }
            else //(text[i] содержит допустимую букву
            {
                PositionOfAcceptables[CountAcceptables] = i;
                CharArray[CountAcceptables] = text[i];// кладем эту буквы на полку = в нужный нам массив букв 
                CountAcceptables++;
            }
        }
        // блок контрольного вывода на консоль результатов
        // System.Console.WriteLine($" недопустимых символов {CountAliens}");
        // if (CountAliens > 0)
        // {
        //     for (int i = 0; i < CountAliens; i++)
        //     {
        //         int j = PositionOfNonAcceptables[i];
        //         System.Console.WriteLine($" {i}: недопустимая буква: {text[j]}  на позиции {PositionOfNonAcceptables[i]},");
        //     };
        // };
        // System.Console.WriteLine($" допустимых символов {CountAcceptables}");
        // if (CountAcceptables > 0)
        // {
        //     for (int i = 0; i < CountAcceptables; i++)
        //     {
        //         int j = PositionOfAcceptables[i];
        //         System.Console.WriteLine($" {i}: допустимая буква: {text[j]} = {CharArray[i]} на позиции {PositionOfAcceptables[i]},");
        //     };
        // };
    };
    return CountAcceptables;
};
int CountDifTwins(int Number, char[] CharArray)
//для данного на входе массива символов с числом Num заполненных элементов находит число пар "НЕ близнецов":
// символ на i-м месте с начала НЕ совпадает с символом на i-м месте с конца 
{
    int CountDif = 0;
    if (Number > 0)
    {
        int centre = Number / 2 - 1;
        int Last = Number - 1;
        for (int i = 0; i <= centre; i++)
        {
            // System.Console.Write($" {i}-й слева символ   {CharArray[i]}   VS");
            // System.Console.WriteLine($" {i}-й справа символ   {CharArray[Last - i]}");
            if (CharArray[i] != CharArray[Last - i])
            {
                CountDif++;
            }
        }
    }
    //System.Console.WriteLine($" разных пар символов {CountDif}");
    return CountDif;
}

string Acceptables = "абвгдеёжзиклмнопрстуфхцшщйэюя";
string Word = ReadString("Введите текст (от 1 до 128 символов):");
char[] candidate = new char[128];
if (Word.Length > 0)
{
    if (Word.Length > 128)
    {
        System.Console.WriteLine("Warning: Вводимая фраза слишком длинная (более 128 символов)");
    };
    int CountAcceptables = CountAcceptablesAndRemoveNonAcceptables(Word, Acceptables, candidate);
    //
    if (CountAcceptables == 0)
    {
        System.Console.WriteLine($" введенный текст:");
        System.Console.WriteLine(Word);
        System.Console.WriteLine($" не содержит допустимых букв");
    }
    else
    {
        System.Console.WriteLine($" введенный текст содержит {CountAcceptables} допустимых букв");
        for (int j = 0; j < CountAcceptables; j++)
        { System.Console.Write($"{candidate[j]}"); }
        System.Console.WriteLine($"   - таков очищенный массив букв");
        int CountDif = CountDifTwins(CountAcceptables, candidate);
        if (CountDifTwins(CountAcceptables, candidate) == 0)
        {
            System.Console.WriteLine($" введенный текст:");
            System.Console.WriteLine(Word);
            System.Console.WriteLine($" является палиандром");
        }
        else { System.Console.WriteLine($" введенный текст не является палиандром"); }
    };
}
else
{
    System.Console.WriteLine(" Вы ввели пустой стринг. Повторите ввод.");
};

