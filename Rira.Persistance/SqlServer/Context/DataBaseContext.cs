using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Rira.Application.Interfaces.Context;
using Rira.Domain.Entities;
using System.Data.Common;

namespace Rira.Persistance.SqlServer.Context
{
    public class DataBaseContext : DbContext, IDataBaseContext
    {
        public DataBaseContext(DbContextOptions options) : base(options) { }
        public DbSet<Person> People { get; set; }

        public DbConnection GetDbConnection(DatabaseFacade databaseFacade)
        {
            var relationalConnection = databaseFacade.GetDbConnection();
            return relationalConnection;
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            ModelBuilderClass.QueryFilter(builder);
        }
    }
}
