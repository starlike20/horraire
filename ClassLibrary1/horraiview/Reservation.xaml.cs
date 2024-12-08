using calendrieclassz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace horraiview
{
    /// <summary>
    /// Interaction logic for reservation.xaml
    /// </summary>
    public partial class reservation : Window
    {
        private int v1;
        private int v2;
        private int v3;
        private DateTime dateTime1;
        private DateTime dateTime2;
        private string v4;

        public int ID_Cours { get; internal set; }
        public int ID_SalleDeClasse { get; internal set; }

        public reservation()
        {
            InitializeComponent();
            DataContext = new MyData();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var enseignantId = (comboBoxEnseignant.SelectedItem as Enseignant).Id;
            var salleId = (comboBoxSalle.SelectedItem as Salle).Id;
            var date = datePicker.SelectedDate.Value;
            var heureDebut = TimeSpan.Parse(comboBoxHeureDebut.SelectedItem.ToString());
            var heureFin = TimeSpan.Parse(comboBoxHeureFin.SelectedItem.ToString());

            DateTime startDate = date.Add(heureDebut);
            DateTime endDate = date.Add(heureFin);

            // Vérifier les collisions
            if (!HasCollision(startDate, endDate, salleId))
            {
                // Ajouter la réservation
                Reservation newReservation = new Reservation
                {
                    EnseignantId = enseignantId,
                    SalleId = salleId,
                    DateHeureDebut = startDate,
                    DateHeureFin = endDate
                };
                Reservations.Add(newReservation);
                MessageBox.Show("Réservation ajoutée avec succès!");
            }
            else
            {
                MessageBox.Show("Impossible d'ajouter la réservation, car il y a une collision avec une autre réservation.");
            }
        }
        public bool colision(DateTime startDate, DateTime endDate, int salleId)
        {
            foreach (var reservation in ((MyData)DataContext).Reservations)
            {
                if (reservation.ID_Reservation == salleId &&
                    ((startDate < reservation.DateHeureFin && startDate >= reservation.DateHeureDebut) ||
                     (endDate > reservation.DateHeureDebut && endDate <= reservation.DateHeureFin)))
                {
                    return true;
                }
            }
            return false;
        }
    }
}