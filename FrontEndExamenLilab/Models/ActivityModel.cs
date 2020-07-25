using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontEndExamenLilab.Models
{
    public class ActivityModel
    {
        public int id { get; set; }
        public string description { get; set; }
        public DateTime? activityDate { get; set; }
        public int? clientId { get; set; }

    }
}