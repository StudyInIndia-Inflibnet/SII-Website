using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIIModel.Courses
{
    public class Course
    {
        public string ID { get; set; }
        public string InstituteID { get; set; }
        public string Discipline_ID { get; set; }
        public string Natureofcourse_Id { get; set; }
        public string ProgramLevel_Id { get; set; }
        public string Branch_Id { get; set; }
        public string EligibilityCriteria { get; set; }
        public string SeatForForeignStudent { get; set; }
        public string AnnualTutionFees { get; set; }
        public string AnnualBoardingFees { get; set; }
        public string G1SeatWaiver { get; set; }
        public string G2SeatWaiver { get; set; }
        public string G3SeatWaiver { get; set; }
        public string G4SeatWaiver { get; set; }
        public string Credits { get; set; }
        public string CourseDurations { get; set; }
        public string ClassRoomHours { get; set; }
        public string CoursePatterns { get; set; }
        public string CourseDesc { get; set; }
        public string AdmissionReq { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedIP { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedDate { get; set; }
        public string ModifiedIP { get; set; }
        public string ModifiedBy { get; set; }
        public string Discipline { get; set; }
        public string Natureofcourse { get; set; }
        public string ProgramLevel { get; set; }
        public string BranchName { get; set; }
        public string IsGivenFromInstitute { get; set; }
        public string FeesForSAARCCountry { get; set; }
        public string FeesForNonSAARCCountry { get; set; }
        public string AnnualTutionFeesCurrency { get; set; }
        public string AnnualBoardingFeesCurrency { get; set; }
        public string FeesForSAARCCountryCurrency { get; set; }
        public string FeesForNonSAARCCountryCurrency { get; set; }
        public string Branch_Name { get; set; }
        public string Q0Req { get; set; }
        public string Q1Req { get; set; }
        public string Q2Req { get; set; }
        public string Q3Req { get; set; }
        public string Q0Qualification { get; set; }
        public string Q0Subject { get; set; }
        public string Q0Percentage { get; set; }
        public string Q1Qualification { get; set; }
        public string Q1Subject { get; set; }
        public string Q1Percentage { get; set; }
        public string Q2Qualification { get; set; }
        public string Q2Subject { get; set; }
        public string Q2Percentage { get; set; }
        public string Q3Qualification { get; set; }
        public string Q3Subject { get; set; }
        public string Q3Percentage { get; set; }
        public string JEEMainReq { get; set; }
        public string JEEMainscoreReq { get; set; }
        public string JEEAdvanceReq { get; set; }
        public string JEEAdvanceScoreReq { get; set; }
        public string IELTSReq { get; set; }
        public string IELTSscoreReq { get; set; }
        public string GMATReq { get; set; }
        public string GMATScoreReq { get; set; }
        public string TOFELReq { get; set; }
        public string TOFELScoreReq { get; set; }
        public string SATReq { get; set; }
        public string SATScoreReq { get; set; }
        public string GATEReq { get; set; }
        public string GATEScoreReq { get; set; }
        public string Edited_by { get; set; }

        public string EduQualifications { get; set; }
        public string AdditionalExams { get; set; }
        public string ParticipatedYear { get; set; }
    }

    public class mEduQualifications
    {
        public string EduQualifications_Id { get; set; }
        public string EduQualifications { get; set; }
        public string EduQualificationsFor { get; set; }
        public string IsActive { get; set; }
    }
    public class mEduSubject
    {
        public string EduSubject_Id { get; set; }
        public string EduSubject { get; set; }
        public string EduQualifications_Id { get; set; }
        public string EduQualifications { get; set; }
        public string IsActive { get; set; }
    }
    public class mInstituteCourse_EC
    {
        public string ID { get; set; }
        public string InstituteID { get; set; }
        public string InstituteCourseID { get; set; }
        public string EduQualifications_Id { get; set; }
        public string EduQualifications { get; set; }
        public string EduQualificationsFor { get; set; }
        public string EduSubject_Id { get; set; }
        public string EduSubject { get; set; }
        public string PercentageID { get; set; }
        public string Operator { get; set; }
        public string OperatorDisplay { get; set; }
    }
    public class mInstituteCourse_AE
    {
        public string ID { get; set; }
        public string InstituteID { get; set; }
        public string InstituteCourseID { get; set; }
        public string AditionalExams_Id { get; set; }
        public string AditionalExams { get; set; }
        public string AditionalExamsFor { get; set; }
        public string CutOff { get; set; }
        public string CriteriaDate { get; set; }
        public string Operator { get; set; }
        public string OperatorDisplay { get; set; }
    }
    public class mAditionalExamScore
    {
        public string AditionalExamScore_Id { get; set; }
        public string AditionalExamScore { get; set; }
        public string AditionalExamSocreDisplay { get; set; }
        public string AditionalExams_Id { get; set; }
        public string IsActive { get; set; }
    }
    public class NicheCourse
    {
        public string ID { get; set; }
        public string InstituteID { get; set; }
        public string Discipline_ID { get; set; }
        public string Natureofcourse_Id { get; set; }
        public string ProgramLevel_Id { get; set; }
        public string Branch_Id { get; set; }
        public string GenderRestrictions { get; set; }
        public string CourseType { get; set; }
        public string MinimumAgeRequirement { get; set; }
        
        public string NoEligibilitycriteria { get; set; }
        public string EligibilityCriteria { get; set; }

        public string AditionalExamsCriteria { get; set; }
        public string AdditionalFacilities { get; set; }
        public string TutionFeesCurrency { get; set; }
        public string TutionFees { get; set; }
        public string TotalFeesCurrency { get; set; }
        public string TotalFees { get; set; }
        public string TutionFeesForSAARCCountryCurrency { get; set; }
        public string TutionFeesForSAARCCountry { get; set; }
        public string TutionFeesForNonSAARCCountryCurrency { get; set; }

        public string TutionFeesForNonSAARCCountry { get; set; }
        public string AnnualTutionFees { get; set; }
        public string AnnualBoardingFees { get; set; }

        public string Credits { get; set; }
        public string CourseDurations { get; set; }
        public string ClassRoomHours { get; set; }
        public string CoursePatterns { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string tobedecided { get; set; }
        public string CourseDesc { get; set; }
        public string AdmissionReq { get; set; }

        public string MinimumBatchSize { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedIP { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedDate { get; set; }
        public string ModifiedIP { get; set; }
        public string ModifiedBy { get; set; }
        public string Discipline { get; set; }
        public string Natureofcourse { get; set; }
        public string ProgramLevel { get; set; }
        public string BranchName { get; set; }
        public string IsGivenFromInstitute { get; set; } 

        public string Branch_Name { get; set; }
       
        public string Edited_by { get; set; }

        public string EduQualifications { get; set; }
        public string AdditionalExams { get; set; }
        public string InternationalBatchSize { get; set; }
        public string CourseDurationsType { get; set; }

        public string MedicalFitness { get; set; }
        public string MandatoryMedicalExamination { get; set; }
        public string MedicalFitnessDocuments { get; set; }
        public string MedicalFitnessDocumentsOther { get; set; }


        public string HostelAccommodation { get; set; }
        public string Food { get; set; }
        public string AC { get; set; }

        public string ParticipatedYear { get; set; }
    }
}
