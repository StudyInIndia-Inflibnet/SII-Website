namespace SIIModel.FrontPanel
{
    public class InstituteSearch : Common
    {
        public string srno { get; set; }
        public string studentid { get; set; }
        public string State { get; set; }
        public string ProgramLevel { get; set; }
        public string NatureOfCourse { get; set; }
        public string BranchID { get; set; }
        public string InstituteType { get; set; }
    }
    public class InstituteSearchPara
    {
        public string Created_By { get; set; }
        public string Created_Ip { get; set; }
        public string Type { get; set; }
        public string Discipline_ID { get; set; }
        public string ProgramLevel_Id { get; set; }
        public string Qualification_ID { get; set; }
        public string CourseOfStudy_ID { get; set; }
        public string InstituteType { get; set; }
        public string InstituteID { get; set; }
        public string ParticipatedYear { get; set; }
        public string ID { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Duration { get; set; }
        public string TopSearch { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }

    }
    public class InstituteSearchVM
    {
        public string InstituteID { get; set; }
        public string InstituteName { get; set; }
        public string Website { get; set; }
        public string StateName { get; set; }
        public string City { get; set; }
        public string Photo { get; set; }
        public string TotalCourse { get; set; }
        public string TotalSeats { get; set; }
        public string Discipline { get; set; }
        public string ProgramLevel { get; set; }
        public string Qualification { get; set; }
        public string CourseOfStudy { get; set; }
        public string TutionFees { get; set; }
        public string TotalFees { get; set; }
        public string TotalFeesCurrency { get; set; }
        public string ID { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }

    }
    public class InstituteSearchFilter
    {
        public string Id { get; set; }
        public string Value { get; set; }
        public string Help { get; set; }
    }
    public class InstituteSearchDropdowns
    {
        public string Id { get; set; }
        public string Value { get; set; }
    }
    public class InstituteSearchResult : Common
    {
        public string InstituteName { get; set; }
        public string instituteweburl { get; set; }
        public string state_name { get; set; }
        public string City { get; set; }
        public string Pin { get; set; }
        public string Address { get; set; }
        public string YOE { get; set; }
        public string description { get; set; }
        public string Photo { get; set; }
        public string NoOfStudentDegreeAward { get; set; }
        public string NoOfStudentStrength { get; set; }
        public string NoOfInterStudentIntake { get; set; }
        public string NoOfResearch { get; set; }
        public string NoOfPatents { get; set; }
        public string NoOfFullTimeStafStrength { get; set; }
        public string NoOfPartTimeStafStrength { get; set; }
        public string CourseCount { get; set; }
        public string AcademicCourses { get; set; }
        public string AreaOfExcellence { get; set; }
        public string SheetCount { get; set; }
        public string FilttredCourseCount { get; set; }
        public string FiltteredSheetCount { get; set; }
    }
}
