using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DOrdenes
    {

        //Variablbes

        private int _Idorden;
        private int _Idusuario;
        private int _Idcliente;
        private DateTime _Fecha;
        private string _Estado;

        public int Idorden { get => _Idorden; set => _Idorden = value; }
        public int Idusuario { get => _Idusuario; set => _Idusuario = value; }
        public int Idcliente { get => _Idcliente; set => _Idcliente = value; }
        public DateTime Fecha { get => _Fecha; set => _Fecha = value; }
        public string Estado { get => _Estado; set => _Estado = value; }


        //construcores
        public DOrdenes()
        {

        }
        public DOrdenes(int idorden, int idusuario, int idcliente, DateTime fecha, string estado)
        {
            this.Idorden = idorden;
            this.Idusuario = idusuario;
            this.Idcliente = idcliente;
            this.Fecha = fecha;
            this.Estado = estado;
        }


        //Metodos

        //recibe un parametro de tipo lista es una instancia de tipo lsita y asi va insertar los detalles ,objeto de tipo list
        public string Insertar(DOrdenes Orden, List<DDetalle_Orden> Detalle)
        {

            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //codigo
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                //etsablecer la transaccion,para que cada detalle de orden sea relacionado con un solo ingreso
                //sql tra es para una transaccion unicca
                SqlTransaction SqlTra = SqlCon.BeginTransaction();
                //Estanlecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.Transaction = SqlTra;
                SqlCmd.CommandText = "insertar_orden";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdorden = new SqlParameter();
                ParIdorden.ParameterName = "@idorden";
                ParIdorden.SqlDbType = SqlDbType.Int;
                ParIdorden.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdorden);

                SqlParameter ParIdusuario = new SqlParameter();
                ParIdusuario.ParameterName = "@idusuario";
                ParIdusuario.SqlDbType = SqlDbType.Int;
                ParIdusuario.Value = Orden.Idusuario;
                SqlCmd.Parameters.Add(ParIdusuario);

                SqlParameter ParIdcliente = new SqlParameter();
                ParIdcliente.ParameterName = "@idcliente";
                ParIdcliente.SqlDbType = SqlDbType.Int;
                ParIdcliente.Value = Orden.Idcliente;
                SqlCmd.Parameters.Add(ParIdcliente);


                SqlParameter ParFecha = new SqlParameter();
                ParFecha.ParameterName = "@fecha";
                ParFecha.SqlDbType = SqlDbType.Date;
                ParFecha.Value = Orden.Fecha;
                SqlCmd.Parameters.Add(ParFecha);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Size = 7;
                ParEstado.Value = Orden.Estado;
                SqlCmd.Parameters.Add(ParEstado);

                //Ejecutamos nuestro comando
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se ingreso el Registro";

                if (rpta.Equals("OK"))
                {
                    //le procedimiento almacenado nos devuelve el id de la orden geenerada
                    //idorden es parametro de salida
                    this.Idorden = Convert.ToInt32(SqlCmd.Parameters["@idorden"].Value);
                    foreach (DDetalle_Orden det in Detalle)
                    {
                        det.Idorden = this.Idorden;
                        //lamar al metodo insertar de clase DDetalle_Ingreso
                        rpta = det.Insertar(det, ref SqlCon, ref SqlTra);
                        if (!rpta.Equals("OK"))
                        {
                            break;
                        }
                    }
                }
                //sqlcommit confirma la transaccion 
                if (rpta.Equals("OK"))
                {
                    SqlTra.Commit();
                }
                //negamos la transaccio
                else
                {
                    SqlTra.Rollback();
                }


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


        public string Anular(DOrdenes Orden)
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
                SqlCmd.CommandText = "anular_orden";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdorden = new SqlParameter();
                ParIdorden.ParameterName = "@idorden";
                ParIdorden.SqlDbType = SqlDbType.Int;
                ParIdorden.Value = Orden.Idorden;
                SqlCmd.Parameters.Add(ParIdorden);

                //Ejecutamos nuestro comando
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se anulo el Registro";

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
            DataTable DtResultado = new DataTable("orden");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "mostrar_orden";
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

        //metodo buscar fechas
        public DataTable BuscarFechas(string TextoBuscar)
        {
            DataTable DtResultado = new DataTable("orden");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "buscar_orden";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = TextoBuscar;
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
        //mostrar los detalles de una orden especifica
        public DataTable MostrarDetalle(string TextoBuscar)
        {
            DataTable DtResultado = new DataTable("detalles_orden");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "mostrar_detalle_orden";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = TextoBuscar;
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
