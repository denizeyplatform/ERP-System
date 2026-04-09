using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Common;
using Template.Domain.Entities;

namespace Template.Infrastructure.Persistance.Data
{
    public class ApplicationDBContext : DbContext 
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
             : base(options)
        {
        }


        public DbSet<Employee> Employees { get; set; }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    foreach (var entityType in builder.Model.GetEntityTypes())
        //    {
        //        if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
        //        {
        //            builder.Entity(entityType.ClrType)
        //                .HasQueryFilter(
        //                    GenerateIsDeletedFilter(entityType.ClrType));
        //        }
        //    }
        //}

        //private static LambdaExpression GenerateIsDeletedFilter(Type type)
        //{
        //    var parameter = Expression.Parameter(type, "e");
        //    var property = Expression.Property(parameter, "IsDeleted");
        //    var condition = Expression.Equal(property, Expression.Constant(false));
        //    return Expression.Lambda(condition, parameter);
        //}



    }
}
