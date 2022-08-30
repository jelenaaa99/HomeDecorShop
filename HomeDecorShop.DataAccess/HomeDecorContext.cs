using Microsoft.EntityFrameworkCore;
using ProjekatASP.Domain;
using System;


namespace ProjekatASP.DataAccess
{
    public class HomeDecorContext:DbContext
    {

        public HomeDecorContext(DbContextOptions options = null)
            : base(options)
        { 
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            modelBuilder.Entity<OrderLine>().HasKey(x => new { x.OrderId, x.ProductId });
            modelBuilder.Entity<UserUseCase>().HasKey(x => new { x.UserId, x.UseCaseId });
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            foreach (var entry in this.ChangeTracker.Entries())
            {
                if (entry.Entity is Entity e)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            e.IsActive = true;
                            e.CreatedAt = DateTime.UtcNow;
                            break;
                    }
                }
            }

            return base.SaveChanges();
        }

        public object UseSqlServer(string conString)
        {
            throw new NotImplementedException();
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<UserUseCase> UserUseCases { get; set; }
        public DbSet<UseCaseLog> UseCaseLogs { get; set; }
    }
}
