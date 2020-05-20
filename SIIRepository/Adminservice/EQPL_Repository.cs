using SIIModel.Admin;
using System;
using System.Data;
using System.Data.SqlClient;

namespace SIIRepository.Adminservice
{
    public class EQPL_Repository : Base
    {
        public DataSet INSERT_UPDATE_EQPLMapping(mEQPL _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("INSERT_UPDATE_EQPLMapping", _cn);
                _cmd.Parameters.AddWithValue("@EduQualifications_Id", _obj.EduQualifications_Id);
                _cmd.Parameters.AddWithValue("@EQPLMapping", _obj.EQPLMapping);
                _cmd.CommandTimeout = 300;
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
        public DataSet SELECT_EQPLMapping_FOR_FORM(string EduQualifications_Id = "0")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("SELECT_EQPLMapping_FOR_FORM", _cn);
                _cmd.Parameters.AddWithValue("@EduQualifications_Id", EduQualifications_Id);
                _cmd.CommandTimeout = 300;
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