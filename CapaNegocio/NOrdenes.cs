using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NOrdenes
    {

        public static string Insertar(int idusuario, int idcliente, DateTime fecha, string estado, DataTable dtDetalles)
        {
            DOrdenes Obj = new DOrdenes();
            Obj.Idusuario = idusuario;
            Obj.Idcliente = idcliente;
            Obj.Fecha = fecha;
            Obj.Estado = estado;
            //detalles es instancia de DDtellaes, esto es una lista para almacenar cda producto
            List<DDetalle_Orden> detalles = new List<DDetalle_Orden>();
            //recorre uno a uno todos los detales que resivimos de la capa presentacion
            foreach (DataRow row in dtDetalles.Rows)
            {
                DDetalle_Orden detalle = new DDetalle_Orden();
                detalle.Idproducto = Convert.ToInt32(row["idProducto"].ToString());
                detalle.Cantidad = Convert.ToInt32(row["cantidad"].ToString());
                detalle.Precio = Convert.ToDecimal(row["precio"].ToString());
                detalles.Add(detalle);
            }
            return Obj.Insertar(Obj, detalles);
        }

        //Metodo Anular que llama al metod anular de la clase Dorden
        //de la CapaDatos
        public static string Anular(int idorden)
        {
            DOrdenes Obj = new DOrdenes();
            Obj.Idorden = idorden;
            return Obj.Anular(Obj);
        }
        //Metodo mostrar que llama al metodo mostrar de la clase DOrden
        //de la CapaDatos
        public static DataTable Mostrar()
        {
            return new DOrdenes().Mostrar();
        }
        //Metodo buscar nombre   que llama al metodo buscar fecha
        //de la clase DIngreso de la CapaDatos

        public static DataTable BuscarFechas(string textobuscar)
        {
            DOrdenes Obj = new DOrdenes();
            return Obj.BuscarFechas(textobuscar);
        }

        public static DataTable MostrarDetalle(string textobuscar)
        {
            DOrdenes Obj = new DOrdenes();
            return Obj.MostrarDetalle(textobuscar);
        }
    }
}
