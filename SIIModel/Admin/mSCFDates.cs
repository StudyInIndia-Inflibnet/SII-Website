using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIIModel.Admin
{
    public class mSCFDates
    {
        public string ProgrammeLevel { get; set; }
        public string ClosingDate { get; set; }
        public string StartingDateApproveReject { get; set; }
        public string ClosingDateApproveReject { get; set; }
    }
    public class mSCFDatesSave
    {
        public string Type { get; set; }
        public string StudentChoiceFillingDateTime { get; set; }
        public string UG_ClosingDate { get; set; }
        public string UG_ApproveReject_StartDate { get; set; }
        public string UG_ApproveReject_EndDate { get; set; }
        public string PG_ClosingDate { get; set; }
        public string PG_ApproveReject_StartDate { get; set; }
        public string PG_ApproveReject_EndDate { get; set; }
        public string PhD_ClosingDate { get; set; }
        public string PhD_ApproveReject_StartDate { get; set; }
        public string PhD_ApproveReject_EndDate { get; set; }
    }
}
