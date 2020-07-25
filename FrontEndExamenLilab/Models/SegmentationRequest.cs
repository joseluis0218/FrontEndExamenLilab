using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontEndExamenLilab.Models
{
    public class SegmentationRequest
    {
        public string segmentationName { get; set; }
        public int? segmentationId { get; set; }
        public int[] clients { get; set; }
    }
}