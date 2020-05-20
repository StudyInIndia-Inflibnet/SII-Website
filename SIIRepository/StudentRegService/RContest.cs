using SIIModel.StudentRegister;
using System;
using System.Data;
using SIIModel.Admin;
using System.Data.SqlClient;

namespace SIIRepository.StudentRegService
{
    public class RContest : Base
    {
        public DataSet SELECT_tbl_contest_details(mContest _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("SELECT_tbl_contest_details", _cn);
                _cmd.Parameters.AddWithValue("@Email", _obj.Email);
                _cmd.Parameters.AddWithValue("@Mobile", _obj.Mobile);
                _cmd.Parameters.AddWithValue("@CreatedIP", _obj.CreatedIP);
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
        public DataSet INSERT_UPDATE_tbl_contest_Doc_Upload(mContest _obj, string Docs)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("INSERT_UPDATE_tbl_contest_Doc_Upload", _cn);
                _cmd.Parameters.AddWithValue("@Name", _obj.Name);
                _cmd.Parameters.AddWithValue("@Institute", _obj.Institute);
                _cmd.Parameters.AddWithValue("@Email", _obj.Email);
                _cmd.Parameters.AddWithValue("@Mobile", _obj.Mobile);
                _cmd.Parameters.AddWithValue("@Country", _obj.Country);
                _cmd.Parameters.AddWithValue("@ProgramLevels", _obj.ProgramLevels);
                _cmd.Parameters.AddWithValue("@mCourseOfStudy", _obj.mCourseOfStudy);
                _cmd.Parameters.AddWithValue("@CourseOther", _obj.CourseOther);
                _cmd.Parameters.AddWithValue("@Docs", Docs);
                _cmd.Parameters.AddWithValue("@CreatedIP", _obj.CreatedIP);
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