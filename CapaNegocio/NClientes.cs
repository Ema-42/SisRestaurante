using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;
using System.Xml.Linq;

namespace CapaNegocio
{
    public class NClientes
    {
        //Metodo que llama al metodo insertar de la clase dCategroia
        //de la CapaDatos

        public static string Insertar( string nombres, string apellidos, string celular, string direccion, string documento)
        {
            //instanciamos , le enviamos nuestros paramaetros
            DClientes Obj = new DClientes();
            Obj.Nombres = nombres;
            Obj.Apellidos =apellidos;
            Obj.Celular = celular;
            Obj.Direccion = direccion;
            Obj.Documento = documento;
            return Obj.Insertar(Obj);
        }
        //Metodo Edistar que llama al metodo editar de la clase DCategoria de la CapaDatos
        public static string Editar(int idcliente, string nombres, string apellidos, string celular, string direccion, string documento)
        {
            DClientes Obj = new DClientes();
            // es el set de DClientes
            Obj.Idcliente = idcliente;
            Obj.Nombres = nombres;
            Obj.Apellidos = apellidos;
            Obj.Celular = celular;
            Obj.Direccion = direccion;
            Obj.Documento = documento;
            //le envio el objeto con todos los atributos
            return Obj.Editar(Obj);
        }
        //Metodo Eliminar que llama al metod eliminar de la clase DClientes
        //de la CapaDatos
        public static string Eliminar(int idcliente)
        {
            DClientes Obj = new DClientes();
            Obj.Idcliente = idcliente;
            return Obj.Eliminar(Obj);
        }
        //Metodo mostrar que llama al metodo mostrar de la clase DCategoria
        //de la CapaDatos
        public static DataTable Mostrar()
        {
            //instancio Dcategoria y llamo a mi meotodo mostrar
            return new DClientes().Mostrar();
        }
        //Metodo buscar nombre   que llama al metodo buscar nombre
        //de la clase DCategoria de la CapaDatos

        public static DataTable BuscarNombre(string textobuscar)
        {
            DClientes Obj = new DClientes();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }
    }
}
