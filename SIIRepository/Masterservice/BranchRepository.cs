using SIIModel.Master;
using System;
using System.Data;
using System.Data.SqlClient;

namespace SIIRepository.Masterservice
{
    public class BranchRepository:Base
    {
        public DataSet sp_select_coursebranch(Branch _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("sp_select_coursebranch", _cn);
                _cmd.Parameters.AddWithValue("@Natureofcourse_Id", _obj.Natureofcourse_Id);
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
