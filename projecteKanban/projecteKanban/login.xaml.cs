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
    /// Lógica de interacción para login.xaml
    /// </summary>
    
    public partial class login : Window
    {
        public string usuari;
        public string contra;
        public login()
        {
            InitializeComponent();

        }

        private void Login_Button_Click(object sender, RoutedEventArgs e)
        {
            usuari = UsernameTextBox.Text;
            contra = PasswordBox.Password;
            if(Usuari.Autenticar(usuari, contra) == null)
            {
                MessageBox.Show("Usuari o contrasenya incorrectes");
                return;
            }
            else if(Usuari.Autenticar(usuari, contra) != null)
            { 
                //MessageBox.Show("Usuari o contrasenya correctes, fent login"); //treure aixo

                Window window = new MainWindow();
                window.Show();
                this.Close();
            }


                     
        }

        private void Register_Button_Click(object sender, RoutedEventArgs e)
        {
            Window window = new Register();
            window.Show();
            this.Close();
        }
    }
}
