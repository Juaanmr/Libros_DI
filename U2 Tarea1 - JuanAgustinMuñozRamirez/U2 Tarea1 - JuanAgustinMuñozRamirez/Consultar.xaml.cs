using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Lógica de interacción para Consultar.xaml
    /// </summary>
    public partial class Consultar : Page
    {

        public Consultar()
        {
            InitializeComponent();
        }

        // boton buscar para cuando le da busque por id y titulo
        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBuscar.Text) && int.TryParse(txtBuscar.Text, out _))
            {
                BuscarPorId();
            }
            else if (!string.IsNullOrEmpty(txtBuscar.Text))
            {
                BuscarPorTitulo();
            }
            else
            {
                MessageBox.Show("Introduce un ID o un TITULO");
            }
        }

        private Libro IngresarLibroTitulo(Libro libro)
        {
            libro.Titulo = txtBuscar.Text;
            txtBuscar.Text.ToString();

            return libro;
        }

        private Libro IngresarLibroId(Libro libro)
        {
            int id = int.Parse(txtBuscar.Text);
            String txt_ID = id.ToString();

            int unidadesBien = int.Parse(txt_ID, System.Globalization.CultureInfo.CurrentCulture);
            libro.id = unidadesBien;

            string titulo = txtBuscar.Text;
            libro.Titulo = txtBuscar.Text;

            return libro;
        }

        // metodo para buscar por titulo 
        private void BuscarPorTitulo()
        {
            Libro libro = new Libro();
            IngresarLibroTitulo(libro);

            try
            {
                string consulta = $"SELECT * FROM appevent_di.catalogo WHERE titulo = '{libro.Titulo}'";

                Conexion conexion = new Conexion();
                MySqlConnection conect = conexion.EstablecerConexion();

                MySqlCommand mySqlCommand = new MySqlCommand(consulta, conect);
                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

                if (mySqlDataReader.Read())
                {
                    MostrarDatos(mySqlDataReader);
                }
                else
                {
                    MessageBox.Show("No se encontraron resultados para el título especificado.");
                }

                mySqlDataReader.Close();
                conexion.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo hacer la conexión: " + ex.ToString());
            }
        }

        // metodo para buscar por id 
        private void BuscarPorId()
        {
            Libro libro = new Libro();
            IngresarLibroId(libro);

            try
            {
                string consulta = $"SELECT * FROM appevent_di.catalogo WHERE id = {libro.id}";

                Conexion conexion = new Conexion();
                MySqlConnection conect = conexion.EstablecerConexion();

                MySqlCommand mySqlCommand = new MySqlCommand(consulta, conect);
                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

                if (mySqlDataReader.Read())
                {
                    MostrarDatos(mySqlDataReader);
                }
                else
                {
                    MessageBox.Show("Algunos resultado no se han encontrado");
                }

                mySqlDataReader.Close();
                conexion.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo hacer la conexión: " + ex.ToString());
            }
        }

        private void MostrarDatos(MySqlDataReader mySqlDataReader)
        {
            txtId.Text = mySqlDataReader["id"].ToString();
            txtTitulo.Text = mySqlDataReader["titulo"].ToString();
            txtAutor.Text = mySqlDataReader["autor"].ToString();
            txtEditorial.Text = mySqlDataReader["editorial"].ToString();

            string fechaPubString = mySqlDataReader["fecha_publicacion"].ToString();
            txtFechaPublicacion.Text = fechaPubString;

            txtImagen.Text = mySqlDataReader["imagen"].ToString();
            txtDescripcion.Text = mySqlDataReader["descripcion"].ToString();
            txtPrecio.Text = mySqlDataReader["precio"].ToString();
            txtUnidadesAlma.Text = mySqlDataReader["unidades"].ToString();

            bool venta = Convert.ToBoolean(mySqlDataReader["enventa"]);
            chkVenta.IsChecked = venta;
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarFormulario();
        }

        // boton para limpiar el formulario de los fatos que tengan los text box
        private void LimpiarFormulario()
        {
            txtBuscar.Clear();
            txtId.Clear();
            txtTitulo.Clear();
            txtAutor.Clear();
            txtEditorial.Clear();
            txtFechaPublicacion.Clear();
            txtDescripcion.Clear();
            txtImagen.Clear();
            txtDescripcion.Clear();
            txtPrecio.Clear();
            txtUnidadesAlma.Clear();
            chkVenta.IsChecked = false;
        }

        // boton eliminar un libro
        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtBuscar.Text, out int id))
            {
                DaoLibro daoLibro = new DaoLibro();
                daoLibro.EliminarPorId(id);
                LimpiarFormulario();
            }
            else
            {
                DaoLibro daoLibro = new DaoLibro();
                daoLibro.EliminarPorTitulo(txtBuscar.Text);
                LimpiarFormulario();
            }
        }

        //boton modificar un libro 
        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            ModificarLibro();
        }

        // metodo para modificar un libro
        public void ModificarLibro()
        {
            Libro libro = new Libro();
            DatosLibros(libro);

            try
            {
                string consulta = "UPDATE catalogo SET titulo = @titulo, autor = @autor, editorial = @editorial, " +
                    "fecha_publicacion = @fecha_publicacion, imagen = @imagen, descripcion = @descripcion, precio = @precio, " +
                    "unidades = @unidades, enventa = @enventa WHERE id = @id";

                Conexion conexion = new Conexion();
                MySqlConnection mySqlConnection = conexion.EstablecerConexion();

                if (mySqlConnection == null)
                {
                    MessageBox.Show("No se ha podido establecer la conexión con la base de datos");
                    return;
                }

                MySqlCommand mySqlCommand = new MySqlCommand(consulta, mySqlConnection);

                // Utilizar parámetros para evitar SQL Injection
                mySqlCommand.Parameters.AddWithValue("@titulo", libro.Titulo);
                mySqlCommand.Parameters.AddWithValue("@autor", libro.Autor);
                mySqlCommand.Parameters.AddWithValue("@editorial", libro.Editorial);
                mySqlCommand.Parameters.AddWithValue("@fecha_publicacion", libro.FechaPublicacion.ToString("yyyy-MM-dd"));
                mySqlCommand.Parameters.AddWithValue("@imagen", libro.Imagen);
                mySqlCommand.Parameters.AddWithValue("@descripcion", libro.Descripcion);
                mySqlCommand.Parameters.AddWithValue("@precio", libro.Precio);
                mySqlCommand.Parameters.AddWithValue("@unidades", libro.Unidades);
                mySqlCommand.Parameters.AddWithValue("@enventa", libro.EnVenta);
                mySqlCommand.Parameters.AddWithValue("@id", libro.id);

                mySqlCommand.ExecuteNonQuery();
                MessageBox.Show("Libro modificado correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar el libro: " + ex.Message);
            }
        }

        private Libro DatosLibros(Libro libro)
        {
            if (int.TryParse(txtId.Text, out int id))
            {
                libro.id = id;
            }

            libro.Titulo = txtTitulo.Text;
            libro.Autor = txtAutor.Text;
            libro.Editorial = txtEditorial.Text;

            /* Apartado fecha
            libro.FechaPublicacion = dtpFechaPublicacion.SelectedDate ?? DateTime.Now;*/

            libro.Imagen = txtImagen.Text;
            libro.Descripcion = txtDescripcion.Text;

            // Apartado precio
            string precioString = txtPrecio.Text.Replace('.', ',');
            if (float.TryParse(precioString, out float precio))
            {
                libro.Precio = precio;
            }
            else
            {
                libro.Precio = 0;
            }

            // Apartado unidades
            if (string.IsNullOrWhiteSpace(txtUnidadesAlma.Text))
            {
                txtUnidadesAlma.Text = "0";
            }
            if (int.TryParse(txtUnidadesAlma.Text, out int unidades))
            {
                libro.Unidades = unidades;
            }
            else
            {
                libro.Unidades = 0;
            }

            // Apartado en venta
            libro.EnVenta = chkVenta.IsChecked ?? false ? (byte)1 : (byte)0;

            return libro;
        }
    }
}

