using MySql.Data.MySqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace projecteKanban
{
    /// <summary>
    /// Lógica de interacción para Tasca.xaml
    /// </summary>
    public partial class TascaControl : UserControl
    {
        private static string connectionString = "Server=ellaboratori.cat;Database=pau;Uid=pau;Pwd=campa123;";

        public TascaControl()
        {
            InitializeComponent();
        }
        // Moure tasca a l'esquerra
        private void btnLeft(object sender, RoutedEventArgs e)
        {
            var tasca = DataContext as Tasca;
            var mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            if (mainWindow == null || tasca == null) return;

            var tascaControl = this;

            (tascaControl.Parent as Panel)?.Children.Remove(tascaControl);

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                if (tasca.Estat == 2)
                {
                    tasca.Estat = 1;
                    mainWindow.col2.Children.Add(tascaControl);

                    string query = "UPDATE Tasca SET idEstat = @estat WHERE codiTasca = @codi";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@estat", tasca.Estat);
                        cmd.Parameters.AddWithValue("@codi", tasca.CodiTasca);
                        cmd.ExecuteNonQuery();
                    }
                }
                else if (tasca.Estat == 1)
                {
                    tasca.Estat = 0;
                    mainWindow.col1.Children.Add(tascaControl);

                    string query = "UPDATE Tasca SET idEstat = @estat WHERE codiTasca = @codi";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@estat", tasca.Estat);
                        cmd.Parameters.AddWithValue("@codi", tasca.CodiTasca);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        // Moure tasca a la dreta
        private void btnRight(object sender, RoutedEventArgs e)
        {
            var tasca = DataContext as Tasca;
            var mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            if (mainWindow == null || tasca == null) return;

            var tascaControl = this;

            (tascaControl.Parent as Panel)?.Children.Remove(tascaControl);

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                if (tasca.Estat == 0)
                {
                    tasca.Estat = 1;
                    mainWindow.col2.Children.Add(tascaControl);

                    string query = "UPDATE Tasca SET idEstat = @estat WHERE codiTasca = @codi";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@estat", tasca.Estat);
                        cmd.Parameters.AddWithValue("@codi", tasca.CodiTasca);
                        cmd.ExecuteNonQuery();
                    }
                }
                else if (tasca.Estat == 1)
                {
                    tasca.Estat = 2;
                    mainWindow.col3.Children.Add(tascaControl);

                    string query = "UPDATE Tasca SET idEstat = @estat WHERE codiTasca = @codi";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@estat", tasca.Estat);
                        cmd.Parameters.AddWithValue("@codi", tasca.CodiTasca);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }


        private void btnEditarTasca_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEliminarTasca_Click(object sender, RoutedEventArgs e)
        {
            var tasca = DataContext as Tasca;

            MySqlConnection conn = new MySqlConnection(connectionString);

            conn.Open();
            string query = "DELETE FROM `Tasca` WHERE coditasca = @codiTasca";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@codiTasca",tasca.CodiTasca);
            cmd.ExecuteNonQuery();
            conn.Close();
            MainWindow.RefrescarKanban();
        }
    }
}
