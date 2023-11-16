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
            Loaded += Listar_Load;
        }

        // llamo al metodo que esta en daoLibro para poder listar la tabla de la base de datos con sus campos
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

        // vinculo los text box con los campos de el grid
        private void dgvLibros_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (dgvLibros.SelectedItem != null)
                {
                    //obtengo la fila seleccionada del DataGrid
                    DataRowView row = (DataRowView)dgvLibros.SelectedItem;

                    //vinculo los textBox del formulario con los apartados de la base de datos
                    txtId.Text = row["id"].ToString();
                    txtTitulo.Text = row["titulo"].ToString();
                    txtAutor.Text = row["autor"].ToString() ;
                    txtEditorial.Text = row["editorial"].ToString();
                    txtFechaPublicacion.Text = row["fecha_publicacion"].ToString();
                    txtImagen.Text = row["imagen"].ToString();
                    txtDescripcion.Text = row["descripcion"].ToString();
                    txtPrecio.Text = row["precio"].ToString();
                    txtUnidadesAlma.Text = row["unidades"].ToString();

                    // Para columnas booleanas, como "enventa"
                    bool enVenta = (bool)row["enventa"];
                    chkVenta.IsChecked = enVenta;
                    chkVenta.IsEnabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message);
            }
        }
    }
}
