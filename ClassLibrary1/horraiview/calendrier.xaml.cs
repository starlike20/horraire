using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using calendrieclassz;

namespace horraiview
{
    public partial class calendrier : Window
    {
        public calendrier() : this(new MyData()) { }
        public calendrier(MyData data)
        {
            InitializeComponent();
            DataContext = data;
            jourcourant();
            for (int i = 0; i < data.Reservations.Count; i++)
            {
                charge(data.Reservations[i]);
            }
        }

        private void charge(Reservation courant)
        {
            Border newBorder = new Border
            {
                Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFAE6E6")),
                CornerRadius = new CornerRadius(10, 10, 10, 10),
                Margin = new Thickness(1, 0, 1, 6),
                BorderThickness = new Thickness(0, 0, 0, 0),
            };

            newBorder.MouseUp += (s, e) => Click_1(courant);

            Grid newGrid = new Grid();
            newGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(25, GridUnitType.Pixel) });
            newGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(10, GridUnitType.Star) });

            Border innerBorder = new Border
            {
                Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF785EF")),
                CornerRadius = new CornerRadius(10, 10, 0, 0)
            };
            Label timeLabel = new Label
            {
                Content = courant.DateHeureDebut.ToString("H'H'mm") + " - " + courant.DateHeureFin.ToString("H'H'mm"),
                FontSize = 10,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            innerBorder.Child = timeLabel;
            newGrid.Children.Add(innerBorder);
            Grid.SetRow(innerBorder, 0);

            WrapPanel wrapPanel = new WrapPanel
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            Label courseLabel = new Label
            {
                Content = courant.Purpose,
            };
            wrapPanel.Children.Add(courseLabel);
            newGrid.Children.Add(wrapPanel);
            Grid.SetRow(wrapPanel, 1);

            newBorder.Child = newGrid;
            revervatio.Children.Add(newBorder);
            Grid.SetRow(newBorder, courant.ligne);
            Grid.SetColumn(newBorder, courant.colonne);
            Grid.SetRowSpan(newBorder, courant.periode);
        }

        private void Click_1(Reservation reservation)
        {
            //ReservationDetailsWindow detailsWindow = new ReservationDetailsWindow(reservation);
           // detailsWindow.ShowDialog();
        }

        private void Button_Click_Precedent(object sender, RoutedEventArgs e)
        {
            MyData data = (MyData)DataContext;
            data.Semaine.Precedent();
            jourcourant();
        }

        private void Button_Click_Suivant(object sender, RoutedEventArgs e)
        {
            MyData data = (MyData)DataContext;
            data.Semaine.Suivant();
            jourcourant();
        }

        private void Button_Click_Aujourdhui(object sender, RoutedEventArgs e)
        {
            MyData data = (MyData)DataContext;
            data.Semaine.Aujourd();
            jourcourant();
        }

        private void jourcourant()
        {
            MyData data = (MyData)DataContext;
            DateTime date = DateTime.Now;
            DateTime d = data.Semaine.Lundi;
            DayOfWeek today = date.DayOfWeek;
            SolidColorBrush highlightBrush = new SolidColorBrush(Color.FromArgb(50, 255, 215, 0));
            if (MyData.AreDatesInSameWeek(date, d))
            {
                switch (today)
                {
                    case DayOfWeek.Monday:
                        lundi.Background = highlightBrush;
                        break;
                    case DayOfWeek.Tuesday:
                        mardi.Background = highlightBrush;
                        break;
                    case DayOfWeek.Wednesday:
                        mercredi.Background = highlightBrush;
                        break;
                    case DayOfWeek.Thursday:
                        jeudi.Background = highlightBrush;
                        break;
                    case DayOfWeek.Friday:
                        vendredi.Background = highlightBrush;
                        break;
                }
            }
            else
            {
                lundi.Background = null;
                mardi.Background = null;
                mercredi.Background = null;
                jeudi.Background = null;
                vendredi.Background = null;
            }
        }
    }
}
