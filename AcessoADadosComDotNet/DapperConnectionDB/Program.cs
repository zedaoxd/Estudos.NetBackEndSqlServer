using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
                // CreateManyCategory(connection);
                // CreateCategory(connection);
                // UpdateCategory(connection);
                // DeleteCategory(connection);
                // ListCategories(connection);
                // Console.WriteLine(GetCategory(connection));
                // ExecuteProcedure(connection, "4799b409-149d-4277-9940-a300582f9c3a");
                // ExecuteReadProcedure(connection, "09ce0b7b-cfca-497b-92c0-3290ad9d5142");
                // ExecuteScalar(connection);
                // ReadView(connection);
                // OneToOne(connection);
                // OneToMany(connection);
                QueryMultiple(connection);
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

        static void CreateManyCategory(SqlConnection connection)
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

            var category2 = new Category(
                Guid.NewGuid(),
                "Categoria Nova",
                "categoria-nova",
                "Categoria Nova",
                9,
                "Categoria",
                true
            );

            // SQL injection
            var insertSql = @"INSERT INTO 
                    [Category] ([Id], [Title], [Url], [Summary], [Order],[Description], [Featured]) 
                VALUES 
                    (@Id, @Title, @Url, @Summary, @Order, @Description, @Featured)";

            var rows = connection.Execute(insertSql, new[]
            {
                new {
                    category.Id,
                    category.Title,
                    category.Url,
                    category.Summary,
                    category.Order,
                    category.Description,
                    category.Featured
                },
                new {
                    category2.Id,
                    category2.Title,
                    category2.Url,
                    category2.Summary,
                    category2.Order,
                    category2.Description,
                    category2.Featured
                }
            });

            Console.WriteLine($"{rows} linhas inseridas!");
        }

        static void ExecuteProcedure(SqlConnection connection, string id)
        {
            var procedure = "[spDeleteStudent]";
            var pars = new { StudentId = id };
            var affectedRows = connection.Execute(procedure, pars, commandType: CommandType.StoredProcedure);
            Console.WriteLine($"{affectedRows} linhas afetadas");
        }

        static void ExecuteReadProcedure(SqlConnection connection, string idCategory)
        {
            var procedure = "[spGetCourseByCategory]";
            var pars = new { CategoryId = idCategory };
            var courses = connection.Query<Category>(
                procedure,
                pars,
                commandType: CommandType.StoredProcedure
            );

            foreach (var item in courses)
            {
                Console.WriteLine($"{item.Id} - {item.Title} - {item.Url}");
            }
        }

        static void ExecuteScalar(SqlConnection connection)
        {
            var category = new Category();
            category.Title = "Amazon AWS";
            category.Url = "amazon";
            category.Description = "Categoria destinada a serviçoes do AWS";
            category.Order = 8;
            category.Summary = "AWS Cloud";
            category.Featured = false;

            // SQL injection
            var insertSql = @"INSERT INTO 
                    [Category] ([Id], [Title], [Url], [Summary], [Order],[Description], [Featured]) 
                OUTPUT
                    inserted.[Id]
                VALUES 
                    (NEWID(), @Title, @Url, @Summary, @Order, @Description, @Featured)";

            var id = connection.ExecuteScalar<Guid>(insertSql, new
            {
                category.Title,
                category.Url,
                category.Summary,
                category.Order,
                category.Description,
                category.Featured
            });

            Console.WriteLine($"A categoria inserida foi: {id}");
        }

        static void ReadView(SqlConnection connection)
        {
            var sql = "SELECT * FROM [vwCourses]";
            var courses = connection.Query(sql);
            foreach (var item in courses)
            {
                Console.WriteLine($"{item.Id} - {item.Title}");
            }
        }

        static void OneToOne(SqlConnection connection)
        {
            var sql = @"
                SELECT TOP 1000
                    * 
                FROM 
                    [CareerItem] 
                INNER JOIN 
                    [Course] ON [CareerItem].[CourseId] = [Course].[Id]";

            var items = connection.Query<CareerItem, Course, CareerItem>(
                sql,
                (carrerItem, course) =>
                {
                    carrerItem.course = course;
                    return carrerItem;
                },
                splitOn: "Id");

            foreach (var item in items)
            {
                Console.WriteLine($"{item.Title} - {item.course.Title}");
            }
        }

        static void OneToMany(SqlConnection connection)
        {
            var sql = @"
                SELECT
                    [Career].[Id],
                    [Career].[Title],
                    [CareerItem].[CareerId],
                    [CareerItem].[Title]
                FROM
                    [Career]
                INNER JOIN
                    [CareerItem] ON [CareerItem].[CareerId] = [Career].[Id]
                ORDER BY 
                    [Career].[Title]";

            var careers = new List<Career>();
            var items = connection.Query<Career, CareerItem, Career>(
                sql,
                (career, careerItem) =>
                {
                    var car = careers.Where(x => x.Id == career.Id).FirstOrDefault();
                    if (car == null)
                    {
                        car = career;
                        car.Items.Add(careerItem);
                        careers.Add(car);
                    }
                    else 
                    {
                        car.Items.Add(careerItem);
                    }
                    return career;
                },
                splitOn: "CareerId"
            );

            foreach (var career in careers)
            {
                Console.WriteLine($"{career.Title}");
                foreach (var item in career.Items)
                {
                    Console.WriteLine($" - {item.Title}");
                }
            }
        }
    
        static void QueryMultiple(SqlConnection connection)
        {
            var sql = @"SELECT * FROM [Category]; 
                        SELECT * FROM [Course];";
            
            using (var multi = connection.QueryMultiple(sql))
            {
                var categories = multi.Read<Category>();
                var courses = multi.Read<Course>();

                foreach (var item in categories)
                {
                    Console.WriteLine(item.Title);
                }
                Console.WriteLine("\n-------------------------\n");
                foreach (var item in courses)
                {
                    Console.WriteLine(item.Title);
                }
            }
        }
    }
}
