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
using System.Windows.Shapes;

namespace projecteKanban
{
    /// <summary>
    /// Lógica de interacción para UserManager.xaml
    /// </summary>
    public partial class UserManager : Window
    {
        public class Usuario
        {
            public string Nombre { get; set; }
        }

        public List<Usuario> Usuarios { get; set; }

        public UserManager()
        {
            InitializeComponent();

      
        }

        private void EditarUser_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EliminarUser_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AfegirUser_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
