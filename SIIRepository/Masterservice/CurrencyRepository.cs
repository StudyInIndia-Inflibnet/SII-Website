using SIIModel.Master;
using System;
using System.Data;
using System.Data.SqlClient;

namespace SIIRepository.Masterservice
{
    public class CurrencyRepository:Base
    {
        public DataSet select_Currency()
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("select_tbl_Currency", _cn);
                _cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter _adp = new SqlDataAdapter(_cmd);
                DataSet _ds = new DataSet();
                _adp.Fill(_ds);
                _adp.Dispose();
                _cmd.Dispose();
                return _ds;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _cn.Close();
            }
        }
    }
}
