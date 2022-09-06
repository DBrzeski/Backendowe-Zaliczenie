using Doggo.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doggo.ProductAPI.DbContexts
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Item> Item { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            //modelBuilder.Entity<Item>().HasData(new Item
            //{
            //    Id = 1,
            //    Name = "",
            //    Price = 0,
            //    Description = "",
            //    PictureUrl = "",
            //});
            //modelBuilder.Entity<Item>().HasData(new Item
            //{
            //    Id = 2,
            //    Name = "",
            //    Price = 0,
            //    Description = "",
            //    PictureUrl = "",
            //});
            //modelBuilder.Entity<Item>().HasData(new Item
            //{
            //    Id = 3,
            //    Name = "",
            //    Price = 0,
            //    Description = "",
            //    PictureUrl = "",
            //});
            //modelBuilder.Entity<Item>().HasData(new Item
            //{
            //    Id = 4,
            //    Name = "",
            //    Price = 0,
            //    Description = "",
            //    PictureUrl = "",
            //});
            //modelBuilder.Entity<Item>().HasData(new Item
            //{
            //    Id = 5,
            //    Name = "",
            //    Price = 0,
            //    Description = "",
            //    PictureUrl = "",
            //});

        }
    }
}
