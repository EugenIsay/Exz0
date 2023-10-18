int[,] field0 = new int[3, 3];
int[,] field1 = new int[3, 3];
int x;
int y;
bool temp;
bool check;
string read;
Random r = new Random();
ConsoleKeyInfo key;
for (int i = 0; i < 3; i++)
{
    for (int j = 0; j < 3; j++)
    {
        field0[j, i] = r.Next(1, 101);
    }
}
void ShowField()
{
    Console.WriteLine("+---+---+---+");
    for (int i = 0; i < 3; i++)
    {
        Console.WriteLine("|   |   |   |");
        Console.WriteLine("+---+---+---+");
    }
}
void ShowNum(int field)
{
    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 3; j++)
        {
            if (KnowField(i, j, field) != 0)
            {
                if (KnowField(i, j, field) < 100)
                {
                    Console.SetCursorPosition(2 + i * 4, 1 + j * 2);
                    Console.WriteLine(KnowField(i, j, field));
                }
                else
                {
                    Console.SetCursorPosition((2 + i * 4) - 1, 1 + j * 2);
                    Console.WriteLine(KnowField(i, j, field));
                }
            }
        }
    }
}
int KnowField(int x, int y, int field)
{
    if (field == 0)
    {
        return field0[y, x];
    }
    else
    {
        return field1[y, x];
    }
}
ShowField();
ShowNum(0);
Console.SetCursorPosition(0, 7);
Console.WriteLine("Запомните все числа в нужном порядке. Нажмите на любую кнопку для продолжения");
key = Console.ReadKey(true);
Console.Clear();
ShowField();
ShowNum(1);
Console.SetCursorPosition(0, 7);
Console.WriteLine("Заполните поле цифрами");
Console.WriteLine("Подтвердите выбор клетки клавишой enter");
Console.SetCursorPosition(2, 1);
y = 0; x = 0;
while (true)
{
    check = false;
    temp = true;
    key = Console.ReadKey(true);
    switch (key.Key.ToString())
    {
        case "UpArrow":
            if (x - 1 >= 0)
            {
                x -= 1;
            }
            break;
        case "DownArrow":
            if (x + 1 <= 2)
            {
                x += 1;
            }
            break;
        case "LeftArrow":
            if (y - 1 >= 0)
            {
                y -= 1;
            }
            break;
        case "RightArrow":
            if (y + 1 <= 2)
            {
                y += 1;
            }
            break;
        case "Enter":


            Console.SetCursorPosition(0, 7);
            Console.WriteLine("Напишите число                                     ");
            Console.WriteLine("                                                   ");
            Console.SetCursorPosition(2 + y * 4, 1 + x * 2);
            read = Console.ReadLine();
            for (int i = 1; i < 101; i++)
            {
                if ($"{i}" == read)
                {
                    check = true;
                    break;
                }
            }
            if (check == true)
            {
                field1[x, y] = Convert.ToInt32(read);
                Console.SetCursorPosition(0, 7);
                Console.WriteLine("Заполните поле цифрами");
                Console.WriteLine("Подтвердите выбор клетки клавишой enter");
            }
            else
            {
                Console.SetCursorPosition(0, 7);
                Console.WriteLine("Некоректный ввод");
                Console.WriteLine("Выберите поле заново");
            }
            Console.SetCursorPosition(0, 0);
            ShowField();
            ShowNum(1);
            break;
    }
    Console.SetCursorPosition(2 + y * 4, 1 + x * 2);
    foreach (int field in field1)
    {
        if (field == 0)
        {
            temp = false; break;
        }
    }
    if (temp == true)
    {
        Console.Clear();
        break;
    }
}
int count = 0;
for (int i = 0; i < 3; i++)
{
    for (int j = 0; j < 3; j++)
    {
        if (field1[j, i] == field0[j, i])
        {
            count++;
        }
    }
}
Console.WriteLine($"Праивльных ответов: {count}");
Console.WriteLine($"Неправильных ответов: {9 - count}");