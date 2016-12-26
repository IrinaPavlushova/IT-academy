using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITacademy.datastorage
{
	public class DatabaseService
	{
		public DbContext CreateContext()
		{
			return new DbContext("", contextOwnsConnection: true);
			// IDbConnectionFactory 1st arg
		}
	}
}
