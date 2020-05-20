using System.Data;
using System.Data.SqlClient;
using SIIModel.Courses;
using System;
using System.Diagnostics;
using System.Configuration;

namespace SIIRepository.Courses
{
    public class NICHE : Base
    {
        public DataSet Select_Niche(string Type = "", string Discipline_ID = "", string ProgramLevel_Id = "", string Qualification_ID = "")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("sp_select_niche", _cn);
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

        public DataSet sp_Select_tbl_InstituteCourse_Niche(string ID, string InstituteID, string ParticipatedYear = "")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("sp_Select_tbl_InstituteCourse_Niche", _cn);
                _cmd.Parameters.AddWithValue("@ID", ID);
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

        public DataSet Delete_tbl_InstituteCourse_Niche(NicheCourse nicheCourse)
        {

            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("sp_Delete_tbl_InstituteCourse_Niche", _cn);
                _cmd.Parameters.AddWithValue("@ID", nicheCourse.ID);
                _cmd.Parameters.AddWithValue("@InstituteID", nicheCourse.InstituteID);
                _cmd.Parameters.AddWithValue("@ParticipatedYear", nicheCourse.ParticipatedYear);
                //Debug.Print(string.Format("sp_Delete_tbl_InstituteCourse_Niche @ID={0}, @InstituteID={1}", nicheCourse.ID, nicheCourse.InstituteID));
                _cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter _adp = new SqlDataAdapter(_cmd);
                DataSet _ds = new DataSet();
                _adp.Fill(_ds); 
                _adp.Dispose();
                _cmd.Dispose();
                return _ds;  
            }
            finally
            {
                _cn.Close();
            }
        }

        public DataSet sp_Insert_Update_tbl_InstituteCourse_Niche(NicheCourse _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("sp_Insert_Update_tbl_InstituteCourse_Niche", _cn);
                _cmd.Parameters.AddWithValue("@ID", _obj.ID);
                _cmd.Parameters.AddWithValue("@InstituteID", _obj.InstituteID);
                _cmd.Parameters.AddWithValue("@Discipline_ID", _obj.Discipline_ID);
                _cmd.Parameters.AddWithValue("@Natureofcourse_Id", _obj.Natureofcourse_Id);
                _cmd.Parameters.AddWithValue("@ProgramLevel_Id", _obj.ProgramLevel_Id);
                _cmd.Parameters.AddWithValue("@Branch_Id", _obj.Branch_Id);
                _cmd.Parameters.AddWithValue("@CourseType", _obj.CourseType);
                _cmd.Parameters.AddWithValue("@GenderRestrictions", _obj.GenderRestrictions);
                _cmd.Parameters.AddWithValue("@MinimumAgeRequirement", _obj.MinimumAgeRequirement);

                _cmd.Parameters.AddWithValue("@NoEligibilitycriteria", _obj.NoEligibilitycriteria);
                _cmd.Parameters.AddWithValue("@EligibilityCriteria", _obj.EligibilityCriteria);
                _cmd.Parameters.AddWithValue("@AditionalExamsCriteria", _obj.AditionalExamsCriteria);
                _cmd.Parameters.AddWithValue("@AdditionalFacilities", _obj.AdditionalFacilities);
                _cmd.Parameters.AddWithValue("@TutionFeesCurrency", _obj.TutionFeesCurrency);
                _cmd.Parameters.AddWithValue("@TutionFees", _obj.TutionFees);
                _cmd.Parameters.AddWithValue("@TotalFeesCurrency", _obj.TotalFeesCurrency);
                _cmd.Parameters.AddWithValue("@TotalFees", _obj.TotalFees);
                _cmd.Parameters.AddWithValue("@TutionFeesForSAARCCountryCurrency", _obj.TutionFeesForSAARCCountryCurrency);
                _cmd.Parameters.AddWithValue("@TutionFeesForSAARCCountry", _obj.TutionFeesForSAARCCountry);
                _cmd.Parameters.AddWithValue("@TutionFeesForNonSAARCCountryCurrency", _obj.TutionFeesForNonSAARCCountryCurrency);
                _cmd.Parameters.AddWithValue("@TutionFeesForNonSAARCCountry", _obj.TutionFeesForNonSAARCCountry);
                _cmd.Parameters.AddWithValue("@Credits", _obj.Credits);
                _cmd.Parameters.AddWithValue("@CourseDurations", _obj.CourseDurations);
                _cmd.Parameters.AddWithValue("@ClassRoomHours", _obj.ClassRoomHours);
                _cmd.Parameters.AddWithValue("@CoursePatterns", _obj.CoursePatterns);
                if (_obj.StartDate == null || _obj.StartDate.Equals(""))
                {
                    _cmd.Parameters.AddWithValue("@StartDate", DBNull.Value);
                }
                else
                {
                    _cmd.Parameters.AddWithValue("@StartDate", DateTime.ParseExact(_obj.StartDate.ToString(), "dd-MM-yyyy", null));
                }
                if (_obj.EndDate == null || _obj.EndDate.Equals(""))
                {
                    _cmd.Parameters.AddWithValue("@EndDate", DBNull.Value);
                }
                else
                {
                    _cmd.Parameters.AddWithValue("@EndDate", DateTime.ParseExact(_obj.EndDate.ToString(), "dd-MM-yyyy", null));
                }
                _cmd.Parameters.AddWithValue("@tobedecided", _obj.tobedecided == "on" ? 1 : 0);
                _cmd.Parameters.AddWithValue("@CourseDesc", _obj.CourseDesc);
                _cmd.Parameters.AddWithValue("@AdmissionReq", _obj.AdmissionReq);
                _cmd.Parameters.AddWithValue("@MinimumBatchSize", _obj.MinimumBatchSize);
                _cmd.Parameters.AddWithValue("@CreatedIP", _obj.CreatedIP);
                _cmd.Parameters.AddWithValue("@CreatedBy", _obj.CreatedBy);
                _cmd.Parameters.AddWithValue("@EduQualifications", _obj.EduQualifications);
                _cmd.Parameters.AddWithValue("@AdditionalExams", _obj.AdditionalExams);
                _cmd.Parameters.AddWithValue("@InternationalBatchSize", _obj.InternationalBatchSize);
                _cmd.Parameters.AddWithValue("@CourseDurationsType", _obj.CourseDurationsType);
                _cmd.Parameters.AddWithValue("@MedicalFitness", _obj.MedicalFitness);
                _cmd.Parameters.AddWithValue("@MandatoryMedicalExamination", _obj.MandatoryMedicalExamination);
                _cmd.Parameters.AddWithValue("@MedicalFitnessDocuments", _obj.MedicalFitnessDocuments);
                _cmd.Parameters.AddWithValue("@MedicalFitnessDocumentsOther", _obj.MedicalFitnessDocumentsOther);

                _cmd.Parameters.AddWithValue("@HostelAccommodation", _obj.HostelAccommodation);
                _cmd.Parameters.AddWithValue("@Food", _obj.Food);
                _cmd.Parameters.AddWithValue("@AC", _obj.AC);
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
        public DataSet sp_Select_tbl_InstituteCourse_Niche_Search(string ID = "", 
            string Discipline_ID = "", string ProgramLevel_Id = "", 
            string Qualification_ID = "", string Type = "", string CourseOfStudy_ID="", string InstituteType="", string InstituteID="" 
            ,string GenderRestrictions=""  , string Month_id = "", string Year_id = "")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("Select_tbl_InstituteCourse_NicheSearch", _cn);
                _cmd.Parameters.AddWithValue("@ID", ID);
                _cmd.Parameters.AddWithValue("@Type", Type);
                _cmd.Parameters.AddWithValue("@Discipline_ID", Discipline_ID);
                _cmd.Parameters.AddWithValue("@Qualification_ID", Qualification_ID);
                _cmd.Parameters.AddWithValue("@CourseOfStudy_ID", CourseOfStudy_ID);

                _cmd.Parameters.AddWithValue("@ProgramLevel_Id", ProgramLevel_Id);

                _cmd.Parameters.AddWithValue("@InstituteType", InstituteType);
                _cmd.Parameters.AddWithValue("@InstituteID", InstituteID);

                _cmd.Parameters.AddWithValue("@Month_id", Month_id);
                _cmd.Parameters.AddWithValue("@Year_id", Year_id);

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
    }
}
