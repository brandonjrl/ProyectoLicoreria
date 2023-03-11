using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Licoreria_AccesosdeDatos;

namespace Licoreria_Negocio
{
    public class CNProductoVenta
    {
        private ProductoVentaDAL objetoCD = new ProductoVentaDAL();
        public DataTable MostrarPV()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarProductoVenta();
            return tabla;
        }
        public void InsertarPV(int cantidad, float unitario, int idProd)
        {
            objetoCD.InsertarProductoVenta(cantidad, unitario, idProd);
        }
        public void EliminarPV(string id)
        {
            objetoCD.EliminarProductoVenta(Convert.ToInt32(id));
        }

        //LLamo procedure producto mas vendido
        public DataTable MasVendidos()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.ProductosMasVendidos();
            return tabla;
        }

        //Funcion ventas por dia llamando al procedure
        public DataTable VentasPorDia(DateTime fecha)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.VentasXDia(fecha);
            return tabla;
        }
    }
}
