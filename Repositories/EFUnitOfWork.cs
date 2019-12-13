using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using URl_Project.Interfaces;
using URl_Project.Models;

namespace URl_Project.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly UrlContext db;
        private UrlModelRepository urlModelRepository;
        private ILoggerFactory loggerFactory;

        public EFUnitOfWork(DbContextOptions<UrlContext> options, ILoggerFactory loggerFactory)
        {
            db = new UrlContext(options);
            this.loggerFactory = loggerFactory;
        }
        public IRepository<UrlModel> UrlModels
        {
            get
            {
                if (urlModelRepository == null)
                {
                    urlModelRepository = new UrlModelRepository(db, loggerFactory);
                }
                return urlModelRepository;
            }
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
