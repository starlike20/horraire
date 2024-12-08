using System;

namespace calendrieclassz
{
    public class Cours
    {
        // Propriétés de la classe Cours

        public int ID_Cours { get; set; } // Identifiant unique du cours
        public string Nom { get; set; }    // Nom du cours
        public string Description { get; set; }  // Description du cours
        public int ID_Programme { get; set; }    // Identifiant du programme associé

        public int Duree { get; set; } // Durée du cours en heures

        // Constructeur avec paramètres
        public Cours(int idCours, string nom, string description, int idProgramme, int duree)
        {
            ID_Cours = idCours;
            Nom = nom;
            Description = description;
            ID_Programme = idProgramme;
            Duree = duree;
        }

        // Constructeur simplifié pour les tests
        public Cours(string nom, string description, int idProgramme, int duree)
        {
            ID_Cours = GenererIDUnique();
            Nom = nom;
            Description = description;
            ID_Programme = idProgramme;
            Duree = duree;
        }

        // Méthode pour générer un ID unique
        private static int _prochainID = 1;
        private static int GenererIDUnique()
        {
            return _prochainID++;
        }

        // Méthode pour afficher les informations du cours
        public override string ToString()
        {
            return $"Cours: {Nom}\nDescription: {Description}\nProgramme: {ID_Programme}\nDurée: {Duree} heures";
        }
    }
}
