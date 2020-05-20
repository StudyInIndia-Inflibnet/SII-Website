using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIIModel.Courses
{
    public class BridgeCourse : Common
    {
        public string CourseName { get; set; }
        public string Language { get; set; }
        public string Duration { get; set; }
        public string DurationType { get; set; }
        public string NumberOfSeats { get; set; }
        public string FeesForSAARCCountry { get; set; }
        public string FeesForNonSAARCCountry { get; set; }
        public string G1SeatWaiver { get; set; }
        public string G2SeatWaiver { get; set; }
        public string G3SeatWaiver { get; set; }
        public string G4SeatWaiver { get; set; }
        public string ClassRoomHours { get; set; }
        public string FeesForSAARCCountryCurrency { get; set; }
        public string FeesForNonSAARCCountryCurrency { get; set; }
        public string TypeOfFees { get; set;}
        public string TotalFeesBridgeCourseCurrency { get; set;}
        public string TotalFeesBridgeCourse { get; set;}
        public string Edited_by { get; set; }
    }
}
