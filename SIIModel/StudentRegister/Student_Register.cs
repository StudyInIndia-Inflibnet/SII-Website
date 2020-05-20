namespace SIIModel.StudentRegister
{
    public class Student_Register
    {
        public string srno { get; set; }
        public string instituteid { get; set; }
        public string studentid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string CountryCode { get; set; }
        public string Nationality { get; set; }
        public string CountryToStay { get; set; }
        public string IsvalidPassport { get; set; }
        public string PassportNo { get; set; }
        public string IssuingAuthority { get; set; }
        public string PassportExpDate { get; set; }
        public string ApplyForPassport { get; set; }
        public string AgreeTermsConditions { get; set; }
        public string Random { get; set; }
        public string IsPasswordChanged { get; set; }
        public string ActualPassword { get; set; }
        public string Created_By { get; set; }
        public string Created_Ip { get; set; }
        public string Country { get; set; }
        public string Captchastr { get; set; }
        public string StrJson { get; set; }
        public string PassportIssueCountry { get; set; }
        public string NameasperPassport { get; set; }
        public string student_path { get; set; }
        public string bCopyAddress { get; set; }

        public string Name { get; set; }
        public string Designation { get; set; }
        public string Institute_employer_name { get; set; }
        public string ContactNo { get; set; }
        public string PassportFileReferenceNumber { get; set; }
        public string RefAddress { get; set; }
        public string RefCountry { get; set; }
        public string RefState { get; set; }
        public string RefCity { get; set; }
        public string RefArea { get; set; }

        public string gov_scheme_id { get; set; }
        public string agency_det_id { get; set; }
        public string bulk_reg { get; set; }

        public string HaveCitizenshipNumber { get; set; }
        public string CitizenshipNumber { get; set; }

        public string Date { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public string ApplyingForCourse { get; set; }
        public string PresentProfession { get; set; }
        public string NicheCourseID { get; set; }
        public string Phase { get; set; }
        public string ParticipatedYear { get; set; }

        public string Photo { get; set; }
        public string Signature { get; set; }
        public string Type { get; set; }
        public string whatsapp_consent { get; set; }
    }
    public class Student_AddressDetails
    {
        public string srno { get; set; }
        public string instituteid { get; set; }
        public string studentid { get; set; }
        public string AddressType { get; set; }
        public string Addressline1 { get; set; }
        public string Addressline2 { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Area { get; set; }
        public string City_name { get; set; }
        public string State_name { get; set; }

    }
    public class StudentAcademic_information
    {
        public string studentid { get; set; }
        public string Degree_name { get; set; }
        public string board_uni_name { get; set; }
        public string passing_year { get; set; }
        public string Marks_obtains { get; set; }
        public string min_marks { get; set; }
        public string subject_studied { get; set; }
        public string country_id { get; set; }
        public string address { get; set; }
        public string Created_By { get; set; }
        public string Created_Date { get; set; }
        public string Created_Ip { get; set; }
        public string strjson { get; set; }
        public string Education_Qualification_Name { get; set; }
        public string jeemain { get; set; }
        public string jeemainscore { get; set; }
        public string jeeadvance { get; set; }
        public string jeeadvancescore { get; set; }

        public string ielts { get; set; }
        public string ieltsscore { get; set; }

        public string GMAT { get; set; }
        public string GMATscore { get; set; }

        public string TOFEL { get; set; }
        public string TOFELscore { get; set; }
        public string SAT { get; set; }
        public string SATscore { get; set; }
        public string experience { get; set; }
        public string experiencescore { get; set; }
        public string TotalMarksinPercentage { get; set; }
        public string GradeConversionDocument { get; set; }
        public string NameofCourse { get; set; }
        public string Academicinformationid { get; set; }
        public string country_name { get; set; }
        public string gov_scheme_id { get; set; }
        public string ProgramLevel { get; set; }


    }
}