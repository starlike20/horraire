using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calendrieclassz
{
    public class Initialisation
    {
        public List<Enseignants> Enseignants { get; set; } = new List<Enseignants>();
        public List<Etudiant> Etudiants { get; set; } = new List<Etudiant>();
        public List<Cours> Cours { get; set; } = new List<Cours>();
        public List<SalleDeClasse> Salles { get; set; } = new List<SalleDeClasse>();
        public List<Reservation> Reservations { get; set; } = new List<Reservation>();
        public List<Programme> Programmes { get; set; } = new List<Programme>();

        public Initialisation()
        {
            InitialiserDonnees();
        }

        private void InitialiserDonnees()
        {
            // Création des enseignants
            Enseignants.Add(new Enseignants("Doe", "John", "M", "jdoe@example.com", "Mathématiques", "Algèbre", new DateTime(2000, 1, 1)));
            Enseignants.Add(new Enseignants("Smith", "Jane", "F", "jsmith@example.com", "Physique", "Mécanique", new DateTime(2002, 1, 1)));

            // Création des cours
            Cours.Add(new Cours(1, "Algèbre 101", "Introduction à l'Algèbre", 1));
            Cours.Add(new Cours(2, "Mécanique 101", "Introduction à la Mécanique", 2));

            // Création des étudiants
            Programme progMath = new Programme(1, "BSc Mathématiques", "Licence en Mathématiques");
            Programme progPhys = new Programme(2, "BSc Physique", "Licence en Physique");
            Etudiants.Add(new Etudiant("Roe", "Richard", "M", "rroe@example.com", new DateTime(2021, 9, 1), progMath));
            Etudiants.Add(new Etudiant("Doe", "Emily", "F", "edoe@example.com", new DateTime(2021, 9, 1), progPhys));

            // Création des salles de classe
            Salles.Add(new SalleDeClasse(1, "Salle 101", 30));
            Salles.Add(new SalleDeClasse(2, "Salle 102", 25));

            // Création des réservations
            Reservations.Add(new Reservation(1, 1, 1, new DateTime(2023, 9, 1, 8, 0, 0), new DateTime(2023, 9, 1, 10, 0, 0), "Cours de Mathématiques"));
            Reservations.Add(new Reservation(2, 2, 2, new DateTime(2023, 9, 2, 9, 0, 0), new DateTime(2023, 9, 2, 11, 0, 0), "Cours de Physique"));

            // Assignation de cours aux programmes
            Programmes.Add(progMath);
            Programmes.Add(progPhys);
            progMath.Listecours.Add(Cours[0]); // Ajout de l'algèbre au programme de mathématiques
            progPhys.Listecours.Add(Cours[1]); // Ajout de la mécanique au programme de physique
        }
    }

}
