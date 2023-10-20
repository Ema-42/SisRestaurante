using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DRoles
    {
        private int _Idrol;
        private string _Nombre;
        private string _Descripcion;

        private string _TextoBuscar;

        public int Idrol { get => _Idrol; set => _Idrol = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        //constructor vacio
        public DRoles()
        {

        }
        //constructor con parametros
        public DRoles(int idrol, string nombre, string descripcion, string textobuscar)
        {
            this.Idrol = idrol;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.TextoBuscar = textobuscar;
        }
        //metodos
        public string Insertar(DRoles Rol)
        {
            string rpta = "";
            //instancia a nuestra cadena de conexion
            SqlConnection Sql = new SqlConnection();
            SqlConnection SqlCon = new SqlConnection();
            //try para capturar errrores
            try
            {
                //Código
                SqlCon.ConnectionString = Conexion.Cn;
                //abrir conexion
                SqlCon.Open();
                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                //el texto comando va ser nuestro procedimiento almacenado
                SqlCmd.CommandText = "insertar_rol";
                //indicar que es un proc almacenados
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdrol = new SqlParameter();
                ParIdrol.ParameterName = "@idrol";
                ParIdrol.SqlDbType = SqlDbType.Int;
                //ya que es un campo autoincremental indicamos que es un parametro de salida
                ParIdrol.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdrol);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Rol.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 50;
                ParDescripcion.Value = Rol.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingreso el Registro";


            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;
        }
        public string Editar(DRoles Rol)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Código
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "editar_rol";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdrol = new SqlParameter();
                ParIdrol.ParameterName = "@idrol";
                ParIdrol.SqlDbType = SqlDbType.Int;
                ParIdrol.Value = Rol.Idrol;
                SqlCmd.Parameters.Add(ParIdrol);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Rol.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 50;
                ParDescripcion.Value = Rol.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Actualizo el Registro";


            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;
        }
        public string Eliminar(DRoles Rol)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Código
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "eliminar_rol";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdrol = new SqlParameter();
                ParIdrol.ParameterName = "@idrol";
                ParIdrol.SqlDbType = SqlDbType.Int;
                ParIdrol.Value = Rol.Idrol;
                SqlCmd.Parameters.Add(ParIdrol);

                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se elimino el Registros";


            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;
        }
        public DataTable Mostrar()
        {
            //enviar el nombre de la tabla 
            DataTable DtResultado = new DataTable("roles");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "mostrar_rol";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                string rpta = "";
                rpta = ex.Message;
                DtResultado = null;
            }
            return DtResultado;
        }
        public DataTable BuscarNombre(DRoles Rol)
        {
            DataTable DtResultado = new DataTable("roles");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                //usar esa cadena de conexion
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "buscar_rol";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Rol.TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                string rpta = "";
                rpta = ex.Message;
                DtResultado = null;

            }
            return DtResultado;
        }
    }
}