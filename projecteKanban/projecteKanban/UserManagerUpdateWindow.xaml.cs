using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
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
using MySql.Data.MySqlClient;

namespace projecteKanban
{
    /// <summary>
    /// Lógica de interacción para UserManagerUpdateWindow.xaml
    /// </summary>
    public partial class UserManagerUpdateWindow : Window
    {
        public string usuari;
        public string contra;

        private static string connectionString = "Server=ellaboratori.cat;Database=pau;Uid=pau;Pwd=campa123;";

        private Usuari _usuari; 
        
        public UserManagerUpdateWindow(Usuari usuari)
        {
            InitializeComponent(); 
            _usuari = usuari;  
            nameInput.Text = _usuari.Nom; 
            passwdInput.Password = _usuari.Contrasenya; 
            responsableCheckBox.IsChecked = _usuari.Responsable; 
        }

        public UserManagerUpdateWindow()
        {
            InitializeComponent();
        }


        private void BtnGuardar(object sender, RoutedEventArgs e)
        {
            usuari = nameInput.Text;
            contra = passwdInput.Password;

            if (string.IsNullOrWhiteSpace(usuari) || string.IsNullOrWhiteSpace(contra))
            {
                MessageBox.Show("El nom d'usuari i la contrasenya no poden estar buits.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                _usuari.Nom = usuari;
                _usuari.Contrasenya = contra;
                _usuari.Responsable = responsableCheckBox.IsChecked ?? false;

                Usuari.UpdateUser(_usuari);

                MessageBox.Show("Usuari actualitzat correctament.", "Èxit", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
        }


    }
}
