using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace URl_Project.Models
{
    public class UrlContext : DbContext
    {
        public DbSet<UrlModel> UrlModels { get; set; }

        public UrlContext(DbContextOptions<UrlContext> options):base(options)
        {

        }
    }
}
