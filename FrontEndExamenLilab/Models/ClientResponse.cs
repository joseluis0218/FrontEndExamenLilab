using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontEndExamenLilab.Models
{
    public class ClientResponse
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string birthdayDate { get; set; }
        public string lastActivityDate { get; set; }
        public string description { get; set; }
    }
}