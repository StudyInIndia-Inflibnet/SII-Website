using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIIModel.Admin
{
    public class mBlogPost
    {
        public string Blog_Id { get; set; }
        public string BlogTitle { get; set; }
        public string UniqueCode { get; set; }
        public string BlogContent { get; set; }
        public string BlogImage { get; set; }
        public string BlogTag { get; set; }
        public string BlogMetaTags { get; set; }
        public string BlogMetaDescription { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedIP { get; set; }
    }

}
