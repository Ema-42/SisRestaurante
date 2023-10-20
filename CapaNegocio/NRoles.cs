using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NRoles
    {
        public static string Insertar(string nombre, string descripcion)
        {
            //instanciamos
            DRoles Obj = new DRoles();
            //le enviamos nuestros paramaetros
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            return Obj.Insertar(Obj);
        }
        //Metodo Edistar que llama al metodo editar de la clase DCategoria
        //de la CapaDatos
        public static string Editar(int idrol, string nombre, string descripcion)
        {
            DRoles Obj = new DRoles();
            // es el set de DCategoria
            Obj.Idrol = idrol;
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            //le envio el objeto con todos los atributos
            return Obj.Editar(Obj);
        }
        //Metodo Eliminar que llama al metod eliminar de la clase DCategoria
        //de la CapaDatos
        public static string Eliminar(int idrol)
        {
            DRoles Obj = new DRoles();
            Obj.Idrol = idrol;
            return Obj.Eliminar(Obj);
        }
        //Metodo mostrar que llama al metodo mostrar de la clase DCategoria
        //de la CapaDatos
        public static DataTable Mostrar()
        {
            //instancio Dcategoria y llamo a mi meotodo mostrar
            return new DRoles().Mostrar();
        }
        //Metodo buscar nombre   que llama al metodo buscar nombre
        //de la clase DCategoria de la CapaDatos

        public static DataTable BuscarNombre(string textobuscar)
        {
            DRoles Obj = new DRoles();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }
    }
}
