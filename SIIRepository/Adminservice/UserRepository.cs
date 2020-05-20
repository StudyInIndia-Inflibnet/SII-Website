using SIIModel.Admin;
using System;
using System.Data;
using System.Data.SqlClient;

namespace SIIRepository.Adminservice
{
    public class UserRepository:Base
    {
        public DataSet Login_Usermaster(Usermaster _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("sp_tbl_user_master", _cn);
                _cmd.Parameters.AddWithValue("@User_Name", _obj.User_Name);
                _cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter _adp = new SqlDataAdapter(_cmd);
                _cmd.CommandTimeout = 300;
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
