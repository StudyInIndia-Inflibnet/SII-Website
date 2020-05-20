using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIIModel.StudentRegister
{
    public class mWebhook
    {
        public string reason { get; set; }
        public string message { get; set; }
    }
    public class mWebhookRequestRegistration
    {
        public string timestamp { get; set; }
        public string user_id { get; set; }
        public string userName { get; set; }
        public string emailID { get; set; }
        public string @event { get; set; }
        public string activationLink { get; set; }
        public string Country { get; set; }
        public string country_code { get; set; }
        public string mobile { get; set; }
        public string whatsapp_consent { get; set; }
    }
    public class mWebhookRequestSubmission
    {
        public string timestamp { get; set; }
        public string user_id { get; set; }
        public string userName { get; set; }
        public string emailID { get; set; }
        public string @event { get; set; }
    }
    public class mWebhookRequestForgot
    {
        public string timestamp { get; set; }
        public string user_id { get; set; }
        public string userName { get; set; }
        public string emailID { get; set; }
        public string new_password { get; set; }
        public string @event { get; set; }
    }
}
