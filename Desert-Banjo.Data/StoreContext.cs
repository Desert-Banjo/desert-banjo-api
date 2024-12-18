﻿using Microsoft.EntityFrameworkCore;
using Desert.Banjo.Domain.Catalog;
using Desert.Banjo.Data;
using Desert.Banjo.Domain.Orders;

namespace Desert.Banjo.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options)
            : base(options)
        { }

        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            DbInitializer.Initialize(builder);
        }
    }
}