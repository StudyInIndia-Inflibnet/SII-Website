using SIIModel.StudentRegister;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SIIRepository.StudentRegService
{
    public class StudentRepository : Base
    {

        #region Student Profile
        public DataSet InsertStudentRegistration(Student_Register _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("InsertStudentRegistration", _cn);
                _cmd.Parameters.AddWithValue("@FirstName", _obj.FirstName);
                _cmd.Parameters.AddWithValue("@LastName", _obj.LastName);
                _cmd.Parameters.AddWithValue("@Email", _obj.Email);
                _cmd.Parameters.AddWithValue("@Country", _obj.Country);
                _cmd.Parameters.AddWithValue("@Mobile", _obj.Mobile);
                _cmd.Parameters.AddWithValue("@CountryCode", _obj.CountryCode);
                _cmd.Parameters.AddWithValue("@Random", _obj.Random);
                _cmd.Parameters.AddWithValue("@Created_Ip", _obj.Created_Ip);
                if (_obj.DateOfBirth == null || _obj.DateOfBirth.Equals(""))
                {
                    _cmd.Parameters.AddWithValue("@DateOfBirth", DBNull.Value);
                }
                else
                {
                    _cmd.Parameters.AddWithValue("@DateOfBirth", DateTime.ParseExact(_obj.DateOfBirth.ToString(), "dd-MM-yyyy", null));
                }
                _cmd.Parameters.AddWithValue("@ActualPassword", _obj.ActualPassword);
                _cmd.Parameters.AddWithValue("@bulk_reg", _obj.bulk_reg);
                _cmd.Parameters.AddWithValue("@ApplyingForCourse", _obj.ApplyingForCourse);
                _cmd.Parameters.AddWithValue("@whatsapp_consent", _obj.whatsapp_consent);
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
        public DataSet InsertStudentRegistration_Niche(Student_Register _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("InsertStudentRegistration_Niche", _cn);
                _cmd.Parameters.AddWithValue("@FirstName", _obj.FirstName);
                _cmd.Parameters.AddWithValue("@LastName", _obj.LastName);
                _cmd.Parameters.AddWithValue("@Email", _obj.Email);
                _cmd.Parameters.AddWithValue("@Country", _obj.Country);
                _cmd.Parameters.AddWithValue("@Mobile", _obj.Mobile);
                _cmd.Parameters.AddWithValue("@Random", _obj.Random);
                _cmd.Parameters.AddWithValue("@Created_Ip", _obj.Created_Ip);
                if (_obj.DateOfBirth == null || _obj.DateOfBirth.Equals(""))
                {
                    _cmd.Parameters.AddWithValue("@DateOfBirth", DBNull.Value);
                }
                else
                {
                    _cmd.Parameters.AddWithValue("@DateOfBirth", DateTime.ParseExact(_obj.DateOfBirth.ToString(), "dd-MM-yyyy", null));
                }
                _cmd.Parameters.AddWithValue("@bulk_reg", DBNull.Value);
                _cmd.Parameters.AddWithValue("@ApplyingForCourse", _obj.ApplyingForCourse);
                _cmd.Parameters.AddWithValue("@PresentProfession", _obj.PresentProfession);
                _cmd.Parameters.AddWithValue("@NicheCourseID", _obj.NicheCourseID);
                _cmd.Parameters.AddWithValue("@instituteid", _obj.instituteid);
                _cmd.Parameters.AddWithValue("@ParticipatedYear", ConfigurationManager.AppSettings["ParticipatedYear"].ToString());
                _cmd.Parameters.AddWithValue("@Phase", ConfigurationManager.AppSettings["CurrentPhase"].ToString());
                _cmd.Parameters.AddWithValue("@Gender", _obj.Gender);
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

        public DataSet InsertUpdatet_tbl_Student_Ch_Choice_Filling_NicheCourse(Student_Register _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("InsertUpdatet_tbl_Student_Ch_Choice_Filling_NicheCourse", _cn);
                _cmd.Parameters.AddWithValue("@studentid", _obj.studentid);
                _cmd.Parameters.AddWithValue("@InstituteNicheCourse_ID", _obj.NicheCourseID);
                _cmd.Parameters.AddWithValue("@instituteid", _obj.instituteid);
                _cmd.Parameters.AddWithValue("@Mobile", _obj.Mobile);
                _cmd.Parameters.AddWithValue("@Created_Ip", _obj.Created_Ip);
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

        public DataSet UpdateStudentRegistration(Student_Register _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("InsertUpdateStudentRegistration", _cn);
                _cmd.Parameters.AddWithValue("@studentid", _obj.studentid);
                _cmd.Parameters.AddWithValue("@FirstName", _obj.FirstName);
                _cmd.Parameters.AddWithValue("@LastName", _obj.LastName);
                _cmd.Parameters.AddWithValue("@MiddleName", _obj.MiddleName);
                if (_obj.DateOfBirth == null || _obj.DateOfBirth.Equals(""))
                {
                    _cmd.Parameters.AddWithValue("@DateOfBirth", DBNull.Value);
                }
                else
                {
                    _cmd.Parameters.AddWithValue("@DateOfBirth", DateTime.ParseExact(_obj.DateOfBirth.ToString(), "dd-MM-yyyy", null));
                }
                _cmd.Parameters.AddWithValue("@Gender", _obj.Gender);
                _cmd.Parameters.AddWithValue("@Email", _obj.Email);
                _cmd.Parameters.AddWithValue("@Mobile", _obj.Mobile);
                _cmd.Parameters.AddWithValue("@CountryCode", _obj.CountryCode);
                _cmd.Parameters.AddWithValue("@Country", _obj.Country);
                _cmd.Parameters.AddWithValue("@CountryToStay", _obj.CountryToStay);
                _cmd.Parameters.AddWithValue("@Created_By", _obj.Created_By);
                _cmd.Parameters.AddWithValue("@Created_Ip", _obj.Created_Ip);
                _cmd.Parameters.AddWithValue("@StrJson", _obj.StrJson);
                _cmd.Parameters.AddWithValue("@bCopyAddress", _obj.bCopyAddress);

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
        public DataSet Select_Student_Information(Student_Register _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("student_authentication", _cn);
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
        public DataSet InsertUpdateStudentRegistration_gov(Student_Register _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("InsertUpdateStudentRegistration_gov", _cn);
                _cmd.Parameters.AddWithValue("@studentid", _obj.studentid);
                _cmd.Parameters.AddWithValue("@FirstName", _obj.FirstName);
                _cmd.Parameters.AddWithValue("@LastName", _obj.LastName);
                _cmd.Parameters.AddWithValue("@MiddleName", _obj.MiddleName);
                if (_obj.DateOfBirth == null || _obj.DateOfBirth.Equals(""))
                {
                    _cmd.Parameters.AddWithValue("@DateOfBirth", DBNull.Value);
                }
                else
                {
                    _cmd.Parameters.AddWithValue("@DateOfBirth", DateTime.ParseExact(_obj.DateOfBirth.ToString(), "dd-MM-yyyy", null));
                }
                _cmd.Parameters.AddWithValue("@Gender", _obj.Gender);
                _cmd.Parameters.AddWithValue("@Email", _obj.Email);
                _cmd.Parameters.AddWithValue("@Mobile", _obj.Mobile);
                _cmd.Parameters.AddWithValue("@CountryCode", _obj.CountryCode);
                _cmd.Parameters.AddWithValue("@Nationality", _obj.Nationality);
                _cmd.Parameters.AddWithValue("@CountryToStay", _obj.CountryToStay);
                _cmd.Parameters.AddWithValue("@Created_By", _obj.Created_By);
                _cmd.Parameters.AddWithValue("@Created_Ip", _obj.Created_Ip);
                _cmd.Parameters.AddWithValue("@gov_scheme_id", _obj.gov_scheme_id);
                _cmd.Parameters.AddWithValue("@agency_det_id", _obj.agency_det_id);
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

        public DataSet select_student_data_gov(string gov_scheme_id)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("select_student_data_gov", _cn);
                _cmd.Parameters.AddWithValue("@gov_scheme_id", gov_scheme_id);
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

        public DataSet update_student_data_gov(string studentid)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("update_student_data_gov", _cn);
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

        #region Login changepassword and forgot password
        public DataSet Login_Student(Student_Register _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("student_authentication", _cn);
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
        public DataSet student_password_change(Student_Register _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("student_password_change", _cn);
                _cmd.Parameters.AddWithValue("@studentid", _obj.studentid);
                _cmd.Parameters.AddWithValue("@ActualPassword", _obj.ActualPassword);
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

        public DataSet student_login_activation_link(string email = "")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("student_login_activation_link", _cn);
                _cmd.Parameters.AddWithValue("@Emailid", email);
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
        public DataSet select_form_load_student()
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("select_form_load_student", _cn);
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
        public DataSet StudentForgotPassword(Student_Register _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("UpdateForgotPassword", _cn);
                _cmd.Parameters.AddWithValue("@random", _obj.Random);
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

        #region Background Information
        public DataSet UpdateStudentBackground(Student_Register _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("updateStudentBackgroundinformation", _cn);
                _cmd.Parameters.AddWithValue("@studentid", _obj.studentid);
                _cmd.Parameters.AddWithValue("@IsvalidPassport", _obj.IsvalidPassport);
                _cmd.Parameters.AddWithValue("@NameasperPassport", _obj.NameasperPassport);
                _cmd.Parameters.AddWithValue("@PassportNo", _obj.PassportNo);
                _cmd.Parameters.AddWithValue("@IssuingAuthority", _obj.IssuingAuthority);
                if (_obj.PassportExpDate == null || _obj.PassportExpDate.Equals(""))
                {
                    _cmd.Parameters.AddWithValue("@PassportExpDate", DBNull.Value);
                }
                else
                {
                    _cmd.Parameters.AddWithValue("@PassportExpDate", DateTime.ParseExact(_obj.PassportExpDate.ToString(), "dd-MM-yyyy", null));
                }
                _cmd.Parameters.AddWithValue("@PassportIssueCountry", _obj.PassportIssueCountry);
                _cmd.Parameters.AddWithValue("@ApplyForPassport", _obj.ApplyForPassport);
                _cmd.Parameters.AddWithValue("@PassportFileReferenceNumber", _obj.PassportFileReferenceNumber);
                _cmd.Parameters.AddWithValue("@AgreeTermsConditions", _obj.AgreeTermsConditions);
                _cmd.Parameters.AddWithValue("@strjson", _obj.StrJson);
                _cmd.Parameters.AddWithValue("@gov_scheme_id", _obj.gov_scheme_id);
                _cmd.Parameters.AddWithValue("@HaveCitizenshipNumber", _obj.HaveCitizenshipNumber);
                _cmd.Parameters.AddWithValue("@CitizenshipNumber", _obj.CitizenshipNumber);
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

        #region  Academic information
        public DataSet insert_academic_information(StudentAcademic_information _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("insert_academic_information", _cn);
                _cmd.Parameters.AddWithValue("@studentid", _obj.studentid);
                _cmd.Parameters.AddWithValue("@strjson", _obj.strjson);
                _cmd.Parameters.AddWithValue("@Created_By", _obj.Created_By);
                _cmd.Parameters.AddWithValue("@Created_Ip", _obj.Created_Ip);
                _cmd.Parameters.AddWithValue("@jeemain", _obj.jeemain);
                _cmd.Parameters.AddWithValue("@jeemainscore", _obj.jeemainscore);
                _cmd.Parameters.AddWithValue("@jeeadvance", _obj.jeeadvance);
                _cmd.Parameters.AddWithValue("@jeeadvancescore", _obj.jeeadvancescore);
                _cmd.Parameters.AddWithValue("@gov_scheme_id", _obj.gov_scheme_id);
                _cmd.Parameters.AddWithValue("@ielts", _obj.ielts);
                _cmd.Parameters.AddWithValue("@ieltsscore", _obj.ieltsscore);
                _cmd.Parameters.AddWithValue("@GMAT", _obj.GMAT);
                _cmd.Parameters.AddWithValue("@GMATscore", _obj.GMATscore);
                _cmd.Parameters.AddWithValue("@TOFEL", _obj.TOFEL);
                _cmd.Parameters.AddWithValue("@TOFELscore", _obj.TOFELscore);
                _cmd.Parameters.AddWithValue("@SAT", _obj.SAT);
                _cmd.Parameters.AddWithValue("@SATscore", _obj.SATscore);
                _cmd.Parameters.AddWithValue("@experience", _obj.experience);
                _cmd.Parameters.AddWithValue("@experiencescore", _obj.experiencescore);
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
        public DataSet select_StudentAcademic_information(string studentid, int id = 0)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("select_StudentAcademic_information", _cn);
                _cmd.Parameters.AddWithValue("@studentid", studentid);
                _cmd.Parameters.AddWithValue("@id", id);
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

        public DataSet insert_other_academicinformation(StudentAcademic_information _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("insert_other_academicinformation", _cn);
                _cmd.Parameters.AddWithValue("@Academicinformationid", _obj.Academicinformationid);
                _cmd.Parameters.AddWithValue("@studentid", _obj.studentid);
                _cmd.Parameters.AddWithValue("@Education_Qualification_Name", _obj.Education_Qualification_Name);
                _cmd.Parameters.AddWithValue("@Degree_name", _obj.Degree_name);
                _cmd.Parameters.AddWithValue("@board_uni_name", _obj.board_uni_name);
                _cmd.Parameters.AddWithValue("@passing_year", _obj.passing_year);
                _cmd.Parameters.AddWithValue("@Marks_obtains", _obj.Marks_obtains);
                _cmd.Parameters.AddWithValue("@min_marks", _obj.min_marks);
                _cmd.Parameters.AddWithValue("@subject_studied", _obj.subject_studied);
                _cmd.Parameters.AddWithValue("@country_id", _obj.country_id);
                _cmd.Parameters.AddWithValue("@address", _obj.address);
                _cmd.Parameters.AddWithValue("@Created_By", _obj.Created_By);
                _cmd.Parameters.AddWithValue("@Created_Ip", _obj.Created_Ip);
                _cmd.Parameters.AddWithValue("@TotalMarksinPercentage", _obj.TotalMarksinPercentage);
                _cmd.Parameters.AddWithValue("@GradeConversionDocument", _obj.GradeConversionDocument);
                _cmd.Parameters.AddWithValue("@NameofCourse", _obj.NameofCourse);
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
        public DataSet delete_other_academicinformation(StudentAcademic_information _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("delete_other_academicinformation", _cn);
                _cmd.Parameters.AddWithValue("@id", _obj.Academicinformationid);
                _cmd.Parameters.AddWithValue("@studentid", _obj.studentid);
                _cmd.Parameters.AddWithValue("@ip", _obj.Created_Ip);
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

        #region document Infomation
        public DataSet insert_studentdocument(student_document _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("insert_studentdocument", _cn);
                _cmd.Parameters.AddWithValue("@studentid", _obj.studentid);
                _cmd.Parameters.AddWithValue("@document_name", _obj.document_name);
                _cmd.Parameters.AddWithValue("@document_path", _obj.document_path);
                _cmd.Parameters.AddWithValue("@Created_By", _obj.created_by);
                //_cmd.Parameters.AddWithValue("@Created_Ip", _obj.Created_Ip);
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
        public DataSet select_studentdocument(string studentid)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("select_studentdocument", _cn);
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

        public DataSet update_image_path(Student_Register _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("update_image_path", _cn);
                _cmd.Parameters.AddWithValue("@studentid", _obj.studentid);
                _cmd.Parameters.AddWithValue("@student_path", _obj.student_path);
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

        public DataSet delete_studentdocument(string document_id)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("sp_Delete_Student_Document", _cn);
                _cmd.Parameters.AddWithValue("@document_id", document_id);
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

        #region Edit My Application
        public DataSet EDIT_MY_APPLICATION(string studentid = "", string CreatedIP = "")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("EDIT_MY_APPLICATION", _cn);
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
        #endregion
        public DataSet Opr_GenerateStudentDtl(string Type, string studentid = "", string ActivationLink = "", string ActivationLinkSent = "", string ActivationLinkStatus = "", string ActivationLinkSentBy = "")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("Opr_GenerateStudentDtl", _cn);
                _cmd.Parameters.AddWithValue("@Type", Type);
                _cmd.Parameters.AddWithValue("@studentid", studentid);
                _cmd.Parameters.AddWithValue("@ActivationLink", ActivationLink);
                _cmd.Parameters.AddWithValue("@ActivationLinkSent", ActivationLinkSent);
                _cmd.Parameters.AddWithValue("@ActivationLinkStatus", ActivationLinkStatus);
                _cmd.Parameters.AddWithValue("@ActivationLinkSentBy", ActivationLinkSentBy);
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
        public DataSet SELECT_IndSAT_Credential(string studentid = "")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("SELECT_IndSAT_Credential", _cn);
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
        public DataSet CHECK_UG_PG_PHD_STUDENT_CH(string studentid = "")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("CHECK_UG_PG_PHD_STUDENT_CH", _cn);
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
    }
}