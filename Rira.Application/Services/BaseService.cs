using Microsoft.EntityFrameworkCore;
using Rira.Application.Interfaces.Context;
using Rira.Domain.Entities;
using System.Collections.Concurrent;
using System.Data;
using System.Data.Common;

namespace Rira.Application.Services
{
    public class BaseService
    {
        private readonly ConcurrentDictionary<string, object> _entitySets = new ConcurrentDictionary<string, object>();

        protected IDataBaseContext _context { get; private set; }

        protected BaseService(IDataBaseContext context)
        {
            _context = context;
        }


        #region Methods
        protected virtual async Task InsertAsync<T>(T entity, CancellationToken cancellationToken = default) where T : BaseEntity
        {
            ArgumentNullException.ThrowIfNull(entity);

            await Entities<T>().AddAsync(entity, cancellationToken);
        }


        protected virtual void Insert<T>(IEnumerable<T> entities) where T : BaseEntity
        {
            if (entities?.Any() != true)
            {
                throw new ArgumentException(nameof(entities));
            }

            Entities<T>().AddRange(entities);
        }

        protected virtual void Update<T>(T entity) where T : BaseEntity
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));

            var entry = _context.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                var trackedEntity = _context.ChangeTracker.Entries<T>()
                                            .FirstOrDefault(x => x.Entity.Id == entity.Id);

                if (trackedEntity != null)
                {
                    trackedEntity.State = EntityState.Detached;
                }

                Entities<T>().Attach(entity);
                entry = _context.Entry(entity);
            }

            if (entry.State != EntityState.Modified)
            {
                entry.State = EntityState.Modified;
            }
        }


        protected virtual void Update<T>(IEnumerable<T> entities)
            where T : BaseEntity
        {
            if (entities?.Any() != true)
            {
                throw new ArgumentException(nameof(entities));
            }

            Entities<T>().AttachRange(entities);
            foreach (var entity in entities)
            {
                _context.Entry(entity).State = EntityState.Modified;
            }
        }

        protected virtual void Delete<T>(T entity) where T : BaseEntity
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var entry = _context.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                Entities<T>().Attach(entity);
            }

            Entities<T>().Remove(entity);
        }


        protected List<T> RawSqlQuery<T>(string query, Func<DbDataReader, T> map)
        {
            using var connection = _context.GetDbConnection(_context.Database);
            using var command = connection.CreateCommand();
            command.CommandText = query;
            command.CommandType = CommandType.Text;

            connection.Open();

            using var result = command.ExecuteReader();
            var entities = new List<T>();

            while (result.Read())
            {
                entities.Add(map(result));
            }

            return entities;
        }
        protected virtual void Delete<T>(IEnumerable<T> entities)
            where T : BaseEntity
        {
            if (entities?.Any() != true)
            {
                throw new ArgumentException(nameof(entities));
            }

            Entities<T>().RemoveRange(entities);
        }


        protected Task<int> SaveAsync()
        {
            var result = _context.SaveChangesAsync();

            return result;
        }

        protected virtual IQueryable<T> Table<T>() where T : BaseEntity
        {
            return Entities<T>().AsNoTracking();
        }

        protected virtual IQueryable<T> TableTracking<T>()
            where T : BaseEntity
        {
            return Entities<T>();
        }

        protected virtual DbSet<T> Entities<T>()
            where T : BaseEntity
        {
            return _entitySets.GetOrAdd(typeof(T).FullName, (key) => { return _context.Set<T>(); }) as DbSet<T>;
        }


        protected virtual Task<T> GetByIdAsync<T>(long entityId) where T : BaseEntity
        {
            return Table<T>().SingleOrDefaultAsync(x => x.Id == entityId);
        }

        protected virtual Task<T> GetById<T>(long entityId, params string[] includs) where T : BaseEntity
        {
            IQueryable<T> table = _context.Set<T>();
            foreach (var inc in includs)
            {
                table = table.Include(inc);
            }

            return table.SingleOrDefaultAsync(x => x.Id == entityId);
        }

        #endregion
    }
}
