using CleanArchMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Infra.Data.Context
{
	public class ApplicationDBContext : DbContext
	{
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) 
			: base(options) 
		{}
    
	public DbSet<Category> Categories { get; set; }

	public DbSet<Product> Products { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDBContext).Assembly);
		}
	}
}
