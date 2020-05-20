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
    public class Qualification_Repository : Base
    {
        public DataSet INSERT_UPDATE_Qualification(mQualification _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("INSERT_UPDATE_Qualification", _cn);
                _cmd.Parameters.AddWithValue("@Qualification_ID", _obj.Qualification_ID);
                _cmd.Parameters.AddWithValue("@ProgramLevel_Id", _obj.ProgramLevel_Id);
                _cmd.Parameters.AddWithValue("@Qualification", _obj.Qualification);
                _cmd.Parameters.AddWithValue("@isNicheCourse", _obj.isNicheCourse);
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
        public DataSet SELECT_Qualification_FOR_FORM(string Qualification_ID = "0", int IsNicheCourse = 0)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("SELECT_Qualification_FOR_FORM", _cn);
                _cmd.Parameters.AddWithValue("@Qualification_ID", Qualification_ID); 
                _cmd.Parameters.AddWithValue("@isNicheCourse", IsNicheCourse);
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
        public DataSet DELETE_Qualification_FOR_FORM(string Qualification_ID = "0", int IsNicheCourse = 0)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("DELETE_Qualification_FOR_FORM", _cn);
                _cmd.Parameters.AddWithValue("@Qualification_ID", Qualification_ID);
                _cmd.Parameters.AddWithValue("@isNicheCourse", IsNicheCourse);
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
        public DataSet SELECT_Qualification_FROM_PROGRAMELEVEL(string ProgramLevel_Id = "0", int IsNicheCourse = 0)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("SELECT_Qualification_FROM_PROGRAMELEVEL", _cn);
                _cmd.Parameters.AddWithValue("@ProgramLevel_Id", ProgramLevel_Id);
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
        public DataSet SELECT_Qualification_FROM_DIS_PL(string Discipline_ID = "0", string ProgramLevel_Id = "0", int IsNicheCourse = 0)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("SELECT_Qualification_FROM_DIS_PL", _cn);
                _cmd.Parameters.AddWithValue("@Discipline_ID", Discipline_ID);
                _cmd.Parameters.AddWithValue("@ProgramLevel_Id", ProgramLevel_Id);
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

        public DataSet INSERT_UPDATE_tbl_NatureOfCourse(mQualificationMapping _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("INSERT_UPDATE_tbl_NatureOfCourse", _cn);
                _cmd.Parameters.AddWithValue("@Natureofcourse_Id", _obj.Natureofcourse_Id);
                _cmd.Parameters.AddWithValue("@Discipline_ID", _obj.Discipline_ID);
                _cmd.Parameters.AddWithValue("@ProgramLevel_Id", _obj.ProgramLevel_Id);
                _cmd.Parameters.AddWithValue("@Qualification_ID", _obj.Qualification_ID);
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
        public DataSet SELECT_tbl_NatureOfCourse_FOR_FORM(string Natureofcourse_Id = "0", int IsNicheCourse = 0)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("SELECT_tbl_NatureOfCourse_FOR_FORM", _cn);
                _cmd.Parameters.AddWithValue("@Natureofcourse_Id", Natureofcourse_Id);
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
        public DataSet DELETE_tbl_NatureOfCourse_FOR_FORM(string Natureofcourse_Id = "0", int IsNicheCourse = 0)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("DELETE_tbl_NatureOfCourse_FOR_FORM", _cn);
                _cmd.Parameters.AddWithValue("@Natureofcourse_Id", Natureofcourse_Id);
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