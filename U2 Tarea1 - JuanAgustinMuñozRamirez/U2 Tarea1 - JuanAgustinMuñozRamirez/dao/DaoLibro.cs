using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using U1Tarea1_JuanAgustinMuñozRamirez.dto;

namespace U2_Tarea1___JuanAgustinMuñozRamirez.dao
{
    internal class DaoLibro
    {
        public void InsertarLibro(Libro libro)
        {
            try
            {
                string query = "INSERT INTO catalogo (titulo, autor, editorial, fecha_publicacion, imagen, descripcion, precio, unidades, enventa) " +
                               "VALUES (@titulo, @autor, @editorial, @fecha_publicacion, @imagen, @descripcion, @precio, @unidades, @enventa)";

                Conexion objetoConexion = new Conexion();
                MySqlConnection conexion = objetoConexion.EstablecerConexion();
                MySqlCommand myCommand = new MySqlCommand(query, conexion);

                myCommand.Parameters.AddWithValue("@titulo", libro.Titulo);
                myCommand.Parameters.AddWithValue("@autor", libro.Autor);
                myCommand.Parameters.AddWithValue("@editorial", libro.Editorial);
                myCommand.Parameters.AddWithValue("@fecha_publicacion", libro.FechaPublicacion);
                myCommand.Parameters.AddWithValue("@imagen", libro.Imagen);
                myCommand.Parameters.AddWithValue("@descripcion", libro.Descripcion);
                myCommand.Parameters.AddWithValue("@precio", libro.Precio);
                myCommand.Parameters.AddWithValue("@unidades", libro.Unidades);
                myCommand.Parameters.AddWithValue("@enventa", libro.EnVenta);

                myCommand.ExecuteNonQuery();

                MessageBox.Show("¡Libro se ha registrado exitosamente!");
                // Limpiar_Form();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar el Libro. Error: " + ex.ToString());
            }
        }

        public void EliminarPorId(int id)
        {
            try
            {
                string consulta = "DELETE FROM catalogo WHERE id = @id";

                Conexion objetoConexion = new Conexion();
                MySqlConnection conexion = objetoConexion.EstablecerConexion();

                MySqlCommand myCommand = new MySqlCommand(consulta, conexion);
                myCommand.Parameters.AddWithValue("@id", id);

                if (conexion.State == ConnectionState.Open)
                {
                    myCommand.ExecuteNonQuery();
                    MessageBox.Show("¡Libro eliminado exitosamente!", "ÉXITO");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error de MySQL: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        public void ListarDatos(DataGrid dataGrid)
        {
            string consulta = "SELECT * FROM appevent_di.catalogo;";
            try
            {
                Conexion conexion = new Conexion();
                MySqlConnection mySqlConnection = conexion.EstablecerConexion();

                MySqlCommand mySqlCommand = new MySqlCommand(consulta, mySqlConnection);
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = mySqlCommand;
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGrid.ItemsSource = dataTable.DefaultView;

                dataGrid.IsReadOnly = true;
                dataGrid.CanUserAddRows = false;
                dataGrid.CanUserDeleteRows = false;

                conexion.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo hacer la conexión: " + ex.ToString());
            }
        }
    }
}
