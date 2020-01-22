using System;
using System.Collections.Generic;
using System.Text;

namespace GO
{
    public partial class Passagier:Person
    {
        // Primaerschluessel wird geerbt

        // --- Einfache Eigenschaften
        public Nullable<System.DateTime> KundeSeit { get; set; }
        public string PassagierStatus { get; set; }

        // --- Navigationseigenschaft definiert als Mengentyp
        public HashSet<Buchung> BuchungSet { get; set; } = new HashSet<Buchung>();
    }
}
