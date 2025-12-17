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
    /// Lógica de interacción para NewUserEditor.xaml
    /// </summary>
    public partial class NewUserEditor : Window
    {
        public NewUserEditor()
        {
            InitializeComponent();
        }

        private void SaveUser(object sender, RoutedEventArgs e)
        {

            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;
            bool isAdmin = IsAdminCheckBox.IsChecked == true;

            Usuari nouUsuari = new Usuari(username, password, isAdmin);
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("El nom d'usuari i la contrasenya no poden estar buits.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (Usuari.ComprovarDuplicats(nouUsuari.Nom))
            {
                MessageBox.Show("El nom d'usuari ja existeix.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Usuari.AfegirUsuari(nouUsuari);
                MessageBox.Show("Usuari registrat correctament.", "Èxit", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
        }

    }
}
