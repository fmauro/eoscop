# Projekt D - Schleifen

Es soll das Programm `ZahlErraten` erweitert werden, dass während der Ausführung immer weiter nach der Zahl gefragt wird, solange diese nicht erraten wurde.

Beispielablauf:
```
> dotnet run 
Geben Sie eine Zahl ein: 34
Leider nein, die gesuchte Zahl ist grösser als 34
Geben Sie eine Zahl ein: 67
Leider nein, die gesuchte Zahl ist kleiner als 67
Geben Sie eine Zahl ein: 65
Genau! Die gesuchte Zahl ist 65
```

Nützliche Befehle:

Schleife
```csharp
while (guess != number)
{
    [...]
}
```

Lerninhalte:
- Schleifen

Fragen:
- Wie funktioniert eine `while` Schleife
- Welche anderen Arten von Schleifen gibt es