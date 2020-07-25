using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontEndExamenLilab.Models
{
    public class ClientRequest
    {
        public int? lastVisitMonth { get; set; }
        public int? birthdayMonth { get; set; }
        public string activity { get; set; }

    }
}