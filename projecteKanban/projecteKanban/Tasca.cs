using MySql.Data.MySqlClient;
using System;

namespace projecteKanban
{
    public class Tasca
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

        public Tasca(string nom, string desc, int idUsuari, DateTime inici, DateTime final, int prioritat, int estat)
        {
            NomTasca = nom;
            Descripcio = desc;
            IdUsuari = idUsuari;
            DataInici = inici;
            DataFinal = final;
            Prioritat = prioritat;
            Estat = estat;
        }

        public Tasca(string nom, string desc, string responsable, DateTime inici, DateTime final, int prioritat, int estat)
        {
            NomTasca = nom;
            Descripcio = desc;
            Responsable = responsable;
            DataInici = inici;
            DataFinal = final;
            Prioritat = prioritat;
            Estat = estat;
        }

        public static void AfegirTasca(Tasca t)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Tasca (nom, descripcio, datacreacio, datafin, idUsuari, idEstat, idPrioritat, coditasca) " +
                               "VALUES (@nom, @desc, @inici, @final, @usuari, @estat, @prioritat, @codi)";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nom", t.NomTasca);
                    cmd.Parameters.AddWithValue("@desc", t.Descripcio);
                    cmd.Parameters.AddWithValue("@inici", t.DataInici);
                    cmd.Parameters.AddWithValue("@final", t.DataFinal);
                    cmd.Parameters.AddWithValue("@usuari", login.UsuariActual.GetId());
                    cmd.Parameters.AddWithValue("@estat", t.Estat);
                    cmd.Parameters.AddWithValue("@prioritat", t.Prioritat);
                    cmd.Parameters.AddWithValue("@codi", t.CodiTasca);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
