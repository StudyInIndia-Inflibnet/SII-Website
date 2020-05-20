using SIIModel.Courses;
using System;
using System.Data;
using System.Data.SqlClient;

namespace SIIRepository.Courses
{
    public class BridgeCourseRepository : Base
    {
        public DataSet OperationCourse(BridgeCourse _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("sp_BridgeCourse", _cn);
                _cmd.Parameters.AddWithValue("@ID", _obj.ID);
                _cmd.Parameters.AddWithValue("@InstituteID", _obj.InstituteID);
                _cmd.Parameters.AddWithValue("@CourseName", _obj.CourseName);
                _cmd.Parameters.AddWithValue("@Language", _obj.Language);
                _cmd.Parameters.AddWithValue("@Duration", _obj.Duration);
                _cmd.Parameters.AddWithValue("@DurationType", _obj.DurationType);
                _cmd.Parameters.AddWithValue("@NumberOfSeats", _obj.NumberOfSeats);
                _cmd.Parameters.AddWithValue("@FeesForSAARCCountry", _obj.FeesForSAARCCountry);
                _cmd.Parameters.AddWithValue("@FeesForNonSAARCCountry", _obj.FeesForNonSAARCCountry);
                _cmd.Parameters.AddWithValue("@FeesForSAARCCountryCurrency", _obj.FeesForSAARCCountryCurrency);
                _cmd.Parameters.AddWithValue("@FeesForNonSAARCCountryCurrency", _obj.FeesForNonSAARCCountryCurrency);
                _cmd.Parameters.AddWithValue("@G1SeatWaiver", _obj.G1SeatWaiver);
                _cmd.Parameters.AddWithValue("@G2SeatWaiver", _obj.G2SeatWaiver);
                _cmd.Parameters.AddWithValue("@G3SeatWaiver", _obj.G3SeatWaiver);
                _cmd.Parameters.AddWithValue("@G4SeatWaiver", _obj.G4SeatWaiver);
                _cmd.Parameters.AddWithValue("@ClassRoomHours", _obj.ClassRoomHours);
                _cmd.Parameters.AddWithValue("@TypeOfFees", _obj.TypeOfFees);
                _cmd.Parameters.AddWithValue("@TotalFeesBridgeCourseCurrency", _obj.TotalFeesBridgeCourseCurrency);
                _cmd.Parameters.AddWithValue("@TotalFeesBridgeCourse", _obj.TotalFeesBridgeCourse);
                _cmd.Parameters.AddWithValue("@CreatedIP", _obj.CreatedIP);
                _cmd.Parameters.AddWithValue("@Type", _obj.Type);
                _cmd.Parameters.AddWithValue("@Control", _obj.Control);
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
    }
}
