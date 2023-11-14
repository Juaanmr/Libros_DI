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
using U1Tarea1_JuanAgustinMuñozRamirez.dto;
using U2_Tarea1___JuanAgustinMuñozRamirez.dao;

namespace U2_Tarea1___JuanAgustinMuñozRamirez
{
    /// <summary>
    /// Lógica de interacción para Añadir.xaml
    /// </summary>
    public partial class Añadir : Page
    {
        public Añadir()
        {
            InitializeComponent();
            dtpFechaPublicacion.SelectedDate = DateTime.Now; // Ajusta el valor de la fecha de publicación
        }

        // Validación del apartado Titulo y Autor con la herramienta ErrorProvider
        
        private void ValidarCampo(TextBox textBox, string mensajeError)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                MessageBox.Show(mensajeError);
                textBox.Focus();
            }
        }

        private void txtTitulo_TextChanged(object sender, TextChangedEventArgs e)
        {
            ValidarCampo(txtTitulo, "Debe introducir un Titulo...");
            
        }

        private void txtAutor_TextChanged(object sender, TextChangedEventArgs e)
        {
            ValidarCampo(txtAutor, "Debe introducir un Autor...");
        }


        // Añadimos al TextBox de Título y Autor que si no ponen nada se ponga en rojo el cuadro de texto
        // y también llamamos a la clase daoLibro y Libro
        private void btnAñadir_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTitulo.Text))
            {
                MessageBox.Show("Debes introducir un Título");
                CambiarEstiloTextBox(txtTitulo, true);
                txtTitulo.Focus();
            }
            else if (string.IsNullOrEmpty(txtAutor.Text))
            {
                MessageBox.Show("Debes introducir un Autor");
                CambiarEstiloTextBox(txtTitulo, false);
                CambiarEstiloTextBox(txtAutor, true);
                txtAutor.Focus();
            }
            else
            {
                Libro libro = new Libro();
                Datos_Libros(libro);

                DaoLibro daoLibro = new DaoLibro();
                daoLibro.InsertarLibro(libro);

                limpiar();
            }
        }

        private void CambiarEstiloTextBox(TextBox textBox, bool resaltar)
        {
            if (resaltar)
            {
                // Cambiar el estilo cuando hay un error (resaltando en rojo)
                textBox.BorderBrush = Brushes.Red;
                textBox.Background = Brushes.LightPink;
            }
            else
            {
                // Restaurar el estilo predeterminado
                textBox.ClearValue(TextBox.BorderBrushProperty);
                textBox.ClearValue(TextBox.BackgroundProperty);
            }
        }

        // Botón limpiar para cuando haya metido un libro se limpie el formulario de añadir
        private void limpiar()
        {
            txtTitulo.Clear();
            txtTitulo.Background = System.Windows.Media.Brushes.WhiteSmoke;
            txtAutor.Clear();
            txtAutor.Background = System.Windows.Media.Brushes.WhiteSmoke;
            txtEditorial.Clear();
            dtpFechaPublicacion.SelectedDate = DateTime.Now;
            txtImagen.Clear();
            txtDescripcion.Clear();
            txtPrecio.Clear();
            txtUnidadesAlma.Clear();
            chkVenta.IsChecked = false;
        }

        private Libro Datos_Libros(Libro libro)
        {
            libro.Titulo = txtTitulo.Text;
            libro.Autor = txtAutor.Text;
            libro.Editorial = txtEditorial.Text;
            libro.FechaPublicacion = dtpFechaPublicacion.SelectedDate ?? DateTime.Now;
            libro.Imagen = txtImagen.Text;
            libro.Descripcion = txtDescripcion.Text;

            // Apartado precio
            if (txtPrecio.Text.Contains("."))
            {
                txtPrecio.Text = txtPrecio.Text.Replace(".", ",");
            }

            if (string.IsNullOrWhiteSpace(txtPrecio.Text))
            {
                txtPrecio.Text = "0";
            }

            float precio = float.Parse(txtPrecio.Text);
            libro.Precio = precio;

            // Apartado unidades
            if (string.IsNullOrWhiteSpace(txtUnidadesAlma.Text))
            {
                txtUnidadesAlma.Text = "0";
            }

            int unidades = int.Parse(txtUnidadesAlma.Text);
            libro.Unidades = unidades;

            // Apartado en venta
            libro.EnVenta = chkVenta.IsChecked ?? false ? (byte)1 : (byte)0;

            return libro;
        }

        
    }
}

