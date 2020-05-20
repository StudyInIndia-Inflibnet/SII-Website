using SIIModel.Admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIIRepository.Adminservice
{
    public class SCFRepository: Base
    {
        public DataSet Opr_ProgrammeLevel_Ch_CloseDT(mSCFDatesSave _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("Opr_ProgrammeLevel_Ch_CloseDT", _cn);
                _cmd.Parameters.AddWithValue("@Type", _obj.Type);
                if (_obj.UG_ClosingDate == null || _obj.UG_ClosingDate.Equals(""))
                {
                    _cmd.Parameters.AddWithValue("@UG_ClosingDate", DBNull.Value);
                }
                else
                {
                    _cmd.Parameters.AddWithValue("@UG_ClosingDate", DateTime.ParseExact(_obj.UG_ClosingDate.ToString(), "yyyy-MM-dd HH-mm-ss", null));
                }
                if (_obj.UG_ApproveReject_StartDate == null || _obj.UG_ApproveReject_StartDate.Equals(""))
                {
                    _cmd.Parameters.AddWithValue("@UG_ApproveReject_StartDate", DBNull.Value);
                }
                else
                {
                    _cmd.Parameters.AddWithValue("@UG_ApproveReject_StartDate", DateTime.ParseExact(_obj.UG_ApproveReject_StartDate.ToString(), "yyyy-MM-dd HH-mm-ss", null));
                }
                if (_obj.UG_ApproveReject_EndDate == null || _obj.UG_ApproveReject_EndDate.Equals(""))
                {
                    _cmd.Parameters.AddWithValue("@UG_ApproveReject_EndDate", DBNull.Value);
                }
                else
                {
                    _cmd.Parameters.AddWithValue("@UG_ApproveReject_EndDate", DateTime.ParseExact(_obj.UG_ApproveReject_EndDate.ToString(), "yyyy-MM-dd HH-mm-ss", null));
                }
                if (_obj.PG_ClosingDate == null || _obj.PG_ClosingDate.Equals(""))
                {
                    _cmd.Parameters.AddWithValue("@PG_ClosingDate", DBNull.Value);
                }
                else
                {
                    _cmd.Parameters.AddWithValue("@PG_ClosingDate", DateTime.ParseExact(_obj.PG_ClosingDate.ToString(), "yyyy-MM-dd HH-mm-ss", null));
                }
                if (_obj.PG_ApproveReject_StartDate == null || _obj.PG_ApproveReject_StartDate.Equals(""))
                {
                    _cmd.Parameters.AddWithValue("@PG_ApproveReject_StartDate", DBNull.Value);
                }
                else
                {
                    _cmd.Parameters.AddWithValue("@PG_ApproveReject_StartDate", DateTime.ParseExact(_obj.PG_ApproveReject_StartDate.ToString(), "yyyy-MM-dd HH-mm-ss", null));
                }
                if (_obj.PG_ApproveReject_EndDate == null || _obj.PG_ApproveReject_EndDate.Equals(""))
                {
                    _cmd.Parameters.AddWithValue("@PG_ApproveReject_EndDate", DBNull.Value);
                }
                else
                {
                    _cmd.Parameters.AddWithValue("@PG_ApproveReject_EndDate", DateTime.ParseExact(_obj.PG_ApproveReject_EndDate.ToString(), "yyyy-MM-dd HH-mm-ss", null));
                }
                if (_obj.PhD_ClosingDate == null || _obj.PhD_ClosingDate.Equals(""))
                {
                    _cmd.Parameters.AddWithValue("@PhD_ClosingDate", DBNull.Value);
                }
                else
                {
                    _cmd.Parameters.AddWithValue("@PhD_ClosingDate", DateTime.ParseExact(_obj.PhD_ClosingDate.ToString(), "yyyy-MM-dd HH-mm-ss", null));
                }
                if (_obj.PhD_ApproveReject_StartDate == null || _obj.PhD_ApproveReject_StartDate.Equals(""))
                {
                    _cmd.Parameters.AddWithValue("@PhD_ApproveReject_StartDate", DBNull.Value);
                }
                else
                {
                    _cmd.Parameters.AddWithValue("@PhD_ApproveReject_StartDate", DateTime.ParseExact(_obj.PhD_ApproveReject_StartDate.ToString(), "yyyy-MM-dd HH-mm-ss", null));
                }
                if (_obj.PhD_ApproveReject_EndDate == null || _obj.PhD_ApproveReject_EndDate.Equals(""))
                {
                    _cmd.Parameters.AddWithValue("@PhD_ApproveReject_EndDate", DBNull.Value);
                }
                else
                {
                    _cmd.Parameters.AddWithValue("@PhD_ApproveReject_EndDate", DateTime.ParseExact(_obj.PhD_ApproveReject_EndDate.ToString(), "yyyy-MM-dd HH-mm-ss", null));
                }
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
    }
}
