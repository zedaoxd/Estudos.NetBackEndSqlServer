using System;
using Dapper;
using DapperConnectionDB.model;
using Microsoft.Data.SqlClient;

namespace DapperConnectionDB
{
    class Program
    {
        static void Main(string[] args)
        {
            var category = new Category(
                Guid.NewGuid(),
                "Amazon AWS",
                "amazon",
                "AWS Cloud",
                8,
                "Categoria destinada a serviçoes do AWS",
                false
            );

            // SQL injection
            var insertSql = @"INSERT INTO 
                    [Category] ([Id], [Title], [Url], [Summary], [Order],[Description], [Featured]) 
                VALUES 
                    (@Id, @Title, @Url, @Summary, @Order, @Description, @Featured)";

            using (var connection = new SqlConnection(StringConnection.connection))
            {
                var rows = connection.Execute(insertSql, new
                {
                    category.Id,
                    category.Title,
                    category.Url,
                    category.Summary,
                    category.Order,
                    category.Description,
                    category.Featured
                });
                Console.WriteLine($"{rows} linhas inseridas!");

                var categories = connection.Query<Category>("SELECT [Id], [Title] FROM [Category]");
                foreach (var item in categories)
                {
                    Console.WriteLine($"{item.Id} - {item.Title}");
                }
            }
        }
    }
}
