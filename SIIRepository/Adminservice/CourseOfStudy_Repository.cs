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
    public class CourseOfStudy_Repository : Base
    {
        public DataSet INSERT_UPDATE_CourseOfStudy(mCourseOfStudy _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("INSERT_UPDATE_CourseOfStudy", _cn);
                _cmd.Parameters.AddWithValue("@CourseOfStudy_ID", _obj.CourseOfStudy_ID);
                _cmd.Parameters.AddWithValue("@CourseOfStudy", _obj.CourseOfStudy);
                _cmd.Parameters.AddWithValue("@IsNicheCourse", _obj.IsNicheCourse);
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
        public DataSet SELECT_CourseOfStudy_FOR_FORM(string CourseOfStudy_ID = "0", int IsNicheCourse = 0)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("SELECT_CourseOfStudy_FOR_FORM", _cn);
                _cmd.Parameters.AddWithValue("@CourseOfStudy_ID", CourseOfStudy_ID);
                _cmd.Parameters.AddWithValue("@IsNicheCourse", IsNicheCourse);
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
        public DataSet DELETE_CourseOfStudy_FOR_FORM(string CourseOfStudy_ID = "0", int IsNicheCourse = 0)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("DELETE_CourseOfStudy_FOR_FORM", _cn);
                _cmd.Parameters.AddWithValue("@CourseOfStudy_ID", CourseOfStudy_ID);
                _cmd.Parameters.AddWithValue("@IsNicheCourse", IsNicheCourse);
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
        
        public DataSet INSERT_UPDATE_tbl_CourseBranch(mCourseOfStudyMapping _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("INSERT_UPDATE_tbl_CourseBranch", _cn);
                _cmd.Parameters.AddWithValue("@Branch_Id", _obj.Branch_Id);
                _cmd.Parameters.AddWithValue("@Natureofcourse_Id", _obj.Natureofcourse_Id);
                _cmd.Parameters.AddWithValue("@Discipline_ID", _obj.Discipline_ID);
                _cmd.Parameters.AddWithValue("@ProgramLevel_Id", _obj.ProgramLevel_Id);
                _cmd.Parameters.AddWithValue("@Qualification_ID", _obj.Qualification_ID);
                _cmd.Parameters.AddWithValue("@CourseOfStudy_ID", _obj.CourseOfStudy_ID);
                _cmd.Parameters.AddWithValue("@IsNicheCourse", _obj.IsNicheCourse);
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
        public DataSet SELECT_tbl_CourseBranch_FOR_FORM(string Branch_Id = "0", int IsNicheCourse = 0)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("SELECT_tbl_CourseBranch_FOR_FORM", _cn);
                _cmd.Parameters.AddWithValue("@Branch_Id", Branch_Id);
                _cmd.Parameters.AddWithValue("@IsNicheCourse", IsNicheCourse);
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
        public DataSet DELETE_tbl_CourseBranch_FOR_FORM(string Branch_Id = "0", int IsNicheCourse = 0)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("DELETE_tbl_CourseBranch_FOR_FORM", _cn);
                _cmd.Parameters.AddWithValue("@Branch_Id", Branch_Id);
                _cmd.Parameters.AddWithValue("@IsNicheCourse", IsNicheCourse);
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