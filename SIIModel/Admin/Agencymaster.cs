using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIIModel.Admin
{
    public class Agencymaster
    {
        public string agencyid { get; set; }
        public string nameofagency { get; set; }
        public string agencyaddress { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string countrycode { get; set; }
        public string mobile { get; set; }
        public string typeofagency { get; set; }
        public string createdip { get; set; }
        public string agency_uniq_id { get; set; }
        public string is_change_pass { get; set; }
        public string change_password { get; set; }
        public string change_date { get; set; }

        public string Captchastr { get; set; }

    }
    public class AgencyDetail
    {
        public string id { get; set; }
        public string agencyid { get; set; }
        public string nameofentitlename { get; set; }
        public string fee_g1 { get; set; }
        public string fee_g2 { get; set; }
        public string fee_g3 { get; set; }
        public string fee_g4 { get; set; }
        public string countryid { get; set; }
        public string noofstudent { get; set; }

    }

}
