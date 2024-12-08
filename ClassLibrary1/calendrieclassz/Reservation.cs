using System;

namespace calendrieclassz
{
    public class Reservation
    {
        #region Définition des Propriétés

        // Identifiant de l'enseignant qui a effectué la réservation
        public int ID_Enseignant { get; set; }

        // Identifiant de la salle réservée
        public int ID_SalleDeClasse { get; set; }

        // Identifiant du cours pour lequel la réservation est effectuée
        public int ID_Cours { get; set; }

        // Date et heure de début de la réservation
        public DateTime DateHeureDebut { get; set; }

        // Date et heure de fin de la réservation
        public DateTime DateHeureFin { get; set; }

        // Description ou objectif de la réservation
        public string Purpose { get; set; }

        // Pour des besoins d'affichage, spécifier la colonne et la ligne dans une grille
        public int ligne { get; set; } // Ligne dans l'affichage (ex: l'heure de début)
        public int colonne { get; set; } // Colonne dans l'affichage (ex: jour de la semaine)
        public int periode { get; set; } // Combien de lignes à occuper (durée de la réservation)

        #endregion

        #region Constructeurs

        // Constructeur principal
        public Reservation(int idEnseignant, int idSalle, int idCours, DateTime debut, DateTime fin, string purpose)
        {
            ID_Enseignant = idEnseignant;
            ID_SalleDeClasse = idSalle;
            ID_Cours = idCours;
            DateHeureDebut = debut;
            DateHeureFin = fin;
            Purpose = purpose;

            CalculerPosition();
        }

        // Constructeur par défaut
        public Reservation()
        {
            ID_Enseignant = -1;
            ID_SalleDeClasse = -1;
            ID_Cours = -1;
            DateHeureDebut = DateTime.MinValue;
            DateHeureFin = DateTime.MinValue;
            Purpose = "Aucune réservation";
        }

        #endregion

        #region Méthodes

        // Calculer la position pour l'affichage de la réservation dans une grille
        private void CalculerPosition()
        {
            // Calcul simple pour positionner dans une grille en fonction des heures
            ligne = (DateHeureDebut.Hour - 7) * 2 + (DateHeureDebut.Minute >= 30 ? 1 : 0);
            periode = (int)((DateHeureFin - DateHeureDebut).TotalMinutes / 30);

            // Calculer la colonne (jour de la semaine)
            switch (DateHeureDebut.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    colonne = 1;
                    break;
                case DayOfWeek.Tuesday:
                    colonne = 2;
                    break;
                case DayOfWeek.Wednesday:
                    colonne = 3;
                    break;
                case DayOfWeek.Thursday:
                    colonne = 4;
                    break;
                case DayOfWeek.Friday:
                    colonne = 5;
                    break;
                default:
                    colonne = 0; // Cas par défaut, au besoin
                    break;
            }
        }

        // Méthode pour vérifier si la réservation se chevauche avec une autre
        public bool EstEnConflit(Reservation autreReservation)
        {
            return ID_SalleDeClasse == autreReservation.ID_SalleDeClasse &&
                   ((DateHeureDebut < autreReservation.DateHeureFin && DateHeureDebut >= autreReservation.DateHeureDebut) ||
                    (DateHeureFin > autreReservation.DateHeureDebut && DateHeureFin <= autreReservation.DateHeureFin));
        }

        // Méthode pour afficher les informations de la réservation
        public override string ToString()
        {
            return $"Réservation de {DateHeureDebut.ToString("dd/MM/yyyy HH:mm")} à {DateHeureFin.ToString("HH:mm")} " +
                   $"pour le cours {ID_Cours}, en salle {ID_SalleDeClasse}, enseignant {ID_Enseignant}. " +
                   $"Objectif : {Purpose}";
        }

        #endregion
    }
}
