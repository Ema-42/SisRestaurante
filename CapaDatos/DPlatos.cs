using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DPlatos
    {
        private int _Idplato;
        private string _Nombre;
        private string _Descripcion;
        private float _Precio;
        private int _Tiempo;

        private string _TextoBuscar;

        public int Idplato { get => _Idplato; set => _Idplato = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }
        public float Precio { get => _Precio; set => _Precio = value; }
        public int Tiempo { get => _Tiempo; set => _Tiempo = value; }

        //constructor vacio
        public DPlatos()
        {

        }
        //constructor con parametros
        public DPlatos(int idplato, string nombre, string descripcion, string textobuscar, float precio, int tiempo)
        {
            this.Idplato = idplato;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Precio = precio;
            this.Tiempo = tiempo;
            this.TextoBuscar = textobuscar;
        }
        //metodos
        public string Insertar(DPlatos Plato)
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
                SqlCmd.CommandText = "insertar_platos";
                //indicar que es un proc almacenados
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdplato = new SqlParameter();
                ParIdplato.ParameterName = "@idplato";
                ParIdplato.SqlDbType = SqlDbType.Int;
                //ya que es un campo autoincremental indicamos que es un parametro de salida
                ParIdplato.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdplato);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Plato.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 50;
                ParDescripcion.Value = Plato.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                SqlParameter ParPrecio = new SqlParameter();
                ParPrecio.ParameterName = "@precio";
                ParPrecio.SqlDbType = SqlDbType.Float;
                ParPrecio.Value = Plato.Precio;
                SqlCmd.Parameters.Add(ParPrecio);

                SqlParameter ParTiempo = new SqlParameter();
                ParTiempo.ParameterName = "@tiempo";
                ParTiempo.SqlDbType = SqlDbType.Float;
                ParTiempo.Value = Plato.Tiempo;
                SqlCmd.Parameters.Add(ParTiempo);

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
        public string Editar(DPlatos Plato)
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
                SqlCmd.CommandText = "editar_platos";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdplato = new SqlParameter();
                ParIdplato.ParameterName = "@idplato";
                ParIdplato.SqlDbType = SqlDbType.Int;
                ParIdplato.Value = Plato.Idplato;
                SqlCmd.Parameters.Add(ParIdplato);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Plato.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 50;
                ParDescripcion.Value = Plato.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                SqlParameter ParPrecio = new SqlParameter();
                ParPrecio.ParameterName = "@precio";
                ParPrecio.SqlDbType = SqlDbType.Float;
                ParPrecio.Value = Plato.Precio;
                SqlCmd.Parameters.Add(ParPrecio);

                SqlParameter ParTiempo = new SqlParameter();
                ParTiempo.ParameterName = "@tiempo";
                ParTiempo.SqlDbType = SqlDbType.Float;
                ParTiempo.Value = Plato.Tiempo;
                SqlCmd.Parameters.Add(ParTiempo);

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
        public string Eliminar(DPlatos Plato)
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
                SqlCmd.CommandText = "eliminar_platos";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdplatos = new SqlParameter();
                ParIdplatos.ParameterName = "@idplato";
                ParIdplatos.SqlDbType = SqlDbType.Int;
                ParIdplatos.Value = Plato.Idplato;
                SqlCmd.Parameters.Add(ParIdplatos);

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
            DataTable DtResultado = new DataTable("platos");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "mostrar_platos";
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
        public DataTable BuscarNombre(DPlatos Plato)
        {
            DataTable DtResultado = new DataTable("platos");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                //usar esa cadena de conexion
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "buscar_platos";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Plato.TextoBuscar;
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