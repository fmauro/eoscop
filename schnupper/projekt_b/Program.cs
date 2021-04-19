using System;

namespace hallowelt
{
    class Program
    {
        static void Main(string[] args)
        {
            // Unsere geheime Zahl
            int target = 65;

            // Benutzer informieren, dass ein Name eingegeben werden soll
            Console.Write("Geben Sie ihren Namen ein: ");
            // Eingegebenen Namen auslesen und in Variable "name" speichern
            string name = Console.ReadLine();

            // Eingegebenen Namen ausgeben:
            Console.WriteLine("Guten Tag " + name);
        }
    }
}
