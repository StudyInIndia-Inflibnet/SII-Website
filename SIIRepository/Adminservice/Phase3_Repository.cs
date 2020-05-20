using SIIModel.Admin;
using System;
using System.Data;
using System.Data.SqlClient;

namespace SIIRepository.Adminservice
{
    public class Phase3_Repository : Base
    {
        public DataSet KPIReport_ParameterDetails(string Type = "", string Control = "", string ParameterCode ="",string SubParameterLevel1Code ="",string SubParameterLevel2Code ="",String UserID="")
        {
            try
            {
                String ParticipatedYear = System.Configuration.ConfigurationManager.AppSettings["ParticipatedYearPostDCS"];
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("KPIReport_ParameterDetails", _cn);
                _cmd.Parameters.AddWithValue("@Type", Type);
                _cmd.Parameters.AddWithValue("@Control", Control);
                _cmd.Parameters.AddWithValue("@ParameterCode", ParameterCode);
                _cmd.Parameters.AddWithValue("@SubParameterLevel1Code", SubParameterLevel1Code);
                _cmd.Parameters.AddWithValue("@SubParameterLevel2Code", SubParameterLevel2Code);
                _cmd.Parameters.AddWithValue("@ParticipatedYear", ParticipatedYear);
                _cmd.Parameters.AddWithValue("@UserID", UserID);
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
        public DataSet KPIReport_ParameterGridDetails(string Type = "", string Control = "", string ParameterCode = "", string SubParameterLevel1Code = "", string SubParameterLevel2Code = "")
        {
            try
            {
                String ParticipatedYear = System.Configuration.ConfigurationManager.AppSettings["ParticipatedYearPostDCS"];
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("KPIReport_ParameterGridDetails", _cn);
                _cmd.Parameters.AddWithValue("@Type", Type);
                _cmd.Parameters.AddWithValue("@Control", Control);
                _cmd.Parameters.AddWithValue("@ParameterCode", ParameterCode);
                _cmd.Parameters.AddWithValue("@SubParameterLevel1Code", SubParameterLevel1Code);
                _cmd.Parameters.AddWithValue("@SubParameterLevel2Code", SubParameterLevel2Code);
                _cmd.Parameters.AddWithValue("@ParticipatedYear", ParticipatedYear);
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

        public DataSet Opr_ConvertImages(string Type = "", string studentid = "", string SignatureNew = "", string PhotoNew = "")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("Opr_ConvertImages", _cn);
                _cmd.Parameters.AddWithValue("@Type", Type);
                _cmd.Parameters.AddWithValue("@studentid", studentid);
                _cmd.Parameters.AddWithValue("@SignatureNew", SignatureNew);
                _cmd.Parameters.AddWithValue("@PhotoNew", PhotoNew);
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
    }
}