using System;
using System.Collections.Generic;

namespace TranspoCity
{
    public interface IVehicule
    {
        void SeDeplacer(int distance);
        decimal ConsommerCarburant();
    }

    public class Voiture : IVehicule
    {
        public decimal ConsommationParKm { get; set; }
        private decimal carburantConsomme = 0;

        public void SeDeplacer(int distance)
        {
            carburantConsomme += distance * ConsommationParKm;
        }

        public decimal ConsommerCarburant()
        {
            decimal consommation = carburantConsomme;
            carburantConsomme = 0; // Réinitialisation
            return consommation;
        }
    }

    public class Bus : IVehicule
    {
        public int NombrePassagers { get; set; }
        public decimal ConsommationParKmParPassager { get; set; }
        private decimal carburantConsomme = 0;

        public void SeDeplacer(int distance)
        {
            carburantConsomme += distance * ConsommationParKmParPassager * NombrePassagers;
        }

        public decimal ConsommerCarburant()
        {
            decimal consommation = carburantConsomme;
            carburantConsomme = 0; // Réinitialisation
            return consommation;
        }
    }

    public class Train : IVehicule
    {
        public int NombreWagons { get; set; }
        public decimal ConsommationParKmParWagon { get; set; }
        private decimal carburantConsomme = 0;

        public void SeDeplacer(int distance)
        {
            carburantConsomme += distance * ConsommationParKmParWagon * NombreWagons;
        }

        public decimal ConsommerCarburant()
        {
            decimal consommation = carburantConsomme;
            carburantConsomme = 0; // Réinitialisation
            return consommation;
        }
    }

    public class Bateau : IVehicule
    {
        public decimal ConsommationParKm { get; set; }
        private decimal carburantConsomme = 0;

        public void SeDeplacer(int distance)
        {
            carburantConsomme += distance * ConsommationParKm;
        }

        public decimal ConsommerCarburant()
        {
            decimal consommation = carburantConsomme;
            carburantConsomme = 0; // Réinitialisation
            return consommation;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            List<IVehicule> vehicules = new List<IVehicule>
            {
                new Voiture { ConsommationParKm = 0.1m },
                new Bus { NombrePassagers = 20, ConsommationParKmParPassager = 0.01m },
                new Train { NombreWagons = 10, ConsommationParKmParWagon = 1m },
                new Bateau { ConsommationParKm = 0.05m }
            };

            foreach (var vehicule in vehicules)
            {
                vehicule.SeDeplacer(100);  // Tous les véhicules se déplacent de 100 km.
            }

            decimal consommationTotale = 0;
            foreach (var vehicule in vehicules)
            {
                consommationTotale += vehicule.ConsommerCarburant();
            }

            Console.WriteLine($"Consommation totale de carburant pour tous les véhicules : {consommationTotale} litres (ou tonnes pour les bateaux)");
        }
    }
}
