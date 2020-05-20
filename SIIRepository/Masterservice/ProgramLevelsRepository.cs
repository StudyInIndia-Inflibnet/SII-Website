using SIIModel.Master;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIIRepository.Masterservice
{
    public class ProgramLevelsRepository:Base
    {
        public DataSet Select_ProgramLevel(string IsActive = "0")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("sp_select_ProgramLevel", _cn);
                _cmd.Parameters.AddWithValue("@IsActive", IsActive);
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
