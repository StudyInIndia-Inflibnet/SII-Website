using SIIModel.Courses;
using System;
using System.Data;
using System.Data.SqlClient;

namespace SIIRepository.Courses
{
    public class CourseRepository : Base
    {
        public DataSet InsertUpdateCourse(Course _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("sp_Insert_Update_tbl_InstituteCourse", _cn);
                _cmd.Parameters.AddWithValue("@ID", _obj.ID);
                _cmd.Parameters.AddWithValue("@InstituteID", _obj.InstituteID);
                _cmd.Parameters.AddWithValue("@Discipline_ID", _obj.Discipline_ID);
                _cmd.Parameters.AddWithValue("@Natureofcourse_Id", _obj.Natureofcourse_Id);
                _cmd.Parameters.AddWithValue("@ProgramLevel_Id", _obj.ProgramLevel_Id);

                if (_obj.Branch_Id != null)
                {
                    if (_obj.Branch_Id.ToString() != "AddBranch")
                    {
                        _cmd.Parameters.AddWithValue("@Branch_Id", _obj.Branch_Id);
                    }
                    else
                    {
                        _cmd.Parameters.AddWithValue("@Branch_Id", "0");
                    }
                }
                else
                {
                    _cmd.Parameters.AddWithValue("@Branch_Id", "0");
                }


                _cmd.Parameters.AddWithValue("@EligibilityCriteria", _obj.EligibilityCriteria);
                _cmd.Parameters.AddWithValue("@SeatForForeignStudent", _obj.SeatForForeignStudent);
                _cmd.Parameters.AddWithValue("@AnnualTutionFees", _obj.AnnualTutionFees);
                _cmd.Parameters.AddWithValue("@AnnualBoardingFees", _obj.AnnualBoardingFees);
                _cmd.Parameters.AddWithValue("@AnnualTutionFeesCurrency", _obj.AnnualTutionFeesCurrency);
                _cmd.Parameters.AddWithValue("@AnnualBoardingFeesCurrency", _obj.AnnualBoardingFeesCurrency);
                _cmd.Parameters.AddWithValue("@G1SeatWaiver", _obj.G1SeatWaiver);
                _cmd.Parameters.AddWithValue("@G2SeatWaiver", _obj.G2SeatWaiver);
                _cmd.Parameters.AddWithValue("@G3SeatWaiver", _obj.G3SeatWaiver);
                _cmd.Parameters.AddWithValue("@G4SeatWaiver", _obj.G4SeatWaiver);
                _cmd.Parameters.AddWithValue("@Credits", _obj.Credits);
                _cmd.Parameters.AddWithValue("@CourseDurations", _obj.CourseDurations);
                _cmd.Parameters.AddWithValue("@ClassRoomHours", _obj.ClassRoomHours);
                _cmd.Parameters.AddWithValue("@CoursePatterns", _obj.CoursePatterns);
                _cmd.Parameters.AddWithValue("@CourseDesc", _obj.CourseDesc);
                _cmd.Parameters.AddWithValue("@AdmissionReq", _obj.AdmissionReq);
                _cmd.Parameters.AddWithValue("@CreatedBy", _obj.CreatedBy);
                _cmd.Parameters.AddWithValue("@CreatedIP", _obj.CreatedIP);
                _cmd.Parameters.AddWithValue("@FeesForNonSAARCCountry", _obj.FeesForNonSAARCCountry);
                _cmd.Parameters.AddWithValue("@FeesForSAARCCountry", _obj.FeesForSAARCCountry);
                _cmd.Parameters.AddWithValue("@FeesForNonSAARCCountryCurrency", _obj.FeesForNonSAARCCountryCurrency);
                _cmd.Parameters.AddWithValue("@FeesForSAARCCountryCurrency", _obj.FeesForSAARCCountryCurrency);
                _cmd.Parameters.AddWithValue("@Branch_Name", _obj.Branch_Name);
                _cmd.Parameters.AddWithValue("@Edited_by", _obj.Edited_by);
                _cmd.Parameters.AddWithValue("@Q0Req", _obj.Q0Req);
                _cmd.Parameters.AddWithValue("@Q1Req", _obj.Q1Req);
                _cmd.Parameters.AddWithValue("@Q2Req", _obj.Q2Req);
                _cmd.Parameters.AddWithValue("@Q3Req", _obj.Q3Req);
                _cmd.Parameters.AddWithValue("@Q0Qualification", _obj.Q0Qualification);
                _cmd.Parameters.AddWithValue("@Q0Subject", _obj.Q0Subject);
                _cmd.Parameters.AddWithValue("@Q0Percentage", _obj.Q0Percentage);
                _cmd.Parameters.AddWithValue("@Q1Qualification", _obj.Q1Qualification);
                _cmd.Parameters.AddWithValue("@Q1Subject", _obj.Q1Subject);
                _cmd.Parameters.AddWithValue("@Q1Percentage", _obj.Q1Percentage);
                _cmd.Parameters.AddWithValue("@Q2Qualification", _obj.Q2Qualification);
                _cmd.Parameters.AddWithValue("@Q2Subject", _obj.Q2Subject);
                _cmd.Parameters.AddWithValue("@Q2Percentage", _obj.Q2Percentage);
                _cmd.Parameters.AddWithValue("@Q3Qualification", _obj.Q3Qualification);
                _cmd.Parameters.AddWithValue("@Q3Subject", _obj.Q3Subject);
                _cmd.Parameters.AddWithValue("@Q3Percentage", _obj.Q3Percentage);
                _cmd.Parameters.AddWithValue("@JEEMainReq", _obj.JEEMainReq);
                _cmd.Parameters.AddWithValue("@JEEMainscoreReq", _obj.JEEMainscoreReq);
                _cmd.Parameters.AddWithValue("@JEEAdvanceReq", _obj.JEEAdvanceReq);
                _cmd.Parameters.AddWithValue("@JEEAdvanceScoreReq", _obj.JEEAdvanceScoreReq);
                _cmd.Parameters.AddWithValue("@IELTSReq", _obj.IELTSReq);
                _cmd.Parameters.AddWithValue("@IELTSscoreReq", _obj.IELTSscoreReq);
                _cmd.Parameters.AddWithValue("@GMATReq", _obj.GMATReq);
                _cmd.Parameters.AddWithValue("@GMATScoreReq", _obj.GMATScoreReq);
                _cmd.Parameters.AddWithValue("@TOFELReq", _obj.TOFELReq);
                _cmd.Parameters.AddWithValue("@TOFELScoreReq", _obj.TOFELScoreReq);
                _cmd.Parameters.AddWithValue("@SATReq", _obj.SATReq);
                _cmd.Parameters.AddWithValue("@SATScoreReq", _obj.SATScoreReq);
                _cmd.Parameters.AddWithValue("@GATEReq", _obj.GATEReq);
                _cmd.Parameters.AddWithValue("@GATEScoreReq", _obj.GATEScoreReq);
                _cmd.Parameters.AddWithValue("@EduQualifications", _obj.EduQualifications);
                _cmd.Parameters.AddWithValue("@AdditionalExams", _obj.AdditionalExams);
                _cmd.Parameters.AddWithValue("@ParticipatedYear", _obj.ParticipatedYear);
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
        public DataSet Select_InstituteCourse(Course _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("sp_Select_tbl_InstituteCourse", _cn);
                _cmd.Parameters.AddWithValue("@ID", _obj.ID);
                _cmd.Parameters.AddWithValue("@InstituteID", _obj.InstituteID);
                _cmd.Parameters.AddWithValue("@ParticipatedYear", _obj.ParticipatedYear);
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
        public DataSet Delete_InstituteCourse(Course _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("sp_Delete_tbl_InstituteCourse", _cn);
                _cmd.Parameters.AddWithValue("@ID", _obj.ID);
                _cmd.Parameters.AddWithValue("@InstituteID", _obj.InstituteID);
                _cmd.Parameters.AddWithValue("@ParticipatedYear", _obj.ParticipatedYear);
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

        public DataSet SELECT_tbl_EduQualifications()
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("SELECT_tbl_EduQualifications", _cn);
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
        public DataSet SELECT_tbl_AditionalExams()
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("SELECT_tbl_AditionalExams", _cn);
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
        public DataSet SELECT_tbl_EduSubject(string EduQualifications_Id = "")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("SELECT_tbl_EduSubject", _cn);
                _cmd.Parameters.AddWithValue("@EduQualifications_Id", EduQualifications_Id);
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
        public DataSet SELECT_tbl_AditionalExamScore(string AditionalExams_Id = "")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("SELECT_tbl_AditionalExamScore", _cn);
                _cmd.Parameters.AddWithValue("@AditionalExams_Id", AditionalExams_Id);
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
