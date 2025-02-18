using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class Context : DbContext
    {
        public Context() : base("name=RecipeMS")
        {
        }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Recipe>()
                        .HasRequired(r => r.User) 
                        .WithMany(u => u.Recipes) 
                        .HasForeignKey(r => r.UserId) 
                        .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
