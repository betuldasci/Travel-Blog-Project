using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TravelBlog3.Models
{
    public class DataContext : DbContext
    {
      
        public DataContext() : base("DataContext") {
            this.Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<City> Citys { get; set; }
        public DbSet<Like> Like { get; set; }
        public DbSet<BlogCity> BlogsCity { get; set; }


      
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // User ve Comment arasındaki ilişki
            modelBuilder.Entity<Comment>()
                .HasRequired(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId)
                .WillCascadeOnDelete(false);

            // User ve Like arasındaki ilişki
            modelBuilder.Entity<Like>()
                .HasRequired(l => l.User)
                .WithMany(u => u.Likes)
                .HasForeignKey(l => l.UserId)
                .WillCascadeOnDelete(false);

            // User ve Blog arasındaki ilişki
            modelBuilder.Entity<Blog>()
                .HasRequired(b => b.User)
                .WithMany(u => u.Blogs)
                .HasForeignKey(b => b.UserId)
                .WillCascadeOnDelete(false);

            // Blog ve BlogCity arasındaki ilişki
            modelBuilder.Entity<BlogCity>()
                .HasRequired(bc => bc.Blog)
                .WithMany(b => b.BlogCities)
                .HasForeignKey(bc => bc.BlogId)
                .WillCascadeOnDelete(false);

            // City ve BlogCity arasındaki ilişki
            modelBuilder.Entity<BlogCity>()
                .HasRequired(bc => bc.City)
                .WithMany(c => c.BlogCities)
                .HasForeignKey(bc => bc.CityId)
                .WillCascadeOnDelete(false);

            // User ve Role arasındaki ilişki (eğer RoleId alanını User modelinize eklediyseniz)
            modelBuilder.Entity<User>()
                .HasRequired(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }

}