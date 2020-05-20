using SIIModel.Admin;
using System;
using System.Data;
using System.Data.SqlClient;

namespace SIIRepository.Adminservice
{
    public class ReportsRepository : Base
    {
        #region Phase 2 Reports
        public DataSet Report(string type = null, string Control = null, string ProgramLevel = null, string Discipline_Id = null, string StudentId = null, string ReportFor = null, string CountryId = null, string Institute_Id = null)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("Mockcounselling_AdminReport", _cn);
                _cmd.Parameters.AddWithValue("@type", type);
                _cmd.Parameters.AddWithValue("@Control", Control);
                _cmd.Parameters.AddWithValue("@ProgramLevel", ProgramLevel);
                _cmd.Parameters.AddWithValue("@Discipline", Discipline_Id);
                _cmd.Parameters.AddWithValue("@StudentId", StudentId);
                _cmd.Parameters.AddWithValue("@For", ReportFor);
                _cmd.Parameters.AddWithValue("@CountryId", CountryId);
                _cmd.Parameters.AddWithValue("@Institute_Id", Institute_Id);
                // _cmd.Parameters.AddWithValue("@StudentId", StudentId);
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
        public DataSet SELECT_PHASE2_RESULT(string Type = "", string For = "", string ValueFor = "", string Value = "", string ProgramLevel = "" , string Round ="")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("SELECT_PHASE2_RESULT", _cn);
                _cmd.Parameters.AddWithValue("@Type", Type);
                _cmd.Parameters.AddWithValue("@For", For);
                _cmd.Parameters.AddWithValue("@Value", Value);
                _cmd.Parameters.AddWithValue("@ValueFor", ValueFor);
                _cmd.Parameters.AddWithValue("@ProgramLevel", ProgramLevel);
                _cmd.Parameters.AddWithValue("@Round", Round);
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
        public DataSet SELECT_PHASE2_RESULT_MERIT_ALLOTED(string Type = "", string ProgramLevel = "", string Country = "", string Alloted = "0", string Round ="")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("SELECT_PHASE2_RESULT_MERIT_ALLOTED", _cn);
                _cmd.Parameters.AddWithValue("@Type", Type);
                _cmd.Parameters.AddWithValue("@ProgramLevel", ProgramLevel);
                _cmd.Parameters.AddWithValue("@Country", Country);
                _cmd.Parameters.AddWithValue("@Alloted", Alloted);
                _cmd.Parameters.AddWithValue("@Round", Round);
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


        #region KPI Reports
        public DataSet SELECT_PHASE2_KPI_REGISTERED_STUDENTS(string Type = "", string For = "", string Value = "")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("SELECT_PHASE2_KPI_REGISTERED_STUDENTS", _cn);
                _cmd.Parameters.AddWithValue("@Type", Type);
                _cmd.Parameters.AddWithValue("@For", For);
                _cmd.Parameters.AddWithValue("@Value", Value);
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
        public DataSet SELECT_PHASE2_KPI_Counselling_Overview(string Type = "", string Control = "", string For = "", string Value = "",string Value2 = null)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("SELECT_PHASE2_KPI_Counselling_Overview", _cn);
                _cmd.Parameters.AddWithValue("@Type", Type);
                _cmd.Parameters.AddWithValue("@For", For);
                _cmd.Parameters.AddWithValue("@Value", Value);
                _cmd.Parameters.AddWithValue("@Control", Control);
                _cmd.Parameters.AddWithValue("@Value2", Value2);
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

        public DataSet SELECT_PHASE2_KPI_Institute_Overview_(string Type = "", string Control = "", string For = "", string Value = "", string Value2 = null)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("SELECT_PHASE2_KPI_Institute_Overview_", _cn);
                _cmd.Parameters.AddWithValue("@Type", Type);
                _cmd.Parameters.AddWithValue("@For", For);
                _cmd.Parameters.AddWithValue("@Value", Value);
                _cmd.Parameters.AddWithValue("@Control", Control);
                _cmd.Parameters.AddWithValue("@Value2", Value2);
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

        public DataSet SELECT_PHASE2_KPI_AdmittedLanded_Overview(string Type = "", string Control = "", string For = "", string Value = "", string Value2 = null)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("SELECT_PHASE2_KPI_AdmittedLanded_Overview", _cn);
                _cmd.Parameters.AddWithValue("@Type", Type);
                _cmd.Parameters.AddWithValue("@For", For);
                _cmd.Parameters.AddWithValue("@Value", Value);
                _cmd.Parameters.AddWithValue("@Control", Control);
                _cmd.Parameters.AddWithValue("@Value2", Value2);
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
        public DataSet SELECT_PHASE2_KPI_SecondRound_OverView(string Type = "", string Control = "", string For = "", string Value = "", string Value2 = null)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("SELECT_PHASE2_KPI_SecondRound_OverView", _cn);
                _cmd.Parameters.AddWithValue("@Type", Type);
                _cmd.Parameters.AddWithValue("@For", For);
                _cmd.Parameters.AddWithValue("@Value", Value);
                _cmd.Parameters.AddWithValue("@Control", Control);
                _cmd.Parameters.AddWithValue("@Value2", Value2);
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
        public DataSet SELECT_PHASE2_KPI_ThirdRound_OverView(string Type = "", string Control = "", string For = "", string Value = "", string Value2 = null)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("SELECT_PHASE2_KPI_ThirdRound_OverView", _cn);
                _cmd.Parameters.AddWithValue("@Type", Type);
                _cmd.Parameters.AddWithValue("@For", For);
                _cmd.Parameters.AddWithValue("@Value", Value);
                _cmd.Parameters.AddWithValue("@Control", Control);
                _cmd.Parameters.AddWithValue("@Value2", Value2);
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

        public DataSet SELECT_PHASE3_KPI_NICHE(string Type = "", string Control = "", string For = "", string Value1 = "", string Value2 = null, string Value3 = null,string Value4 = null, string Value5 = null)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("SELECT_PHASE3_KPI_NICHE", _cn);
                _cmd.Parameters.AddWithValue("@Type", Type);
                _cmd.Parameters.AddWithValue("@Control", Control);
                _cmd.Parameters.AddWithValue("@For", For);
                _cmd.Parameters.AddWithValue("@Value1", Value1);
                _cmd.Parameters.AddWithValue("@Value2", Value2);
                _cmd.Parameters.AddWithValue("@Value3", Value3);
                _cmd.Parameters.AddWithValue("@Value4", Value4);
                _cmd.Parameters.AddWithValue("@Value5", Value5);
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
    }
}