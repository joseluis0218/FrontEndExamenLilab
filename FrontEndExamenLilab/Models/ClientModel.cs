using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontEndExamenLilab.Models
{
    public class ClientModel
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public DateTime? birthdayDate { get; set; }
    }
}