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

namespace projecteKanban
{
    /// <summary>
    /// Lógica de interacción para NewTasca.xaml
    /// </summary>
    public partial class NewTasca : Window
    {
        public NewTasca()
        {
            InitializeComponent();
        }

        private void CrearTasca(object sender, RoutedEventArgs e)
        {
            //string codiTasca = CodiTascaTextBox.Text;
            string nomTasca = NomTascaTextBox.Text;
            string descripcio = DescripcioTextBox.Text;
            DateTime dataInici = (DateTime)DataIniciPicker.SelectedDate;
            DateTime dataFinal = (DateTime)DataEntregaPicker.SelectedDate;
            int prioritat = -1;
            if (UrgentRadioButton.IsChecked == true) prioritat = 4;
            else if (AltaRadioButton.IsChecked == true) prioritat = 3;
            else if (MitjaRadioButton.IsChecked == true) prioritat = 2;
            else if (BaixaRadioButton.IsChecked == true) prioritat = 1;
            else if (OpcionalRadioButton.IsChecked == true) prioritat = 0;

            var tasca = new Tasca
            {
                NomTasca = nomTasca,
                Descripcio = descripcio,
                DataInici = dataInici,
                DataFinal = dataFinal,
                Prioritat = prioritat
            };

            var tascaControl = new TascaControl();
            tascaControl.DataContext = tasca;

            if (tasca.Prioritat == 4)
            {
                tascaControl.Background = Brushes.Red;
            }
            else if (tasca.Prioritat == 3)
            {
                tascaControl.Background = Brushes.Orange;
            }
            else if (tasca.Prioritat == 2)
            {
                tascaControl.Background = Brushes.Yellow;
            }
            else if (tasca.Prioritat == 1)
            {
                tascaControl.Background = Brushes.Green;
            }
            else if(tasca.Prioritat == 0)
            {
                tascaControl.Background = Brushes.White;
            }

            var mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            if (mainWindow != null)
                mainWindow.col1.Children.Add(tascaControl);

            Close();
        }


    }
}

