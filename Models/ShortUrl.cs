using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace URl_Project.Models
{
    public class ShortUrl
    {
        public int ID { get; set; }
        public int ID_Url { get; set; }
        public string Url { get; set; }
        public DateTime DateTimeInput { get; set; }
        public bool IsActive { get; set; }
        public int NumberClick { get; set; }
    }
}
