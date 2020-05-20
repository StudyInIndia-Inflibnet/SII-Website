using SIIModel.Admin;
using System;
using System.Data;
using System.Data.SqlClient;

namespace SIIRepository.Adminservice
{
    public  class AgencyRepository:Base
    {
        public DataSet insert_update_agency(Agencymaster _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("insert_update_agency", _cn);
                _cmd.Parameters.AddWithValue("@agencyid", _obj.agencyid);
                _cmd.Parameters.AddWithValue("@agency_uniq_id", _obj.agency_uniq_id);
                _cmd.Parameters.AddWithValue("@nameofagency", _obj.nameofagency);
                _cmd.Parameters.AddWithValue("@agencyaddress", _obj.agencyaddress);
                _cmd.Parameters.AddWithValue("@email", _obj.email);
                _cmd.Parameters.AddWithValue("@password", _obj.password);
                _cmd.Parameters.AddWithValue("@countrycode", _obj.countrycode);
                _cmd.Parameters.AddWithValue("@mobile", _obj.mobile);
                _cmd.Parameters.AddWithValue("@typeofagency", _obj.typeofagency);
                _cmd.Parameters.AddWithValue("@createdip", _obj.createdip);
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
        public DataSet select_Agency_master(string ID="")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("select_Agency_master", _cn);
                _cmd.Parameters.AddWithValue("@agencyid", ID);
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
        public DataSet insert_update_agency_detail(AgencyDetail _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("insert_update_agency_detail", _cn);
               // _cmd.Parameters.AddWithValue("@id", _obj.id);
                _cmd.Parameters.AddWithValue("@agencyid", _obj.agencyid);
                _cmd.Parameters.AddWithValue("@nameofentitlename", _obj.nameofentitlename);
                _cmd.Parameters.AddWithValue("@fee_g1", _obj.fee_g1);
                _cmd.Parameters.AddWithValue("@fee_g2", _obj.fee_g2);
                _cmd.Parameters.AddWithValue("@fee_g3", _obj.fee_g3);
                _cmd.Parameters.AddWithValue("@fee_g4", _obj.fee_g4);
                _cmd.Parameters.AddWithValue("@countryid", _obj.countryid);
                _cmd.Parameters.AddWithValue("@noofstudent", _obj.noofstudent);
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
        public DataSet select_tbl_Agency_detail(string ID = "")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("select_tbl_Agency_detail", _cn);
                _cmd.Parameters.AddWithValue("@agencyid", ID);
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
        public DataSet delete_tbl_Agency_detail(string ID = "")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("delete_tbl_Agency_detail", _cn);
                _cmd.Parameters.AddWithValue("@id", ID);
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
        public DataSet delete_tbl_Agency_master(string ID = "")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("delete_tbl_Agency_master", _cn);
                _cmd.Parameters.AddWithValue("@id", ID);
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
        public DataSet select_tbl_Agency_master_login(Agencymaster _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("select_tbl_Agency_master_login", _cn);
                _cmd.Parameters.AddWithValue("@agency_uniq_id", _obj.agency_uniq_id);
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
        public DataSet agency_password_change(Agencymaster _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("agency_password_change", _cn);
                _cmd.Parameters.AddWithValue("@agency_uniq_id", _obj.agency_uniq_id);
                _cmd.Parameters.AddWithValue("@change_password", _obj.change_password);
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
