using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DUsuarios
    {
        //VARIABLES

        private int _Idusuario;
        private string _Nombres;
        private string _Apellidos;
        private string _Numero_Documento;
        private string _Direccion;
        private string _Sexo;
        private byte[] _Imagen;
        private DateTime _Fecha_Registro;
        private string _Usuario;
        private string _Password;
        private int _Idrol;
        private string _Celular;
        private string _TextoBuscar;

        public int Idusuario { get => _Idusuario; set => _Idusuario = value; }
        public string Nombres { get => _Nombres; set => _Nombres = value; }
        public string Apellidos { get => _Apellidos; set => _Apellidos = value; }
        public string Numero_Documento { get => _Numero_Documento; set => _Numero_Documento = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public string Sexo { get => _Sexo; set => _Sexo = value; }
        public byte[] Imagen { get => _Imagen; set => _Imagen = value; }
        public DateTime Fecha_Registro { get => _Fecha_Registro; set => _Fecha_Registro = value; }
        public string Usuario { get => _Usuario; set => _Usuario = value; }
        public string Password { get => _Password; set => _Password = value; }
        public int Idrol { get => _Idrol; set => _Idrol = value; }
        public string Celular { get => _Celular; set => _Celular = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        //CONSTRUCTORES
        public DUsuarios()
        {

        }

        public DUsuarios(int idusuario, string nombres, string apellidos, string numero_documento,
            string direccion, string sexo, byte[] imagen,DateTime fecha_registro,string usuario, 
            string password,int idrol,string celular ,string textobuscar)
        {
            this.Idusuario = idusuario;
            this.Nombres = nombres;
            this.Apellidos = apellidos;
            this.Numero_Documento = numero_documento;
            this.Direccion = direccion;
            this.Sexo = sexo;
            this.Imagen = imagen;
            this.Fecha_Registro = fecha_registro;
            this.Usuario = usuario;
            this.Password = password;
            this.Idrol = idrol;
            this.Celular = celular;
            this.TextoBuscar = textobuscar;
        }
        //METODOS
        public string Insertar(DUsuarios Usuario)
        {

            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //codigo
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                //Estanlecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "insertar_usuarios";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdusuario = new SqlParameter();
                ParIdusuario.ParameterName = "@idusuario";
                ParIdusuario.SqlDbType = SqlDbType.Int;
                ParIdusuario.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdusuario);

                SqlParameter ParNombres = new SqlParameter();
                ParNombres.ParameterName = "@nombres";
                ParNombres.SqlDbType = SqlDbType.VarChar;
                ParNombres.Size = 50;
                ParNombres.Value = Usuario.Nombres;
                SqlCmd.Parameters.Add(ParNombres);

                SqlParameter ParApellidos = new SqlParameter();
                ParApellidos.ParameterName = "@apellidos";
                ParApellidos.SqlDbType = SqlDbType.VarChar;
                ParApellidos.Size = 50;
                ParApellidos.Value = Usuario.Apellidos;
                SqlCmd.Parameters.Add(ParApellidos);

                SqlParameter ParNumero_Documento = new SqlParameter();
                ParNumero_Documento.ParameterName = "@numero_documento";
                ParNumero_Documento.SqlDbType = SqlDbType.VarChar;
                ParNumero_Documento.Size = 50;
                ParNumero_Documento.Value = Usuario._Numero_Documento;
                SqlCmd.Parameters.Add(ParNumero_Documento);

                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@direccion";
                ParDireccion.SqlDbType = SqlDbType.VarChar;
                ParDireccion.Size = 50;
                ParDireccion.Value = Usuario.Direccion;
                SqlCmd.Parameters.Add(ParDireccion);

                SqlParameter ParSexo = new SqlParameter();
                ParSexo.ParameterName = "@sexo";
                ParSexo.SqlDbType = SqlDbType.VarChar;
                ParSexo.Size = 2;
                ParSexo.Value = Usuario.Sexo;
                SqlCmd.Parameters.Add(ParSexo);

                SqlParameter ParImagen = new SqlParameter();
                ParImagen.ParameterName = "@imagen";
                ParImagen.SqlDbType = SqlDbType.Image;
                ParImagen.Value = Usuario.Imagen;
                SqlCmd.Parameters.Add(ParImagen);

                SqlParameter ParFecha_Registro = new SqlParameter();
                ParFecha_Registro.ParameterName = "@fecha_registro";
                ParFecha_Registro.SqlDbType = SqlDbType.DateTime;
                ParFecha_Registro.Value = Usuario.Fecha_Registro;
                SqlCmd.Parameters.Add(ParFecha_Registro);


                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@usuario";
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParUsuario.Size = 50;
                ParUsuario.Value = Usuario.Usuario;
                SqlCmd.Parameters.Add(ParUsuario);


                SqlParameter ParPassword = new SqlParameter();
                ParPassword.ParameterName = "@password";
                ParPassword.SqlDbType = SqlDbType.VarChar;
                ParPassword.Size = 50;
                ParPassword.Value = Usuario.Password;
                SqlCmd.Parameters.Add(ParPassword);

                SqlParameter ParIdrol = new SqlParameter();
                ParIdrol.ParameterName = "@idrol";
                ParIdrol.SqlDbType = SqlDbType.Int;
                ParIdrol.Value = Usuario.Idrol;
                SqlCmd.Parameters.Add(ParIdrol);

                SqlParameter ParCelular = new SqlParameter();
                ParCelular.ParameterName = "@celular";
                ParCelular.SqlDbType = SqlDbType.VarChar;
                ParCelular.Size = 50;
                ParCelular.Value = Usuario.Celular;
                SqlCmd.Parameters.Add(ParCelular);

                //Ejecutamos nuestro comando
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se ingreso el Registro";


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

        //metod editar
        public string Editar(DUsuarios Usuario)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //codigo
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                //Estanlecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "editar_usuarios";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdusuario = new SqlParameter();
                ParIdusuario.ParameterName = "@idusuario";
                ParIdusuario.SqlDbType = SqlDbType.Int;
                ParIdusuario.Value = Usuario.Idusuario;
                SqlCmd.Parameters.Add(ParIdusuario);

                SqlParameter ParNombres = new SqlParameter();
                ParNombres.ParameterName = "@nombres";
                ParNombres.SqlDbType = SqlDbType.VarChar;
                ParNombres.Size = 50;
                ParNombres.Value = Usuario.Nombres;
                SqlCmd.Parameters.Add(ParNombres);

                SqlParameter ParApellidos = new SqlParameter();
                ParApellidos.ParameterName = "@apellidos";
                ParApellidos.SqlDbType = SqlDbType.VarChar;
                ParApellidos.Size = 50;
                ParApellidos.Value = Usuario.Apellidos;
                SqlCmd.Parameters.Add(ParApellidos);

                SqlParameter ParNumero_Documento = new SqlParameter();
                ParNumero_Documento.ParameterName = "@numero_documento";
                ParNumero_Documento.SqlDbType = SqlDbType.VarChar;
                ParNumero_Documento.Size = 50;
                ParNumero_Documento.Value = Usuario._Numero_Documento;
                SqlCmd.Parameters.Add(ParNumero_Documento);

                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@direccion";
                ParDireccion.SqlDbType = SqlDbType.VarChar;
                ParDireccion.Size = 50;
                ParDireccion.Value = Usuario.Direccion;
                SqlCmd.Parameters.Add(ParDireccion);

                SqlParameter ParSexo = new SqlParameter();
                ParSexo.ParameterName = "@sexo";
                ParSexo.SqlDbType = SqlDbType.VarChar;
                ParSexo.Size = 1;
                ParSexo.Value = Usuario.Sexo;
                SqlCmd.Parameters.Add(ParSexo);

                SqlParameter ParImagen = new SqlParameter();
                ParImagen.ParameterName = "@imagen";
                ParImagen.SqlDbType = SqlDbType.Image;
                ParImagen.Value = Usuario.Imagen;
                SqlCmd.Parameters.Add(ParImagen);

                SqlParameter ParFecha_Registro = new SqlParameter();
                ParFecha_Registro.ParameterName = "@fecha_registro";
                ParFecha_Registro.SqlDbType = SqlDbType.DateTime;
                ParFecha_Registro.Value = Usuario.Fecha_Registro;
                SqlCmd.Parameters.Add(ParFecha_Registro);


                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@usuario";
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParUsuario.Size = 50;
                ParUsuario.Value = Usuario.Usuario;
                SqlCmd.Parameters.Add(ParUsuario);


                SqlParameter ParPassword = new SqlParameter();
                ParPassword.ParameterName = "@password";
                ParPassword.SqlDbType = SqlDbType.VarChar;
                ParPassword.Size = 50;
                ParPassword.Value = Usuario.Password;
                SqlCmd.Parameters.Add(ParPassword);

                SqlParameter ParIdrol = new SqlParameter();
                ParIdrol.ParameterName = "@idrol";
                ParIdrol.SqlDbType = SqlDbType.Int;
                ParIdrol.Value = Usuario.Idrol;
                SqlCmd.Parameters.Add(ParIdrol);

                SqlParameter ParCelular = new SqlParameter();
                ParCelular.ParameterName = "@celular";
                ParCelular.SqlDbType = SqlDbType.VarChar;
                ParCelular.Size = 50;
                ParCelular.Value = Usuario.Celular;
                SqlCmd.Parameters.Add(ParCelular);

                //Ejecutamos nuestro comando
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se actualizo el Registro";

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

        //Metodo eliminar

        public string Eliminar(DUsuarios Usuario)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //codigo
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                //Estanlecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "eliminar_usuarios";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdusuario = new SqlParameter();
                ParIdusuario.ParameterName = "@idusuario";
                ParIdusuario.SqlDbType = SqlDbType.Int;
                ParIdusuario.Value = Usuario.Idusuario;
                SqlCmd.Parameters.Add(ParIdusuario);

                //Ejecutamos nuestro comando
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se elimino el Registro";
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

        //Metodo mostra

        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("usuarios");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "mostrar_usuarios";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;

        }

        public DataTable BuscarNombre(DUsuarios Usuario)
        {
            DataTable DtResultado = new DataTable("usuarios");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "buscar_usuarios";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Usuario.TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }

        public DataTable BuscarDocumento(DUsuarios Usuario)
        {
            DataTable DtResultado = new DataTable("usuarios");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "buscar_usuarios_documento";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Usuario.TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }


    }

}
