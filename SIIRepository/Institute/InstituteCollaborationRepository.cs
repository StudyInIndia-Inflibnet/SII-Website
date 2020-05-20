using SIIModel.Institute;
using System;
using System.Data;
using System.Data.SqlClient;

namespace SIIRepository.Institute
{
    public class InstituteCollaborationRepository : Base
    {
        public DataSet InstituteCollaboration_Select(string Id,string InstituteID)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("sp_Select_tbl_InstituteCollaboration", _cn);
                _cmd.Parameters.AddWithValue("@ID", Id);
                _cmd.Parameters.AddWithValue("@InstituteID",InstituteID);
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
        public DataSet InstituteCollaboration_Insert(InstituteCollaboration _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("sp_Insert_Update_tbl_InstituteCollaboration", _cn);
                _cmd.Parameters.AddWithValue("@ID", _obj.ID);
                _cmd.Parameters.AddWithValue("@InstituteID", _obj.InstituteID);
                _cmd.Parameters.AddWithValue("@NameOfProgram", _obj.NameOfProgram);
                _cmd.Parameters.AddWithValue("@CollaborateInstitute", _obj.CollaborateInstitute);
                _cmd.Parameters.AddWithValue("@CollaborateState", _obj.Collaboratecountry);
                _cmd.Parameters.AddWithValue("@CollaborateAddress", _obj.CollaborateAddress);
                _cmd.Parameters.AddWithValue("@Remarks", _obj.Remarks);
                _cmd.Parameters.AddWithValue("@CreatedIP", _obj.CreatedIP);
                _cmd.Parameters.AddWithValue("@Collaborate_country", _obj.Collaborate_country);
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
        public DataSet InstituteCollaboration_Delete(string ID)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("sp_Delete_tbl_InstituteCollaboration", _cn);
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
