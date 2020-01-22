using System;
using System.Collections.Generic;
using System.Text;

namespace GO
{
    // partial: Klasse kann ueber mehrere Dateien aufgeteilt werden
    public partial class Flug
    {
        // Parameterloser Konstruktor ist immer notwendig fuer EF!
        public Flug()
        {

        }

        public Flug(string abflugort, string zielort)
        {
            this.Abflugort = abflugort;
            this.Zielort = zielort;
        }

        // --- Primaerschluessel
        public int FlugID { get; set; }
        // --- einfache Eigenschaften
        public string Abflugort { get; set; }
        public string Zielort { get; set; }
        public System.DateTime Datum { get; set; }
        public bool NichtRaucherFlug { get; set; }
        // durch das Fragezeichen kann der Wert 'null' angenommen werden
        // 'short?' = 'Nullable<int>'
        public short? Plaetze { get; set; }
        public short? FreiePlaetze { get; set; }
        public decimal Preis { get; set; }

        // Explizites Property
        private string memo;
        public string Memo
        {
            get { return this.memo; }
            set { this.memo = value; }
        }

        // Navigationseigenschaften
        // 1:0/1 Beziehung mit der Klasse Pilot
        // bidirektional, da die Klasse Pilot zwei Properties (als Listen) des Typs 
        // Flugs enthaelt
        public Pilot Pilot { get; set; }
        public Pilot Copilot { get; set; }

        // 1:0/N Beziehung mit der Klasse Buchung
        public ICollection<Buchung> BuchungSet { get; set; } = new List<Buchung>();

        // Methode (Ohne Bedeutung fuer ORM)
        public override string ToString()
        {
            return String.Format($"Flug #{this.FlugID}> von {this.Abflugort} nach {this.Zielort} " +
                $"Freie Plaetze> {this.FreiePlaetze}");
        }
    }
}
