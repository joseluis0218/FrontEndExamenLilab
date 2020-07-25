using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.HttpHelpers
{
    public class ConstantURL
    {
        public static string ApiCore = ConfigurationManager.AppSettings["ApiCoreDev"];

    }
}
