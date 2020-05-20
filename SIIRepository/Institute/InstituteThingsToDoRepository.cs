using SIIModel.Institute;
using System;
using System.Data;
using System.Data.SqlClient;

namespace SIIRepository.Institute
{
    public class InstituteThingsToDoRepository:Base
    {
        public DataSet Save_Institute_Things_To_Do(mInstituteThingsToDo _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("sp_Insert_Update_Things_To_Do", _cn);
                _cmd.Parameters.AddWithValue("@ID", _obj.ID);
                _cmd.Parameters.AddWithValue("@InstituteID", _obj.InstituteID);
                _cmd.Parameters.AddWithValue("@ThingsToDo", _obj.ThingsToDo);
                _cmd.Parameters.AddWithValue("@Discription", _obj.Discription);
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
        public DataSet Select_Institute_Things_To_Do(string ID = "")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("sp_Select_Institute_Things_To_Do", _cn);
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
        public DataSet Delete_Institute_Things_To_Do(string ID = "")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("sp_Delete_Institute_Things_To_Do", _cn);
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
