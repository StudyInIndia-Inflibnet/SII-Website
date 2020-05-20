using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIIModel.Admin
{
    public class mPhase3
    {
        public string AdminUsersID { get; set; }
        public string AdminUsersName { get; set; }
        public string AdminUsersEmail { get; set; }
        public string Username { get; set; }
        public string IsSuperAdmin { get; set; }
        public string Random { get; set; }
        public string Password { get; set; }
        public string IsPasswordChanged { get; set; }
        public string PasswordChangedDate { get; set; }
        public string CreatedIP { get; set; }
        public string MacAddress { get; set; }
        public string CaptchaStr { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
