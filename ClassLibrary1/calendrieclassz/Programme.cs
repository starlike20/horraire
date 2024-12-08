using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace calendrieclassz
{
    public class Programme
    {
        // Propriétés de la classe Programme

        public int ID_Programme { get; set; }    // Identifiant unique du programme
        public string Nom { get; set; }          // Nom du programme (par exemple, "BSc Mathématiques")
        public string Description { get; set; }  // Description du programme
        public List<Cours> Listecours { get; set; } // Liste des cours associés au programme

        // Constructeur avec paramètres
        public Programme(int idProgramme, string nom, string description)
        {
            ID_Programme = idProgramme;
            Nom = nom;
            Description = description;
            Listecours = new List<Cours>();
        }

        // Constructeur simplifié pour les tests (génère un ID unique)
        public Programme(string nom, string description)
        {
            ID_Programme = GenererIDUnique();
            Nom = nom;
            Description = description;
            Listecours = new List<Cours>();
        }

        // Méthode pour générer un ID unique
        private static int _prochainID = 1;
        private static int GenererIDUnique()
        {
            return _prochainID++;
        }

        // Méthode pour ajouter un cours au programme
        public void AjouterCours(Cours cours)
        {
            if (cours != null && !Listecours.Contains(cours))
            {
                Listecours.Add(cours);
            }
        }

        // Méthode pour retirer un cours du programme
        public void RetirerCours(Cours cours)
        {
            if (cours != null && Listecours.Contains(cours))
            {
                Listecours.Remove(cours);
            }
        }

        // Méthode pour afficher les informations du programme
        public override string ToString()
        {
            string programmeDetails = $"Programme: {Nom}\nDescription: {Description}\nCours inclus:\n";

            foreach (var cours in Listecours)
            {
                programmeDetails += $"- {cours.Nom}\n";
            }

            return programmeDetails;
        }
    }
}
