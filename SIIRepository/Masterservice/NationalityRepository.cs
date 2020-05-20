using SIIModel.Master;
using System;
using System.Data;
using System.Data.SqlClient;

namespace SIIRepository.Masterservice
{
    public class NationalityRepository:Base
    {
        public DataSet select_nationality_master(Nationality _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("select_nationality_master", _cn);
               // _cmd.Parameters.AddWithValue("@studentid", _obj.studentid);
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
