# Projekt C - Variablen und Datentypen

Es soll ein Programm entstehen, welches eine Zahl in einer Variable speichert und den Benutzer nach einer Zahl fragt. Ist die eingegebene Zahl des Benutzers gleich wie die im Code definierte Zahl, wird dies dem Benutzer mitgeteilt. Ansonsten wird dem Benutzer gesagt, ob die gesuchte Zahl grösser oder kleiner ist.

Beispielablauf:
```
> dotnet run 
Geben Sie eine Zahl ein: 45
Leider nein, die gesuchte Zahl ist grösser als 45
> dotnet run 
Geben Sie eine Zahl ein: 98
Leider nein, die gesuchte Zahl ist kleiner als 98
> dotnet run 
Geben Sie eine Zahl ein: 65
Genau! Die gesuchte Zahl ist 65
```

Nützliche Befehle:

Zeichenfolge ausgeben:

```csharp
Console.Write("BlaBla");
Console.WriteLine("BlaBlaBla");
```

Zeichenfolge einlesen:
```csharp
string input = Console.ReadLine();
```

Zeichenfolge in Ganzzahl verwandeln:
```csharp
string input = Console.ReadLine();
int number = int.Parse(input);
```


```csharp
if (number > guess)
{
    Console.WriteLine("Number is greater than guess");
} 
else if (number < guess)
{
    Console.WriteLine("Number is lesser than guess");
}
else
{
    Console.WriteLine("Number is equal to guess");
}
```

Lerninhalte:
- Variablen
- Operationen
- Datentypen
- Bedingungen

Fragen:
- Was ist ein `string`?
- Was ist ein `int`?
- Welche Datentypen gibt es sonst noch?
- Was ist ein `if` statement und was bewirkt es?