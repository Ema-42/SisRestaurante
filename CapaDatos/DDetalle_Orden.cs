using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using CapaDatos;

namespace CapaDatos
{
    public class DDetalle_Orden
    {
        //VARIABLES
        private int _Iddetalle_orden;
        private int _Idorden;
        private int _Idproducto;
        private int _Cantidad;
        private decimal _Precio;

        public int Iddetalle_orden { get => _Iddetalle_orden; set => _Iddetalle_orden = value; }
        public int Idorden { get => _Idorden; set => _Idorden = value; }
        public int Idproducto { get => _Idproducto; set => _Idproducto = value; }
        public int Cantidad { get => _Cantidad; set => _Cantidad = value; }
        public decimal Precio { get => _Precio; set => _Precio = value; }

        //constructores
        public DDetalle_Orden()
        {

        }
        public DDetalle_Orden(int iddetalle_orden, int idorden, int idprodcuto, decimal precio,int cantidad)
        {
            this.Iddetalle_orden = iddetalle_orden;
            this.Idorden = idorden;
            this.Idproducto = idprodcuto;
            this.Cantidad = cantidad;
            this.Precio = Precio;
        }

        //metodo insertar 
        //sqlconnection para usar la conexion que envia la clase DIngreso, asi que recibimos es conexion por referencia
        //sqltran se va insertar una unica transaccion y no mezclar ingresos, estos parametro van a venir de DOrden
        //para insertar una orden con todos sus detalles
        public string Insertar(DDetalle_Orden Detalle_Orden, ref SqlConnection SqlCon, ref SqlTransaction SqlTran)
        {

            string rpta = "";
            //ya no necesitamos esta conexion
            //SqlConnection SqlCon = new SqlConnection();
            try
            {

                //SqlCon.ConnectionString = Conexion.Cn;
                //SqlCon.Open();

                //Estanlecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.Transaction = SqlTran;
                SqlCmd.CommandText = "insertar_detalle_orden";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIddetalle_Orden = new SqlParameter();
                ParIddetalle_Orden.ParameterName = "@iddetalle_orden";
                ParIddetalle_Orden.SqlDbType = SqlDbType.Int;
                ParIddetalle_Orden.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIddetalle_Orden);

                SqlParameter ParIdorden = new SqlParameter();
                ParIdorden.ParameterName = "@idorden";
                ParIdorden.SqlDbType = SqlDbType.Int;
                ParIdorden.Value = Detalle_Orden.Idorden;
                SqlCmd.Parameters.Add(ParIdorden);

                SqlParameter ParIdproducto = new SqlParameter();
                ParIdproducto.ParameterName = "@idproducto";
                ParIdproducto.SqlDbType = SqlDbType.Int;
                ParIdproducto.Value = Detalle_Orden.Idproducto;
                SqlCmd.Parameters.Add(ParIdproducto);

                SqlParameter ParPrecio = new SqlParameter();
                ParPrecio.ParameterName = "@precio";
                ParPrecio.SqlDbType = SqlDbType.Decimal;
                ParPrecio.Value = Detalle_Orden.Precio;
                SqlCmd.Parameters.Add(ParPrecio);

                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@cantidad";
                ParCantidad.SqlDbType = SqlDbType.Int;
                ParCantidad.Value = Detalle_Orden.Cantidad;
                SqlCmd.Parameters.Add(ParCantidad);

                //Ejecutamos nuestro comando
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se ingreso el registro";

            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }

            return rpta;
        }
    }

}

