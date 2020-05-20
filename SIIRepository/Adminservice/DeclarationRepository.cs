using SIIModel.StudentRegister;
using System;
using System.Data;
using System.Data.SqlClient;

namespace SIIRepository.Adminservice
{
    public class DeclarationRepository:Base
    {
        public DataSet Check_Declarations(StudentDeclaration _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("Check_Declarations", _cn);
                _cmd.Parameters.AddWithValue("@studentid", _obj.studentid);
                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.CommandTimeout = 300;
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
