using MySql.Data.MySqlClient;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace projecteKanban
{
    public partial class TascaControl : UserControl
    {
        private static string connectionString = "Server=ellaboratori.cat;Database=pau;Uid=pau;Pwd=campa123;";

        public TascaControl()
        {
            InitializeComponent();
        }

        private void btnLeft(object sender, RoutedEventArgs e)
        {
            var tasca = DataContext as Tasca;
            var mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            if (mainWindow == null || tasca == null) return;

            var control = this;
            (control.Parent as Panel)?.Children.Remove(control);

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                if (tasca.Estat == 2)
                {
                    tasca.Estat = 1;
                    mainWindow.col2.Children.Add(control);
                }
                else if (tasca.Estat == 1)
                {
                    tasca.Estat = 0;
                    mainWindow.col1.Children.Add(control);
                }

                string query = "UPDATE Tasca SET idEstat = @estat WHERE coditasca = @codi";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@estat", tasca.Estat);
                    cmd.Parameters.AddWithValue("@codi", tasca.CodiTasca);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void btnRight(object sender, RoutedEventArgs e)
        {
            var tasca = DataContext as Tasca;
            var mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            if (mainWindow == null || tasca == null) return;

            var control = this;
            (control.Parent as Panel)?.Children.Remove(control);

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                if (tasca.Estat == 0)
                {
                    tasca.Estat = 1;
                    mainWindow.col2.Children.Add(control);
                }
                else if (tasca.Estat == 1)
                {
                    tasca.Estat = 2;
                    mainWindow.col3.Children.Add(control);
                }

                string query = "UPDATE Tasca SET idEstat = @estat WHERE coditasca = @codi";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@estat", tasca.Estat);
                    cmd.Parameters.AddWithValue("@codi", tasca.CodiTasca);
                    cmd.ExecuteNonQuery();
                }
            }
        }

       private void btnEditarTasca_Click(object sender, RoutedEventArgs e)
{
    var tasca = DataContext as Tasca;
    if (tasca == null) return;

    var window = new NewTasca(tasca);
    window.ShowDialog();
}


        private void btnEliminarTasca_Click(object sender, RoutedEventArgs e)
        {
            var tasca = DataContext as Tasca;
            if (tasca == null) return;

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM Tasca WHERE coditasca = @codi";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@codi", tasca.CodiTasca);
                    cmd.ExecuteNonQuery();
                }
            }

            var mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault(); 
            mainWindow?.RefrescarKanban();
        }
    }
}
