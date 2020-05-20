using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIIModel.Institute
{
    public class InstituteInfrascuture
    {
        public string ID { get; set; }
        public string InstituteID { get; set; }
        public string Area { get; set; }
        public string ITInfrastructure { get; set; }
        public string ITInfrastructureWifiFacility { get; set; }
        public string AcademicFacilities { get; set; }
        public string Database { get; set; }
        public string elibrary { get; set; }
        public string ResearchFacilitiesLabs { get; set; }
        public string Accommodation { get; set; }
        public string AccommodationWifi { get; set; }
        public string CuisineServedInMess { get; set; }
        public string CuisinesOfFoodServed { get; set; }
        public string Doctors { get; set; }
        public string Pharmacy { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedIP { get; set; }
        public string ModifiedDate { get; set; }
        public string ModifiedIP { get; set; }

        public string Edited_by { get; set; }
    }
    public class LifeOnCampus
    {
        public string ID { get; set; }
        public string InstituteID { get; set; }
        public string SportArea { get; set; }
        public string TypesOfSportsCurrentlyPlayed { get; set; }
        public string SportAccomplishments { get; set; }
        public string MusicInstruments { get; set; }
        public string MusicAccomplishments { get; set; }
        public string AcademicBodie { get; set; }
        public string FestivalsConductedByStudents { get; set; }
        public string NewsLatters { get; set; }
        public string EventsCompetitions { get; set; }
        public string OfficialEvents { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedIP { get; set; }
        public string ModifiedDate { get; set; }
        public string ModifiedIP { get; set; }
        public string Edited_by { get; set; }
    }
    public class LifeOutsideCampus
    {
        public string ID { get; set; }
        public string InstituteID { get; set; }
        public string PlacesToVisit { get; set; }
        public string ThingsToDo { get; set; }
        public string LocalLanguages { get; set; }
        public string LocalCulture { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedIP { get; set; }
        public string ModifiedDate { get; set; }
        public string ModifiedIP { get; set; }
        public string Edited_by { get; set; }
    }
}
