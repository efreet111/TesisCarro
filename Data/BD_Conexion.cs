using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;

namespace Data
{
    public class BD_Conexion
    {
        public string GetConnectionString()
        {
            string connectionString = string.Empty;
            try
            {
                //connectionString = ff.Desencriptar(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString);
                connectionString = (ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString);
            }
            catch
            {
                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new ApplicationException("La cadena de conexión no puede estar en blanco");
                }
            }
            return connectionString;
        }
    }
}
