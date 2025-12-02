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
    public partial class TascaControl : UserControl
    {
        public TascaControl()
        {
            InitializeComponent();
        }
        // Moure tasca a l'esquerra
        private void btnLeft(object sender, RoutedEventArgs e)
        {
            var tasca = DataContext as Tasca;
            var mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            if (mainWindow == null || tasca == null) return;

            var tascaControl = this;

            (tascaControl.Parent as Panel).Children.Remove(tascaControl);

            if (tasca.Estat == 2)
            {
                tasca.Estat = 1;
                mainWindow.col2.Children.Add(tascaControl);
            }
            else if (tasca.Estat == 1)
            {
                tasca.Estat = 0;
                mainWindow.col1.Children.Add(tascaControl);
            }
        }
        // Moure tasca a la dreta
        private void btnRight(object sender, RoutedEventArgs e)
        {
            var tasca = DataContext as Tasca;
            var mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            if (mainWindow == null) return;

            var tascaControl = this;

            (tascaControl.Parent as Panel).Children.Remove(tascaControl);

            if (tasca.Estat == 0 && tascaControl != null)
            {
                tasca.Estat = 1;
                mainWindow.col2.Children.Add(tascaControl);
            }
            else if (tasca.Estat == 1 && tascaControl != null)
            {
                tasca.Estat = 2;
                mainWindow.col3.Children.Add(tascaControl);
            }
        }
    }
}
