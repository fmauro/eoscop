using System;

// Unsere geheime Zahl
int target = 65;
int guess = 0;

while (target != guess)
{
    // Benutzer informieren, dass eine Zahl eingegeben werden soll
    Console.Write("Geben Sie eine Zahl ein: ");
    // Eingegebene Zahl auslesen und in Variable "input" speichern
    string input = Console.ReadLine();

    // Eingegebene Zeichenfolge "input" in eine echte Zahl verwandeln
     guess = int.Parse(input);

    // Eingabe mit Geheimzahl vergleichen
    if (guess == target)
    {
        Console.WriteLine("Genau! Die gesuchte Zahl ist " + target);
    }
    else if (guess > target)
    {
        Console.WriteLine("Leider nein, die gesuchte Zahl ist kleiner als " + guess);
    }
    else
    {
        Console.WriteLine("Leider nein, die gesuchte Zahl ist grösser als " + guess);
    }
}