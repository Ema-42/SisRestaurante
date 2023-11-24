using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NProductos
    {
        //Metodo que llama al metodo insertar de la clase dCategroia
        //de la CapaDatos

        public static string Insertar(string nombre, string descripcion, decimal precio, int idcategoria)
        {
            //instanciamos , le enviamos nuestros paramaetros
            DProductos Obj = new DProductos();
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            Obj.Precio = precio;
            Obj.Idcategoria = idcategoria;
            return Obj.Insertar(Obj);
        }
        //Metodo Edistar que llama al metodo editar de la clase DCategoria de la CapaDatos
        public static string Editar(int idproducto, string nombre, string descripcion, decimal precio, int idcategoria)
        {
            DProductos Obj = new DProductos();
            // es el set de DPLATOS
            Obj.Idproducto = idproducto;
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            Obj.Precio = precio;
            Obj.Idcategoria = idcategoria;
            //le envio el objeto con todos los atributos
            return Obj.Editar(Obj);
        }
        //Metodo Eliminar que llama al metod eliminar de la clase Dplatos
        //de la CapaDatos
        public static string Eliminar(int idproducto)
        {
            DProductos Obj = new DProductos();
            Obj.Idproducto = idproducto;
            return Obj.Eliminar(Obj);
        }
        //Metodo mostrar que llama al metodo mostrar de la clase DCategoria
        //de la CapaDatos
        public static DataTable Mostrar()
        {
            //instancio Dcategoria y llamo a mi meotodo mostrar
            return new DProductos().Mostrar();
        }
        //Metodo buscar nombre   que llama al metodo buscar nombre
        //de la clase DCategoria de la CapaDatos

        public static DataTable BuscarNombre(string textobuscar)
        {
            DProductos Obj = new DProductos();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }
    }
}
