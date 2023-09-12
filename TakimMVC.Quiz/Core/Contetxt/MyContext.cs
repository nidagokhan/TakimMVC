using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakimMVC.Quiz.Entities;

namespace TakimMVC.Quiz.Core.Contetxt
{
    //"data source=.;initial catalog=TakimMVC;integrated security=true;"
    public class MyContext : DbContext
    {
        public MyContext()
        {

        }
        public MyContext(DbContextOptions opt) : base(opt)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kisi>()
            .HasOne(k => k.KisiOzluk)
            .WithOne(ko => ko.Kisi)
            .HasForeignKey<KisiOzluk>(ko => ko.KisiOzlukID);

            modelBuilder.Entity<Kisi>()
            .HasOne(k => k.Takim)
            .WithMany(t => t.Kisis)
            .HasForeignKey(k => k.TakimID); // 

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Kisi> Kisi { get; set; }
        public DbSet<Takim> Takim { get; set; }
        public DbSet<Unvan> Unvan { get; set; }
    }

}
