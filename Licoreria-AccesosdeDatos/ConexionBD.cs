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
        private SqlConnection Conexion = new SqlConnection(@"Server=tcp:proyecto2bim.database.windows.net,1433;Initial Catalog=LicoreriaBDD;Persist Security Info=False;User ID=BaseAzure;Password=proyecto-2bim;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"); 
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
        //holis
        //comentario cualquiera
    }
}
