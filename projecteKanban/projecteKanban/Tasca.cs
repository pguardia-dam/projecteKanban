using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projecteKanban
{
    public class Tasca
    {
        public string CodiTasca { get; set; }
        public string NomTasca { get; set; }
        public string Descripcio { get; set; }
        public string Responsable { get; set; }
        public DateTime DataInici { get; set; }
        public DateTime DataFinal { get; set; }
        public int Prioritat { get; set; }
        public int Estat { get; set; }
    }
}
