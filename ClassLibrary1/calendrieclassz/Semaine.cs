using System;
using System.ComponentModel;

namespace calendrieclassz
{
    public class Semaine: INotifyPropertyChanged
    {

        private DateTime lundi;
        public DateTime Lundi
        {
            get { return lundi; }
            set
            {
                lundi = value;
                OnPropertyChanged(nameof(Lundi));
            }
        }
        private DateTime mardi;
        public DateTime Mardi
        {
            get { return mardi; }
            set
            {
                mardi = value;
                OnPropertyChanged(nameof(Mardi));
            }
        }
        private DateTime mercredi;
        public DateTime Mercredi
        {
            get { return mercredi; }
            set
            {
                mercredi = value;
                OnPropertyChanged(nameof(Mercredi));
            }
        }

        private DateTime jeudi;
        public DateTime Jeudi
        {
            get { return jeudi; }
            set
            {
                jeudi = value;
                OnPropertyChanged(nameof(Jeudi));
            }
        }
        private DateTime vendredi;

        public event PropertyChangedEventHandler? PropertyChanged;

        public DateTime Vendredi
        {
            get { return vendredi; }
            set
            {
                vendredi = value;
                OnPropertyChanged(nameof(Vendredi));
            }
        }

        public Semaine()
        {
            SetCurrentWeek();
        }

        public void Precedent()
        {
            SetWeek(-7);
        }

        public void Suivant()
        {
            SetWeek(7);
        }

        private void SetCurrentWeek()
        {
            DateTime today = DateTime.Today;
            int daysToMonday = DayOfWeek.Monday - today.DayOfWeek;
            DateTime monday = today.AddDays(daysToMonday);
            if (today.DayOfWeek == DayOfWeek.Sunday)
            {
                monday = today.AddDays(-6);
            }
            Lundi = monday;
            Mardi= monday.AddDays(1);
            Mercredi = monday.AddDays(2);
            Jeudi = monday.AddDays(3);
            Vendredi = monday.AddDays(4);
            // Assurez-vous de définir et notifier les changements pour les autres jours ici
        }

        private void SetWeek(int days)
        {
            Lundi = Lundi.AddDays(days);
            Mardi = Mardi.AddDays(days);
            Mercredi = Mercredi.AddDays(days);
            Jeudi = Jeudi.AddDays(days);
            Vendredi = Vendredi.AddDays(days);
            // Mettez à jour les autres jours ici, en notifiant les changements
        }

        public void Aujourd()
        {
            DateTime today = DateTime.Today;


            int daysToMonday = DayOfWeek.Monday - today.DayOfWeek;
            DateTime monday = today.AddDays(daysToMonday);

            if (today.DayOfWeek == DayOfWeek.Sunday)
            {
                monday = today.AddDays(-6);
            }
            Lundi = monday;
            Mardi = monday.AddDays(1);
            Mercredi = monday.AddDays(2);
            Jeudi = monday.AddDays(3);
            Vendredi = monday.AddDays(4);
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}