using GO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace DZ
{
    public class EFKontext:DbContext
    {
        /// <summary>
        /// The override modifier is required to extend or modify the abstract or 
        /// virtual implementation of an inherited method, property, indexer, or event.
        /// 
        /// Methode fuer die Verbindungszeichenfolge (connection string)
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            string connstring = @"Server=192.168.178.35;Port=5432;Database=EfcForward;
                                    username=postgres";
            // Erweiterungsmethode, um die Datenbank mit den Daten 
            // des connection strings aufzurufen
            //builder.UseSqlServer(connstring);
            builder.UseNpgsql(connstring);
        }

        
        // Anpassungen per Fluent-API
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Pilot und Passagier erben ihren Primaerschluessel von Person,
            // diese wird aber ECF nicht erkannt, da sie bei den beiden
            // Klassen nicht den Konventionen entspricht.
            // HINWEIS: wird nur bei ID, aber nicht Id akzeptiert
            builder.Entity<Passagier>().HasKey(x => x.PersonID);
            builder.Entity<Pilot>().HasKey(x => x.PersonID);

            builder.Entity<Buchung>().HasKey(b => new { b.FlugNr,b.PassagierId});

            // Zuordnung von Pilot und Copilot zur richtigen Liste
            // in den Klassen Flug und Pilot
            // HINWEIS: f.FlugID in Buch steht f.PilotId, muss ein Fehler sein
            builder.Entity<Pilot>().HasMany(p=>p.FluegeAlsCopilot)
                .WithOne(f => f.Copilot).HasForeignKey(f => f.FlugID);
            builder.Entity<Pilot>().HasMany(p => p.FluegeAlsPilot)
                .WithOne(f => f.Pilot).HasForeignKey(f => f.FlugID);
        }

        /// <summary>
        /// Fuer jede Entitaetsklasse muss eine DbSet<T> Property angelegt werden.
        /// </summary>
        public DbSet<Flug> FlugSet { get; set; }
        public DbSet<Pilot> PilotSet { get; set; }
        public DbSet<Passagier> PassagierSet { get; set; }
        public DbSet<Buchung> BuchungSet { get; set; }
    }
}
