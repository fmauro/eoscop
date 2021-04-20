# Projekt F - TicTacToe

Es soll ein bestehendes Programm `TicTacToe` erweitert werden, sodass geprüft wird, ob das Spiel vorbei ist und allenfalls welcher Spieler gewonnen hat.

Spielcode:
```csharp
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
        }

        targetRow = targetCol = -1;
    }
}
```

Nützliche Befehle:

Zweidimensionaler Array-Zugriff und Vergleich:
```csharp
if(mainGame[0, 0] == mainGame[0, 1]) 
{
    Console.WriteLine("a1 und a2 sind gleich");
}
```

Lerninhalte:
- Arrays

Fragen:
- Was prüft folgender Code:
```csharp
string input = Console.ReadLine().ToUpper();
if (input.Length == 2 &&
    (input[0] > 64 && input[0] < 68) &&
    (input[1] > 48 && input[1] < 52))
{
    [...]
}
```