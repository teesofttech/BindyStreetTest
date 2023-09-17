using BindyStreet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BindyStreet.Persistence.Context
{
    public partial class BindyStreetContext : DbContext
    {
        public BindyStreetContext()
        {

        }
        public BindyStreetContext(DbContextOptions<BindyStreetContext> options)
        : base(options)
        {
        }


        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        ////public virtual DbSet<Author> Author { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<User>(entity => {
        //        entity.HasKey(k => k.Id);
        //    });
        //    OnModelCreatingPartial(modelBuilder);
        //}
        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
