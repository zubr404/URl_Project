using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using URl_Project.Models;

namespace URl_Project.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<UrlModel> UrlModels { get; }
        void Save();
    }
}
