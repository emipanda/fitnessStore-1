using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FitnessStore.Models;

namespace FitnessStore.Data
{
    public class FitnessStoreContext : DbContext
    {
        public FitnessStoreContext (DbContextOptions<FitnessStoreContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
        }

        public DbSet<FitnessStore.Models.Account> Account { get; set; }

        public DbSet<FitnessStore.Models.Product> Product { get; set; }

        public DbSet<FitnessStore.Models.Category> Category { get; set; }

        public DbSet<FitnessStore.Models.Cart> Cart { get; set; }

        public DbSet<FitnessStore.Models.Contact> Contact { get; set; }

        public DbSet<FitnessStore.Models.CartItem> CartItem { get; set; }

        public DbSet<FitnessStore.Models.Order> Order { get; set; }
        public DbSet<FitnessStore.Models.OrderItem> OrderItem { get; set; }
    }
}
