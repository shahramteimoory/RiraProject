using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Rira.Domain.Entities;
using System.Data.Common;

namespace Rira.Application.Interfaces.Context
{
    public interface IDataBaseContext
    {
        DbSet<Person> People { get; set; }

        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());

        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        DatabaseFacade Database { get; }
        ChangeTracker ChangeTracker { get; }
        DbConnection GetDbConnection(DatabaseFacade databaseFacade);
    }
}
