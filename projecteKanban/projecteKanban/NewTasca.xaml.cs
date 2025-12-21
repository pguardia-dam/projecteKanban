using System;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace projecteKanban
{
    public partial class NewTasca : Window
    {
        private Tasca tascaOriginal;
        private bool isEditMode;
        private int prioritatAntiga;


        // Constructor per crear
        public NewTasca()
        {
            InitializeComponent();
            isEditMode = false;
        }

        // Constructor per editar
        public NewTasca(Tasca tasca) : this()
        {
            tascaOriginal = tasca;
            isEditMode = true;

            prioritatAntiga = tasca.Prioritat;

            // Omplir els camps amb les dades existents
            NomTascaTextBox.Text = tasca.NomTasca;
            DescripcioTextBox.Text = tasca.Descripcio;
            DataIniciPicker.SelectedDate = tasca.DataInici;
            DataEntregaPicker.SelectedDate = tasca.DataFinal;

            switch (tasca.Prioritat)
            {
                case 4: UrgentRadioButton.IsChecked = true; break;
                case 3: AltaRadioButton.IsChecked = true; break;
                case 2: MitjaRadioButton.IsChecked = true; break;
                case 1: BaixaRadioButton.IsChecked = true; break;
                case 0: OpcionalRadioButton.IsChecked = true; break;
            }

            CrearButton.Content = "Guardar Canvis"; // canvia el text del botó
        }

        private void CrearTasca(object sender, RoutedEventArgs e)
        {
            string nom = NomTascaTextBox.Text;
            string desc = DescripcioTextBox.Text;
            DateTime inici = (DateTime)DataIniciPicker.SelectedDate;
            DateTime final = (DateTime)DataEntregaPicker.SelectedDate;

            if (string.IsNullOrWhiteSpace(nom) || string.IsNullOrWhiteSpace(desc) 
                || inici == null || final == null 
                || (UrgentRadioButton.IsChecked != true 
                && AltaRadioButton.IsChecked != true && MitjaRadioButton.IsChecked != true 
                && BaixaRadioButton.IsChecked != true && OpcionalRadioButton.IsChecked != true)) 
            { 
                MessageBox.Show("Emplena tots els camps.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                int prioritat = -1;
                if (UrgentRadioButton.IsChecked == true) prioritat = 4;
                else if (AltaRadioButton.IsChecked == true) prioritat = 3;
                else if (MitjaRadioButton.IsChecked == true) prioritat = 2;
                else if (BaixaRadioButton.IsChecked == true) prioritat = 1;
                else if (OpcionalRadioButton.IsChecked == true) prioritat = 0;

                if (isEditMode)
                {
                    // Actualitzar la tasca existent
                    tascaOriginal.NomTasca = nom;
                    tascaOriginal.Descripcio = desc;
                    tascaOriginal.DataInici = inici;
                    tascaOriginal.DataFinal = final;
                    tascaOriginal.Prioritat = prioritat;

                    // Guardar canvis
                    Tasca.ActualitzarTasca(tascaOriginal, tascaOriginal.CodiTasca, prioritatAntiga);
                }
                else
                {
                    // Crear nova tasca
                    Tasca t = new Tasca(
                        nom,
                        desc,
                        login.UsuariActual.GetNom(),
                        inici,
                        final,
                        prioritat,
                        0
                    );

                    // Generar codi segons prioritat
                    switch (prioritat)
                    {
                        case 4: Tasca.ContadorUrgents++; t.CodiTasca = "U" + Tasca.ContadorUrgents; break;
                        case 3: Tasca.ContadorAlts++; t.CodiTasca = "A" + Tasca.ContadorAlts; break;
                        case 2: Tasca.ContadorMig++; t.CodiTasca = "M" + Tasca.ContadorMig; break;
                        case 1: Tasca.ContadorBaix++; t.CodiTasca = "B" + Tasca.ContadorBaix; break;
                        case 0: Tasca.ContadorOpcional++; t.CodiTasca = "O" + Tasca.ContadorOpcional; break;
                    }

                    Tasca.AfegirTasca(t); // INSERT a la BD
                }

                // Refrescar el kanban
                var main = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
                main?.RefrescarKanban();

                Close();
            }

            
        }
    }
}
