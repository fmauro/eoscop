# Projekt A - Programmierumgebung

Als erstes richten wir die Umgebung ein, um ein Programm überhaupt schreiben zu können.
Dazu verwenden wir eine IDE ([Integrated Development Environment](https://de.wikipedia.org/wiki/Integrierte_Entwicklungsumgebung)). Es gibt eine grosse Auswahl an IDEs, in unserem Fall verwenden wir [Visual Studio Code](https://code.visualstudio.com/).

Als Programmiersprache für unsere Projekte werden wir C# verwenden.
>[C# in Visual Studio Code](https://code.visualstudio.com/docs/languages/csharp)

## Visual Studio Code und dotnet installieren

1. Lade den Installer für Visual Studio Code herunter: [https://code.visualstudio.com/](https://code.visualstudio.com/)
2. Starte den Installer aus dem Download-Verzeichnis und installiere Visual Studio Code
3. Installiere die dotnet core SDK (Version 5): [https://dotnet.microsoft.com/download](https://dotnet.microsoft.com/download)
3. Öffne Visual Studio Code
4. Gehe zu Menü "View" -> "Extensions"
5. In der Suche oben Links eingeben: C#
6. Ersten Eintrag in der Liste wählen und installieren ![csharp](img/vscode_csharp_ext.png)

## Ein erstes Projekt erstellen und ausführen

Ist die Umgebung korrekt installiert, können wir nun unser erstes Programm erstellen.

Dazu sind folgende Schritte notwendig:

1. Im Explorer ein Verzeichnis erstellen, in welches das Projekt gespeichert werden soll. Ein Beispiel auf Windows wäre: `C:\Users\mauro.frischherz\source\repos\schnupper`
2. In Visual Studio Code auf "File" -> "Open Folder" und anschliessend zum neu erstellten Ordner navigieren. ![proj-root](img/vscode_project_root.png)
3. Nun öffnen wir ein neues "Terminal" über den Menüpunkt: "Terminal" -> "New Terminal". Dies zeigt uns nun eine Kommandozeile am unteren Rand der Applikation an. Diese Kommandozeile ist bereits im richtigen Ordner "schnupper": ![terminal](img/vscode_terminal.png)
4. In diesem Terminal geben wir einen Befehl ein, welcher ein neues C# dotnet Projekt erzeugt, inkl. aller nötigen Grunddaten: 

```dotnet new console -o hallowelt```

5. Wenn wir im Explorer nachschauen, wurde ein neuer Ordner "hallowelt" erstellt.
6. Im Terminal wechseln wir nun vom Ordner "schnupper" in den Ordner "hallowelt" mit dem Befehl:

```cd hallowelt```

7. In diesem Ordner können wir nun die erstellte Applikation ausführen mit:

```dotnet run```