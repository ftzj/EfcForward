using DZ;
using GO;
using System;
using System.Linq;

namespace EFC_Konsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start...");
            using(var ctx = new EFKontext())
            {
                // Datenbank anlegen, wenn nicht vorhanden!
                ctx.Database.EnsureCreated();
                // Passagierobjekt erzeugen
                var p = new Passagier();
                p.Vorname = "Holger";
                p.Name = "Schwichtenberg";
                // Passagier an EF-Kontext anfuegen
                ctx.PassagierSet.Add(p);
                // Objekt speichern
                var anz=ctx.SaveChanges();
                Console.WriteLine("Anzahl Aenderungen: " + anz);
                // Alle Passagiere einlesen aus der Datenbank
                var passagierSet = ctx.PassagierSet.ToList();
                Console.WriteLine("Anzahl Passagiere: " + passagierSet.Count);
            }
        }
    }
}
