using SIIModel.Admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIIRepository.Adminservice
{
    public class DocumentVerification_Repository : Base
    {
        public DataSet Opr_DocumentVerification_Admin(string Type ="", string Phase = "", string For= "All")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("Opr_DocumentVerification_Admin", _cn);
                _cmd.Parameters.AddWithValue("@Type", Type);
                _cmd.Parameters.AddWithValue("@Phase", Phase);
                _cmd.Parameters.AddWithValue("@For", For);
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
        public DataSet Opr_VerifyDocuments(string studentid = "", string Docs = "")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("Opr_VerifyDocuments", _cn);
                _cmd.Parameters.AddWithValue("@studentid", studentid);
                _cmd.Parameters.AddWithValue("@Docs", Docs);
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
