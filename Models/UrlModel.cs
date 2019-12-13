using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace URl_Project.Models
{
    public class UrlModel
    {
        public int ID { get; set; }
        public string UrlLong { get; set; }
        public string UrlShort { get; set; }
        public DateTime DateTimeInput { get; set; }
        public int NumberClick { get; set; }
    }
}
