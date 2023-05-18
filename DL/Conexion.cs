using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DL
{
    public class Conexion
    {
        public static string GetConnectionString()
        {
            string cadenaConexion = "Data Source=.;Initial Catalog=JPinedaDigisPro;Persist Security Info=True;User ID=sa;Password=pass@word1";

            return cadenaConexion;
        }
    }
}
