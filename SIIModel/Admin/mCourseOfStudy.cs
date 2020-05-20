using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIIModel.Admin
{
    public class mCourseOfStudy
    {
        public string CourseOfStudy_ID { get; set; }
        public string CourseOfStudy { get; set; }
        public string IsActive { get; set; }
        public string IsNicheCourse { get; set; }
    }
    public class mCourseOfStudyMapping
    {
        public string Branch_Id { get; set; }
        public string Natureofcourse_Id { get; set; }
        public string Qualification_ID { get; set; }
        public string Mpng_ID { get; set; }
        public string Discipline_ID { get; set; }
        public string ProgramLevel_Id { get; set; }
        public string Discipline { get; set; }
        public string ProgramLevel { get; set; }
        public string CourseOfStudy_ID { get; set; }
        public string CourseOfStudy { get; set; }
        public string IsNicheCourse { get; set; }
    }
}
