# Projekt E - Zufallszahlen

Es soll das Programm `ZahlErraten` erweitert werden, die zu erratende Zahl nicht mehr fix im Code definiert ist, sondern zufällig gewählt wird.

Nützliche Befehle:

Zufallszahlengenerator
```csharp
// Neuen Zufallszahlgenerator erstellen
var random = new Random(DateTime.Now.Milliseconds);

// Zufallszahl zwischen 0 und 100 generieren
int guess = random.Next(0, 100)
```

Lerninhalte:
- Zufallszahlen

Fragen:
- Weshalb wird `Random` mit dem Parameter `DateTime.Now.Milliseconds` initialisiert?