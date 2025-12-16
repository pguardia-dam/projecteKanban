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

        public int IdUsuari { get; set; }

        public static int ContadorUrgents = 0;
        public static int ContadorAlts = 0;
        public static int ContadorMig = 0;
        public static int ContadorBaix = 0;
        public static int ContadorOpcional = 0;

        public Tasca(string nomTasca, string descripcio, string responsable, DateTime dataInici, DateTime dataFinal, int prioritat, int estat)
        {
            NomTasca = nomTasca;
            Descripcio = descripcio;
            Responsable = responsable;
            DataInici = dataInici;
            DataFinal = dataFinal;
            Prioritat = prioritat;
            Estat = estat;
        }

        public Tasca(string nomTasca, string descripcio, int idUsuari, DateTime dataInici, DateTime dataFinal, int prioritat, int estat)
        {
            NomTasca = nomTasca;
            Descripcio = descripcio;
            IdUsuari = idUsuari;
            DataInici = dataInici;
            DataFinal = dataFinal;
            Prioritat = prioritat;
            Estat = estat;
        }

        public static void AfegirTasca(Tasca tasca)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);

            conn.Open();
            string query = "INSERT INTO Tasca (nom, descripcio, datacreacio, datafin, idUsuari, idEstat, idPrioritat, coditasca ) VALUES (@nom, @descripcio, @dataInici, @dataFi, @user, @estat, @prioritat, @codiTasca)";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@nom", tasca.NomTasca);
            cmd.Parameters.AddWithValue("@descripcio", tasca.Descripcio);
            cmd.Parameters.AddWithValue("@dataInici", tasca.DataInici);
            cmd.Parameters.AddWithValue("@dataFi", tasca.DataFinal);
            cmd.Parameters.AddWithValue("@user", login.UsuariActual.GetId());
            cmd.Parameters.AddWithValue("@estat", NewTasca.estatSeleccionat);
            cmd.Parameters.AddWithValue("@prioritat", NewTasca.prioritatSeleccionada);
            cmd.Parameters.AddWithValue("@codiTasca", NewTasca.codiTascaGenerat);





            cmd.ExecuteNonQuery();
            conn.Close();

        }


        
    }

}
        
