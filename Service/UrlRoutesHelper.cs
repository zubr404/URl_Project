using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace URl_Project.Service
{
    public class UrlRoutesHelper
    {
        public const string ROUTEHOST = "http://localhost:44300/";
        public const string ROUTECONTROLLER = "api/Url";
        public const string ROUTEGETURLS = "geturls";
        public const string ROUTEGETURL = "geturl/{id}";
        public const string ROUTECREATEURL = "create";
        public const string ROUTEDELETEURL = "{id}";
        public const string ROUTEREDIRECTURL = "{id}";

    }
}
