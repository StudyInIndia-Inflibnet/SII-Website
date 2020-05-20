using SIIModel.Master;
using System;
using System.Data;
using System.Data.SqlClient;

namespace SIIRepository.Masterservice
{
    public class CityRepository : Base
    {
        public DataSet select_city(City _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("select_city", _cn);
                _cmd.Parameters.AddWithValue("@country_id", _obj.country_id);
                _cmd.Parameters.AddWithValue("@state_id", _obj.state_id);
                _cmd.Parameters.AddWithValue("@city_id", _obj.city_id);
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
