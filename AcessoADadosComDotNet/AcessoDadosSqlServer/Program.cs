using System;
using Microsoft.Data.SqlClient; // dotnet add package Microsoft.Data.SqlClient --version 2.1.3 (NUGET)

namespace AcessoDadosSqlServer
{
	class Program
	{
		static void Main(string[] args)
		{
			using (var connection = new SqlConnection(StringConnection.connection))
			{
				connection.Open();
				using(var command = new SqlCommand())
				{
					command.Connection = connection;
					command.CommandType = System.Data.CommandType.Text;
					command.CommandText = "SELECT [Id], [Title] FROM [Category]";
					
					var reader = command.ExecuteReader();
					while (reader.Read())
					{
						Console.WriteLine($"{reader.GetGuid(0)} - {reader.GetString(1)}");
					}
				}
				connection.Close();
			}
		}
	}
}
