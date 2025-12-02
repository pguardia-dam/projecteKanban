using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projecteKanban
{
    public class Tasca //model de la tasca
    {
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
    }
}
