using SIIModel.Admin;
using System;
using System.Data;
using System.Data.SqlClient;

namespace SIIRepository.Adminservice
{
    public class MockRoundRepository : Base
    {

        public DataSet GenerateResult(string type = null, string Control = null, string ProgramLevel = null, string Discipline_Id = null, string StudentId = null, string ReportFor = null, string InstituteAction = null)
        {
            try
            {
                _cn.Open();

                SqlCommand _cmd = new SqlCommand("Mockcounselling_Admin", _cn);
                _cmd.Parameters.AddWithValue("@type", type);
                _cmd.Parameters.AddWithValue("@Control", Control);
                _cmd.Parameters.AddWithValue("@ProgramLevel", ProgramLevel);
                _cmd.Parameters.AddWithValue("@Discipline", Discipline_Id);
                _cmd.Parameters.AddWithValue("@StudentId", StudentId);
                _cmd.Parameters.AddWithValue("@For", ReportFor);
                _cmd.Parameters.AddWithValue("@InstituteAction", InstituteAction);
                _cmd.CommandTimeout = 300;
                // _cmd.Parameters.AddWithValue("@StudentId", StudentId);
                _cmd.CommandType = CommandType.StoredProcedure;
                // _cmd.CommandTimeout = 100;
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


        public DataSet GenerateResult_Second(string type = null, string Control = null, string ProgramLevel = null, string Discipline_Id = null, string StudentId = null, string ReportFor = null, string InstituteAction = null)
        {
            try
            {
                _cn.Open();

                SqlCommand _cmd = new SqlCommand("Mockcounselling_Admin_2Round", _cn);
                _cmd.Parameters.AddWithValue("@type", type);
                _cmd.Parameters.AddWithValue("@Control", Control);
                _cmd.Parameters.AddWithValue("@ProgramLevel", ProgramLevel);
                _cmd.Parameters.AddWithValue("@Discipline", Discipline_Id);
                _cmd.Parameters.AddWithValue("@StudentId", StudentId);
                _cmd.Parameters.AddWithValue("@For", ReportFor);
                _cmd.Parameters.AddWithValue("@InstituteAction", InstituteAction);
                _cmd.CommandTimeout = 300;
                // _cmd.Parameters.AddWithValue("@StudentId", StudentId);
                _cmd.CommandType = CommandType.StoredProcedure;
                // _cmd.CommandTimeout = 100;
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
