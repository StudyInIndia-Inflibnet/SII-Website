using SIIModel.Faculty;
using System;
using System.Data;
using System.Data.SqlClient;

namespace SIIRepository.Institute
{
    public class InstituteFacultyAlumniRepository : Base
    {
        public DataSet Save_Institute_Faculty(mInstituteFaculty _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("sp_Insert_Update_Institute_Faculty", _cn);
                _cmd.Parameters.AddWithValue("@ID", _obj.ID);
                _cmd.Parameters.AddWithValue("@InstituteID", _obj.InstituteID);
                _cmd.Parameters.AddWithValue("@FacultyName", _obj.FacultyName);
                _cmd.Parameters.AddWithValue("@Designation", _obj.Designation);
                _cmd.Parameters.AddWithValue("@Qualification", _obj.Qualification);
                _cmd.Parameters.AddWithValue("@AreaofExcellence", _obj.AreaofExcellence);
                _cmd.Parameters.AddWithValue("@flag_faculty", _obj.flag_faculty);
                _cmd.Parameters.AddWithValue("@Photo", _obj.Photo);
                _cmd.Parameters.AddWithValue("@IsRegular", _obj.IsRegular);
                _cmd.Parameters.AddWithValue("@CreatedIP", _obj.CreatedIP);
                _cmd.Parameters.AddWithValue("@CurrentEmployer", _obj.CurrentEmployer);
                _cmd.Parameters.AddWithValue("@AlumniDesignation", _obj.AlumniDesignation);
                _cmd.Parameters.AddWithValue("@Edited_by", _obj.Edited_by);
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
        public DataSet Select_Institute_Faculty(string ID = "",string flag_faculty="",string InstituteID="")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("sp_Select_Institute_Faculty", _cn);
                _cmd.Parameters.AddWithValue("@ID", ID);
                _cmd.Parameters.AddWithValue("@InstituteID", InstituteID);
                _cmd.Parameters.AddWithValue("@flag_faculty", flag_faculty);
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
        public DataSet Delete_Institute_Faculty(string ID = "")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("sp_Delete_Institute_Faculty", _cn);
                _cmd.Parameters.AddWithValue("@ID", ID);
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
        public DataSet select_load_faculty()
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("sp_select_load_faculty", _cn);
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
