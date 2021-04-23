# Projekt G - Billiardkugeln

Es soll ein bestehendes Programm erweitert werden, sodass Kugelzusammenstösse korrekt dargestellt werden.

Dieses Programm verwendet die [Monogame](https://www.monogame.net/) Engine (ehemals Microsoft XNA)

Um diesen Code in einem neuen Projekt auszuführen, muss in der `.csproj` Datei folgender Abschnitt eingefügt werden:
```xml
  <ItemGroup>
    <PackageReference Include="MonoGame.Framework.DesktopGL" Version="3.8.0.1641" />
  </ItemGroup>
```

Das Projekt-File sollte anschliessend folgendermassen aussehen:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net5.0</TargetFramework>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="MonoGame.Framework.DesktopGL" Version="3.8.0.1641" />
  </ItemGroup>
</Project>
```

Code-Vorgabe:
```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

var display = new GameWindow();
display.Run();

// Klasse in welcher unser Fenster definiert und aktualisiert wird
class GameWindow : Game
{
    private GraphicsDeviceManager _gdm;
    private SpriteBatch _sb;
    private GraphicsDevice _gd;

    // Definiert ob Updates gemacht werden sollen oder nicht
    private bool _simulate = false;
    private KeyboardState _previousState = new KeyboardState();

    // List von Kreisen, welche gezeichnet werden 
    private List<Circle> _circles = new List<Circle>();

    public GameWindow()
    {
        _gdm = new GraphicsDeviceManager(this);
    }

    protected override void Initialize()
    {
        base.Initialize();

        // Fenster initialisieren
        IsFixedTimeStep = true;
        _gdm.PreferredBackBufferWidth = 800;
        _gdm.PreferredBackBufferHeight = 800;
        _gdm.SynchronizeWithVerticalRetrace = true;
        _gdm.ApplyChanges();
        _gd = _gdm.GraphicsDevice;

        // Objekt zum Zeichnen von Texturen im Fenster
        _sb = new SpriteBatch(_gd);

        // Zwanzig Kreise instanziieren und in Liste _circles speichern
        for (int i = 0; i < 20; i++)
        {
            var circle = new Circle(_gd, 600);
            _circles.Add(circle);
        }

        // Kreise zufällig verteilen und skalieren
        RandomizeCircles();
    }

    private void RandomizeCircles() {
        var rand = new Random((int)(DateTime.Now.Ticks / 10000));
        float maxVelocity = 9;
        int maxSize = 150;
        foreach(var circle in _circles) {
            circle.Diameter = rand.Next(20, maxSize);
            circle.X = rand.Next(0, _gdm.PreferredBackBufferWidth);
            circle.Y = rand.Next(0, _gdm.PreferredBackBufferHeight);
            circle.Color = Color.FromNonPremultiplied(
                rand.Next(50, 255), rand.Next(50, 255), rand.Next(50, 255), 255);
            circle.Velocity = new Vector2((float)(rand.NextDouble() * maxVelocity), 
                (float)(rand.NextDouble() * maxVelocity));
        }
    }

    private bool HasKeyBeenPressed(KeyboardState state, Keys keys) {
        return state.IsKeyDown(keys) && _previousState.IsKeyUp(keys);
    }

    // Diese Methode wird vor jedem Zeichnen ausgeführt
    protected override void Update(GameTime delta)
    {
        base.Update(delta);

        var state = Keyboard.GetState();
        if(HasKeyBeenPressed(state, Keys.Space)) _simulate = !_simulate;
        if(HasKeyBeenPressed(state, Keys.R)) RandomizeCircles();
        _previousState = state;

        if(!_simulate) return;

        // Iteration über alle Kreise
        foreach (var circle in _circles)
        {
            // Kreis je nach definierter Geschwindigkeit aktualisieren
            circle.Update();

            // Kreis nicht aus dem Fenster wandern lassen
            if (circle.X <= 0)
            {
                circle.X = 0;
                circle.Velocity.X = Math.Abs(circle.Velocity.X);
            }

            if (circle.X >= _gdm.PreferredBackBufferWidth)
            {
                circle.X = _gdm.PreferredBackBufferWidth;
                circle.Velocity.X = -Math.Abs(circle.Velocity.X);
            }

            if (circle.Y <= 0)
            {
                circle.Y = 0;
                circle.Velocity.Y = Math.Abs(circle.Velocity.Y);
            }

            if (circle.Y >= _gdm.PreferredBackBufferHeight)
            {
                circle.Y = _gdm.PreferredBackBufferHeight;
                circle.Velocity.Y = -Math.Abs(circle.Velocity.Y);
            }
        }
    }

    // In dieser Methode kann gezeichnet werden
    protected override void Draw(GameTime delta)
    {
        base.Draw(delta);

        // Ganzer Schirm mit Schwarz ausmalen
        _gd.Clear(Color.Black);

        // Zeichnungsschritt beginnen
        _sb.Begin();

        // Jeden Kreis in der Liste _circles zeichnen
        foreach (var circle in _circles)
        {
            circle.Draw(_sb);
        }

        // Zeichnungsschritt beenden
        _sb.End();
    }
}

// Diese Klasse beschreibt einen Kreis 
// mit einer Farbe, Position, Radius und Geschwindigkeit
// Bei einem Aufruf der Methode Update() wird die Position
// um die aktuelle Geschwindigkeit verschoben.
class Circle
{
    private static Texture2D _texture;
    private Rectangle _destRect = new Rectangle();

    public Vector2 Velocity = new Vector2();

    public Color Color = Color.White;

    public int Diameter
    {
        get => _destRect.Width;
        set
        {
            _destRect.Width = value;
            _destRect.Height = value;
        }
    }

    public float Radius => Diameter / 2;

    public Vector2 Position = new Vector2();

    public float X
    {
        get => Position.X;
        set
        {
            Position.X = value;
            _destRect.X = (int)(Position.X - Diameter / 2);
        }
    }
    public float Y
    {
        get => Position.Y;
        set
        {
            Position.Y = value;
            _destRect.Y = (int)(Position.Y - Diameter / 2);
        }
    }

    public Circle(GraphicsDevice gd, int textureRadius)
    {
        if (_texture == null)
        {
            _texture = CreateCircleTexture(gd, textureRadius);
        }
    }

    // Verschiebt die aktuelle Position um die aktuelle Geschwindigkeit
    public void Update()
    {
        X += Velocity.X;
        Y += Velocity.Y;
    }

    // Zeichnet den Kreis
    public void Draw(SpriteBatch sb)
    {
        sb.Draw(_texture, _destRect, null, Color);
    }

    // Erstellt eine Textur, welche einen Kreis enthält
    private static Texture2D CreateCircleTexture(GraphicsDevice gd, int radius)
    {
        int diam = radius * 2;
        var output = new Texture2D(gd, diam, diam);
        var colorData = new Color[diam * diam];

        var center = new Vector2(output.Width / 2, output.Height / 2);

        for (int x = 0; x < diam; x++)
        {
            for (int y = 0; y < diam; y++)
            {
                var pos = new Vector2(x, y);
                var dist = pos - center;
                var length = dist.Length();
                if (length < radius) colorData[y * diam + x] = Color.White;
                else colorData[y * diam + x] = Color.Transparent;
            }
        }

        output.SetData(colorData);
        return output;
    }
}
```

Lerninhalte:
- Monogame Engine