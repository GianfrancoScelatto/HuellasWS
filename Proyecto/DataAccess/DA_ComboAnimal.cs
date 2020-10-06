using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
namespace DataAccess
{
    public class DA_ComboAnimal : DA_Connection
    {
        public bool RellenarCombo(cmbEspecie combo, string campo1, string campo2, string tabla)
        {
            bool rta;
            using (var connection = GetConnection())
            {
                try
                {
                    connection.Open();
                    var comando = new SqlCommand();
                    var sentencia = "SELECT " + campo1.ToUpper() + ", " + campo2 + " FROM " + tabla + " ORDER BY " + campo1 + "";
                    comando.Connection = connection;
                    var comando2 = new SqlCommand(sentencia, connection);
                    var da = new SqlDataAdapter(comando2);
                    var ds = new DataSet();
                    da.Fill(ds);
                    combo.DataSource = ds.Tables[0];
                    combo.DisplayMember = ds.Tables[0].Columns[0].Caption;
                    rta = true;
                }
                catch (Exception ex)
                {
                    rta = false;
                    throw ex;
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }

                return rta;
            }
        }
    }
}
