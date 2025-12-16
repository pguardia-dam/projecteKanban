using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static projecteKanban.UserManager;

namespace projecteKanban
{
    public class Tasca //model de la tasca lol
    {
        private static string connectionString = "Server=ellaboratori.cat;Database=pau;Uid=pau;Pwd=campa123;";

        public string CodiTasca { get; set; }
        public string NomTasca { get; set; }
        public string Descripcio { get; set; }
        public string Responsable { get; set; }
        public DateTime DataInici { get; set; }
        public DateTime DataFinal { get; set; }
        public int Prioritat { get; set; }
        public int Estat { get; set; }

        public static int ContadorUrgents = 0;
        public static int ContadorAlts = 0;
        public static int ContadorMig = 0;
        public static int ContadorBaix = 0;
        public static int ContadorOpcional = 0;

        public Tasca( string nomTasca, string descripcio, string responsable, DateTime dataInici, DateTime dataFinal, int prioritat, int estat)
        {
            nomTasca = NomTasca;
            descripcio = Descripcio;
            responsable = Responsable;
            dataInici = DataInici;
            dataFinal = DataFinal;
            prioritat = Prioritat;
            estat = Estat;
        }
        public static void AfegirTasca(Tasca tasca)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);

            conn.Open();
            string query = "INSERT INTO Tasca (nom, descripcio, datacreacio, datafin, ) VALUES (@nom, @contra, @resp)";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@usr", login.UsuariActual.GetId());

            cmd.ExecuteNonQuery();
            conn.Close();

        }
    }

}
        
