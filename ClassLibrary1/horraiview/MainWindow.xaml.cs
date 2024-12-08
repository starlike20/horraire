using System.Windows;
using System.Windows.Controls;
using calendrieclassz;

namespace horraiview
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MyData Data { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Data = new MyData();
            DataContext = Data;
        }

        // Gestion de l'événement pour les ComboBox sélectionnées
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox comboBox)
            {
                if (comboBox.Name == "group")
                {
                    var selectedProgramme = comboBox.SelectedItem as Programme;
                    if (selectedProgramme != null)
                    {
                        // Mettre à jour les réservations basées sur le programme sélectionné
                        Data.Enfonctions(1, selectedProgramme.Nom);
                    }
                }
                else if (comboBox.Name == "salle")
                {
                    var selectedSalle = comboBox.SelectedItem as SalleDeClasse;
                    if (selectedSalle != null)
                    {
                        // Mettre à jour les réservations basées sur la salle sélectionnée
                        Data.Enfonctions(2, selectedSalle.NomSalle);
                    }
                }
                else if (comboBox.Name == "Ensei")
                {
                    var selectedEnseignant = comboBox.SelectedItem as Enseignants;
                    if (selectedEnseignant != null)
                    {
                        // Mettre à jour les réservations basées sur l'enseignant sélectionné
                        Data.Enfonctions(3, selectedEnseignant.Nom);
                    }
                }
            }
        }

        // Gestion de l'événement pour le bouton envoyer du groupe d'étudiants
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (group.SelectedItem is Programme selectedProgramme)
            {
                MessageBox.Show($"Envoi des informations pour le groupe {selectedProgramme.Nom}", "Envoyer Informations", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        // Gestion de l'événement pour le bouton envoyer de la salle de classe
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (salle.SelectedItem is SalleDeClasse selectedSalle)
            {
                MessageBox.Show($"Envoi des informations pour la salle {selectedSalle.NomSalle}", "Envoyer Informations", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        // Gestion de l'événement pour le bouton envoyer des enseignants
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (Ensei.SelectedItem is Enseignants selectedEnseignant)
            {
                MessageBox.Show($"Envoi des informations pour l'enseignant {selectedEnseignant.Nom}", "Envoyer Informations", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        // Gestion de l'événement pour le bouton "rester connecté"
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            if (checkBox.IsChecked == true)
            {
                MessageBox.Show("Vous serez maintenant connecté en permanence.", "Connexion permanente", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
