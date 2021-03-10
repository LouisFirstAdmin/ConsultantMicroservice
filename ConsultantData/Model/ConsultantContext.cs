using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ConsultantData.Model
{
    public class ConsultantContext : DbContext
    {
        public static IConfigurationRoot configuration;

        public ConsultantContext()
        {
        }

		public DbSet<Consultant> Consultants { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			configuration = new ConfigurationBuilder()
				.SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
				.AddJsonFile("appsettings.json", false)
				.Build();

			var connectionString = configuration.GetConnectionString("ConsultantDB");

			if (connectionString != null)
			{
				optionsBuilder.UseSqlServer(
					connectionString,
					options => options.MaxBatchSize(150));
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//Consultants
			modelBuilder.Entity<Consultant>().ToTable("Consultants");
			modelBuilder.Entity<Consultant>().HasKey(c => c.ID);
			modelBuilder.Entity<Consultant>().Property(c => c.ID)
				.ValueGeneratedOnAdd();
			modelBuilder.Entity<Consultant>().Property(c => c.FirstName)
				.IsRequired()
				.HasMaxLength(50);
			modelBuilder.Entity<Consultant>().Property(c => c.LastName)
				.IsRequired()
				.HasMaxLength(50);
			modelBuilder.Entity<Consultant>().Property(c => c.Description)
				.IsRequired()
				.HasMaxLength(250);
			modelBuilder.Entity<Consultant>().Property(c => c.Place)
				.IsRequired()
				.HasMaxLength(50);
			modelBuilder.Entity<Consultant>().Property(c => c.EmailAddress)
				.IsRequired()
				.HasMaxLength(50);
			modelBuilder.Entity<Consultant>().Property(c => c.PhoneNumber)
				.IsRequired()
				.HasMaxLength(50);
			modelBuilder.Entity<Consultant>().Property(c => c.DateOfBirth)
				.IsRequired();		
		}
	}
}
