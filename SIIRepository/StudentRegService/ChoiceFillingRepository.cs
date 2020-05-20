using SIIModel.StudentRegister;
using System;
using System.Data;
using System.Data.SqlClient;

namespace SIIRepository.StudentRegService
{
    public class ChoiceFillingRepository : Base
    {
        #region document Infomation
        public DataSet Select_InstituteList(ChoiceFilling _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("Student_Choice_Filling_new", _cn);
                _cmd.Parameters.AddWithValue("@Created_By", _obj.studentid);
                _cmd.Parameters.AddWithValue("@Type", _obj.Type);
                _cmd.Parameters.AddWithValue("@Control", _obj.Control);
                _cmd.Parameters.AddWithValue("@Discipline_ID", _obj.Discipline_ID);
                _cmd.Parameters.AddWithValue("@ProgramLevel_Id", _obj.ProgramLevel_Id);
                _cmd.Parameters.AddWithValue("@Natureofcourse_Id", _obj.Natureofcourse_Id);
                _cmd.Parameters.AddWithValue("@InstituteID", _obj.InstituteID);
                _cmd.Parameters.AddWithValue("@Branch_Id", _obj.Branch_Id);
                _cmd.Parameters.AddWithValue("@studentid", _obj.studentid);
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
        public DataSet Insert_InstituteList(ChoiceFilling _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("Student_Choice_Filling_Insert", _cn);
                _cmd.Parameters.AddWithValue("@Created_By", _obj.studentid);
                _cmd.Parameters.AddWithValue("@Type", _obj.Type);
                _cmd.Parameters.AddWithValue("@Control", _obj.Control);
                _cmd.Parameters.AddWithValue("@Discipline_ID", _obj.Discipline_ID);
                _cmd.Parameters.AddWithValue("@ProgramLevel_Id", _obj.ProgramLevel_Id);
                _cmd.Parameters.AddWithValue("@Natureofcourse_Id", _obj.Natureofcourse_Id);
                _cmd.Parameters.AddWithValue("@InstituteID", _obj.InstituteID);
                _cmd.Parameters.AddWithValue("@Branch_Id", _obj.Branch_Id);
                _cmd.Parameters.AddWithValue("@Institute_List_JSON", _obj.Institute_List_JSON);
                _cmd.Parameters.AddWithValue("@StudentId", _obj.studentid);
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
        public DataSet Insert_InstituteList_New(ChoiceFilling _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("Student_Choice_Filling_Insert_New", _cn);
                _cmd.Parameters.AddWithValue("@Student_ID", _obj.studentid);
                _cmd.Parameters.AddWithValue("@InstituteCourse_ID", _obj.InstituteCourse_ID);
                _cmd.Parameters.AddWithValue("@CreatedBy", _obj.CreatedBy);
                _cmd.Parameters.AddWithValue("@CreatedIp", _obj.CreatedIp);
                _cmd.Parameters.AddWithValue("@SeatWaivertype", _obj.SeatWaivertype);
                _cmd.Parameters.AddWithValue("@Type", _obj.Type);
                _cmd.Parameters.AddWithValue("@Control", _obj.Control);
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
        public DataSet Delete_InstituteList(string ID = "", string Student_id = "")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("delete_StudentChoiceFilling", _cn);
                _cmd.Parameters.AddWithValue("@ID", ID);
                _cmd.Parameters.AddWithValue("@Student_id", Student_id);
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
        public DataSet UpdateSequenceNumber_swap_move(ChoiceFilling _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("update_SequenceNumber_swap_move", _cn);
                _cmd.Parameters.AddWithValue("@Created_By", _obj.studentid);
                _cmd.Parameters.AddWithValue("@Type", _obj.Type);
                _cmd.Parameters.AddWithValue("@drpformid", _obj.drpformid);
                _cmd.Parameters.AddWithValue("@drptoid", _obj.drptoid);
                _cmd.Parameters.AddWithValue("@Created_Ip", _obj.CreatedIp);
                _cmd.Parameters.AddWithValue("@studentid", _obj.studentid);
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

        public DataSet update_StudentChoiceFilling(string ID = "", string Student_id = "")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("update_StudentChoiceFilling", _cn);
                _cmd.Parameters.AddWithValue("@ID", ID);
                _cmd.Parameters.AddWithValue("@Student_id", Student_id);
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

        #region submit student choice filling
        public DataSet Opr_Upload_Student_Image(Student_Register _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("Opr_Upload_Student_Image", _cn);
                _cmd.Parameters.AddWithValue("@studentid", _obj.studentid);
                _cmd.Parameters.AddWithValue("@Photo", _obj.Photo);
                _cmd.Parameters.AddWithValue("@Signature", _obj.Signature);
                _cmd.Parameters.AddWithValue("@Type", _obj.Type);
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
        public DataSet student_submit_choice_filling(ChoiceFilling _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("student_submit_choice_filling", _cn);
                _cmd.Parameters.AddWithValue("@student_id", _obj.studentid);
                _cmd.Parameters.AddWithValue("@ip", _obj.CreatedIp);
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

        #region New Choice Filling Student_Ch

        #region Basic
        public DataSet INSERT_UPDATE_tbl_Student_Ch_Basic(mStudent_Ch_Basic _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("INSERT_UPDATE_tbl_Student_Ch_Basic", _cn);
                _cmd.Parameters.AddWithValue("@studentid", _obj.studentid);
                _cmd.Parameters.AddWithValue("@ApplicationNo", _obj.ApplicationNo);
                _cmd.Parameters.AddWithValue("@EduQualifications", _obj.EduQualifications);
                _cmd.Parameters.AddWithValue("@AdditionalExams", _obj.AdditionalExams);
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
        public DataSet CHECK_tbl_Student_Ch_Basic(mStudent_Ch_Basic _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("CHECK_tbl_Student_Ch_Basic", _cn);
                _cmd.Parameters.AddWithValue("@studentid", _obj.studentid);
                _cmd.Parameters.AddWithValue("@ApplicationNo", _obj.ApplicationNo);
                _cmd.Parameters.AddWithValue("@EduQualifications", _obj.EduQualifications);
                _cmd.Parameters.AddWithValue("@AdditionalExams", _obj.AdditionalExams);
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
        public DataSet RESET_tbl_Student_Ch_Choice_Filling(mStudent_Ch_Basic _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("RESET_tbl_Student_Ch_Choice_Filling", _cn);
                _cmd.Parameters.AddWithValue("@studentid", _obj.studentid);
                _cmd.Parameters.AddWithValue("@ApplicationNo", _obj.ApplicationNo);
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
        public DataSet SELECT_tbl_Student_Ch_Basic(string studentid = "0")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("SELECT_tbl_Student_Ch_Basic", _cn);
                _cmd.Parameters.AddWithValue("@studentid", studentid);
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
        public DataSet SELECT_tbl_AditionalExams_For_Ch()
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("SELECT_tbl_AditionalExams_For_Ch", _cn);
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

        #region Select Disciplines
        public DataSet INSERT_UPDATE_tbl_Student_Ch_SelectDiscipline(mStudent_Ch_Basic _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("INSERT_UPDATE_tbl_Student_Ch_SelectDiscipline", _cn);
                _cmd.Parameters.AddWithValue("@studentid", _obj.studentid);
                _cmd.Parameters.AddWithValue("@ApplicationNo", _obj.ApplicationNo);
                _cmd.Parameters.AddWithValue("@SelectedDisciplines", _obj.SelectedDisciplines);
                _cmd.Parameters.AddWithValue("@ModifiedIP", _obj.CreatedIP);
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
        public DataSet INSERT_UPDATE_tbl_Student_Ch_SelectProgramLevel(mStudent_Ch_Basic _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("INSERT_UPDATE_tbl_Student_Ch_SelectProgramLevel", _cn);
                _cmd.Parameters.AddWithValue("@studentid", _obj.studentid);
                _cmd.Parameters.AddWithValue("@ApplicationNo", _obj.ApplicationNo);
                _cmd.Parameters.AddWithValue("@SelectedProgramLevel", _obj.SelectedProgramLevel);
                _cmd.Parameters.AddWithValue("@ModifiedIP", _obj.CreatedIP);
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
        public DataSet SELECT_tbl_Student_Ch_SelecedDiscipline(string studentid = "0", string ApplicationNo = "0")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("SELECT_tbl_Student_Ch_SelecedDiscipline", _cn);
                _cmd.Parameters.AddWithValue("@studentid", studentid);
                _cmd.Parameters.AddWithValue("@ApplicationNo", ApplicationNo);
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
        public DataSet SELECT_PROGRAMELEVEL_FROM_DISCIPLINE_FOR_CH(string studentid = "", string ApplicationNo = "", string Discipline_ID = "0",  string type = "")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("SELECT_PROGRAMELEVEL_FROM_DISCIPLINE_FOR_CH", _cn);
                _cmd.Parameters.AddWithValue("@studentid", studentid);
                _cmd.Parameters.AddWithValue("@Discipline_ID", Discipline_ID);
                _cmd.Parameters.AddWithValue("@ApplicationNo", ApplicationNo);
                _cmd.Parameters.AddWithValue("@type", type);
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

        #region Choice Filling 
        public DataSet SELECT_tbl_Student_Ch_Select_Disciplines(string studentid = "0", string ApplicationNo = "0")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("SELECT_tbl_Student_Ch_Select_Disciplines", _cn);
                _cmd.Parameters.AddWithValue("@studentid", studentid);
                _cmd.Parameters.AddWithValue("@ApplicationNo", ApplicationNo);
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

        #region Choice Filling New - Sachin
        public DataSet Student_Ch_Choice_Filling_From(mStudent_ch_choiceFilling obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("Student_Ch_Choice_Filling_From", _cn);
                _cmd.Parameters.AddWithValue("@Discipline", obj.Discipline);
                _cmd.Parameters.AddWithValue("@ProgramLevel", obj.ProgramLevel);
                _cmd.Parameters.AddWithValue("@NameofCourse", obj.NameofCourse);
                _cmd.Parameters.AddWithValue("@Specialization", obj.Specialization);
                _cmd.Parameters.AddWithValue("@InstituteID", obj.InstituteID);
                _cmd.Parameters.AddWithValue("@studentID", obj.studentID);
                _cmd.Parameters.AddWithValue("@id", obj.id);
                _cmd.Parameters.AddWithValue("@Type", obj.Type);
                _cmd.Parameters.AddWithValue("@Control", obj.Control);
                _cmd.Parameters.AddWithValue("@ip", obj.ip);
                _cmd.CommandTimeout = 600;
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

        public DataSet INSERT_UPDATE_tbl_Student_Ch_Choice_Filling(mStudent_Ch_Choice_Filling_Save _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("INSERT_UPDATE_tbl_Student_Ch_Choice_Filling", _cn);
                _cmd.Parameters.AddWithValue("@studentid", _obj.studentid);
                _cmd.Parameters.AddWithValue("@ApplicationNo", _obj.ApplicationNo);
                _cmd.Parameters.AddWithValue("@InstituteID", _obj.InstituteID);
                _cmd.Parameters.AddWithValue("@InstituteCourse_ID", _obj.InstituteCourse_ID);
                _cmd.Parameters.AddWithValue("@Discipline_Id", _obj.Discipline_Id);
                _cmd.Parameters.AddWithValue("@ProgramLevel_Id", _obj.ProgramLevel_Id);
                _cmd.Parameters.AddWithValue("@NatureOfCourse_Id", _obj.NatureOfCourse_Id);
                _cmd.Parameters.AddWithValue("@Branch_Course_Id", _obj.Branch_Course_Id);
                _cmd.Parameters.AddWithValue("@Stud_Ch_EC", _obj.Stud_Ch_EC);
                _cmd.Parameters.AddWithValue("@Stud_Ch_AE", _obj.Stud_Ch_AE);
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
        public DataSet SELECT_tbl_Student_Ch_Choice_Filling(mStudent_Ch_Choice_Filling_Save _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("SELECT_tbl_Student_Ch_Choice_Filling", _cn);
                _cmd.Parameters.AddWithValue("@studentid", _obj.studentid);
                _cmd.Parameters.AddWithValue("@ApplicationNo", _obj.ApplicationNo);
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
        public DataSet DELETE_tbl_Student_Ch_Choice_Filling(string ID = "0", string ApplicationNo  = "", string studentid = "")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("DELETE_tbl_Student_Ch_Choice_Filling", _cn);
                _cmd.Parameters.AddWithValue("@ID", ID);
                _cmd.Parameters.AddWithValue("@ApplicationNo", ApplicationNo);
                _cmd.Parameters.AddWithValue("@studentid", studentid);
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
        public DataSet SWAP_tbl_Student_Ch_Choice_Filling(mStudent_Ch_Choice_Filling_Swap _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("SWAP_tbl_Student_Ch_Choice_Filling", _cn);
                _cmd.Parameters.AddWithValue("@Created_By", _obj.studentid);
                _cmd.Parameters.AddWithValue("@Type", _obj.Type);
                _cmd.Parameters.AddWithValue("@drpformid", _obj.drpformid);
                _cmd.Parameters.AddWithValue("@drptoid", _obj.drptoid);
                _cmd.Parameters.AddWithValue("@Created_Ip", _obj.CreatedIp);
                _cmd.Parameters.AddWithValue("@studentid", _obj.studentid);
                _cmd.Parameters.AddWithValue("@ApplicationNo", _obj.ApplicationNo);
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

        #region Upload 
        public DataSet SELECT_tbl_Student_Ch_Doc_Upload(string ApplicationNo = "", string studentid = "")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("SELECT_tbl_Student_Ch_Doc_Upload", _cn);
                _cmd.Parameters.AddWithValue("@ApplicationNo", ApplicationNo);
                _cmd.Parameters.AddWithValue("@studentid", studentid);
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
        public DataSet INSERT_UPDATE_tbl_Student_Ch_Doc_Upload(string ApplicationNo = "", string studentid = "", string Docs="",string CreatedIP="")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("INSERT_UPDATE_tbl_Student_Ch_Doc_Upload", _cn);
                _cmd.Parameters.AddWithValue("@ApplicationNo", ApplicationNo);
                _cmd.Parameters.AddWithValue("@studentid", studentid);
                _cmd.Parameters.AddWithValue("@Docs", Docs);
                _cmd.Parameters.AddWithValue("@CreatedIP", CreatedIP);
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

        #region Submit
        public DataSet Submit_Student_Ch(string studentid = "", string CreatedIP = "")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("Submit_Student_Ch", _cn);
                //_cmd.Parameters.AddWithValue("@ApplicationNo", ApplicationNo);
                _cmd.Parameters.AddWithValue("@studentid", studentid);
                _cmd.Parameters.AddWithValue("@CreatedIP", CreatedIP);
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
        public DataSet SELECT_Student_Ch_Report(string studentid = "")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("SELECT_Student_Ch_Report", _cn);
                _cmd.Parameters.AddWithValue("@studentid", studentid);
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

        #endregion
        public DataSet Opr_TestCentreRegitration(TestCentreRegitration _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("Opr_TestCentreRegitration", _cn);
                _cmd.Parameters.AddWithValue("@studentid", _obj.studentid);
                _cmd.Parameters.AddWithValue("@Type", _obj.Type);
                _cmd.Parameters.AddWithValue("@FatherName", _obj.FatherName);
                _cmd.Parameters.AddWithValue("@TestCountry", _obj.TestCountry);
                _cmd.Parameters.AddWithValue("@TestCity", _obj.TestCity);
                _cmd.Parameters.AddWithValue("@CreatedIP", _obj.CreatedIP);
                _cmd.Parameters.AddWithValue("@Country", _obj.Country);
                _cmd.Parameters.AddWithValue("@ApplyingForCourse", _obj.ApplyingForCourse);
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

        public DataSet Opr_DocumentUpload(string Type= "", string studentid="", string ID = "", string Path = "")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("Opr_DocumentUpload", _cn);
                _cmd.Parameters.AddWithValue("@studentid", studentid);
                _cmd.Parameters.AddWithValue("@Type", Type);
                _cmd.Parameters.AddWithValue("@ID", ID);
                _cmd.Parameters.AddWithValue("@Path", Path);
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