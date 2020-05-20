using SIIModel.Admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace SIIRepository.Adminservice
{
    public class Discipline_Repository : Base
    {
        public DataSet INSERT_UPDATE_DISCIPLINE(mDiscipline _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("INSERT_UPDATE_DISCIPLINE", _cn);
                _cmd.Parameters.AddWithValue("@Discipline_ID", _obj.Discipline_ID);
                _cmd.Parameters.AddWithValue("@Discipline", _obj.Discipline);
                _cmd.Parameters.AddWithValue("@isNicheCourse", _obj.isNicheCourse);

                Debug.Print(string.Format("{0} @Discipline_ID='{1}', @Discipline='{2}', @isNicheCourse='{3}'", _cmd.CommandText, "Discipline_ID", "Discipline", "isNicheCourse"));

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
        public DataSet SELECT_DISCIPLINE_FOR_FORM(string Discipline_ID = "0", string IsNicheCourse = "0")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("SELECT_DISCIPLINE_FOR_FORM", _cn);
                _cmd.Parameters.AddWithValue("@Discipline_ID", Discipline_ID);
                _cmd.Parameters.AddWithValue("@IsNicheCourse", IsNicheCourse);

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
        public DataSet DELETE_DISCIPLINE_FOR_FORM(string Discipline_ID = "0", string IsNicheCourse = "0")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("DELETE_DISCIPLINE_FOR_FORM", _cn);
                _cmd.Parameters.AddWithValue("@Discipline_ID", Discipline_ID);
                _cmd.Parameters.AddWithValue("@IsNicheCourse", IsNicheCourse);
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
    }
}