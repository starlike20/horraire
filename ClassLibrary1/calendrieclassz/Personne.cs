using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calendrieclassz
{
    public abstract class Personne
    {
        private int _idPersonne;
        public int IdPersonne
        {
            get { return _idPersonne; }
            set { _idPersonne = value; }
        }

        private string _nom;
        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        private string _prenom;
        public string Prenom
        {
            get { return _prenom; }
            set { _prenom = value; }
        }

        private string _sexe;
        public string Sexe
        {
            get { return _sexe; }
            set
            {
                if (value.Length > 1)
                    throw new ArgumentException("Le sexe doit être un caractère unique.");
                _sexe = value;
            }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private string _profil;
        public string Profil
        {
            get { return _profil; }
            set { _profil = value; }
        }

        private DateTime _dateNaissance;
        public DateTime DateNaissance
        {
            get { return _dateNaissance; }
            set
            {
                int years = DateTime.Today.Year - value.Year;
                if (years < 17)
                {
                    throw new ArgumentException("Vous n'avez pas l'âge requis.");
                }
                _dateNaissance = value;
            }
        }

        public int Age
        {
            get
            {
                int years = DateTime.Today.Year - DateNaissance.Year;
                if (DateNaissance > DateTime.Today.AddYears(-years))
                {
                    years--;
                }
                return years;
            }
        }

        static int num = 0;

        // Constructeur principal
        public Personne(string nom, string prenom, string sexe, string mail, string profil, DateTime date)
        {
            num++;
            IdPersonne = num;
            Nom = nom;
            Prenom = prenom;
            Sexe = sexe;
            Email = mail;
            Profil = profil;
            DateNaissance = date;
        }

        // Constructeur par défaut
        public Personne() : this("rien", "rien", "x", "rien", "C:\\Users\\fogan\\OneDrive\\Bureau\\hepl 2\\c#\\exercices\\profil\\Anonyme.png", new DateTime(2006, 1, 1))
        {
        }

        public override string ToString()
        {
            return $"IdPersonne={IdPersonne},\nNom={Nom},\nPrenom={Prenom},\nSexe={Sexe},\nEmail={Email}\n";
        }
    }
}
