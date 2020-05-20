namespace SIIModel.StudentRegister
{
    public class Student_dashbaord
    {
       
        public string FirstName { get; set; }
        
        public string DateOfBirth { get; set; }
        
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Nationality { get; set; }
        public string PassportNo { get; set; }
        public string CitizenshipNumber { get; set; }
        public string Residential { get; set; }
        public string Permanent { get; set; }
        public string StudentRefrenceDetail { get; set; }
        public string AcademicInformation_EC { get; set; }
        public string AcademicInformation_AE { get; set; }
        public string Disciplinelist { get; set; }
        public string TotalChoicefill { get; set; }
        public string Doc_required { get; set; }
        public string Uploded_doc { get; set; }
        public string finalSubmit { get; set; }
        public string IndSATCenter { get; set; }
        public string DocumentVerified { get; set; }
    }
    public class StudentDocumentVerification
    {
        public string ID { get; set; }
        public string name { get; set; }
        public string For { get; set; }
        public string Type { get; set; }
        public string studentid { get; set; }
        public string Path { get; set; }
        public string MainPart { get; set; }
        public string DeciamlPart { get; set; }
        public string EQ_AE_ID { get; set; }
        public string Score { get; set; }
    }
}