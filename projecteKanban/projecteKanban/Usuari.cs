using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projecteKanban
{
    public class Usuari 
    {
        int id { get; set; }
        public string Nom { get; set; }
        public string Contrasenya { get; set; }
        public bool Responsable { get; set; }

        private static string connectionString = "Server=ellaboratori.cat;Database=pau;Uid=pau;Pwd=campa123;";
        public Usuari(string nom, string contrasenya, bool responsable)
        {
            Nom = nom;
            Contrasenya = contrasenya;
            Responsable = responsable;
        }

        public static void AfegirUsuari(Usuari usuari)
        {
            MySqlConnection conn = new MySqlConnection(connectionString); 
            
            conn.Open(); 
            string query = "INSERT INTO Usuari (nom, contrasenya, responsable) VALUES (@nom, @contra, @resp)"; 
            MySqlCommand cmd = new MySqlCommand(query, conn); 
            cmd.Parameters.AddWithValue("@nom", usuari.Nom); 
            cmd.Parameters.AddWithValue("@contra", usuari.Contrasenya);
            cmd.Parameters.AddWithValue("@resp", usuari.Responsable);
            cmd.ExecuteNonQuery(); 
            conn.Close();

        }

        public static Usuari GetUsuari(string nom, string contrasenya)
        {
            MySqlConnection conexio = new MySqlConnection(connectionString);
            conexio.Open();

            string query = "SELECT * FROM Usuari WHERE nom = @nom AND contrasenya = @contra";
            MySqlCommand cmd = new MySqlCommand(query, conexio);

            cmd.Parameters.AddWithValue("@nom", nom);
            cmd.Parameters.AddWithValue("@contra", contrasenya);

            MySqlDataReader reader = cmd.ExecuteReader();

            Usuari usuari = null;

            if (reader.Read())
            {
                usuari = new Usuari(
                    reader.GetString("nom"),
                    reader.GetString("contrasenya"),
                    reader.GetBoolean("responsable")
                );

                // Si quieres guardar el id también:
                usuari.id = reader.GetInt32("idusuari");
            }

            conexio.Close();
            return usuari;
        }


        public string GetNom()
        {
            return Nom;
        }
        public string GetContrasenya()
        {
            return Contrasenya;
        }
        public void SetNom(string nom)
        {
            Nom = nom;
        }
        public void SetContrasenya(string contrasenya)
        {
            Contrasenya = contrasenya;
        }

        public int GetId()
        {
            return id;
        }   
        public void SetId(int ID)
        {
             id = ID;
        }   

        public static bool ComprovarDuplicats(string nom)
        {
            MySqlConnection conexio = new MySqlConnection(connectionString);
            conexio.Open();

            string query = "SELECT COUNT(*) FROM Usuari WHERE nom = @nom";
            MySqlCommand comanda = new MySqlCommand(query, conexio);
            comanda.Parameters.AddWithValue("@nom", nom);

            int count = Convert.ToInt32(comanda.ExecuteScalar());

            conexio.Close();

            return count > 0;
        }


        public static bool Autenticar(string nom, string contrasenya)
        {
            MySqlConnection conexio = new MySqlConnection(connectionString);
            conexio.Open();

            string query = "SELECT COUNT(*) FROM Usuari WHERE nom = @nom";
            MySqlCommand comanda = new MySqlCommand(query, conexio);
            comanda.Parameters.AddWithValue("@nom", nom);

            int count = Convert.ToInt32(comanda.ExecuteScalar());

            conexio.Close();

            return count > 0;
        }

    }
}
