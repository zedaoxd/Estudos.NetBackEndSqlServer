using System;
using Blog.ui.userUis.categories;
using Blog.ui.userUis.posts;
using Blog.ui.userUis.reports;
using Blog.ui.userUis.roles;
using Blog.ui.userUis.tags;
using Blog.ui.userUis.users;
using Microsoft.Data.SqlClient;

namespace Blog
{
    public class Program
    {
        static void Main(string[] args)
        {
            Database.connection = new SqlConnection(StringConnection.Connection);
            Database.connection.Open();

            Load();

            Console.ReadKey();
            Database.connection.Close();
        }

        public static void Load() { 
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("-----------Blog------------");
            Console.WriteLine("---------------------------");
            Console.WriteLine();
            Console.WriteLine("[1] Gestão de usuário");
            Console.WriteLine("[2] Gestão de perfil");
            Console.WriteLine("[3] Gestão de categoria");
            Console.WriteLine("[4] Gestão de tag");
            Console.WriteLine("[5] Gestão de post");
            Console.WriteLine("[6] Relatórios");
            Console.WriteLine("[0] Sair");
            Console.WriteLine("\n\n");
            var option = short.Parse(Console.ReadLine()!);

            switch (option)
            {
                case 1:
                    MenuUserUi.Load();
                    break;
                case 2:
                    MenuRolesUi.Load();
                    break;
                case 3:
                    MenuCategoryUi.Load();
                    break;
                case 4:
                    MenuTagUi.Load();
                    break;
                case 5:
                    MenuPostsUi.Load();
                    break;
                case 6:
                    MenuReportsUi.Load();
                    break;
                case 0:
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }
    }
}
