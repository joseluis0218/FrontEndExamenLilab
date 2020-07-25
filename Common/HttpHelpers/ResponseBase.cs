using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.HttpHelpers
{
    public class ResponseBase<T>
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public T Object { get; set; }
        public List<T> List { get; set; }
        public string ErrorMessage { get; set; }
        public Exception Exception { get; set; }
    }
}
