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
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window window = new login();
            window.Show();
            this.Close();
        }

        private void btnAfegir_Click(object sender, RoutedEventArgs e)
        {
            Window window = new NewTasca();
            window.Show();
        }

        private void btnUsuari_Click(object sender, RoutedEventArgs e)
        {
            Window window = new UserManager();
            window.Show();
        }
    }
}
