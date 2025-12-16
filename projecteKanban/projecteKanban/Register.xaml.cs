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
    /// Lógica de interacción para Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        private static string connectionString = "Server=ellaboratori.cat;Database=pau;Uid=pau;Pwd=campa123;";

        public string usuari;
        public string contra;
        public Register()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            usuari = UsernameTextBox.Text;
            contra = PasswordBox.Password;
            Usuari nouUsuari = new Usuari(usuari, contra, true);

            Usuari.AfegirUsuari(nouUsuari);


            if (string.IsNullOrWhiteSpace(usuari) || string.IsNullOrWhiteSpace(contra))
            {
                MessageBox.Show("El nom d'usuari i la contrasenya no poden estar buits.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (Usuari.ComprovarDuplicats(nouUsuari.Nom))
            {
                MessageBox.Show("El nom d'usuari ja existeix.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                Usuari.AfegirUsuari(nouUsuari);
                MessageBox.Show("Usuari registrat correctament.", "Èxit", MessageBoxButton.OK, MessageBoxImage.Information);
                Window loginWindow = new login();
                loginWindow.Show();
                this.Close();
            }
        }
    }
}
