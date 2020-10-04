using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace DataAccess
{
    public abstract class DA_Connection
    {
        public readonly string connection;
        public DA_Connection()
        {
            connection = ConfigurationManager.ConnectionStrings["Huellas___Gatos_y_Perros_de_Flores___WiredSoft.Properties.Settings.Connection"].ConnectionString;
        }
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(connection);
        }
    }
}

