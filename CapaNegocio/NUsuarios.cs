using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NUsuarios { 
    
        //METODOS para comunicarnos con la capa datos
        //Metodo que llama al metodo insertar de la clase DUsuarios
        public static string Insertar( string nombres, string apellidos, string numero_documento,
            string direccion, string sexo, byte[] imagen, DateTime fecha_registro, string usuario,
            string password, int idrol, string celular)
        {
            DUsuarios Obj = new DUsuarios();
            Obj.Nombres = nombres;
            Obj.Apellidos = apellidos;
            Obj.Numero_Documento = numero_documento;
            Obj.Direccion = direccion;
            Obj.Sexo = sexo;
            Obj.Imagen = imagen;
            Obj.Fecha_Registro = fecha_registro;
            Obj.Usuario = usuario;
            Obj.Password = password;
            Obj.Idrol = idrol;
            Obj.Celular = celular;

            return Obj.Insertar(Obj);
        }

        public static string Editar(int idusuario, string nombres, string apellidos, string numero_documento,
            string direccion, string sexo, byte[] imagen, DateTime fecha_registro, string usuario,
            string password, int idrol, string celular)
        {
            DUsuarios Obj = new DUsuarios();
            Obj.Idusuario = idusuario;
            Obj.Nombres = nombres;
            Obj.Apellidos = apellidos;
            Obj.Numero_Documento = numero_documento;
            Obj.Direccion = direccion;
            Obj.Sexo = sexo;
            Obj.Imagen = imagen;
            Obj.Fecha_Registro = fecha_registro;
            Obj.Usuario = usuario;
            Obj.Password = password;
            Obj.Idrol = idrol;
            Obj.Celular = celular;

            return Obj.Editar(Obj);
        }

        public static string Eliminar(int idusuario)
        {
            DUsuarios Obj = new DUsuarios();
            Obj.Idusuario = idusuario;
            return Obj.Eliminar(Obj);
        }

        public static DataTable Mostrar()
        {
            return new DUsuarios().Mostrar();
        }

        public static DataTable BuscarNombre(string textobuscar)
        {
            DUsuarios Obj = new DUsuarios();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }

        public static DataTable BuscarDocumento(string textobuscar)
        {
            DUsuarios Obj = new DUsuarios();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarDocumento(Obj);
        }

        public static DataTable Login(string usuario, string password)
        {
            DUsuarios Obj = new DUsuarios();
            Obj.Usuario = usuario;
            Obj.Password = password;
            return Obj.Login(Obj);
        }

    }
}
