using SIIModel.Institute;
using System;
using System.Data;
using System.Data.SqlClient;

namespace SIIRepository.Institute
{
    public class InstituteAssociationsRepository : Base
    {
        public DataSet InstituteAssociations_Select(string Id, string InstituteID)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("sp_Select_tbl_InstituteAssociations", _cn);
                _cmd.Parameters.AddWithValue("@ID", Id);
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
        public DataSet InstituteAssociations_Insert(InstituteAssociations _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("sp_Insert_Update_tbl_InstituteAssociations", _cn);
                _cmd.Parameters.AddWithValue("@ID", _obj.ID);
                _cmd.Parameters.AddWithValue("@InstituteID", _obj.InstituteID);
                _cmd.Parameters.AddWithValue("@FamousProject", _obj.FamousProject);
                _cmd.Parameters.AddWithValue("@FamousProject2", _obj.FamousProject2);
                _cmd.Parameters.AddWithValue("@FamousProject3", _obj.FamousProject3);
                _cmd.Parameters.AddWithValue("@FamousProject4", _obj.FamousProject4);
                _cmd.Parameters.AddWithValue("@FamousProject5", _obj.FamousProject5);
                _cmd.Parameters.AddWithValue("@Researches", _obj.Researches);
                _cmd.Parameters.AddWithValue("@Researches2", _obj.Researches2);
                _cmd.Parameters.AddWithValue("@Researches3", _obj.Researches3);
                _cmd.Parameters.AddWithValue("@Researches4", _obj.Researches4);
                _cmd.Parameters.AddWithValue("@Researches5", _obj.Researches5);
                _cmd.Parameters.AddWithValue("@PlacementOffering", _obj.PlacementOffering);
                _cmd.Parameters.AddWithValue("@SummerInternship", _obj.SummerInternship);
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
        public DataSet InstituteAssociations_Delete(InstituteAssociations _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("sp_Delete_tbl_InstituteAssociations", _cn);
                _cmd.Parameters.AddWithValue("@ID", _obj.ID);
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
