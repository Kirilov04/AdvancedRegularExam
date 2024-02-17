
int n = int.Parse(Console.ReadLine());
char[,] airSpace = new char[n, n];

int row = 0, col = 0, enemies = 0,
    armour = 300;

for (int i = 0; i < n; i++)
{
    string line = Console.ReadLine();
    for (int j = 0; j < n; j++)
    {
        airSpace[i, j] = line[j];
        if (line[j] == 'J')
        {
            row = i;
            col = j;
            airSpace[i, j] = '-';
        }
        else if (line[j] == 'E') enemies++;
    }
}
while (true)
{
    string command = Console.ReadLine();
    switch (command)
    {
        case "up": row--; break;
        case "down": row++; break;
        case "left": col--; break;
        case "right": col++; break;
    }

    if (airSpace[row, col] == 'E')
    {
        if (enemies == 1)
        {
            Console.WriteLine("Mission accomplished, you neutralized the aerial threat!");
            break;
        }
        else
        {
            airSpace[row, col] = '-';
            armour -= 100;
            enemies--;
            if (armour == 0)
            {
                Console.WriteLine($"Mission failed, your jetfighter was shot down! Last coordinates [{row}, {col}]!");
                break;
            }
        }
    }

    else if (airSpace[row, col] == 'R')
    {
        armour = 300;
        airSpace[row, col] = '-';
    }
}

airSpace[row, col] = 'J';

for (int i = 0; i < n; i++)
{
    for (int j = 0; j < n; j++)
    {
        Console.Write(airSpace[i, j]);
    }
    Console.WriteLine();
}
