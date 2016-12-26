using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITacademy.datastorage.Entities
{
	public sealed class Log
	{
		#region Configuration

		private sealed class LogConfiguration : EntityTypeConfiguration<Log>
		{
			public LogConfiguration()
			{
				ToTable("Log");

				Property(e => e.Id)
					.IsRequired()
					.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

				Property(e => e.Comment)
					.IsOptional()
					.IsUnicode()
					.HasMaxLength(255);
			}
		}

		public static EntityTypeConfiguration<Log> CreateConfiguration() => new LogConfiguration();

		#endregion

		#region Properties

		public long Id { get; set; }

		public string Comment { get; set; } 

		#endregion

	}
}
