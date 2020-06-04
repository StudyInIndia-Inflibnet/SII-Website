using SIIModel.Institute;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SIIRepository.Institute
{
    public class InstituteRepository : Base
    {

        #region Login changepassword and forgot password
        public DataSet Login_Institute(InstituteMaster _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("sp_Select_InstituteMaster", _cn);
                _cmd.Parameters.AddWithValue("@InstituteID", _obj.InstituteID);
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
        public DataSet SP_SELECT_INSTITUTE_PARTICIPATION(string InstituteID = "")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("SP_SELECT_INSTITUTE_PARTICIPATION", _cn);
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
        public DataSet Institute_password_change(InstituteMaster _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("sp_institute_password_change", _cn);
                _cmd.Parameters.AddWithValue("@InstituteID", _obj.InstituteID);
                _cmd.Parameters.AddWithValue("@Password", _obj.Password);
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
        public DataSet StudentForgotPassword(InstituteMaster _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("UpdateForgotPassword", _cn);
                _cmd.Parameters.AddWithValue("@random", _obj.DefaultPassword);
                _cmd.Parameters.AddWithValue("@Email", _obj.Email);
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

        #region save update institute
        public DataSet Update_Institute_Details(InstituteMaster _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("sp_Update_Institute_Details", _cn);
                _cmd.Parameters.AddWithValue("@ID", _obj.ID);
                _cmd.Parameters.AddWithValue("@InstituteID", _obj.InstituteID);
                _cmd.Parameters.AddWithValue("@InstituteName", _obj.InstituteName);
                _cmd.Parameters.AddWithValue("@Address", _obj.Address);
                _cmd.Parameters.AddWithValue("@State", _obj.State);
                _cmd.Parameters.AddWithValue("@City", _obj.City);
                _cmd.Parameters.AddWithValue("@Pin", _obj.Pin);
                _cmd.Parameters.AddWithValue("@YOE", _obj.YOE);
                _cmd.Parameters.AddWithValue("@Description", _obj.Description);
                _cmd.Parameters.AddWithValue("@Email", _obj.Email);
                //_cmd.Parameters.AddWithValue("@History", _obj.History);
                //_cmd.Parameters.AddWithValue("@Awards", _obj.Awards);
                //_cmd.Parameters.AddWithValue("@Fellows", _obj.Fellows);
                //_cmd.Parameters.AddWithValue("@News", _obj.News);
                //_cmd.Parameters.AddWithValue("@Area", _obj.Area);
                //  _cmd.Parameters.AddWithValue("@ProgramOffered", _obj.ProgramOffered);
                _cmd.Parameters.AddWithValue("@AcademicCourses", _obj.AcademicCourses);
                _cmd.Parameters.AddWithValue("@AreaOfExcellence", _obj.AreaOfExcellence);
                _cmd.Parameters.AddWithValue("@ResearchCapability", _obj.ResearchCapability);
                // _cmd.Parameters.AddWithValue("@FacultyOverview", _obj.FacultyOverview);
                _cmd.Parameters.AddWithValue("@NotableResearchPublication", _obj.NotableResearchPublication);
                _cmd.Parameters.AddWithValue("@NIRFRanking", _obj.NIRFRanking);
                _cmd.Parameters.AddWithValue("@NBANAACAccreditation", _obj.NBANAACAccreditation);
                _cmd.Parameters.AddWithValue("@instituteweburl", _obj.instituteweburl);
                _cmd.Parameters.AddWithValue("@ModifiedIP", _obj.ModifiedIP);
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
                _obj = null;
                _cn.Close();
            }
        }
        public DataSet Search_Institute_By_Id(string ID)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("sp_Select_InstituteMaster", _cn);
                _cmd.Parameters.AddWithValue("@InstituteID", ID);
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

        #region Data Generation & Preamble
        public DataSet Select_All_Institutes()
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("sp_Select_All_Institutes", _cn);
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
        public DataSet Update_Institute_Data_For_MailSending(string ID, string InstituteID, string AccessURL, string DefaultPassword)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("sp_Update_Institutes_Link_And_InstituteID", _cn);
                _cmd.Parameters.AddWithValue("@ID", ID);
                _cmd.Parameters.AddWithValue("@InstituteID", InstituteID);
                _cmd.Parameters.AddWithValue("@AccessURL", AccessURL);
                _cmd.Parameters.AddWithValue("@DefaultPassword", DefaultPassword);
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
        public DataSet Select_Institute_By_InstituteID(string InstituteID)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("sp_Select_Institute_By_InstituteID", _cn);
                _cmd.Parameters.AddWithValue("@InstituteID", InstituteID);
                _cmd.Parameters.AddWithValue("@ParticipatedYear", ConfigurationManager.AppSettings["ParticipatedYear"].ToString());
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
        public DataSet Save_Preamble_Data(mNodalHeadOfficers _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("sp_Register_Nodal_Head_Officers", _cn);
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
                _cmd.Parameters.AddWithValue("@Password", _obj.Password);
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

        //#region Dashboard
        //public DataSet Get_Dashboard_Data(string InstituteID = "")
        //{
        //    try
        //    {
        //        _cn.Open();
        //        SqlCommand _cmd = new SqlCommand("sp_Select_Dashboard_Data", _cn);
        //        _cmd.Parameters.AddWithValue("@InstituteID", InstituteID);
        //        _cmd.CommandType = CommandType.StoredProcedure;
        //        SqlDataAdapter _adp = new SqlDataAdapter(_cmd);
        //        DataSet _ds = new DataSet();
        //        _adp.Fill(_ds);
        //        _adp.Dispose();
        //        _cmd.Dispose();
        //        return _ds;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        _cn.Close();
        //    }
        //}
        //#endregion

        //Replace code in InstituteRepository.cs in Repository

        #region Dashboard
        public DataSet Get_Dashboard_Data(string InstituteID = "", string ParticipatedYear = "")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("sp_Select_Dashboard_Data", _cn);
                _cmd.Parameters.AddWithValue("@InstituteID", InstituteID);
                _cmd.Parameters.AddWithValue("@ParticipatedYear", ParticipatedYear);
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

        public DataSet Get_Dashboard_Modal_Data(string InstituteID, string QueryFor, string GallaryCattegory = "", string ParticipatedYear = "", String NicheCoursesID = null)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("sp_Select_Dashboard_Modal_Data", _cn);
                _cmd.Parameters.AddWithValue("@InstituteID", InstituteID);
                _cmd.Parameters.AddWithValue("@QueryFor", QueryFor);
                _cmd.Parameters.AddWithValue("@ParticipatedYear", ParticipatedYear);
                _cmd.Parameters.AddWithValue("@NicheCoursesID", NicheCoursesID);
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

        public DataSet Get_Dashboard_Modal_Data(string InstituteID, string QueryFor, string GallaryCattegory = "")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("sp_Select_Dashboard_Modal_Data", _cn);
                _cmd.Parameters.AddWithValue("@InstituteID", InstituteID);
                _cmd.Parameters.AddWithValue("@QueryFor", QueryFor);
                _cmd.Parameters.AddWithValue("@GallaryCategoryID", GallaryCattegory);
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

        public DataSet InstituteForgotPassword(InstituteMaster _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("sp_Update_Institute_ForgotPassword", _cn);
                _cmd.Parameters.AddWithValue("@DefaultPassword", _obj.DefaultPassword);
                _cmd.Parameters.AddWithValue("@InstituteId", _obj.InstituteID);
                _cmd.Parameters.AddWithValue("@Email", _obj.Email);
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
        public DataSet Addmiited_Student_List(string ProgramLevel = "0", string type = "", string Control = "", string Discipline = "0", string StudentId = "", string For = "", string InstituteID = "", string choiceid = "", string SeatApprove = "", string SeatApproveReason = "", string IsRequireSkypeInterview = "", string SkypeInterviewRemarks = "", string IsSkypeInterviewComplete = "", string IsStudentAcceptSeat = "")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("Mockcounselling_Institute", _cn);
                _cmd.Parameters.AddWithValue("@ProgramLevel", ProgramLevel);
                _cmd.Parameters.AddWithValue("@Type", type);
                _cmd.Parameters.AddWithValue("@Control", Control);
                _cmd.Parameters.AddWithValue("@Discipline", Discipline);
                _cmd.Parameters.AddWithValue("@StudentId", StudentId);
                _cmd.Parameters.AddWithValue("@For", For);
                _cmd.Parameters.AddWithValue("@InstituteId", InstituteID);
                _cmd.Parameters.AddWithValue("@ChoiceID", choiceid);
                _cmd.Parameters.AddWithValue("@SeatApprove", SeatApprove);
                _cmd.Parameters.AddWithValue("@SeatApproveReason", SeatApproveReason);
                _cmd.Parameters.AddWithValue("@IsRequireSkypeInterview", IsRequireSkypeInterview);
                _cmd.Parameters.AddWithValue("@SkypeInterviewRemarks", SkypeInterviewRemarks);
                _cmd.Parameters.AddWithValue("@IsSkypeInterviewComplete", IsSkypeInterviewComplete);
                _cmd.Parameters.AddWithValue("@IsStudentAcceptSeat", IsStudentAcceptSeat);
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

        public DataSet Addmiited_Student_List_Second_Round(string ProgramLevel = "0", string type = "", string Control = "", string Discipline = "0", string StudentId = "", string For = "", string InstituteID = "", string choiceid = "", string SeatApprove = "", string SeatApproveReason = "", string IsRequireSkypeInterview = "", string SkypeInterviewRemarks = "", string IsSkypeInterviewComplete = "", string IsStudentAcceptSeat = "")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("Mockcounselling_Institute_Second", _cn);
                _cmd.Parameters.AddWithValue("@ProgramLevel", ProgramLevel);
                _cmd.Parameters.AddWithValue("@Type", type);
                _cmd.Parameters.AddWithValue("@Control", Control);
                _cmd.Parameters.AddWithValue("@Discipline", Discipline);
                _cmd.Parameters.AddWithValue("@StudentId", StudentId);
                _cmd.Parameters.AddWithValue("@For", For);
                _cmd.Parameters.AddWithValue("@InstituteId", InstituteID);
                _cmd.Parameters.AddWithValue("@ChoiceID", choiceid);
                _cmd.Parameters.AddWithValue("@SeatApprove", SeatApprove);
                _cmd.Parameters.AddWithValue("@SeatApproveReason", SeatApproveReason);
                _cmd.Parameters.AddWithValue("@IsRequireSkypeInterview", IsRequireSkypeInterview);
                _cmd.Parameters.AddWithValue("@SkypeInterviewRemarks", SkypeInterviewRemarks);
                _cmd.Parameters.AddWithValue("@IsSkypeInterviewComplete", IsSkypeInterviewComplete);
                _cmd.Parameters.AddWithValue("@IsStudentAcceptSeat", IsStudentAcceptSeat);
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
        public DataSet SELECT_INSTITUTE_SEARCH_NICHE_DROPDOWNS(string Type = "", string Discipline_ID = "0", string ProgramLevel_Id = "0", string Qualification_ID = "0")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("SELECT_INSTITUTE_SEARCH_NICHE_DROPDOWNS", _cn);
                _cmd.Parameters.AddWithValue("@Type", Type);
                _cmd.Parameters.AddWithValue("@Discipline_ID", Discipline_ID);
                _cmd.Parameters.AddWithValue("@ProgramLevel_Id", ProgramLevel_Id);
                _cmd.Parameters.AddWithValue("@Qualification_ID", Qualification_ID);
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

        #region Institute Search
        public DataSet SELECT_INSTITUTE_SEARCH_DROPDOWNS(string Type = "", string Discipline_ID = "0", string ProgramLevel_Id = "0", string Qualification_ID = "0")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("SELECT_INSTITUTE_SEARCH_DROPDOWNS", _cn);
                _cmd.Parameters.AddWithValue("@Type", Type);
                _cmd.Parameters.AddWithValue("@Discipline_ID", Discipline_ID);
                _cmd.Parameters.AddWithValue("@ProgramLevel_Id", ProgramLevel_Id);
                _cmd.Parameters.AddWithValue("@Qualification_ID", Qualification_ID);
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

        public DataSet SELECT_PHASE2_ALLOTED_STUDENTS_FOR_INSTITUTES(string InstituteID = "", string Type = "", string ProgramLevel = "", string StartIndex = "", string PageSize = "", string SearchByText = "")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("SELECT_PHASE2_ALLOTED_STUDENTS_FOR_INSTITUTES", _cn);
                _cmd.Parameters.AddWithValue("@InstituteID", InstituteID);
                _cmd.Parameters.AddWithValue("@Type", Type);
                _cmd.Parameters.AddWithValue("@ProgramLevel", ProgramLevel);
                _cmd.Parameters.AddWithValue("@StartIndex", StartIndex);
                _cmd.Parameters.AddWithValue("@PageSize", PageSize);
                _cmd.Parameters.AddWithValue("@SearchByText", SearchByText);
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
        public DataSet SKYPE_INTERVIEW_PHASE2_ALLOTED_STUDENTS(string ID = "", string InstituteID = "", string SkypeInterviewStatus = "", string SkypeInterviewDate = "")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("SKYPE_INTERVIEW_PHASE2_ALLOTED_STUDENTS", _cn);
                _cmd.Parameters.AddWithValue("@ID", ID);
                _cmd.Parameters.AddWithValue("@InstituteID", InstituteID);
                _cmd.Parameters.AddWithValue("@SkypeInterviewStatus", SkypeInterviewStatus);
                if (SkypeInterviewDate.Equals(""))
                {
                    _cmd.Parameters.AddWithValue("@SkypeInterviewDate", DBNull.Value);
                }
                else
                {
                    _cmd.Parameters.AddWithValue("@SkypeInterviewDate", DateTime.ParseExact(SkypeInterviewDate.ToString(), "dd-MM-yyyy", null));
                }
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
        public DataSet SKYPE_INTERVIEW_PHASE2_ALLOTED_STUDENTS_SELECT(string ID = "0")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("SKYPE_INTERVIEW_PHASE2_ALLOTED_STUDENTS_SELECT", _cn);
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
        public DataSet APPROVE_REJECT_PHASE2_ALLOTED_STUDENTS(string InstituteID = "", string StudentID = "", string CourseID = "", string Remarks = "", string AR = "0", string CMRID = "0")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("APPROVE_REJECT_PHASE2_ALLOTED_STUDENTS", _cn);
                _cmd.Parameters.AddWithValue("@InstituteID", InstituteID);
                _cmd.Parameters.AddWithValue("@StudentID", StudentID);
                _cmd.Parameters.AddWithValue("@CourseID", CourseID);
                _cmd.Parameters.AddWithValue("@Remarks", Remarks);
                _cmd.Parameters.AddWithValue("@AR", AR);
                _cmd.Parameters.AddWithValue("@CMRID", CMRID);
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

        public DataSet ALLOTMENT_UPLOAD_PHASE2_ALLOTED_STUDENTS(string ID = "", string InstituteID = "", string Doc_AllotmentLetter = "")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("ALLOTMENT_UPLOAD_PHASE2_ALLOTED_STUDENTS", _cn);
                _cmd.Parameters.AddWithValue("@ID", ID);
                _cmd.Parameters.AddWithValue("@InstituteID", InstituteID);
                _cmd.Parameters.AddWithValue("@Doc_AllotmentLetter", Doc_AllotmentLetter);
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
        
        public DataSet SP_PARTICIPATE_INSTITUTE(string InstituteID = "", string IP = "", string ParticipatedYear = "")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("SP_PARTICIPATE_INSTITUTE", _cn);
                _cmd.Parameters.AddWithValue("@InstituteID", InstituteID);
                _cmd.Parameters.AddWithValue("@IP", IP);
                _cmd.Parameters.AddWithValue("@ParticipatedYear", ParticipatedYear);
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
        
        public DataSet Select_tbl_Student_Ch_Choice_Filling_NicheCourse(string InstituteID = "")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("Select_tbl_Student_Ch_Choice_Filling_NicheCourse", _cn);
                _cmd.Parameters.AddWithValue("@InstituteID", InstituteID);
                _cmd.Parameters.AddWithValue("@ParticipatedYear", ConfigurationManager.AppSettings["ParticipatedYear"].ToString());
                _cmd.Parameters.AddWithValue("@Phase", ConfigurationManager.AppSettings["CurrentPhase"].ToString());
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
        public DataSet Opr_Select_First_Priority_StudentsList(string InstituteID = "", string RegistrationPhase = "", string ParticipatedYear = "")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("Opr_Select_First_Priority_StudentsList", _cn);
                _cmd.Parameters.AddWithValue("@InstituteID", InstituteID);
                _cmd.Parameters.AddWithValue("@RegistrationPhase", RegistrationPhase);
                _cmd.Parameters.AddWithValue("@ParticipatedYear", ParticipatedYear);
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
