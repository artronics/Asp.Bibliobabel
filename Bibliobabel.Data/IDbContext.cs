using System.Data.Entity;
using Bibliobabel.Domain.Models;

namespace Bibliobabel.Data
{
    public interface IDbContext
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;
        int SaveChanges();
    }
}