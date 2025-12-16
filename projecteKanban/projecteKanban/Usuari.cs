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
        int id;
        public string Nom;
        public string Contrasenya;
        public bool Responsable;

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


        public static Usuari Autenticar(string nom, string contrasenya)
        {
            Usuari user = new Usuari("admin", "admin", true); //per evitar errors en compilar abans de tenir la base de dades
            return user;
            //foreach (Usuari u in UsuariList)
            //{
            //    if (u.Nom == nom && u.Contrasenya == contrasenya)
            //    {
            //        return u;
            //    }
            //}
            //return null;
        }

    }
}
