using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using URl_Project.Interfaces;
using URl_Project.Models;
using URl_Project.Logging;

namespace URl_Project.Repositories
{
    public class UrlModelRepository : IRepository<UrlModel>
    {
        private readonly UrlContext db;
        private readonly ILogger logger;

        public UrlModelRepository(UrlContext context, ILoggerFactory loggerFactory)
        {
            this.db = context;
            loggerFactory.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "logger.txt"));
            logger = loggerFactory.CreateLogger("FileLogger");
        }
        public void Create(UrlModel item)
        {
            db.UrlModels.Add(item);
        }

        public void Delete(int id)
        {
            UrlModel url = db.UrlModels.Find(id);
            if (url != null) { db.UrlModels.Remove(url); }
        }

        public List<UrlModel> Find(Func<UrlModel, bool> predicate)
        {
            try
            {
                return db.UrlModels.Where(predicate).ToList();
            }
            catch (ArgumentNullException ex)
            {
                logger.LogInformation(ex.Message);
                return new List<UrlModel>();
            }
        }

        public UrlModel Get(int id)
        {
            return db.UrlModels.Find(id);
        }

        public List<UrlModel> GetAll()
        {
            //logger.LogInformation("Данные успешно загружены.");
            return db.UrlModels.ToList();
        }

        public void Update(UrlModel item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
