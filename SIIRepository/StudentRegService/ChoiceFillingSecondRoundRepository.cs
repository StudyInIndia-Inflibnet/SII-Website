using SIIModel.StudentRegister;
using System;
using System.Data;
using System.Data.SqlClient;

namespace SIIRepository.StudentRegService
{
    public class ChoiceFillingSecondRoundRepository : Base
    {


        #region document Infomation
        public DataSet Select_InstituteList(ChoiceFillingSecondRound _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("Student_Choice_Filling_new_2Round", _cn);
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
        public DataSet Insert_InstituteList(ChoiceFillingSecondRound _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("Student_Choice_Filling_Insert_2Round", _cn);
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
        public DataSet Insert_InstituteList_New(ChoiceFillingSecondRound _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("Student_Choice_Filling_Insert_New_2Round", _cn);
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
                SqlCommand _cmd = new SqlCommand("delete_StudentChoiceFilling_2Round", _cn);
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
        public DataSet UpdateSequenceNumber_swap_move(ChoiceFillingSecondRound _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("update_SequenceNumber_swap_move_2Round", _cn);
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
                SqlCommand _cmd = new SqlCommand("update_StudentChoiceFilling_2Round", _cn);
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
        public DataSet student_submit_choice_filling(ChoiceFillingSecondRound _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("student_submit_choice_filling_2Round", _cn);
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

    }
}