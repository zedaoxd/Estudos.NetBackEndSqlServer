using System;

namespace Blog.ui.userUis.categories
{
    public static class MenuCategoryUi
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("----Gestão de categoria----");
            Console.WriteLine("---------------------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("[1] Listar categorias");
            Console.WriteLine("[2] Cadastrar categoria");
            Console.WriteLine("[3] Atualizar categoria");
            Console.WriteLine("[4] Excluir categoria");
            Console.WriteLine("\n\n");

            try
            {
                var option = short.Parse(Console.ReadLine()!);
                switch (option)
                {
                    case 1:
                        ListCategoriesUi.Load();
                        break;
                    case 2:
                        CreateCategoryUi.Load();
                        break;
                    case 3:
                        UpdateCategoryUi.Load();
                        break;
                    case 4:
                        DeleteCategoryUi.Load();
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