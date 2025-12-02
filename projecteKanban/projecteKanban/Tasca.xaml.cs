using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace projecteKanban
{
    /// <summary>
    /// Lógica de interacción para Tasca.xaml
    /// </summary>
    public partial class Tasca : UserControl
    {
        public string CodiTasca { get; set; }
        public string Descripcio { get; set; }
        public string Responsable { get; set; }
        public DateTime DataInici { get; set; }
        public DateTime DataFinal { get; set; }
        public string Prioritat { get; set; }


        public Tasca()
        {
            InitializeComponent();
        }
    }
}
