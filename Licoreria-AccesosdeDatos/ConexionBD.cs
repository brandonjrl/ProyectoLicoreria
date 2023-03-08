using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace Licoreria_AccesosdeDatos
{
    public class ConexionBD
    {
        //revisar string de conexion 
        //
       
        private SqlConnection Conexion = new SqlConnection(Licoreria_AccesosdeDatos.Properties.Resources.String1); 
        public SqlConnection AbrirConexion()
        {
            if (Conexion.State == ConnectionState.Closed)
                Conexion.Open();
            return Conexion;
        }
        public SqlConnection CerrarConexion()
        {
            if (Conexion.State == ConnectionState.Open)
                Conexion.Close();
            return Conexion;
        }

    }
}
