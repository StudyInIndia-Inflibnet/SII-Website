using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIIModel.Admin
{
    public class mProgrammeLevel
    {
        public string ProgramLevel_Id { get; set; }
        public string ProgramLevel { get; set; }
        public string IsActive { get; set; }
        public string isNicheCourse { get; set; }
    }
    public class mProgrammeLevelMapping
    {
        public string Mpng_ID { get; set; }
        public string Discipline_ID { get; set; }
        public string ProgramLevel_Id { get; set; }
        public string Discipline { get; set; }
        public string ProgramLevel { get; set; }
    }
}
