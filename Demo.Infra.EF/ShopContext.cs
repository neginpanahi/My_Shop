using Demo.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Infra.EF
{
    public class ShopContext:DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options)
             : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Media> Medias { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}


