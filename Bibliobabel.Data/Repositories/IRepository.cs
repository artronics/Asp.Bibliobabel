using System;
using System.Collections.Generic;
using System.Linq;
using Bibliobabel.Domain.Models;

namespace Bibliobabel.Data.Repositories
{
    public interface IRepository<T> where T:BaseEntity 
    {
        T GetById(object id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        IQueryable<T> Table { get; }
    }
}