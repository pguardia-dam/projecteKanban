using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace projecteKanban
{
    public partial class MainWindow : Window
    {
        private static string connectionString = "Server=ellaboratori.cat;Database=pau;Uid=pau;Pwd=campa123;";

        public MainWindow()
        {
            InitializeComponent();
            RefrescarKanban();
        }

        private void btnUsuari_Click(object sender, RoutedEventArgs e)
        {
            new UserManager().Show();
        }

        private void btnAfegir_Click(object sender, RoutedEventArgs e)
        {
            new NewTasca().Show();
        }

        public void RefrescarKanban()
        {
            var mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            if (mainWindow == null) return;

            mainWindow.col1.Children.Clear();
            mainWindow.col2.Children.Clear();
            mainWindow.col3.Children.Clear();



            List<Tasca> tasques = new List<Tasca>();

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT coditasca, nom, descripcio, idUsuari, datacreacio, datafin, idPrioritat, idEstat FROM Tasca";

                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var t = new Tasca(
                            reader.GetString("nom"),
                            reader.GetString("descripcio"),
                            reader.GetInt32("idUsuari"),
                            reader.GetDateTime("datacreacio"),
                            reader.GetDateTime("datafin"),
                            reader.GetInt32("idPrioritat"),
                            reader.GetInt32("idEstat")
                        );

                        t.CodiTasca = reader.GetString("coditasca");
                        tasques.Add(t);
                    }
                }
            }

            foreach (var t in tasques)
            {
                var tascaControl = new TascaControl();
                tascaControl.DataContext = t;

                // Colors segons prioritat
                switch (t.Prioritat)
                {
                    case 4: tascaControl.Background = Brushes.Red; break;
                    case 3: tascaControl.Background = Brushes.Orange; break;
                    case 2: tascaControl.Background = Brushes.Yellow; break;
                    case 1: tascaControl.Background = Brushes.Green; break;
                    default: tascaControl.Background = Brushes.Gray; break;
                }

                // Afegir a la columna correcta
                switch (t.Estat)
                {
                    case 0: mainWindow.col1.Children.Add(tascaControl); break;
                    case 1: mainWindow.col2.Children.Add(tascaControl); break;
                    case 2: mainWindow.col3.Children.Add(tascaControl); break;
                }
            }
        }
    }
}
