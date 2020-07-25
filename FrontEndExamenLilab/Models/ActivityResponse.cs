using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontEndExamenLilab.Models
{
    public class ActivityResponse
    {
        public int id { get; set; }
        public string description { get; set; }
        public DateTime? activityDate { get; set; }
        public ClientModel Client { get; set; }
    }
}