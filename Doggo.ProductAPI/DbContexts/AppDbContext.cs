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

            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = 1,
                Name = "Belcando Adult Lamb & Rice",
                Price = 234.80,
                Description = "Karma sucha jakości premium dla dorosłych psów o wrażliwym układzie pokarmowym, zawiera jagnięcinę i lekkostrawny ryż, mączkę z pestek winogron, szałwię hiszpańską",
                PictureUrl = "https://shop-cdn-m.mediazs.com/bilder/belcando/adult/lamb/rice/0/400/113614_bewital_belcando_adult_lambrice_12_5kg_hs_02_0.jpg",
            });
            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = 2,
                Name = "Pedigree Adult Classic",
                Price = 89.80,
                Description = "Pedigree Adult Classic, mokra karma dla psa to doskonale zbilansowany skład ze smacznym mięsem, bez wzmacniaczy smaku, barwników ani aromatów",
                PictureUrl = "https://shop-cdn-m.mediazs.com/bilder/pedigree/adult/classic/x/g/2/140/55090_pla_pedigree_3sorten_fleisch_400g_2.jpg",
            });
            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = 3,
                Name = "Pakiet Pedigree Saszetki, 12 x 100 g",
                Price = 27.80,
                Description = "Karma mokra w sosie, delikatnej galarecie lub soczystym pasztecie dla dorosłych psów, różne odmiany, w 100% zbilansowana, bez sztucznych polepszaczy smaku, środków barwiących i konserwujących",
                PictureUrl = "https://shop-cdn-m.mediazs.com/bilder/pakiet/pedigree/saszetki/x/g/7/140/192298_pla_marsgermany_pedigree_frischebeutel_multipack_nassfutter_hunde_souce_12x100g_hs_01_7.jpg",
            });
            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = 4,
                Name = "Wolf of Wilderness Senior",
                Price = 57.80,
                Description = "Bezzbożowa karma mokra inspirowana naturalnym sposobem żywienia się wilków, wysoka zawartość mięsa, specjalnie dla starszych psów, z jagnięciną i kurczakiem lub kaczką i cielęciną",
                PictureUrl = "https://shop-cdn-m.mediazs.com/bilder/wolf/of/wilderness/senior/x/g/9/400/wow_senior_wildhills_400g_1000x1000_9.jpg",
            });

        }
    }
}
