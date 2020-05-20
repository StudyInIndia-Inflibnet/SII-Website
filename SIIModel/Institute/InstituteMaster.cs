using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIIModel.Institute
{
    public class InstituteMaster
    {
        public string ID { get; set; }
        public string InstituteID { get; set; }
        public string InstituteName { get; set; }
        public string Email { get; set; }
        public string AccessURL { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Pin { get; set; }
        public string YOE { get; set; }
        public string IsActivated { get; set; }
        public string IsActivatedDate { get; set; }
        public string IsPasswordChanged { get; set; }
        public string DefaultPassword { get; set; }
        public string Password { get; set; }
        public string History { get; set; }
        public string Awards { get; set; }
        public string Fellows { get; set; }
        public string News { get; set; }
        public string Area { get; set; }
        public string ProgramOffered { get; set; }
        public string IsSubmited { get; set; }
        public string Description { get; set; }
        public string AcademicCourses { get; set; }
        public string AreaOfExcellence { get; set; }
        public string ResearchCapability { get; set; }
        public string FacultyOverview { get; set; }
        public string NotableResearchPublication { get; set; }
        public string NIRFRanking { get; set; }
        public string NBANAACAccreditation { get; set; }
        public string NBARanking { get; set; }
        public string CreatedIP { get; set; }
        public string ModifiedIP { get; set; }
        public string Captchastr { get; set; }
        public string instituteweburl { get; set; }
        public string Edited_by { get; set; }
    }
    public class mNodalHeadOfficers
    {
        public string ID { get; set; }
        public string InstituteID { get; set; }
        public string HeadPrefix { get; set; }
        public string HeadFirstName { get; set; }
        public string HeadLastName { get; set; }
        public string HeadEmail { get; set; }
        public string HeadMobile { get; set; }
        public string HeadDesignation { get; set; }
        public string HeadPhone { get; set; }
        public string NodalPrefix { get; set; }
        public string NodalFirstName { get; set; }
        public string NodalLastName { get; set; }
        public string NodalEmail { get; set; }
        public string NodalMobile { get; set; }
        public string NodalDesignation { get; set; }
        public string NodalPhone { get; set; }
        public string CreatedIP { get; set; }
        public string ModifiedIP { get; set; }
        public string Password { get; set; }
    }

}
