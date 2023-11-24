using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DProductos
    {
        private int _Idproducto;
        private string _Nombre;
        private string _Descripcion;
        private decimal _Precio;
        private int _Idcategoria;

        private string _TextoBuscar;

        public int Idproducto { get => _Idproducto; set => _Idproducto = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public decimal Precio { get => _Precio; set => _Precio = value; }
        public int Idcategoria { get => _Idcategoria; set => _Idcategoria = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }



        //constructor vacio
        public DProductos()
        {

        }
        //constructor con parametros
        public DProductos(int idproducto, string nombre, string descripcion, string textobuscar, decimal precio, int idcategoria)
        {
            this.Idproducto = idproducto;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Precio = precio;
            this.Idcategoria = idcategoria;
            this.TextoBuscar = textobuscar;
        }
        //metodos
        public string Insertar(DProductos Producto)
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
                SqlCmd.CommandText = "insertar_productos";
                //indicar que es un proc almacenados
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdproducto = new SqlParameter();
                ParIdproducto.ParameterName = "@idproducto";
                ParIdproducto.SqlDbType = SqlDbType.Int;
                //ya que es un campo autoincremental indicamos que es un parametro de salida
                ParIdproducto.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdproducto);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Producto.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 50;
                ParDescripcion.Value = Producto.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                SqlParameter ParPrecio = new SqlParameter();
                ParPrecio.ParameterName = "@precio";
                ParPrecio.SqlDbType = SqlDbType.Decimal;
                ParPrecio.Value = Producto.Precio;
                SqlCmd.Parameters.Add(ParPrecio);

                SqlParameter ParIdCategoria = new SqlParameter();
                ParIdCategoria.ParameterName = "@idCategoria";
                ParIdCategoria.SqlDbType = SqlDbType.Int;
                ParIdCategoria.Value = Producto.Idcategoria;
                SqlCmd.Parameters.Add(ParIdCategoria);

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
        public string Editar(DProductos Producto)
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
                SqlCmd.CommandText = "editar_productos";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdproducto = new SqlParameter();
                ParIdproducto.ParameterName = "@idproducto";
                ParIdproducto.SqlDbType = SqlDbType.Int;
                ParIdproducto.Value = Producto.Idproducto;
                SqlCmd.Parameters.Add(ParIdproducto);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Producto.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 50;
                ParDescripcion.Value = Producto.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                SqlParameter ParPrecio = new SqlParameter();
                ParPrecio.ParameterName = "@precio";
                ParPrecio.SqlDbType = SqlDbType.Decimal;
                ParPrecio.Value = Producto.Precio;
                SqlCmd.Parameters.Add(ParPrecio);

                SqlParameter ParIdCategoria = new SqlParameter();
                ParIdCategoria.ParameterName = "@idCategoria";
                ParIdCategoria.SqlDbType = SqlDbType.Int;
                ParIdCategoria.Value = Producto.Idcategoria;
                SqlCmd.Parameters.Add(ParIdCategoria);

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
        public string Eliminar(DProductos Producto)
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
                SqlCmd.CommandText = "eliminar_productos";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdproducto = new SqlParameter();
                ParIdproducto.ParameterName = "@idproducto";
                ParIdproducto.SqlDbType = SqlDbType.Int;
                ParIdproducto.Value = Producto.Idproducto;
                SqlCmd.Parameters.Add(ParIdproducto);

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
            DataTable DtResultado = new DataTable("productos");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "mostrar_productos";
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
        public DataTable BuscarNombre(DProductos Producto)
        {
            DataTable DtResultado = new DataTable("productos");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                //usar esa cadena de conexion
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "buscar_productos";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Producto.TextoBuscar;
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