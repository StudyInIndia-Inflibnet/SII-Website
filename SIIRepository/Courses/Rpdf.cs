using System.Data;
using System.Data.SqlClient;
using SIIModel.Courses;
using System;

namespace SIIRepository.Courses
{
    public class Rpdf : Base
    {
        public DataSet UPLOAD_PDF(Mpdf _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("UPLOAD_PDF", _cn);
                _cmd.Parameters.AddWithValue("@pdfpath", _obj.pdfpath);
                _cmd.Parameters.AddWithValue("@created_ip", _obj.created_ip);
                _cmd.Parameters.AddWithValue("@InstituteID", _obj.InstituteID);
                _cmd.Parameters.AddWithValue("@Filename", _obj.Filename);
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
                _cn.Dispose();
            }
        }

        public DataSet SELECT_PDF(string InstituteID ="")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("SELECT_PDF", _cn);
                _cmd.Parameters.AddWithValue("@InstituteID", InstituteID);
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

        public DataSet DELETE_PDF(string pdf_id = "")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("DELETE_PDF", _cn);
                _cmd.Parameters.AddWithValue("@pdf_id", pdf_id);
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
