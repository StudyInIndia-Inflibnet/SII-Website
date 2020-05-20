using SIIModel.Admin;
using System;
using System.Data;
using System.Data.SqlClient;

namespace SIIRepository.Adminservice
{
    public class BlogPost_Repository: Base
    { 
        public DataSet INSERT_UPDATE_BLOGPOST(mBlogPost _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("INSERT_UPDATE_BLOGPOST", _cn);
                _cmd.Parameters.AddWithValue("@Blog_Id", _obj.Blog_Id);
                _cmd.Parameters.AddWithValue("@BlogTitle", _obj.BlogTitle);
                _cmd.Parameters.AddWithValue("@UniqueCode", _obj.UniqueCode);
                _cmd.Parameters.AddWithValue("@BlogContent", _obj.BlogContent);
                _cmd.Parameters.AddWithValue("@BlogImage", _obj.BlogImage);
                _cmd.Parameters.AddWithValue("@BlogTag", _obj.BlogTag);
                _cmd.Parameters.AddWithValue("@BlogMetaTags", _obj.BlogMetaTags);
                _cmd.Parameters.AddWithValue("@BlogMetaDescription", _obj.BlogMetaDescription);
                _cmd.Parameters.AddWithValue("@CreatedBy", _obj.CreatedBy);
                _cmd.Parameters.AddWithValue("@CreatedIP", _obj.CreatedIP);
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
        public DataSet SELECT_BLOGPOST(mBlogPost _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("SELECT_BLOGPOST", _cn);
                _cmd.Parameters.AddWithValue("@Blog_Id", _obj.Blog_Id);
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
        public DataSet SELECT_BLOGPOST_FOR_LIST(string RegistrationPhase= "")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("SELECT_BLOGPOST_FOR_LIST", _cn);
                _cmd.Parameters.AddWithValue("@RegistrationPhase", RegistrationPhase);
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
        public DataSet SELECT_BLOGPOST_BY_UNIQUECODE(string UniqueCode = "")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("SELECT_BLOGPOST_BY_UNIQUECODE", _cn);
                _cmd.Parameters.AddWithValue("@UniqueCode", UniqueCode);
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
