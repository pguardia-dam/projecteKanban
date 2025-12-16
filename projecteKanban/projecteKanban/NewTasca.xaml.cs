using System;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace projecteKanban
{
    public partial class NewTasca : Window
    {
        public NewTasca()
        {
            InitializeComponent();
        }

        private void CrearTasca(object sender, RoutedEventArgs e)
        {
            string nom = NomTascaTextBox.Text;
            string desc = DescripcioTextBox.Text;
            DateTime inici = (DateTime)DataIniciPicker.SelectedDate;
            DateTime final = (DateTime)DataEntregaPicker.SelectedDate;

            int prioritat = -1; if (UrgentRadioButton.IsChecked == true) prioritat = 4;
            else if (AltaRadioButton.IsChecked == true) prioritat = 3;
            else if (MitjaRadioButton.IsChecked == true) prioritat = 2;
            else if (BaixaRadioButton.IsChecked == true) prioritat = 1;
            else if (OpcionalRadioButton.IsChecked == true) prioritat = 0;

            Tasca t = new Tasca(
                nom,
                desc,
                login.UsuariActual.GetNom(),
                inici,
                final,
                prioritat,
                0
            );

            // Generar codi únic
            // Generar codi segons prioritat
            switch (prioritat)
            {
                case 4:
                    Tasca.ContadorUrgents++;
                    t.CodiTasca = "U" + Tasca.ContadorUrgents;
                    break;

                case 3:
                    Tasca.ContadorAlts++;
                    t.CodiTasca = "A" + Tasca.ContadorAlts;
                    break;

                case 2:
                    Tasca.ContadorMig++;
                    t.CodiTasca = "M" + Tasca.ContadorMig;
                    break;

                case 1:
                    Tasca.ContadorBaix++;
                    t.CodiTasca = "B" + Tasca.ContadorBaix;
                    break;

                case 0:
                    Tasca.ContadorOpcional++;
                    t.CodiTasca = "O" + Tasca.ContadorOpcional;
                    break;
            }


            // Crear control visual
            var control = new TascaControl();
            control.DataContext = t;

            switch (prioritat)
            {
                case 4: control.Background = Brushes.Red; break;
                case 3: control.Background = Brushes.Orange; break;
                case 2: control.Background = Brushes.Yellow; break;
                case 1: control.Background = Brushes.Green; break;
                default: control.Background = Brushes.Gray; break;
            }

            // Guardar a BD
            Tasca.AfegirTasca(t);

            // Afegir al tauler
            var main = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            if (main != null)
                main.col1.Children.Add(control);

            Close();
        }
    }
}
