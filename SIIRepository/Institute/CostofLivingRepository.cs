using SIIModel.Institute;
using System;
using System.Data;
using System.Data.SqlClient;

namespace SIIRepository.Institute
{
    public class CostofLivingRepository:Base
    {
        public DataSet insertupdate_CostofLiving(CostofLiving _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("sp_insert_update_tbl_CostofLiving", _cn);
                _cmd.Parameters.AddWithValue("@ID", _obj.ID);
                _cmd.Parameters.AddWithValue("@InstituteID", _obj.InstituteID);
                _cmd.Parameters.AddWithValue("@Natureofcostcategory_id", _obj.Natureofcostcategory_id);
                _cmd.Parameters.AddWithValue("@ApproximatCost", _obj.ApproximatCost);
                _cmd.Parameters.AddWithValue("@ApproximatCostType", _obj.ApproximatCostType);
                _cmd.Parameters.AddWithValue("@UploadedFilePath", _obj.UploadedFilePath);
                _cmd.Parameters.AddWithValue("@CreatedBy", _obj.CreatedBy);
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

        public DataSet select_tbl_CostofLiving(CostofLiving _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("sp_select_tbl_CostofLiving", _cn);
                _cmd.Parameters.AddWithValue("@ID", _obj.ID);
                _cmd.Parameters.AddWithValue("@InstituteID", _obj.InstituteID);
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
        public DataSet delete_tbl_CostofLiving(CostofLiving _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("sp_delete_tbl_CostofLiving", _cn);
                _cmd.Parameters.AddWithValue("@ID", _obj.ID);
                _cmd.Parameters.AddWithValue("@InstituteID", _obj.InstituteID);
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
