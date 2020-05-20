using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIIModel.Admin
{
    public class mDocumentVerification
    {
        public string ID { get; set; }
        public string studentid { get; set; }
        public string StudentName { get; set; }
        public string Country_Name { get; set; }
        public string ProgramLevel { get; set; }
    }
    public class mDocumentVerificationView
    {
        public string Srno { get; set; }
        public string studentid { get; set; }
        public string StudentName { get; set; }
        public string Country_Name { get; set; }
        public string ProgramLevel { get; set; }
        public string IsVerified { get; set; }
        public string VerifiedDate { get; set; }
    }
}
