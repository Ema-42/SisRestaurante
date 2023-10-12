using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NCategoria
    {
        //Metodo que llama al metodo insertar de la clase dCategroia
        //de la CapaDatos

        public static string Insertar(string nombre, string descripcion)
        {
            //instanciamos
            DCategoria Obj = new DCategoria();
            //le enviamos nuestros paramaetros
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;

            return Obj.Insertar(Obj);
        }
        //Metodo Edistar que llama al metodo editar de la clase DCategoria
        //de la CapaDatos
        public static string Editar(int idcategoria, string nombre, string descripcion)
        {
            DCategoria Obj = new DCategoria();
            // es el set de DCategoria
            Obj.Idcategoria = idcategoria;
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            //le envio el objeto con todos los atributos
            return Obj.Editar(Obj);
        }
        //Metodo Eliminar que llama al metod eliminar de la clase DCategoria
        //de la CapaDatos
        public static string Eliminar(int idcategoria)
        {
            DCategoria Obj = new DCategoria();
            Obj.Idcategoria = idcategoria;
            return Obj.Eliminar(Obj);
        }
        //Metodo mostrar que llama al metodo mostrar de la clase DCategoria
        //de la CapaDatos
        public static DataTable Mostrar()
        {
            //instancio Dcategoria y llamo a mi meotodo mostrar
            return new DCategoria().Mostrar();
        }
        //Metodo buscar nombre   que llama al metodo buscar nombre
        //de la clase DCategoria de la CapaDatos

        public static DataTable BuscarNombre(string textobuscar)
        {
            DCategoria Obj = new DCategoria();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }
    }
}
