using SIIModel.StudentRegister;
using System;
using System.Data;
using System.Data.SqlClient;

namespace SIIRepository.StudentRegService
{
    public class MockResultRepository : Base
    {
        public DataSet Select_InstituteList(Mockcounselling _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("Mockcounselling_Student", _cn);
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

        public DataSet Select_InstituteList_Second(Mockcounselling _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("Mockcounselling_Student_Second", _cn);
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

        public DataSet SELECT_STUDENT_SEAT_RESULT_PHASE2(string StudentID = "")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("SELECT_STUDENT_SEAT_RESULT_PHASE2", _cn);
                _cmd.Parameters.AddWithValue("@StudentID", StudentID);
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
        public DataSet ACCEPT_PHASE2_BY_STUDENTS(string InstituteID = "", string StudentID = "", string CourseID = "", string Remarks = "")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("ACCEPT_PHASE2_BY_STUDENTS", _cn);
                _cmd.Parameters.AddWithValue("@InstituteID", InstituteID);
                _cmd.Parameters.AddWithValue("@StudentID", StudentID);
                _cmd.Parameters.AddWithValue("@CourseID", CourseID);
                _cmd.Parameters.AddWithValue("@Remarks", Remarks);
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
        public DataSet REJECT_PHASE2_BY_STUDENTS(string InstituteID = "", string StudentID = "", string CourseID = "", string Remarks = "")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("REJECT_PHASE2_BY_STUDENTS", _cn);
                _cmd.Parameters.AddWithValue("@InstituteID", InstituteID);
                _cmd.Parameters.AddWithValue("@StudentID", StudentID);
                _cmd.Parameters.AddWithValue("@CourseID", CourseID);
                _cmd.Parameters.AddWithValue("@Remarks", Remarks);
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