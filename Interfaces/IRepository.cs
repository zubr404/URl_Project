﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace URl_Project.Interfaces
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        T Get(int id);
        List<T> Find(Func<T, Boolean> predicate);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
