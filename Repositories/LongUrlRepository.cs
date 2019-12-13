using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using URl_Project.Interfaces;
using URl_Project.Models;

namespace URl_Project.Repositories
{
    public class LongUrlRepository : IRepository<LongUrl>
    {
        private readonly UrlContext db;

        public LongUrlRepository(UrlContext context)
        {
            this.db = context;
        }
        public void Create(LongUrl item)
        {
            db.LongUrls.Add(item);
        }

        public void Delete(int id)
        {
            LongUrl url = db.LongUrls.Find(id);
            if(url != null) { db.LongUrls.Remove(url); }
        }

        public IEnumerable<LongUrl> Find(Func<LongUrl, bool> predicate)
        {
            return db.LongUrls.Where(predicate).ToList();
        }

        public LongUrl Get(int id)
        {
            return db.LongUrls.Find(id);
        }

        public IEnumerable<LongUrl> GetAll()
        {
            return db.LongUrls;
        }

        public void Update(LongUrl item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
