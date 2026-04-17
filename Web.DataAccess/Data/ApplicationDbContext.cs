using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Channels;
using Web.Models;

namespace Web.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        
        public DbSet<Category> Categories {  get; set; }
        public DbSet<TaskManager> Tasks { get; set; }
       


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    Id = 1,
                    Name="Assignment"
                }
                );

            modelBuilder.Entity<TaskManager>().HasData(
                new TaskManager()
                {
                    Id = 1,
                    Title = "Assignment",
                    Description = "Developing a Application",
                    DueDate = new DateTime(2026,04,20),
                    StartDate = new DateTime(2026,04,17)
                }
                );
        }
    }
}
