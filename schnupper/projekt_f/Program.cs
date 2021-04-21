using System;

char[,] NewGame()
{
    return new char[,] {
        {' ',' ',' '},
        {' ',' ',' '},
        {' ',' ',' '}
    };
}

void PrintGame(char[,] game)
{
    Console.WriteLine("   1   2   3");
    for (int row = 0; row < 3; row++)
    {
        char rowLabel = (char)(65 + row);
        Console.Write($"{rowLabel}  ");
        for (int col = 0; col < 3; col++)
        {
            Console.Write(game[row, col]);
            if (col < 2) Console.Write(" | ");
        }
        Console.WriteLine();
        if (row < 2) Console.WriteLine("   ---------");
    }
}

char GetChain(char[,] g)
{
    // Zeilen
    if (g[0, 0] == g[0, 1] && g[0, 1] == g[0, 2] && g[0, 0] != ' ') return g[0, 0];
    if (g[1, 0] == g[1, 1] && g[1, 1] == g[1, 2] && g[1, 0] != ' ') return g[1, 0];
    if (g[2, 0] == g[2, 1] && g[2, 1] == g[2, 2] && g[2, 0] != ' ') return g[2, 0];

    // Spalten
    if (g[0, 0] == g[1, 0] && g[1, 0] == g[2, 0] && g[0, 0] != ' ') return g[0, 0];
    if (g[0, 1] == g[1, 1] && g[1, 1] == g[2, 1] && g[0, 1] != ' ') return g[0, 1];
    if (g[0, 2] == g[1, 2] && g[1, 2] == g[2, 2] && g[0, 2] != ' ') return g[0, 2];

    // Diagonalen
    if (g[0, 0] == g[1, 1] && g[1, 1] == g[2, 2] && g[0, 0] != ' ') return g[0, 0];
    if (g[0, 2] == g[1, 1] && g[1, 1] == g[2, 0] && g[0, 2] != ' ') return g[0, 2];

    return ' ';
}

bool IsGameFull(char[,] g)
{
    for (int row = 0; row < 3; row++)
    {
        for (int col = 0; col < 3; col++)
        {
            if (g[row, col] == ' ') return false;
        }
    }

    return true;
}

char[,] mainGame = NewGame();
bool player = true;

int targetRow = -1;
int targetCol = -1;

while (targetRow == -1 && targetCol == -1)
{
    PrintGame(mainGame);
    Console.WriteLine();
    Console.Write($"{(player ? "Spieler 1" : "Spieler 2")} am Zug: ");
    string input = Console.ReadLine().ToUpper();

    if (input.Length == 2 &&
        (input[0] > 64 && input[0] < 68) &&
        (input[1] > 48 && input[1] < 52))
    {
        targetRow = input[0] - 65;
        targetCol = input[1] - 49;

        if (mainGame[targetRow, targetCol] == ' ')
        {
            mainGame[targetRow, targetCol] = player ? 'x' : 'o';
            player = !player;

            // Prüfung
            char chain = GetChain(mainGame);
            if (chain != ' ')
            {
                PrintGame(mainGame);
                Console.WriteLine($"{chain} gewinnt!");
                break;
            }
            else if (IsGameFull(mainGame))
            {
                PrintGame(mainGame);
                Console.WriteLine($"Spiel zuende, kein Gewinner");
                break;
            }
        }

        targetRow = targetCol = -1;
    }
}

