using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Model.Entities;

namespace Model.DBContext
{
    public class AplicationDBContext : IdentityDbContext
    {
        public AplicationDBContext(DbContextOptions options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Api Fluent para configurar las entidades de la base de datos
            // Task
            //modelBuilder
            //    .Entity<Entities.Task>()
            //    .Property(t => t.Title)
            //    .IsRequired()
            //    .HasMaxLength(200);
        }

        // DbSet es una colección de entidades

        public DbSet<Entities.Task> Tasks { get; set; }
        public DbSet<Step> Steps { get; set; }
        public DbSet<Attachment> Attachments { get; set; }

        /*
         *
         * Comandos para crear la base de datos
         *
         * Add-Migration Tasks
         * Update-Database
         *
         */
    }
}
