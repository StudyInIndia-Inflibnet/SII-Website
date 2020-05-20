using SIIModel.Admin;
using SIIModel.Institute;
using System;
using System.Data;
using System.Data.SqlClient;

namespace SIIRepository.Adminservice
{
    public class DashboardRepository : Base
    {
        #region Phase1
        public DataSet Dashboard_Institute()
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("sp_admin_dashboard", _cn);
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
        public DataSet sp_select_institute_Data(Dashboard _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("sp_select_institute_Data", _cn);
                _cmd.Parameters.AddWithValue("@IsPasswordChanged", _obj.IsPasswordChanged);
                _cmd.Parameters.AddWithValue("@IsSubmited", _obj.IsSubmited);
                _cmd.Parameters.AddWithValue("@IsParticipated", _obj.IsParticipated);
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

        public DataSet Dashboard_Admin_StateWiseInstituteCount(Dashboard _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("Dashboard_Admin_StateWiseInstituteCount", _cn);
                _cmd.Parameters.AddWithValue("@Created_By", _obj.Created_By);
                _cmd.Parameters.AddWithValue("@Created_Ip", _obj.Created_Ip);
                _cmd.Parameters.AddWithValue("@StateID", _obj.StateID);
                _cmd.Parameters.AddWithValue("@Type", _obj.Type);
                _cmd.Parameters.AddWithValue("@Control", _obj.Control);
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

        public DataSet Dashboard_Admin_CourseWiseInstituteCount(Dashboard _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("Dashboard_Admin_CourseWiseInstituteCount", _cn);
                _cmd.Parameters.AddWithValue("@Created_By", _obj.Created_By);
                _cmd.Parameters.AddWithValue("@Created_Ip", _obj.Created_Ip);
                _cmd.Parameters.AddWithValue("@Natureofcourse_Id", _obj.Natureofcourse_Id);
                _cmd.Parameters.AddWithValue("@Type", _obj.Type);
                _cmd.Parameters.AddWithValue("@Control", _obj.Control);
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
        public DataSet sp_Select_All_Institutes(Dashboard _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("sp_Select_All_Institutes", _cn);
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

        public DataSet sp_select_all_student(string CountryToStay = "0", string IsPartiallySubmitted = "0")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("sp_select_all_student", _cn);
                _cmd.Parameters.AddWithValue("@CountryToStay", CountryToStay);
                _cmd.Parameters.AddWithValue("@IsPartiallySubmitted", IsPartiallySubmitted);
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

        public DataSet Dashboard_Admin_countryWiseStudentCount(Dashboard _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("Dashboard_Admin_countryWiseStudentCount", _cn);
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
        public DataSet Select_Admin_Dashboard_Institute_SeatMatrix_Counts()
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("Select_Admin_Dashboard_Institute_SeatMatrix_Counts", _cn);
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
        public DataSet Select_Admin_Dashboard_Institute_SeatMatrix(string InstituteID)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("Select_Admin_Dashboard_Institute_SeatMatrix", _cn);
                _cmd.Parameters.AddWithValue("@InstituteID", InstituteID);
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
        public DataSet Select_Admin_Dashboard_Institute_SeatMatrix_Course(string ID)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("Select_Admin_Dashboard_Institute_SeatMatrix_Course", _cn);
                _cmd.Parameters.AddWithValue("@ID", ID);
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

        public DataSet SELECT_tbl_InstituteNodalAndHeadOfficers(string InstituteID = "")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("SELECT_tbl_InstituteNodalAndHeadOfficers", _cn);
                _cmd.Parameters.AddWithValue("@InstituteID", InstituteID);
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
        #endregion

        #region Phase2
        public DataSet Dashboard_Institute_Phase2(string Phase = "")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("sp_admin_dashboard_phase2", _cn);
                _cmd.Parameters.AddWithValue("@Phase", Phase);
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
        public DataSet SELECT_INSTITUTE_COURSE_PHASE2()
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("SELECT_INSTITUTE_COURSE_PHASE2", _cn);
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
        public DataSet SELECT_INSTITUTE_NICHE_COURSE_PHASE2()
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("SELECT_INSTITUTE_NICHE_COURSE_PHASE2", _cn);
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

        public DataSet sp_select_all_student_Phase2(string CountryToStay = "0", string IsPartiallySubmitted = "0", string Phase = "")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("sp_select_all_student_phase2", _cn);
                _cmd.Parameters.AddWithValue("@Phase", Phase);
                _cmd.Parameters.AddWithValue("@CountryToStay", CountryToStay);
                _cmd.Parameters.AddWithValue("@IsPartiallySubmitted", IsPartiallySubmitted);
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
        public DataSet Dashboard_Admin_countryWiseStudentCount_Phase2(Dashboard _obj, string Phase = "")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("Dashboard_Admin_countryWiseStudentCount_phase2", _cn);
                _cmd.Parameters.AddWithValue("@Phase", Phase);
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
        #endregion
        public DataSet Save_NodalHead_Data(mNodalHeadOfficers _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("sp_Update_Nodal_Head_Officers", _cn);
                _cmd.Parameters.AddWithValue("@InstituteID", _obj.InstituteID);
                _cmd.Parameters.AddWithValue("@HeadPrefix", _obj.HeadPrefix);
                _cmd.Parameters.AddWithValue("@HeadFirstName", _obj.HeadFirstName);
                _cmd.Parameters.AddWithValue("@HeadLastName", _obj.HeadLastName);
                _cmd.Parameters.AddWithValue("@HeadEmail", _obj.HeadEmail);
                _cmd.Parameters.AddWithValue("@HeadMobile", _obj.HeadMobile);
                _cmd.Parameters.AddWithValue("@HeadDesignation", _obj.HeadDesignation);
                _cmd.Parameters.AddWithValue("@HeadPhone", _obj.HeadPhone);
                _cmd.Parameters.AddWithValue("@NodalPrefix", _obj.NodalPrefix);
                _cmd.Parameters.AddWithValue("@NodalFirstName", _obj.NodalFirstName);
                _cmd.Parameters.AddWithValue("@NodalLastName", _obj.NodalLastName);
                _cmd.Parameters.AddWithValue("@NodalEmail", _obj.NodalEmail);
                _cmd.Parameters.AddWithValue("@NodalMobile", _obj.NodalMobile);
                _cmd.Parameters.AddWithValue("@NodalDesignation", _obj.NodalDesignation);
                _cmd.Parameters.AddWithValue("@NodalPhone", _obj.NodalPhone);
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

        #region Profile Management
        public DataSet Search_Student_Data(string SearchString = "", string IP = "", string Type = "SEARCH")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("sp_Search_Student_Data", _cn);
                _cmd.Parameters.AddWithValue("@SearchString", SearchString);
                _cmd.Parameters.AddWithValue("@IP", IP);
                _cmd.Parameters.AddWithValue("@Type", Type);
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
        public DataSet SELECT_STUDENT_DATA_FOREDIT(string StudentID, string IP = "", string Type = "EDIT")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("sp_Search_Student_Data", _cn);
                _cmd.Parameters.AddWithValue("@SearchString", StudentID);
                _cmd.Parameters.AddWithValue("@IP", IP);
                _cmd.Parameters.AddWithValue("@Type", Type);
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
        public DataSet INSERT_STUDENT_DATA_FOREDIT(ProfileManagement _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("INSERT_STUDENT_DATA_FOREDIT", _cn);
                _cmd.Parameters.AddWithValue("@StudentID", _obj.StudentID);
                _cmd.Parameters.AddWithValue("@FirstName", _obj.FirstName);
                _cmd.Parameters.AddWithValue("@MiddleName", _obj.MiddleName);
                _cmd.Parameters.AddWithValue("@LastName", _obj.LastName);

                if (_obj.DateOfBirth == null || _obj.DateOfBirth.Equals(""))
                {
                    _cmd.Parameters.AddWithValue("@DateOfBirth", DBNull.Value);
                }
                else
                {
                    _cmd.Parameters.AddWithValue("@DateOfBirth", DateTime.ParseExact(_obj.DateOfBirth.ToString(), "dd-MM-yyyy", null));
                }
                _cmd.Parameters.AddWithValue("@Email", _obj.Email);
                _cmd.Parameters.AddWithValue("@Mobile", _obj.Mobile);
                _cmd.Parameters.AddWithValue("@Country", _obj.Country);
                _cmd.Parameters.AddWithValue("@updatedBy", _obj.updatedBy);
                _cmd.Parameters.AddWithValue("@IP", _obj.IP);
                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.CommandTimeout = 600;
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
                _cn.Close(); _cn.Dispose();
            }
        }
        #endregion
        public DataSet Opr_TestCentreRegitration_Admin(string Type = "")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("Opr_TestCentreRegitration_Admin", _cn);
                _cmd.Parameters.AddWithValue("@Type", Type);
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
