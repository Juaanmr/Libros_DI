using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace U2_Tarea1___JuanAgustinMuñozRamirez.dao
{
    internal class Conexion
    {
        MySqlConnection conexion = new MySqlConnection();

        static string servidor = "188.164.193.188";
        static string db = "appevent_di";
        static string usuario = "profedi";
        static string password = "Fw?179p6n";
        static string puerto = "3306";

        string cadenaConexion = $"server={servidor}; port={puerto}; user id={usuario}; password={password}; database={db};";

        public MySqlConnection EstablecerConexion()
        {
            try
            {
                conexion.ConnectionString = cadenaConexion;
                conexion.Open();
                // MessageBox.Show("Se conectó a la base de datos");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo conectar a la base de datos, error: " + ex.ToString());
            }
            return conexion;
        }

        public void CerrarConexion()
        {
            conexion.Close();
        }
    }
}