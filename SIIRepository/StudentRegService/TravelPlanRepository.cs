using SIIModel.StudentRegister;
using System;
using System.Data;
using System.Data.SqlClient;

namespace SIIRepository.StudentRegService
{
    public class TravelPlanRepository : Base
    {
        #region Passport
        public DataSet INSERT_UPDATE_StudentTravelPlanPassport(mTravelPlanPassport _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("INSERT_UPDATE_StudentTravelPlanPassport", _cn);
                _cmd.Parameters.AddWithValue("@StudentID", _obj.StudentID);
                _cmd.Parameters.AddWithValue("@ApplicationNo", _obj.ApplicationNo);
                _cmd.Parameters.AddWithValue("@HaveValidPassport", _obj.HaveValidPassport);
                _cmd.Parameters.AddWithValue("@PassportNumber", _obj.PassportNumber);
                if (_obj.PassportExpiryDate != null)
                {
                    if (_obj.PassportExpiryDate.Equals(""))
                    {
                        _cmd.Parameters.AddWithValue("@PassportExpiryDate", DBNull.Value);
                    }
                    else
                    {
                        _cmd.Parameters.AddWithValue("@PassportExpiryDate", DateTime.ParseExact(_obj.PassportExpiryDate.ToString(), "dd-MM-yyyy", null));
                    }
                }
                else
                {
                    _cmd.Parameters.AddWithValue("@PassportExpiryDate", DBNull.Value);
                }
                _cmd.Parameters.AddWithValue("@PassportDocument", _obj.PassportDocument);
                _cmd.Parameters.AddWithValue("@ApplicationNumber", _obj.ApplicationNumber);
                _cmd.Parameters.AddWithValue("@ApplicationDocument", _obj.ApplicationDocument);
                _cmd.Parameters.AddWithValue("@CitizenshipNumber", _obj.CitizenshipNumber);
                if (_obj.CitizenshipIssueDate != null)
                {
                    if (_obj.CitizenshipIssueDate.Equals(""))
                    {
                        _cmd.Parameters.AddWithValue("@CitizenshipIssueDate", DBNull.Value);
                    }
                    else
                    {
                        _cmd.Parameters.AddWithValue("@CitizenshipIssueDate", DateTime.ParseExact(_obj.CitizenshipIssueDate.ToString(), "dd-MM-yyyy", null));
                    }
                }
                else
                {
                    _cmd.Parameters.AddWithValue("@CitizenshipIssueDate", DBNull.Value);
                }
                _cmd.Parameters.AddWithValue("@CitizenshipDocument", _obj.CitizenshipDocument);
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
        public DataSet SELECT_StudentTravelPlanPassport(string StudentID = "", string ApplicationNo = "")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("SELECT_StudentTravelPlanPassport", _cn);
                _cmd.Parameters.AddWithValue("@StudentID", StudentID);
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
        #endregion

        #region Air Ticket
        public DataSet INSERT_UPDATE_StudentTravelPlanAirTicket(mTravelPlanAirTicket _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("INSERT_UPDATE_StudentTravelPlanAirTicket", _cn);
                _cmd.Parameters.AddWithValue("@StudentID", _obj.StudentID);
                _cmd.Parameters.AddWithValue("@ApplicationNo", _obj.ApplicationNo);
                _cmd.Parameters.AddWithValue("@HaveBookedTicket", _obj.HaveBookedTicket);
                if (_obj.LandingDate != null)
                {
                    if (_obj.LandingDate.Equals(""))
                    {
                        _cmd.Parameters.AddWithValue("@LandingDate", DBNull.Value);
                    }
                    else
                    {
                        _cmd.Parameters.AddWithValue("@LandingDate", DateTime.ParseExact(_obj.LandingDate.ToString(), "dd-MM-yyyy", null));
                    }
                }
                else
                {
                    _cmd.Parameters.AddWithValue("@LandingDate", DBNull.Value);
                }
                _cmd.Parameters.AddWithValue("@LandingTime", _obj.LandingTime);
                _cmd.Parameters.AddWithValue("@OriginCountry", _obj.OriginCountry);
                _cmd.Parameters.AddWithValue("@OriginAirport", _obj.OriginAirport);
                _cmd.Parameters.AddWithValue("@OtherOriginAirport", _obj.OtherOriginAirport);
                _cmd.Parameters.AddWithValue("@DestinationCountry", _obj.DestinationCountry);
                _cmd.Parameters.AddWithValue("@DestinationAirport", _obj.DestinationAirport);
                _cmd.Parameters.AddWithValue("@OtherDestinationAirport", _obj.OtherDestinationAirport);
                _cmd.Parameters.AddWithValue("@ETicket", _obj.ETicket);
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
        public DataSet SELECT_StudentTravelPlanAirTicket(string StudentID = "", string ApplicationNo = "")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("SELECT_StudentTravelPlanAirTicket", _cn);
                _cmd.Parameters.AddWithValue("@StudentID", StudentID);
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
        #endregion

        #region Visa
        public DataSet INSERT_UPDATE_StudentTravelPlanVisa(mTravelPlanVisa _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("INSERT_UPDATE_StudentTravelPlanVisa", _cn);
                _cmd.Parameters.AddWithValue("@StudentID", _obj.StudentID);
                _cmd.Parameters.AddWithValue("@ApplicationNo", _obj.ApplicationNo);
                _cmd.Parameters.AddWithValue("@HaveIndianStudentVisa", _obj.HaveIndianStudentVisa);
                _cmd.Parameters.AddWithValue("@VisaNumber", _obj.VisaNumber);
                if (_obj.ExpiryDate != null)
                {
                    if (_obj.ExpiryDate.Equals(""))
                    {
                        _cmd.Parameters.AddWithValue("@ExpiryDate", DBNull.Value);
                    }
                    else
                    {
                        _cmd.Parameters.AddWithValue("@ExpiryDate", DateTime.ParseExact(_obj.ExpiryDate.ToString(), "dd-MM-yyyy", null));
                    }
                }
                else
                {
                    _cmd.Parameters.AddWithValue("@ExpiryDate", DBNull.Value);
                }
                _cmd.Parameters.AddWithValue("@VisaType", _obj.VisaType);
                _cmd.Parameters.AddWithValue("@VisaDocument", _obj.VisaDocument);
                _cmd.Parameters.AddWithValue("@VisaApplicationNumber", _obj.VisaApplicationNumber);
                _cmd.Parameters.AddWithValue("@VisaApplicationDocument", _obj.VisaApplicationDocument);
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
        public DataSet SELECT_StudentTravelPlanVisa(string StudentID = "", string ApplicationNo = "")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("SELECT_StudentTravelPlanVisa", _cn);
                _cmd.Parameters.AddWithValue("@StudentID", StudentID);
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
        #endregion

        #region Institute Spoc
        public DataSet INSERT_UPDATE_StudentTravelInstituteSpoc(mTravelPlanInstituteSpoc _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("INSERT_UPDATE_StudentTravelInstituteSpoc", _cn);
                _cmd.Parameters.AddWithValue("@ID", _obj.ID);
                _cmd.Parameters.AddWithValue("@ProgramLevel", _obj.ProgramLevel);
                _cmd.Parameters.AddWithValue("@InstituteID", _obj.InstituteID);
                _cmd.Parameters.AddWithValue("@StudentIDs", _obj.StudentIDs);
                _cmd.Parameters.AddWithValue("@NameOfSpoc", _obj.NameOfSpoc);
                _cmd.Parameters.AddWithValue("@Mobile", _obj.Mobile);
                _cmd.Parameters.AddWithValue("@Email", _obj.Email);
                _cmd.Parameters.AddWithValue("@DocumentName1", _obj.DocumentName1);
                _cmd.Parameters.AddWithValue("@OtherDocumentName1", _obj.OtherDocumentName1);
                _cmd.Parameters.AddWithValue("@DoumentPath1", _obj.DoumentPath1);
                _cmd.Parameters.AddWithValue("@DocumentName2", _obj.DocumentName2);
                _cmd.Parameters.AddWithValue("@OtherDocumentName2", _obj.OtherDocumentName2);
                _cmd.Parameters.AddWithValue("@DoumentPath2", _obj.DoumentPath2);
                _cmd.Parameters.AddWithValue("@DocumentName3", _obj.DocumentName3);
                _cmd.Parameters.AddWithValue("@OtherDocumentName3", _obj.OtherDocumentName3);
                _cmd.Parameters.AddWithValue("@DoumentPath3", _obj.DoumentPath3);
                _cmd.Parameters.AddWithValue("@DocumentName4", _obj.DocumentName4);
                _cmd.Parameters.AddWithValue("@OtherDocumentName4", _obj.OtherDocumentName4);
                _cmd.Parameters.AddWithValue("@DoumentPath4", _obj.DoumentPath4);
                _cmd.Parameters.AddWithValue("@DocumentName5", _obj.DocumentName5);
                _cmd.Parameters.AddWithValue("@OtherDocumentName5", _obj.OtherDocumentName5);
                _cmd.Parameters.AddWithValue("@DoumentPath5", _obj.DoumentPath5);
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
        public DataSet SELECT_StudentTravelInstituteSpoc(string ID = "", string InstituteID = "",string ProgramLevel = "")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("SELECT_StudentTravelInstituteSpoc", _cn);
                _cmd.Parameters.AddWithValue("@ID", ID);
                _cmd.Parameters.AddWithValue("@InstituteID", InstituteID);
                _cmd.Parameters.AddWithValue("@ProgramLevel", ProgramLevel);
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
        public DataSet DELETE_StudentTravelInstituteSpoc(string ID = "", string InstituteID = "", string ProgramLevel = "")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("DELETE_StudentTravelInstituteSpoc", _cn);
                _cmd.Parameters.AddWithValue("@ID", ID);
                _cmd.Parameters.AddWithValue("@InstituteID", InstituteID);
                _cmd.Parameters.AddWithValue("@ProgramLevel", ProgramLevel);
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
        public DataSet SELECT_StudentTravelInstituteSpoc_ForStudents(string StudentID = "")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("SELECT_StudentTravelInstituteSpoc_ForStudents", _cn);
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
        #endregion
        public DataSet SELECT_Student_TravelPlan_Status(string StudentID = "", string ApplicationNo = "")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("SELECT_Student_TravelPlan_Status", _cn);
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
        public DataSet SELECT_COUNTRY_FOR_AIRPORTS()
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("SELECT_COUNTRY_FOR_AIRPORTS", _cn);
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
        public DataSet SELECT_COUNTRY_WISE_AIRPORTS(string Country_id = "")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("SELECT_COUNTRY_WISE_AIRPORTS", _cn);
                _cmd.Parameters.AddWithValue("@Country_id", Country_id);
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
        public DataSet STUDENT_ADMITTED_BY_INSTITUTE(string StudentID = "", string InstituteID = "", string ProgramLevel = "", string Admitted = "")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("STUDENT_ADMITTED_BY_INSTITUTE", _cn);
                _cmd.Parameters.AddWithValue("@StudentID", StudentID);
                _cmd.Parameters.AddWithValue("@InstituteID", InstituteID);
                _cmd.Parameters.AddWithValue("@ProgramLevel", ProgramLevel);
                _cmd.Parameters.AddWithValue("@IsAdmittedByInstitute", Admitted);
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
