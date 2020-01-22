using System;
using System.Collections.Generic;
using System.Text;

namespace GO
{
    public enum Fluglizenztyp
    {
        CPL,PPL,GPL,SPL,LAPL    
    }
    public partial class Pilot:Person
    {
        // Primary Key wird vererbt

        // --- Weitere Eigenschaften
        public System.DateTime FlugscheinSeit { get; set; }
        public Nullable<int> Flugstunden { get; set; }
        
        /// <summary>
        /// Auch Aufzaehlungstypen (hier: enum) sind als Properties fuer die Datenbank
        /// erlaubt.
        /// </summary>
        public Fluglizenztyp Fluglizenztyp { get; set; }
        public string Flugschule { get; set; }

        // --- Navigationseigenschaft deklariert auf Schnittstellen mit expliziter 
        // Mengentypinstanziierung
        // bidirektional, da die Klasse Flug eine Property mit dem Typ Pilot
        // enthaelt
        public List<Flug> FluegeAlsPilot { get; set; } = new List<Flug>();

        // --- Navigationseigenschaft deklariert auf Mengentzp mit expliziter
        // Mengentypinstanziierung
        // bidirektional, da die Klasse Flug eine Property mit dem Typ Pilot
        // enthaelt
        public List<Flug> FluegeAlsCopilot { get; set; } = new List<Flug>();

    }
}
