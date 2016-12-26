using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITacademy.datastorage.Entities;

namespace ITacademy.datastorage
{
	public sealed class ITacademyContext : DbContext
	{
		public ITacademyContext()
		{

		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			var configurations = modelBuilder.Configurations;

			configurations.Add(Log.CreateConfiguration());

			base.OnModelCreating(modelBuilder);
		}
	}
}
