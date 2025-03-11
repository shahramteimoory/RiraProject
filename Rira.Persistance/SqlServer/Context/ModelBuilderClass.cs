using Microsoft.EntityFrameworkCore;
using Rira.Domain.Entities;

namespace Rira.Persistance.SqlServer.Context
{
    public static class ModelBuilderClass
    {
        public static void QueryFilter(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
