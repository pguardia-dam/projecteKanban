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
                Prioritat = prioritat,
                Estat = 0
            };
            var tascaControl = new TascaControl();
            tascaControl.DataContext = tasca;

            if (tasca.Prioritat == 4)
            {
                Tasca.ContadorUrgents++;
                tascaControl.Background = Brushes.Red;
                tasca.CodiTasca = "U" + Tasca.ContadorUrgents.ToString();
            }
            else if (tasca.Prioritat == 3)
            {
                Tasca.ContadorAlts++;
                tascaControl.Background = Brushes.Orange;
                tasca.CodiTasca = "A" + Tasca.ContadorAlts.ToString();
            }
            else if (tasca.Prioritat == 2)
            {
                Tasca.ContadorMig++;
                tascaControl.Background = Brushes.Yellow;
                tasca.CodiTasca = "M" + Tasca.ContadorMig.ToString();
            }
            else if (tasca.Prioritat == 1)
            {
                Tasca.ContadorBaix++;
                tascaControl.Background = Brushes.Green;
                tasca.CodiTasca = "B" + Tasca.ContadorBaix.ToString();
            }
            else if (tasca.Prioritat == 0)
            {
                Tasca.ContadorOpcional++;
                tascaControl.Background = Brushes.Gray;
                tasca.CodiTasca = "O" + Tasca.ContadorOpcional.ToString();
            }


            var mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            if (mainWindow != null)
                mainWindow.col1.Children.Add(tascaControl);

            Close();
        }


    }
}

