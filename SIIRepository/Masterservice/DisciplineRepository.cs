using SIIModel.Master;
using System;
using System.Data;
using System.Data.SqlClient;

namespace SIIRepository.Masterservice
{
    public class DisciplineRepository : Base
    {
        public DataSet Select_decipline(string IsActive = "0")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("sp_select_decipline", _cn);
                _cmd.Parameters.AddWithValue("@IsActive", IsActive);
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
