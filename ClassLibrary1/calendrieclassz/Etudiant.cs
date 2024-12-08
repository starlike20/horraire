using System;

namespace calendrieclassz
{
    public class Etudiant : Personne
    {
        #region Définition des Propriétés

        private DateTime _dateInscription;

        // Date d'inscription de l'étudiant
        public DateTime DateInscription
        {
            get { return _dateInscription; }
            set
            {
                if (value > DateTime.Today)
                {
                    throw new ArgumentException("La date d'inscription ne peut pas être postérieure à aujourd'hui.");
                }
                _dateInscription = value;
            }
        }

        // Programme auquel l'étudiant est inscrit
        public Programme Programme { get; set; }

        #endregion

        #region Constructeurs

        // Constructeur principal
        public Etudiant(string nom, string prenom, string sexe, string email, string profil, DateTime dateNaissance, DateTime dateInscription, Programme programme)
            : base(nom, prenom, sexe, email, profil, dateNaissance)
        {
            try
            {
                DateInscription = dateInscription;
                Programme = programme;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Erreur dans le constructeur d'étudiant : " + ex.Message);
            }
        }

        // Constructeur par défaut
        public Etudiant() : base()
        {
            DateInscription = DateTime.Today;
            Programme = new Programme("Non spécifié", "Programme non spécifié");
        }

        #endregion

        #region Méthodes

        // Méthode pour changer le programme de l'étudiant
        public void ChangerProgramme(Programme nouveauProgramme)
        {
            if (nouveauProgramme != null)
            {
                Programme = nouveauProgramme;
            }
        }

        // Méthode pour afficher les informations de l'étudiant
        public override string ToString()
        {
            return base.ToString() +
                   $"\nDate d'inscription : {DateInscription.ToShortDateString()}\n" +
                   $"Programme : {Programme.Nom}";
        }

        #endregion
    }
}
