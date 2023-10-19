using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NPlatos
    {
        //Metodo que llama al metodo insertar de la clase dCategroia
        //de la CapaDatos

        public static string Insertar(string nombre, string descripcion, float precio, int tiempo)
        {
            //instanciamos , le enviamos nuestros paramaetros
            DPlatos Obj = new DPlatos();
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            Obj.Precio = precio;
            Obj.Tiempo = tiempo;
            return Obj.Insertar(Obj);
        }
        //Metodo Edistar que llama al metodo editar de la clase DCategoria de la CapaDatos
        public static string Editar(int idplato, string nombre, string descripcion, float precio, int tiempo)
        {
            DPlatos Obj = new DPlatos();
            // es el set de DPLATOS
            Obj.Idplato = idplato;
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            Obj.Precio = precio;
            Obj.Tiempo = tiempo;
            //le envio el objeto con todos los atributos
            return Obj.Editar(Obj);
        }
        //Metodo Eliminar que llama al metod eliminar de la clase Dplatos
        //de la CapaDatos
        public static string Eliminar(int idplato)
        {
            DPlatos Obj = new DPlatos();
            Obj.Idplato = idplato;
            return Obj.Eliminar(Obj);
        }
        //Metodo mostrar que llama al metodo mostrar de la clase DCategoria
        //de la CapaDatos
        public static DataTable Mostrar()
        {
            //instancio Dcategoria y llamo a mi meotodo mostrar
            return new DPlatos().Mostrar();
        }
        //Metodo buscar nombre   que llama al metodo buscar nombre
        //de la clase DCategoria de la CapaDatos

        public static DataTable BuscarNombre(string textobuscar)
        {
            DPlatos Obj = new DPlatos();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }
    }
}
