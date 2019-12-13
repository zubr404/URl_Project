using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using URl_Project.Models;

namespace URl_Project.Service
{
    public class RequestUrlResult
    {
        public bool IsSuccess { get; set; }
        public string ErrorMes { get; set; } = string.Empty;
        public string UrlShortCustomer { get; set; } = string.Empty;
        public UrlModel UrlModelResult { get; set; }
        public List<UrlModel> UrlModelsResult { get; set; }
    }
}
