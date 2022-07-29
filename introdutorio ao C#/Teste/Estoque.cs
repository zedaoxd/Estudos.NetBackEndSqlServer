using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teste
{
	public class Estoque : IDisposable
	{
		
		public Estoque()
		{
			Pagamento.AoFinalizarPagamento += SepararStoque;
		}

		public void Dispose()
		{
			Pagamento.AoFinalizarPagamento -= SepararStoque;
		}

		private void SepararStoque()
		{
			Console.WriteLine("Separado no estoque");
		}
	}
}