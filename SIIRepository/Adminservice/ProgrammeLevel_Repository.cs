using SIIModel.Admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace SIIRepository.Adminservice
{
    public class ProgrammeLevel_Repository : Base
    {
        public DataSet INSERT_UPDATE_PROGRAMMELEVEL(mProgrammeLevel _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("INSERT_UPDATE_PROGRAMMELEVEL", _cn);
                _cmd.Parameters.AddWithValue("@ProgramLevel_Id", _obj.ProgramLevel_Id);
                _cmd.Parameters.AddWithValue("@ProgramLevel", _obj.ProgramLevel);
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
        public DataSet SELECT_PROGRAMMELEVEL_FOR_FORM(string ProgramLevel_Id = "0", string isNicheCourse = "0")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("SELECT_PROGRAMMELEVEL_FOR_FORM", _cn);
                _cmd.Parameters.AddWithValue("@ProgramLevel_Id", ProgramLevel_Id);
                _cmd.Parameters.AddWithValue("@IsNicheCourse", isNicheCourse);
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
        public DataSet DELETE_PROGRAMMELEVEL_FOR_FORM(string ProgramLevel_Id = "0", int IsNicheCourse = 0)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("DELETE_PROGRAMMELEVEL_FOR_FORM", _cn);
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

        public DataSet SELECT_PROGRAMELEVEL_FROM_DISCIPLINE(string Discipline_ID = "0", int IsNicheCourse = 0)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("SELECT_PROGRAMELEVEL_FROM_DISCIPLINE", _cn);
                _cmd.Parameters.AddWithValue("@Discipline_ID", Discipline_ID);
                _cmd.Parameters.AddWithValue("@IsNicheCourse", IsNicheCourse);
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

        public DataSet INSERT_UPDATE_Discipline_Programme_Mapping(mProgrammeLevelMapping _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("INSERT_UPDATE_Discipline_Programme_Mapping", _cn);
                _cmd.Parameters.AddWithValue("@Mpng_ID", _obj.Mpng_ID);
                _cmd.Parameters.AddWithValue("@Discipline_ID", _obj.Discipline_ID);
                _cmd.Parameters.AddWithValue("@ProgramLevel_Id", _obj.ProgramLevel_Id);
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
        public DataSet SELECT_Discipline_Programme_Mapping_FOR_FORM(string Mpng_ID = "0", string IsNicheCourse = "0")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("SELECT_Discipline_Programme_Mapping_FOR_FORM", _cn);
                _cmd.Parameters.AddWithValue("@Mpng_ID", Mpng_ID);
                _cmd.Parameters.AddWithValue("@IsNicheCourse", IsNicheCourse);
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
        public DataSet DELETE_Discipline_Programme_Mapping_FOR_FORM(string Mpng_ID = "0")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("DELETE_Discipline_Programme_Mapping_FOR_FORM", _cn);
                _cmd.Parameters.AddWithValue("@Mpng_ID", Mpng_ID); 
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

        public DataSet SELECT_tbl_CourseOfStudy_FROM_Qaulification(string Discipline_ID = "0", string ProgramLevel_Id = "0", string Qualification_ID = "0")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("SELECT_tbl_CourseOfStudy_FROM_Qaulification", _cn);
                _cmd.Parameters.AddWithValue("@Discipline_ID", Discipline_ID);
                _cmd.Parameters.AddWithValue("@ProgramLevel_Id", ProgramLevel_Id);
                _cmd.Parameters.AddWithValue("@Qualification_ID", Qualification_ID);
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