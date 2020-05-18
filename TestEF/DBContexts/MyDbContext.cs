using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using TestEF.Models;

namespace TestEF
{
	public class MyDbContext : DbContext 
	{
		public  virtual DbSet<Blog> Blogs { get; set; }


		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite("Filename=TestDatabase.db", options =>
			{
				options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
			});
 
			base.OnConfiguring(optionsBuilder);
		}


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{ 
			base.OnModelCreating(modelBuilder);
			
			/*modelBuilder.Entity<BlogCustom>(b =>
			{
				b.ToTable("Blog");
			});
			
			
			modelBuilder.Entity<BlogCustom>().HasBaseType(typeof(Blog));
			*/
		}
	}
}