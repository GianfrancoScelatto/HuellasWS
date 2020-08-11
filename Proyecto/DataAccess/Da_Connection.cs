using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
namespace DataAccess
{
    public abstract class Da_Connection
    {
            public readonly string connection;
            public Da_Connection()
            {
                connection = ConfigurationManager.ConnectionStrings["Gatos_y_Perros_de_Flores.Properties.Settings.ConexionGPF"].ConnectionString;
            }
            protected SqlConnection GetConnection()
            {
                return new SqlConnection(connection);
            }
        }
    }
