using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace itacademy.gui
{
	public class StudentsLogRepositoryFilter
	{
		public DateTime From { get; }

		public DateTime To { get; }
	}

	public class StudentsLogRepository
	{
		public StudentsLogRepository(IDbConnectionFactory dbConnectionFactory)
		{
			DbConnectionFactory = dbConnectionFactory;
		}

		public IDbConnectionFactory DbConnectionFactory { get; }

		public IReadOnlyList<StudentsLogRecord> FetchRecords(StudentsLogRepositoryFilter fileter)
		{
			using(var dbConnection = DbConnectionFactory.CreateDbConnection())
			{
				dbConnection.Open();

				var records = new List<StudentsLogRecord>();

				using(var command = dbConnection.CreateCommand())
				{
					// Fix-me: напиши запрос.
					command.CommandText = "SELECT * FROM Что-нибудь";
					using(var reader = command.ExecuteReader())
					{
						while(reader.Read())
						{
							records.Add(new StudentsLogRecord()
							{
								X = reader["X"].ToString(),
								Timestamp = DateTime.Parse(reader["Timestamp"].ToString()),
							});

							// Fix-me
						}

						return records;
					}
				}
			}
		}
	}

	public class StudentsLogRecord
	{
		public string X { get; set; }

		public DateTime Timestamp { get; set; }
	}

	public interface IDbConnectionFactory
	{
		DbConnection CreateDbConnection();
	}

	public class SqlServerConnectionFactory : IDbConnectionFactory
	{
		public SqlServerConnectionFactory(IConnectionStringProvider connectionStringProvider)
		{
			ConnectionStringProvider = connectionStringProvider;
		}

		public IConnectionStringProvider ConnectionStringProvider { get; }

		public DbConnection CreateDbConnection()
		{
			return new SqlConnection(ConnectionStringProvider.GetConnectionString());
		}
	}

	public interface IConnectionStringProvider
	{
		string GetConnectionString();
	}

	public enum AuthType : int
	{
		Windows = 0,
		Server  = 1,
	}

	public class SqlServerConfiguration : IConnectionStringProvider
	{
		public static class Defaults
		{
			public const string DatabaseName = "default";

			public const string Hostname = @"localhost\SQLExpress";

			public static readonly AuthType AuthType = AuthType.Windows;

			public const string Username = "";

			public const string Password = "";
		}

		#region .ctor

		public SqlServerConfiguration()
		{
			SetDefaults();
		}

		#endregion

		#region Properties

		public string DatabaseName { get; set; }

		public string Hostname { get; set; }

		public AuthType AuthType { get; set; }

		public string Username { get; set; }

		public string Password { get; set; }

		#endregion

		#region Methods

		public string GetConnectionString()
		{
			var sb = new SqlConnectionStringBuilder();

			sb.InitialCatalog = DatabaseName;
			sb.DataSource = Hostname;
			sb.IntegratedSecurity = AuthType == AuthType.Windows;
			sb.UserID = Username;
			sb.Password = Password;

			return sb.ToString();
		}

		#endregion

		#region Config

		public void SetDefaults()
		{
			DatabaseName = Defaults.DatabaseName;

		}

		public void Save()
		{

		}

		public void Load()
		{

		}

		#endregion
	}
}
