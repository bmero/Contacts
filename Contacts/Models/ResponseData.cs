using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.Models
{
    public class ResponseData
    {
        public string status { get; set; }
        public string message { get; set; }
        public int statusCode { get; set; }
        public string data { get; set; }
    }

}
