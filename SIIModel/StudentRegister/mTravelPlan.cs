using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIIModel.StudentRegister
{
    public class mTravelPlan
    {
    }
    public class mTravelPlanPassport
    {
        public string ID { get; set; }
        public string StudentID { get; set; }
        public string ApplicationNo { get; set; }
        public string HaveValidPassport { get; set; }
        public string PassportNumber { get; set; }
        public string PassportExpiryDate { get; set; }
        public string PassportDocument { get; set; }
        public string ApplicationNumber { get; set; }
        public string ApplicationDocument { get; set; }
        public string CitizenshipNumber { get; set; }
        public string CitizenshipIssueDate { get; set; }
        public string CitizenshipDocument { get; set; }
        public string CreatedIP { get; set; }
    }
    public class mTravelPlanAirTicket
    {
        public string ID { get; set; }
        public string StudentID { get; set; }
        public string ApplicationNo { get; set; }
        public string HaveBookedTicket { get; set; }
        public string LandingDate { get; set; }
        public string LandingTime { get; set; }
        public string OriginCountry { get; set; }
        public string OriginAirport { get; set; }
        public string OtherOriginAirport { get; set; }
        public string DestinationCountry { get; set; }
        public string DestinationAirport { get; set; }
        public string OtherDestinationAirport { get; set; }
        public string ETicket { get; set; }
        public string CreatedIP { get; set; }
    }
    public class mTravelPlanVisa
    {
        public string ID { get; set; }
        public string StudentID { get; set; }
        public string ApplicationNo { get; set; }
        public string HaveIndianStudentVisa { get; set; }
        public string VisaNumber { get; set; }
        public string ExpiryDate { get; set; }
        public string VisaType { get; set; }
        public string VisaDocument { get; set; }
        public string VisaApplicationNumber { get; set; }
        public string VisaApplicationDocument { get; set; }
        public string CreatedIP { get; set; }
    }
    public class mTravelPlanInstituteSpoc
    {
        public string ID { get; set; }
        public string ProgramLevel { get; set; }
        public string NameOfSpoc { get; set; }
        public string StudentIDs { get; set; }
        public string InstituteID { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string DocumentName1 { get; set; }
        public string OtherDocumentName1 { get; set; }
        public string DoumentPath1 { get; set; }
        public string DocumentName2 { get; set; }
        public string OtherDocumentName2 { get; set; }
        public string DoumentPath2 { get; set; }
        public string DocumentName3 { get; set; }
        public string OtherDocumentName3 { get; set; }
        public string DoumentPath3 { get; set; }
        public string DocumentName4 { get; set; }
        public string OtherDocumentName4 { get; set; }
        public string DoumentPath4 { get; set; }
        public string DocumentName5 { get; set; }
        public string OtherDocumentName5 { get; set; }
        public string DoumentPath5 { get; set; }
        public string CreatedIP { get; set; }
    }
    public class mTravelPlanAirports
    {
        public string ID { get; set; }
        public string name { get; set; }
        public string Country_ID { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string iso_country { get; set; }
    }
}
