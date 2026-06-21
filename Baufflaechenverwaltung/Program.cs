using System;
using System.Collections.Generic;

namespace Baufflaechenverwaltung
{
    public enum FlaechenStatus { Frei, Reserviert, Bebaut }
    public enum BauvorhabenStatus { AntragEingereicht, Genehmigt, Abgelehnt, InBearbeitung, Abgeschlossen }

    public class Antragsteller
    {
        public string Name { get; set; } = string.Empty;
        public string Kontaktdaten { get; set; } = string.Empty;
        public string Firma { get; set; } = string.Empty;
    }

    public class Bauvorhaben
    {
        public string Titel { get; set; } = string.Empty;
        public Antragsteller Antragsteller { get; set; } = new();
        public string GeplanteNutzung { get; set; } = string.Empty;
        public DateTime Beginn { get; set; }
        public DateTime Fertigstellung { get; set; }
        public BauvorhabenStatus Status { get; set; }
        public List<Bauflaeche> ZugeordneteFlaechen { get; set; } = new();

        public void StatusAktualisieren(BauvorhabenStatus neuerStatus)
        {
            Status = neuerStatus;
        }
    }

    public class Bauflaeche
    {
        public string FlaechenId { get; set; } = string.Empty;
        public double Groesse { get; set; }
        public string Lage { get; set; } = string.Empty;
        public string AktuelleNutzung { get; set; } = string.Empty;
        public string Bebaubarkeit { get; set; } = string.Empty;
        public string BPlanNummer { get; set; } = string.Empty;
        public decimal Bodenrichtwert { get; set; }
        public string Eigentuemer { get; set; } = string.Empty;
        public FlaechenStatus Status { get; set; } = FlaechenStatus.Frei;

        public void FlaecheReservieren()
        {
            if (Status == FlaechenStatus.Bebaut)
            {
                throw new InvalidOperationException($"Fläche {FlaechenId} ist bereits bebaut und kann nicht reserviert werden.");
            }
            Status = FlaechenStatus.Reserviert;
        }
    }

    public class Grundstueck
    {
        public string FlurstueckNummer { get; set; } = string.Empty;
        public List<Bauflaeche> Bauflaechen { get; set; } = new();

        public void BauvorhabenAnlegen(Bauvorhaben vorhaben, Bauflaeche flaeche)
        {
            if (flaeche.Status == FlaechenStatus.Bebaut)
            {
                throw new InvalidOperationException($"Fläche {flaeche.FlaechenId} ist bereits bebaut und kann nicht für ein neues Bauvorhaben verwendet werden.");
            }
            vorhaben.ZugeordneteFlaechen.Add(flaeche);
            flaeche.Status = FlaechenStatus.Bebaut;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Demonstration der Funktionalität
            var grundstueck = new Grundstueck { FlurstueckNummer = "0015 00012 001/002" };
            var flaeche = new Bauflaeche 
            {
                FlaechenId = "F1", 
                Groesse = 500, 
                Lage = "Nordseite", 
                AktuelleNutzung = "Brachfläche", 
                Bebaubarkeit = "ja", 
                BPlanNummer = "BP-2022-089", 
                Bodenrichtwert = 500m, 
                Eigentuemer = "Max Mustermann"
            };
            grundstueck.Bauflaechen.Add(flaeche);

            var antragsteller = new Antragsteller { Name = "Erika Musterfrau", Firma = "Bau AG" };
            var vorhaben1 = new Bauvorhaben 
            {
                Titel = "Wohnhaus Nord", 
                Antragsteller = antragsteller, 
                GeplanteNutzung = "Wohngebäude", 
                Beginn = DateTime.Now, 
                Fertigstellung = DateTime.Now.AddYears(1), 
                Status = BauvorhabenStatus.AntragEingereicht
            };

            Console.WriteLine($"Fläche Status: {flaeche.Status}");
            flaeche.FlaecheReservieren();
            Console.WriteLine($"Fläche nach Reservierung: {flaeche.Status}");

            grundstueck.BauvorhabenAnlegen(vorhaben1, flaeche);
            Console.WriteLine($"Fläche Status nach Bauvorhaben 1: {flaeche.Status}");

            // Fehlerfall demonstrieren: Erneute Reservierung einer bebauten Fläche
            try
            {
                Console.WriteLine("Versuch, bebaute Fläche erneut zu reservieren...");
                flaeche.FlaecheReservieren();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler: {ex.Message}");
            }

            // Fehlerfall demonstrieren: Erneute Verwendung einer bebauten Fläche für neues Vorhaben
            try
            {
                var vorhaben2 = new Bauvorhaben { Titel = "Gewerbebau Ost" };
                Console.WriteLine("Versuch, bebaute Fläche für neues Bauvorhaben zu nutzen...");
                grundstueck.BauvorhabenAnlegen(vorhaben2, flaeche);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler: {ex.Message}");
            }
        }
    }
}