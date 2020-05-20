using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIIModel.StudentRegister
{
    public class mStudent_Ch_Basic
    {
        public string ID { get; set; }
        public string studentid { get; set; }
        public string ApplicationNo { get; set; }
        public string EduQualifications { get; set; }
        public string AdditionalExams { get; set; }
        public string SelectedDisciplines { get; set; }
        public string SelectedProgramLevel { get; set; }
        public string CreatedIP { get; set; }
    }
    public class mStudent_Ch_Basic_AE
    {
        public string ID { get; set; }
        public string studentid { get; set; }
        public string ApplicationNo { get; set; }
        public string IsGiven { get; set; }
        public string AEName { get; set; }
        public string AEID { get; set; }
        public string Score { get; set; }
        public string CreatedIP { get; set; }
    }
    public class mStudent_Ch_Basic_EC
    {
        public string ID { get; set; }
        public string studentid { get; set; }
        public string ApplicationNo { get; set; }
        public string IsGiven { get; set; }
        public string EQName { get; set; }
        public string EQID { get; set; }
        public string MainPart { get; set; }
        public string DeciamlPart { get; set; }
        public string CreatedIP { get; set; }
    }

    public class mStudent_Ch_SelectedDisciplines
    {
        public string ID { get; set; }
        public string studentid { get; set; }
        public string ApplicationNo { get; set; }
        public string Discipline_ID { get; set; }
        public string ProgrammeLevel_IDs { get; set; }
        public string CreatedIP { get; set; }
    }
    public class mStudent_ch_choiceFilling
    {
        public string Discipline { get; set; }
        public string ProgramLevel { get; set; }
        public string NameofCourse { get; set; }
        public string Specialization { get; set; }
        public string InstituteID { get; set; }
        public string id { get; set; }
        public string Type { get; set; }
        public string Control { get; set; }
        public string ip { get; set; }
        public string Eligibility { get; set; }
        public string AdditionalEligibility { get; set; }

        public string InstituteName { get; set; }
        public string studentID { get; set; }
        public string Coursename { get; set; }
    }
    public class mStudent_ch_choiceFilling_result
    {
        public string ID { get; set; }
        public string Srno { get; set; }
        public string InstituteID { get; set; }
        public string InstituteName { get; set; }
        public string InstituteType { get; set; }
        public string Discipline { get; set; }
        public string ProgramLevel { get; set; }
        public string Coursename { get; set; }
        public string Specialization { get; set; }
        public string Eligibility { get; set; }
        public string AdditionalEligibility { get; set; }
    }
    public class mStudent_Ch_Choice_Filling_Save
    {
        public string studentid { get; set; }
        public string ApplicationNo { get; set; }
        public string InstituteID { get; set; }
        public string InstituteCourse_ID { get; set; }
        public string Discipline_Id { get; set; }
        public string ProgramLevel_Id { get; set; }
        public string NatureOfCourse_Id { get; set; }
        public string Branch_Course_Id { get; set; }
        public string SequenceNumber { get; set; }
        public string CreatedIP { get; set; }
        public string Stud_Ch_EC { get; set; }
        public string Stud_Ch_AE { get; set; }
    }
    public class mStudent_Ch_Choice_Filling_Saved_List
    {
        public string id { get; set; }
        public string studentid { get; set; }
        public string ApplicationNo { get; set; }
        public string InstituteID { get; set; }
        public string InstituteName { get; set; }
        public string InstituteCourse_ID { get; set; }
        public string InstituteCourseName { get; set; }
        public string SequenceNumber { get; set; }
        public string InstituteType { get; set; }
        public string Discipline { get; set; }
        public string ProgramLevel { get; set; }
        public string Coursename { get; set; }
        public string Specialization { get; set; }
    }
    public class mStudent_Ch_Choice_Filling_Swap
    {
        public string id { get; set; }
        public string studentid { get; set; }
        public string ApplicationNo { get; set; }
        public string Created_By { get; set; }
        public string Type { get; set; }
        public string drpformid { get; set; }
        public string drptoid { get; set; }
        public string CreatedIp { get; set; }
    }
    public class mStudent_Ch_Doc_Upload
    {
        public string id { get; set; }
        public string studentid { get; set; }
        public string ApplicationNo { get; set; }
        public string EQ_AE_Name { get; set; }
        public string EQ_AE_ID { get; set; }
        public string EQ_AE_For { get; set; }
        public string Path { get; set; }
        public string CreatedIP { get; set; }
    }
}
