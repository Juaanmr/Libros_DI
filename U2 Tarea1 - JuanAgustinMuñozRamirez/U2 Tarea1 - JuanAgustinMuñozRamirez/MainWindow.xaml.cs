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

namespace U2_Tarea1___JuanAgustinMuñozRamirez
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MyFrame.NavigationService.Navigate(new Inicio());
        }

        private void btnPrincipal_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.NavigationService.Navigate(new Inicio());
        }

        private void btnAñadir_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.NavigationService.Navigate(new Añadir());
        }

        private void btnConsultar_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.NavigationService.Navigate(new Consultar());
        }

        private void btnListar_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.NavigationService.Navigate(new Listar());
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Seguro que desea cerrar la aplicacion", "Salir", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }      
    }
}
