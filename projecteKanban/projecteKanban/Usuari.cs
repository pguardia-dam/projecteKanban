using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projecteKanban
{
    public class Usuari
    {
        public string Nom { get; set; }
        public string Contrasenya { get; set; }
        public Usuari(string nom, string contrasenya)
        {
            Nom = nom;
            Contrasenya = contrasenya;
        }
    }
}
