using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calendrieclassz
{
    public class Enseignants : Personne
    {
        #region Definition
        private string _departement;
        public string Departement
        {
            get { return _departement; }
            set { _departement = value; }
        }

        private string _specialite;
        public string Specialite
        {
            get { return _specialite; }
            set { _specialite = value; }
        }

        private DateTime _dateDebutExperience;
        public DateTime DateDebutExperience
        {
            get { return _dateDebutExperience; }
            set
            {
                if (value > DateTime.Today)
                {
                    throw new ArgumentException("La date de début d'expérience doit être antérieure à la date actuelle.");
                }
                int years = DateTime.Today.Year - value.Year;
                if (years < 20)
                {
                    throw new ArgumentException("La date de début d'expérience n'est pas possible pour votre âge.");
                }
                _dateDebutExperience = value;
            }
        }

        public int AnneeExperience
        {
            get
            {
                int years = DateTime.Today.Year - DateDebutExperience.Year;

                if (DateDebutExperience > DateTime.Today.AddYears(-years))
                {
                    years--;
                }
                return years;
            }
        }

        private ObservableCollection<Cours> _coursEnseignes;
        public ObservableCollection<Cours> CoursEnseignes
        {
            get { return _coursEnseignes; }
            set { _coursEnseignes = value; }
        }
        #endregion

        #region Constructeur
        // Constructeur principal
        public Enseignants(string nom, string prenom, string sexe, string email, string profil, DateTime dateNaissance, string departement, string specialite, DateTime dateDebutExperience)
            : base(nom, prenom, sexe, email, profil, dateNaissance)
        {
            Departement = departement;
            Specialite = specialite;
            DateDebutExperience = dateDebutExperience;
            CoursEnseignes = new ObservableCollection<Cours>();
        }

        // Constructeur par défaut
        public Enseignants() : base()
        {
            Departement = "Rien";
            Specialite = "Rien";
            DateDebutExperience = new DateTime(2020, 1, 1);
            CoursEnseignes = new ObservableCollection<Cours>();
        }
        #endregion

        #region Override
        public override string ToString()
        {
            return base.ToString() + "Département : " + Departement + "\n" +
                                     "Spécialité : " + Specialite + "\n" +
                                     "Date de début d'expérience : " + DateDebutExperience.ToShortDateString() + "\n" +
                                     "Années d'expérience : " + AnneeExperience;
        }
        #endregion
    }
}