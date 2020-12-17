using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Voyager.Models.Orm.Entities;
using Voyager.Models.Vm;

namespace Voyager.Models.Orm.Context
{
    public class VoyagerContext : DbContext
    {
        public VoyagerContext(DbContextOptions<VoyagerContext> options) : base(options) { }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Trip> Trips{ get; set; }
        public DbSet<AdminUser> AdminUsers { get; set; }
        public DbSet<Menu> Menus { get; set; }

        public override int SaveChanges()
        {
            var now = DateTime.Now;

            foreach (var changedEntity in ChangeTracker.Entries())
            {
                if (changedEntity.Entity is BaseEntity entity)
                {
                    switch (changedEntity.State)
                    {
                        case EntityState.Added:
                            entity.CreatedDate = now;
                            entity.UpdatedDate = now;
                            entity.IsDeleted = false;
                            break;

                        case EntityState.Modified:
                            entity.UpdatedDate = now;
                            break;
                    }
                }
            }

            return base.SaveChanges();
        }




    }
}
