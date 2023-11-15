using System;
using System.Collections.Generic;
using System.Data;
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
using U1Tarea1_JuanAgustinMuñozRamirez.dto;
using U2_Tarea1___JuanAgustinMuñozRamirez.dao;

namespace U2_Tarea1___JuanAgustinMuñozRamirez
{
    /// <summary>
    /// Lógica de interacción para Listar.xaml
    /// </summary>
    public partial class Listar : Page
    {
        public Listar()
        {
            InitializeComponent();
            Loaded += Listar_Load; // Suscribir al evento Loaded para cargar los datos al abrir la ventana
        }

        private void Listar_Load(object sender, RoutedEventArgs e)
        {
            try
            {
                DaoLibro daoLibro = new DaoLibro();
                daoLibro.ListarDatos(dgvLibros);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message);
            }
        }

        private void dgvLibros_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (dgvLibros.SelectedItem != null)
                {
                    // Obtener el DataRowView desde el DataGrid
                    DataRowView rowView = (DataRowView)dgvLibros.SelectedItem;

                    // Obtener el objeto Libro desde el DataRowView
                    Libro selectedLibro = rowView.Row.ItemArray[0] as Libro;

                    if (selectedLibro != null)
                    {
                        txtId.Text = selectedLibro.id.ToString();
                        txtTitulo.Text = selectedLibro.Titulo;
                        txtEditorial.Text = selectedLibro.Editorial;
                        txtFechaPublicacion.Text = selectedLibro.FechaPublicacion.ToString();
                        txtImagen.Text = selectedLibro.Imagen;
                        txtDescripcion.Text = selectedLibro.Descripcion;
                        txtPrecio.Text = selectedLibro.Precio.ToString();
                        txtUnidadesAlma.Text = selectedLibro.Unidades.ToString();

                        chkVenta.IsChecked = selectedLibro.EnVenta == 1;
                        chkVenta.IsEnabled = false; // Puedes deshabilitar el CheckBox si es necesario
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message);
            }
        }
    }
}
