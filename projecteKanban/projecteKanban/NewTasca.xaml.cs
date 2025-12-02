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
                Prioritat = prioritat,
                Estat = 0
            };

            var tascaControl = new TascaControl();
            tascaControl.DataContext = tasca;

            if (tasca.Prioritat == "Urgent")
            {
                Tasca.ContadorUrgents++;
                tascaControl.Background = Brushes.Red;
                tasca.CodiTasca = "U" + Tasca.ContadorUrgents.ToString();
            }
            else if (tasca.Prioritat == "Alta")
            {
                Tasca.ContadorAlts++;
                tascaControl.Background = Brushes.Orange;
                tasca.CodiTasca = "A" + Tasca.ContadorAlts.ToString();
            }
            else if (tasca.Prioritat == "Mitja")
            {
                Tasca.ContadorMig++;
                tascaControl.Background = Brushes.Yellow;
                tasca.CodiTasca = "M" + Tasca.ContadorMig.ToString();
            }
            else if (tasca.Prioritat == "Baixa")
            {
                Tasca.ContadorBaix++;
                tascaControl.Background = Brushes.Green;
                tasca.CodiTasca = "B" + Tasca.ContadorBaix.ToString();
            }else if (tasca.Prioritat == "Opcional/NA")
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

