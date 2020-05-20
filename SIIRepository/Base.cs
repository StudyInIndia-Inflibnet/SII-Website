using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SIIRepository
{
    public class Base
    {
        protected SqlConnection _cn = null;
        public Base()
        {
            if (_cn != null && _cn.State == ConnectionState.Open)
            {
                _cn.Close();
            }
            _cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SII"].ConnectionString);
        }
    }
}
