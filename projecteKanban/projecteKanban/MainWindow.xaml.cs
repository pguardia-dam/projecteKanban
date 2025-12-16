using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace projecteKanban
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static string connectionString = "Server=ellaboratori.cat;Database=pau;Uid=pau;Pwd=campa123;";

        public MainWindow()
        {
            InitializeComponent();
            RefrescarKanban(); // refresca al abrir la ventana
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window window = new login();
            window.Show();
            this.Close();
        }

        private void btnAfegir_Click(object sender, RoutedEventArgs e)
        {
            Window window = new NewTasca();
            window.Show();
            // cuando cierres la ventana de nueva tasca, puedes volver a llamar a RefrescarKanban()
        }

        private void btnUsuari_Click(object sender, RoutedEventArgs e)
        {
            Window window = new UserManager();
            window.Show();
        }

        public static void RefrescarKanban()
        {
            var mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault(); 
            if (mainWindow == null) 
                return;
            mainWindow.col1.Children.Clear();
            mainWindow.col2.Children.Clear(); 
            mainWindow.col3.Children.Clear();

            List<Tasca> tasques = new List<Tasca>();
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT coditasca, nom, descripcio, idUsuari, datacreacio, datafin, idPrioritat, idEstat  FROM Tasca";
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

                if (t.Prioritat == 4)
                {
                    Tasca.ContadorUrgents++;
                    tascaControl.Background = Brushes.Red;
                    t.CodiTasca = "U" + Tasca.ContadorUrgents.ToString();
                }
                else if (t.Prioritat == 3)
                {
                    Tasca.ContadorAlts++;
                    tascaControl.Background = Brushes.Orange;
                    t.CodiTasca = "A" + Tasca.ContadorAlts.ToString();
                }
                else if (t.Prioritat == 2)
                {
                    Tasca.ContadorMig++;
                    tascaControl.Background = Brushes.Yellow;
                    t.CodiTasca = "M" + Tasca.ContadorMig.ToString();
                }
                else if (t.Prioritat == 1)
                {
                    Tasca.ContadorBaix++;
                    tascaControl.Background = Brushes.Green;
                    t.CodiTasca = "B" + Tasca.ContadorBaix.ToString();
                }
                else if (t.Prioritat == 0)
                {
                    Tasca.ContadorOpcional++;
                    tascaControl.Background = Brushes.Gray;
                    t.CodiTasca = "O" + Tasca.ContadorOpcional.ToString();
                }

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
