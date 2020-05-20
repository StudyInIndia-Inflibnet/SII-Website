using SIIModel.Institute;
using System;
using System.Data;
using System.Data.SqlClient;

namespace SIIRepository.Institute
{
    public class InstituteInfrascutureRepository : Base
    {
        #region Infrastucture
        public DataSet Save_Campus_Infrastructure(InstituteInfrascuture _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("sp_Insert_Update_Institute_Campus_Infrastructure", _cn);
                _cmd.Parameters.AddWithValue("@InstituteID", _obj.InstituteID);
                _cmd.Parameters.AddWithValue("@Area", _obj.Area);
                _cmd.Parameters.AddWithValue("@ITInfrastructure", _obj.ITInfrastructure);
                _cmd.Parameters.AddWithValue("@ITInfrastructureWifiFacility", _obj.ITInfrastructureWifiFacility);
                _cmd.Parameters.AddWithValue("@AcademicFacilities", _obj.AcademicFacilities);
                _cmd.Parameters.AddWithValue("@Database", _obj.Database);
                _cmd.Parameters.AddWithValue("@elibrary", _obj.elibrary);
                _cmd.Parameters.AddWithValue("@ResearchFacilitiesLabs", _obj.ResearchFacilitiesLabs);
                _cmd.Parameters.AddWithValue("@Accommodation", _obj.Accommodation);
                _cmd.Parameters.AddWithValue("@AccommodationWifi", _obj.AccommodationWifi);
                _cmd.Parameters.AddWithValue("@CuisineServedInMess", _obj.CuisineServedInMess);
                _cmd.Parameters.AddWithValue("@CuisinesOfFoodServed", _obj.CuisinesOfFoodServed);
                _cmd.Parameters.AddWithValue("@Doctors", _obj.Doctors);
                _cmd.Parameters.AddWithValue("@Pharmacy", _obj.Pharmacy);
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
        public DataSet Select_Campus_Infrastructure(string InstituteID = "")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("sp_Select_Institute_Campus_Infrastructure", _cn);
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
        #endregion

        #region Life On Campus
        public DataSet Save_Campus_Life_On_Campus(LifeOnCampus _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("sp_Insert_Update_Institute_Life_On_Campus", _cn);
                _cmd.Parameters.AddWithValue("@InstituteID", _obj.InstituteID);
                _cmd.Parameters.AddWithValue("@SportArea", _obj.SportArea);
                _cmd.Parameters.AddWithValue("@TypesOfSportsCurrentlyPlayed", _obj.TypesOfSportsCurrentlyPlayed);
                _cmd.Parameters.AddWithValue("@SportAccomplishments", _obj.SportAccomplishments);
                _cmd.Parameters.AddWithValue("@MusicInstruments", _obj.MusicInstruments);
                _cmd.Parameters.AddWithValue("@MusicAccomplishments", _obj.MusicAccomplishments);
                _cmd.Parameters.AddWithValue("@AcademicBodie", _obj.AcademicBodie);
                _cmd.Parameters.AddWithValue("@FestivalsConductedByStudents", _obj.FestivalsConductedByStudents);
                _cmd.Parameters.AddWithValue("@NewsLatters", _obj.NewsLatters);
                _cmd.Parameters.AddWithValue("@EventsCompetitions", _obj.EventsCompetitions);
                _cmd.Parameters.AddWithValue("@OfficialEvents", _obj.OfficialEvents);
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
        public DataSet Select_Campus_Life_On_Campus(string InstituteID = "")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("sp_Select_Institute_Life_On_Campus", _cn);
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
        #endregion

        #region Life Outside Campus
        public DataSet Save_Campus_Life_Outside_Campus(LifeOutsideCampus _obj)
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("sp_Insert_Update_Institute_Life_Outside_Campus", _cn);
                _cmd.Parameters.AddWithValue("@InstituteID", _obj.InstituteID);
                _cmd.Parameters.AddWithValue("@PlacesToVisit", _obj.PlacesToVisit);
                _cmd.Parameters.AddWithValue("@ThingsToDo", _obj.ThingsToDo);
                _cmd.Parameters.AddWithValue("@LocalLanguages", _obj.LocalLanguages);
                _cmd.Parameters.AddWithValue("@LocalCulture", _obj.LocalCulture);
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
        public DataSet Select_Campus_Life_Outside_Campus(string InstituteID = "")
        {
            try
            {
                _cn.Open();
                SqlCommand _cmd = new SqlCommand("sp_Select_Institute_Life_Outside_Campus", _cn);
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
        #endregion
    }
}
