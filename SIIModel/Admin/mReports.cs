using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIIModel.Admin
{
    public class mReports
    {
    }
    public class mReportsRegisteredStudents
    {
        public string Srno { get; set; }
        public string StudentID { get; set; }
        public string StudentName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Country_Name { get; set; }
        public string RegistrationDate { get; set; }
        public string SubmitChoiceFill { get; set; }
        public string SubmitChoiceFillingDate { get; set; }
        public string EditApplication { get; set; }
        public string EditApplicationDate { get; set; }
        public string FilledChoices { get; set; }
    }
}
