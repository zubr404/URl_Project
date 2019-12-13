using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using URl_Project.Interfaces;
using URl_Project.Models;

namespace URl_Project.Service
{
    public class SummaryData
    {
        public int ID { get; set; }
        public string LongUrl { get; set; }
        public string ShortUrl { get; set; }
        public int NumberClick { get; set; }
    }
}
