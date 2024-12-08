using calendrieclassz;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace horraiview
{
    public class MyData : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        // Collections des données
        public ObservableCollection<Enseignants> Enseignants { get; set; } = new ObservableCollection<Enseignants>();
        public ObservableCollection<Etudiant> Etudiants { get; set; } = new ObservableCollection<Etudiant>();
        public ObservableCollection<Cours> Cours { get; set; } = new ObservableCollection<Cours>();
        public ObservableCollection<SalleDeClasse> Salles { get; set; } = new ObservableCollection<SalleDeClasse>();
        public ObservableCollection<Reservation> Reservations { get; set; } = new ObservableCollection<Reservation>();
        public ObservableCollection<Programme> Programmes { get; set; } = new ObservableCollection<Programme>();
        public ObservableCollection<Reservation> totaleReservations { get; set; } = new ObservableCollection<Reservation>();

        // Autres propriétés
        public string Title { get; set; }
        public Enseignants courant { get; set; }
        public string img { get; set; }

        private Semaine _semaine;

        public Semaine Semaine
        {
            get { return _semaine; }
            set
            {
                _semaine = value;
                OnPropertyChanged(nameof(Semaine));
            }
        }

        // Constructeur
        public MyData()
        {
            InitialiserDonneesDeTest(); // Initialiser avec des données de test
        }

        // Méthode pour initialiser des données de test
        public void InitialiserDonneesDeTest()
        {
            // Ajouter quelques réservations de test
            string profilPath = "C:\\Users\\fogan\\OneDrive\\Bureau\\hepl 2\\c#\\exercices\\profil\\Anonyme.png";
            Programme programm = new Programme(3, "BSc Maths", "Programme de licence en mathématiques");
            Cours cour1 = new Cours("Math 101", "Introduction à l'algèbre", 1, 3);
            Cours cour2 = new Cours("physique 101", "Introduction à l'algèbre", 1, 3);
            programm.Listecours.Add(cour1);
            programm.Listecours.Add(cour2);
            Programmes.Add(programm);

            totaleReservations.Add(new Reservation(1, 101, 201, new DateTime(2024, 5, 1, 9, 0, 0), new DateTime(2024, 5, 1, 12, 0, 0), "Cours de mathématiques"));
            totaleReservations.Add(new Reservation(2, 102, 202, new DateTime(2024, 5, 2, 9, 0, 0), new DateTime(2024, 5, 2, 11, 0, 0), "Cours de physique"));

            // Création des enseignants
            Enseignants enseignants1 = new Enseignants("Doe", "John", "M", "jdoe@example.com", profilPath, new DateTime(1975, 1, 1), "Mathématiques", "Algèbre", new DateTime(2000, 1, 1));
            enseignants1.CoursEnseignes.Add(cour1);
            enseignants1.CoursEnseignes.Add(cour2);
            Enseignants.Add(enseignants1);
            Enseignants.Add(new Enseignants("Smith", "Jane", "F", "jsmith@example.com", profilPath, new DateTime(1980, 6, 15), "Physique", "Mécanique", new DateTime(2002, 1, 1)));

            // Création des cours
            Cours cour3 = new Cours("Algèbre 101", "Introduction à l'Algèbre", 1, 1);
            Cours cour4 = new Cours("Mécanique 101", "Introduction à la Mécanique", 2, 2);
            Cours.Add(cour3);
            Cours.Add(cour4);

            // Création des étudiants
            Programme progMath = new Programme(1, "BSc Mathématiques", "Licence en Mathématiques");
            Programme progPhys = new Programme(2, "BSc Physique", "Licence en Physique");
            progMath.Listecours.Add(cour3);
            progPhys.Listecours.Add(cour4);

            Etudiants.Add(new Etudiant("Roe", "Richard", "M", "rroe@example.com", profilPath, new DateTime(2001, 9, 1), DateTime.Today, progMath));
            Etudiants.Add(new Etudiant("Doe", "Emily", "F", "edoe@example.com", profilPath, new DateTime(2001, 9, 1), DateTime.Today, progPhys));

            // Création des salles de classe
            Salles.Add(new SalleDeClasse(1, "Salle 101", 30));
            Salles.Add(new SalleDeClasse(2, "Salle 102", 25));

            // Création des réservations
            totaleReservations.Add(new Reservation(1, 1, 1, new DateTime(2023, 9, 1, 16, 0, 0), new DateTime(2023, 9, 1, 17, 30, 0), "Cours de Mathématiques"));
            totaleReservations.Add(new Reservation(2, 2, 2, new DateTime(2023, 9, 2, 9, 0, 0), new DateTime(2023, 9, 2, 11, 0, 0), "Cours de Physique"));

            // Assignation de cours aux programmes
            Programmes.Add(progMath);
            Programmes.Add(progPhys);
            progMath.Listecours.Add(Cours[0]);
            progPhys.Listecours.Add(Cours[1]);

            // Définir le courant
            courant = Enseignants[0];
            img = "";
            Semaine = new Semaine();
        }

        // Méthode de gestion des filtres sur les réservations
        public void Enfonctions(int a, string b)
        {
            Title = b;
            switch (a)
            {
                case 1:
                    {
                        Programme program = Programmes.FirstOrDefault(p => p.Nom == b);
                        if (program != null)
                        {
                            var courseIds = program.Listecours.Select(c => c.ID_Cours).ToList();
                            var reservationsForProgram = totaleReservations.Where(r => courseIds.Contains(r.ID_Cours)).ToList();
                            Reservations = new ObservableCollection<Reservation>(reservationsForProgram);
                        }
                    }
                    break;

                case 2:
                    {
                        var salle = Salles.FirstOrDefault(r => r.NomSalle == b);
                        if (salle != null)
                        {
                            var reservationsSalle = totaleReservations.Where(r => r.ID_SalleDeClasse == salle.ID_SalleDeClasse).ToList();
                            Reservations = new ObservableCollection<Reservation>(reservationsSalle);
                        }
                    }
                    break;

                case 3:
                    {
                        var enseignant = Enseignants.FirstOrDefault(p => p.Nom == b);
                        if (enseignant != null)
                        {
                            var coursIds = enseignant.CoursEnseignes.Select(c => c.ID_Cours).ToList();
                            var reservationsForEnseignant = totaleReservations.Where(r => coursIds.Contains(r.ID_Cours)).ToList();
                            Reservations = new ObservableCollection<Reservation>(reservationsForEnseignant);
                        }
                    }
                    break;
            }
        }

        // Vérifie si deux dates sont dans la même semaine
        public static bool AreDatesInSameWeek(DateTime date1, DateTime date2)
        {
            date1 = date1.Date;
            date2 = date2.Date;

            DateTime startOfWeekDate1 = date1.AddDays(-(int)(date1.DayOfWeek == DayOfWeek.Sunday ? 6 : (int)date1.DayOfWeek - 1));
            DateTime startOfWeekDate2 = date2.AddDays(-(int)(date2.DayOfWeek == DayOfWeek.Sunday ? 6 : (int)date2.DayOfWeek - 1));

            return startOfWeekDate1 == startOfWeekDate2;
        }

        // Récupérer le nom du programme à partir de son ID
        public string GetNomProgramme(int idProgramme)
        {
            Programme program = Programmes.FirstOrDefault(p => p.ID_Programme == idProgramme);
            return program != null ? program.Nom : "Inconnu";
        }

        // Méthode pour notifier les changements de propriété
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
