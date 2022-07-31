using System;

namespace Blog.ui.userUis.posts
{
    public static class MenuPostsUi
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("------Gestão de post-------");
            Console.WriteLine("---------------------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("[1] Listar posts");
            Console.WriteLine("[2] Cadastrar post");
            Console.WriteLine("[3] Atualizar post");
            Console.WriteLine("[4] Excluir post");
            Console.WriteLine("\n\n");

            try
            {
                var option = short.Parse(Console.ReadLine()!);
                switch (option)
                {
                    case 1:
                        ListPostUi.Load();
                        break;
                    case 2:
                        CreatePostsUi.Load();
                        break;
                    case 3:
                        UpdatePostUi.Load();
                        break;
                    case 4:
                        DeletePostUi.Load();
                        break;
                    default:
                        Load();
                        break;
                }
            }
            catch
            {
                Program.Load();
            }
        }
    }
}