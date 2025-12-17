using MySql.Data.MySqlClient;
using Org.BouncyCastle.Pqc.Crypto.Lms;
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
    /// Lógica de interacción para UserManager.xaml
    /// </summary>
    public partial class UserManager : Window
    {
        private static string connectionString = "Server=ellaboratori.cat;Database=pau;Uid=pau;Pwd=campa123;";

        public List<Usuari> Usuaris { get; set; }

        public UserManager()
        {
            InitializeComponent();
            CarregarUsuaris();
        }

        public static List<Usuari> GetAllUsers()
        {
            List<Usuari> users = new List<Usuari>();

            MySqlConnection connexio = new MySqlConnection(connectionString);
            connexio.Open();

            string query = "SELECT * FROM Usuari";
            MySqlCommand comanda = new MySqlCommand(query, connexio);

            MySqlDataReader reader = comanda.ExecuteReader();

            while (reader.Read())
            {
                Usuari user = new Usuari(
                    reader.GetString("nom"),
                    reader.GetString("contrasenya"),
                    reader.GetBoolean("responsable")
                );

                user.SetId(reader.GetInt32("idusuari"));

                users.Add(user);
            }

            connexio.Close();
            return users;
        }

        private void CarregarUsuaris() 
        { 
            lbUsers.DisplayMemberPath = "Nom";
            lbUsers.ItemsSource = GetAllUsers(); 
        }

        private void EditarUser_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EliminarUser_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AfegirUser_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditWindow(object sender, RoutedEventArgs e)
        {
            Usuari seleccionat = (Usuari)lbUsers.SelectedItem;

            if (seleccionat != null)
            {
                UserManagerUpdateWindow window = new UserManagerUpdateWindow(seleccionat);
                window.ShowDialog(); // mejor ShowDialog para que sea modal
            }
            else
            {
                MessageBox.Show("Selecciona un usuario primero.");
            }
        }

    }
}
