using SIIModel.Institute;
using System;
using System.Data;
using System.Data.SqlClient;

namespace SIIRepository.Institute
{
    public class InstituteStudentsFacilityRepository : Base
    {
        public DataSet InstituteStudentsFacility_Select(InstituteStudentsFacility _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("sp_Select_tbl_InstituteStudentsFacility", _cn);
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
        public DataSet InstituteStudentsFacility_Insert(InstituteStudentsFacility _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("sp_Insert_tbl_InstituteStudentsFacility", _cn);
                _cmd.Parameters.AddWithValue("@ID", _obj.ID);
                _cmd.Parameters.AddWithValue("@InstituteID", _obj.InstituteID);
                _cmd.Parameters.AddWithValue("@HasCellOffice", _obj.HasCellOffice);
                _cmd.Parameters.AddWithValue("@CellOfficeDesc", _obj.CellOfficeDesc);
                _cmd.Parameters.AddWithValue("@HasVisaAssistance", _obj.HasVisaAssistance);
                _cmd.Parameters.AddWithValue("@VisaAssistanceDesc", _obj.VisaAssistanceDesc);
                _cmd.Parameters.AddWithValue("@OtherFacility", _obj.OtherFacility);

                _cmd.Parameters.AddWithValue("@HasCulturalEngagement", _obj.HasCulturalEngagement);
                _cmd.Parameters.AddWithValue("@HasStudentBoarding", _obj.HasStudentBoarding);
                _cmd.Parameters.AddWithValue("@HasArrival", _obj.HasArrival);

                _cmd.Parameters.AddWithValue("@HasMentor", _obj.HasMentor);
                _cmd.Parameters.AddWithValue("@IntroProgram", _obj.IntroProgram);
                _cmd.Parameters.AddWithValue("@ContactPersonName", _obj.ContactPersonName);

                _cmd.Parameters.AddWithValue("@ContactPersonEmail", _obj.ContactPersonEmail);
                _cmd.Parameters.AddWithValue("@ContactPersonMobile", _obj.ContactPersonMobile);
                _cmd.Parameters.AddWithValue("@ContactPersonPhone", _obj.ContactPersonPhone);
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
        public DataSet InstituteStudentsFacility_Delete(InstituteStudentsFacility _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("sp_Delete_tbl_InstituteStudentsFacility", _cn);
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
