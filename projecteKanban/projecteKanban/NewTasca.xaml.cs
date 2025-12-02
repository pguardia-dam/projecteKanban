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
            string prioritat = "";
            if (UrgentRadioButton.IsChecked == true) prioritat = "Urgent";
            else if (AltaRadioButton.IsChecked == true) prioritat = "Alta";
            else if (MitjaRadioButton.IsChecked == true) prioritat = "Mitja";
            else if (BaixaRadioButton.IsChecked == true) prioritat = "Baixa";
            else if (OpcionalRadioButton.IsChecked == true) prioritat = "Opcional/NA";

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

            var mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            if (mainWindow != null)
                mainWindow.col1.Children.Add(tascaControl);

            Close();
        }


    }
}

