using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projecteKanban
{
    public class Usuari
    {
        public string Nom;
        public string Contrasenya;

        public static List<Usuari> UsuariList = new List<Usuari>();

        public Usuari(string nom, string contrasenya)
        {
            Nom = nom;
            Contrasenya = contrasenya;
        }

        public static void AfegirUsuari(Usuari usuari)
        {
            UsuariList.Add(usuari);
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

        public static bool ComprovarDuplicats(string nom)
        {
            foreach (Usuari u in UsuariList)
            {
                if (u.Nom == nom)
                {
                    return true;
                }
            }
            return false;
        }

        public static Usuari Autenticar(string nom, string contrasenya)
        {
            foreach (Usuari u in UsuariList)
            {
                if (u.Nom == nom && u.Contrasenya == contrasenya)
                {
                    return u;
                }
            }
            return null;
        }

    }
}
