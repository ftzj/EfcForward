using System;
using System.Collections.Generic;
using System.Text;

namespace GO
{
    /// <summary>
    /// Zwischen(entitaets)klasse, weil EF Core bisher kein N:M unterstuetzt.
    /// 
    /// </summary>
    public class Buchung
    {
        // --- Primaerschluessel
        // ohne ID ist das korrekt?
        public int FlugNr { get; set; }
        public int PassagierId { get; set; }

        // --- Navigationseigenschaften
        public Flug Flug { get; set; }
        public Passagier Passagier { get; set; }
    }
}
