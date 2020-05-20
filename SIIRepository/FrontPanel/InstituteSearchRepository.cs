using SIIModel.FrontPanel;
using SIIModel.StudentRegister;
using System;
using System.Data;
using System.Data.SqlClient;

namespace SIIRepository.FrontPanel
{
    public class InstituteSearchRepository : Base
    {
        #region Institute Search
        //public DataSet OperationInstituteSearch(InstituteSearch _obj)
        //{
        //    try
        //    {
        //        _cn.Open();
        //        SqlCommand _cmd = new SqlCommand("Institute_Search", _cn);
        //        _cmd.Parameters.AddWithValue("@Created_IP", _obj.CreatedIP);
        //        _cmd.Parameters.AddWithValue("@Type", _obj.Type);
        //        _cmd.Parameters.AddWithValue("@Control", _obj.Control);
        //        _cmd.Parameters.AddWithValue("@InstituteID", _obj.InstituteID);
        //        _cmd.CommandType = CommandType.StoredProcedure;
        //        SqlDataAdapter _adp = new SqlDataAdapter(_cmd);
        //        DataSet _ds = new DataSet();
        //        _adp.Fill(_ds);
        //        _adp.Dispose();
        //        _cmd.Dispose();
        //        return _ds;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        _cn.Close();
        //    }
        //}
        public DataSet OperationInstituteSearch(InstituteSearch _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("Institute_Search", _cn);
                _cmd.Parameters.AddWithValue("@Created_IP", _obj.CreatedIP);
                _cmd.Parameters.AddWithValue("@Type", _obj.Type);
                _cmd.Parameters.AddWithValue("@Control", _obj.Control);
                _cmd.Parameters.AddWithValue("@State", _obj.State);
                _cmd.Parameters.AddWithValue("@ProgramLevel", _obj.ProgramLevel);
                _cmd.Parameters.AddWithValue("@NatureOfCourse", _obj.NatureOfCourse);
                _cmd.Parameters.AddWithValue("@BranchID", _obj.BranchID);
                _cmd.Parameters.AddWithValue("@InstituteType", _obj.InstituteType);
                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.CommandTimeout = 180;
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
        public DataSet InstituteSearchForWebsite(InstituteSearchPara _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("InstituteSearchForWebsite", _cn);
                _cmd.Parameters.AddWithValue("@Created_IP", _obj.Created_Ip);
                _cmd.Parameters.AddWithValue("@Type", _obj.Type);
                _cmd.Parameters.AddWithValue("@Discipline_ID", _obj.Discipline_ID);
                _cmd.Parameters.AddWithValue("@ProgramLevel_Id", _obj.ProgramLevel_Id);
                _cmd.Parameters.AddWithValue("@Qualification_ID", _obj.Qualification_ID);
                _cmd.Parameters.AddWithValue("@CourseOfStudy_ID", _obj.CourseOfStudy_ID);
                _cmd.Parameters.AddWithValue("@InstituteType", _obj.InstituteType);
                _cmd.Parameters.AddWithValue("@InstituteID", _obj.InstituteID);
                _cmd.Parameters.AddWithValue("@ParticipatedYear", _obj.ParticipatedYear);
                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.CommandTimeout = 180;
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
        public DataSet InstituteSearchForWebsite_New(InstituteSearchPara _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("InstituteSearchForWebsite_New", _cn);
                _cmd.Parameters.AddWithValue("@Created_IP", _obj.Created_Ip);
                _cmd.Parameters.AddWithValue("@Type", _obj.Type);
                _cmd.Parameters.AddWithValue("@Discipline_ID", _obj.Discipline_ID);
                _cmd.Parameters.AddWithValue("@ProgramLevel_Id", _obj.ProgramLevel_Id);
                _cmd.Parameters.AddWithValue("@Qualification_ID", _obj.Qualification_ID);
                _cmd.Parameters.AddWithValue("@CourseOfStudy_ID", _obj.CourseOfStudy_ID);
                _cmd.Parameters.AddWithValue("@InstituteType", _obj.InstituteType);
                _cmd.Parameters.AddWithValue("@InstituteID", _obj.InstituteID);
                _cmd.Parameters.AddWithValue("@ParticipatedYear", _obj.ParticipatedYear);
                _cmd.Parameters.AddWithValue("@ID", _obj.ID);
                _cmd.Parameters.AddWithValue("@City", _obj.City);
                _cmd.Parameters.AddWithValue("@State", _obj.State);
                _cmd.Parameters.AddWithValue("@Duration", _obj.Duration);
                _cmd.Parameters.AddWithValue("@TopSearch", _obj.TopSearch);
                if (_obj.StartDate != null)
                {
                    if (_obj.StartDate.Equals(""))
                    {
                        _cmd.Parameters.AddWithValue("@StartDate", DBNull.Value);
                    }
                    else
                    {
                        _cmd.Parameters.AddWithValue("@StartDate", DateTime.ParseExact(_obj.StartDate.ToString(), "dd/MM/yyyy", null));
                    }
                }
                else
                {
                    _cmd.Parameters.AddWithValue("@StartDate", DBNull.Value);
                }
                if (_obj.EndDate != null)
                {
                    if (_obj.EndDate.Equals(""))
                    {
                        _cmd.Parameters.AddWithValue("@EndDate", DBNull.Value);
                    }
                    else
                    {
                        _cmd.Parameters.AddWithValue("@EndDate", DateTime.ParseExact(_obj.EndDate.ToString(), "dd/MM/yyyy", null));
                    }
                }
                else
                {
                    _cmd.Parameters.AddWithValue("@EndDate", DBNull.Value);
                }
                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.CommandTimeout = 180;
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
        #endregion

        #region Grade
        public DataSet SELECT_TBL_GRADE(string Country="")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("select_tbl_grade_details", _cn);
                _cmd.Parameters.AddWithValue("@Country", Country);
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
        #endregion

        #region Fee Waivers and Concessions
        public DataSet SELECT_FEEWAIVER_WEBSITE(string Country = "")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("SELECT_FEEWAIVER_WEBSITE", _cn);
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
        #endregion
    }
}