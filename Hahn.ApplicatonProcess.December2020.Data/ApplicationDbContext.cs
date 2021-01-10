using Hahn.ApplicatonProcess.December2020.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hahn.ApplicatonProcess.December2020.Data
{
	public class ApplicationDbContext : DbContext
	{
		public DbSet<Applicant> Applicants { get; set; }
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> context) : base(context)
		{

		}

	}
}
