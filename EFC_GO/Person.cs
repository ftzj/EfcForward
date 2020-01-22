using System;
using System.Collections.Generic;
using System.Text;

namespace GO
{
    public abstract partial class Person
    {
        //-- Primary Key
        // Waer nur Id nicht besser, damit die erbenden Klassen
        // diese Propertz als Primaerschluessel verwenden koennen?
        public int PersonID { get; set; }

        // --- Einfache Eigenschaften
        public string Name { get; set; }
        public string Vorname { get; set; }
        public Nullable<System.DateTime> Geburtsdatum { get; set; }
        public string Strasse { get; set; }
        public Byte[] Foto { get; set; }
        public string Email { get; set; }
        public string Stadt { get; set; }
        public string Land { get; set; }

        // Property kann von erbender Klasse ueberschrieben werden
        public virtual string Memo { get; set; }

        // Berechnete Eigenschaften (wird nicht persistiert)
        public string GanzerName { get { return this.Vorname + " " + this.Name; } }

        // Methode (ohne Bedeutung fuer ORM)
        public override string ToString()
        {
            return "#" + this.PersonID + ": " + this.GanzerName;
        }
    }
}
