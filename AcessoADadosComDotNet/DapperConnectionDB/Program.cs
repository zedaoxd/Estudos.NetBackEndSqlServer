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
            using (var connection = new SqlConnection(StringConnection.connection))
            {
                //CreateCategory(connection);
                //UpdateCategory(connection);
                //DeleteCategory(connection);
                //ListCategories(connection);
                Console.WriteLine(GetCategory(connection));
            }
        }

        static void ListCategories(SqlConnection connection)
        {
            var categories = connection.Query<Category>("SELECT [Id], [Title] FROM [Category]");
            foreach (var item in categories)
            {
                Console.WriteLine($"{item.Id} - {item.Title}");
            }
        }

        static void CreateCategory(SqlConnection connection)
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
        }

        static void UpdateCategory(SqlConnection connection)
        {
            var updateQuery = "UPDATE [Category] SET [Title] = @title WHERE [Id] = @id";
            var rows = connection.Execute(updateQuery, new
            {
                id = new Guid("af3407aa-11ae-4621-a2ef-2028b85507c4"),
                title = "Frontend 2022"
            });

            Console.WriteLine($"{rows} registros atualizados");
        }

        static void DeleteCategory(SqlConnection connection)
        {
            var deleteQuery = "DELETE [Category] WHERE [Id] = @id";
            var rows = connection.Execute(deleteQuery, new
            {
                id = new Guid("c9ee3468-d95e-4413-bb50-67ca475ecfc5")
            });

            Console.WriteLine($"{rows} registros deletadas");
        }

        static Category GetCategory(SqlConnection connection)
        {
            return connection.QueryFirstOrDefault<Category>(
                @"SELECT TOP 1 
                    [Id], [Title], [Url], [Summary], [Order], [Description], [Featured]
                FROM
                    [Category]
                WHERE
                    [Id] = @id",
                new
                {
                    id = "06d73e6b-315f-4cfc-b462-f643e1a50e97"
                });
        }
    }
}
