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
        //pongo como pantalla principal la ventana de inicio 
        public MainWindow()
        {
            InitializeComponent();
            MyFrame.NavigationService.Navigate(new Inicio());
        }

        //vinculo la ventana de inicio con el boton principal 
        private void btnPrincipal_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.NavigationService.Navigate(new Inicio());
        }

        //vinculo la ventana de añadir con el boton añadir 
        private void btnAñadir_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.NavigationService.Navigate(new Añadir());
        }

        //vinculo la ventana de consultar con el boton consultar 
        private void btnConsultar_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.NavigationService.Navigate(new Consultar());
        }

        //vinculo la ventana de listar con el boton listar 
        private void btnListar_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.NavigationService.Navigate(new Listar());
        }

        //vinculo en el boton salir cerrar la apalicacion con un menssaje de aviso
        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Seguro que desea cerrar la aplicacion", "Salir", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }      
    }
}
