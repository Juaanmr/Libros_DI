using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U1Tarea1_JuanAgustinMuñozRamirez.dto
{
    internal class Libro
    {
        // Implementamos propiedades con notificación de cambios para ser usadas en WPF
        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _titulo;
        public string Titulo
        {
            get { return _titulo; }
            set { _titulo = value; }
        }

        private string _autor;
        public string Autor
        {
            get { return _autor; }
            set { _autor = value; }
        }

        private string _editorial;
        public string Editorial
        {
            get { return _editorial; }
            set { _editorial = value; }
        }

        private DateTime _fechaPublicacion;
        public DateTime FechaPublicacion
        {
            get { return _fechaPublicacion; }
            set { _fechaPublicacion = value; }
        }

        private string _imagen;
        public string Imagen
        {
            get { return _imagen; }
            set { _imagen = value; }
        }

        private string _descripcion;
        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        private float _precio;
        public float Precio
        {
            get { return _precio; }
            set { _precio = value; }
        }

        private int _unidades;
        public int Unidades
        {
            get { return _unidades; }
            set { _unidades = value; }
        }

        private byte _enVenta;
        public byte EnVenta
        {
            get { return _enVenta; }
            set { _enVenta = value; }
        }


        //Constructor
        public Libro()
        {
            this.id = id;
            this.Titulo = Titulo;
            this.Autor = Autor;
            this.Editorial = Editorial;
            this.FechaPublicacion = FechaPublicacion;
            this.Imagen = Imagen;
            this.Descripcion = Descripcion;
            this.Precio = Precio;
            this.Unidades = Unidades;
            this.EnVenta = EnVenta;
        }

    }
}