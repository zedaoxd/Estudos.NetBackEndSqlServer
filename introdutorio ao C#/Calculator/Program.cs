
short choice = Menu();

if (choice == 5)
	System.Environment.Exit(0);

PegaValor(out var v1, out var v2);

switch (choice)
{
	case 1:
		Console.WriteLine($"Soma: {MathUtils.Soma(v1, v2)}");
		Console.ReadKey();
		Menu();
		break;
	case 2:
		Console.WriteLine($"Subtração: {MathUtils.Subtracao(v1, v2)}");
		Console.ReadKey();
		Menu();
		break;
	case 3:
		Console.WriteLine($"Divisao: {MathUtils.Divisao(v1, v2)}");
		Console.ReadKey();
		Menu();
		break;
	case 4:
		Console.WriteLine($"Multiplicacao: {MathUtils.Multiplicacao(v1, v2)}");
		Console.ReadKey();
		Menu();
		break;
	default:
		Menu();
		break;
}


static void PegaValor(out float v1, out float v2)
{
	Console.Clear();
	Console.WriteLine("Primeiro valor: ");
	v1 = float.Parse(Console.ReadLine());

	Console.WriteLine("Segundo valor: ");
	v2 = float.Parse(Console.ReadLine());
}

static short Menu()
{
	Console.Clear();
	Console.WriteLine("O que deseja fazer? ");
	Console.WriteLine("1 - Soma");
	Console.WriteLine("2 - Subtração");
	Console.WriteLine("3 - Divisão");
	Console.WriteLine("4 - Multiplicação");
	Console.WriteLine("5 - Sair");
	
	Console.WriteLine("==========================");
	Console.WriteLine("Selecione uma opção: ");
	return short.Parse(Console.ReadLine());
}
