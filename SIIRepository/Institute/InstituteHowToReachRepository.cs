using SIIModel.Institute;
using System;
using System.Data;
using System.Data.SqlClient;

namespace SIIRepository.Institute
{
    public class InstituteHowToReachRepository : Base
    {
        public DataSet Save_Institute_How_To_Reach(mInstituteHowToReach _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("sp_Insert_Update_HowToReach", _cn);
                _cmd.Parameters.AddWithValue("@ID", _obj.ID);
                _cmd.Parameters.AddWithValue("@InstituteID", _obj.InstituteID);
                _cmd.Parameters.AddWithValue("@ReachBy", _obj.ReachBy);
                _cmd.Parameters.AddWithValue("@NearByStationName", _obj.NearByStationName);
                _cmd.Parameters.AddWithValue("@remarks", _obj.remarks);
                _cmd.Parameters.AddWithValue("@ApproxTime", _obj.ApproxTime);
                _cmd.Parameters.AddWithValue("@ApproxTimeType", _obj.ApproxTimeType);
                _cmd.Parameters.AddWithValue("@Distance", _obj.Distance);
                _cmd.Parameters.AddWithValue("@DistanceType", _obj.DistanceType);
                _cmd.Parameters.AddWithValue("@CreatedIP", _obj.CreatedIP);
                _cmd.Parameters.AddWithValue("@Edited_by", _obj.Edited_by);
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

        public DataSet Select_Institute_How_To_Reach(string ID = "", string InstituteID = "")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("sp_Select_Institute_How_To_Reach", _cn);
                _cmd.Parameters.AddWithValue("@ID", ID);
                _cmd.Parameters.AddWithValue("@InstituteID", InstituteID);
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

        public DataSet Delete_Institute_How_To_Reach(string ID = "")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("sp_Delete_Institute_How_To_Reach", _cn);
                _cmd.Parameters.AddWithValue("@ID", ID);
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
