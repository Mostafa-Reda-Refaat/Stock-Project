using Demo.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Context
{
	public class StockDbContext : DbContext
	{
        public StockDbContext(DbContextOptions<StockDbContext> options) : base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			//optionsBuilder.UseSqlServer("server=.; database=StockProjectDb; trusted_connection= true;");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ItemStock>()
						.HasKey(IS => new {IS.ItemId, IS.StoreId});

			base.OnModelCreating(modelBuilder);
		}

		public DbSet<Store> Stores { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemStock> ItemStocks { get; set; }



    }
}
