using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace GraKosci
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random rnd = new Random();

        int[] kosci = new int[5];

        bool[] zablokowane = new bool[5];

        public ObservableCollection<Rzut> Rzuty { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Rzuty = new ObservableCollection<Rzut>();
        }

        private void RzucKoscmi(object sender, RoutedEventArgs e)
        {
            int suma = 0;

            for (int i = 0; i < 5; i++)
            {
                if (!zablokowane[i])
                {
                    kosci[i] = rnd.Next(1, 7);
                }

                suma += kosci[i];
            }

            Kosc1.Source = ZaladujObraz(kosci[0]);
            Kosc2.Source = ZaladujObraz(kosci[1]);
            Kosc3.Source = ZaladujObraz(kosci[2]);
            Kosc4.Source = ZaladujObraz(kosci[3]);
            Kosc5.Source = ZaladujObraz(kosci[4]);

            Wynik.Text = suma.ToString();
        }

        private void Kosc_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Image img && img.Tag != null)
            {
                int index = int.Parse(img.Tag.ToString());

                zablokowane[index] = !zablokowane[index];

                if (zablokowane[index])
                {
                    img.Opacity = 0.5;
                }
                else
                {
                    img.Opacity = 1.0;
                }
            }
        }

        private BitmapImage ZaladujObraz(int oczka)
        {
            return new BitmapImage(
                new Uri($"/Images/kosc{oczka}.png", UriKind.Relative)
            );
        }
    }
}