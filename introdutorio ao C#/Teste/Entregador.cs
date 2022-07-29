using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teste
{
	public class Entregador : IDisposable
	{
		public Entregador()
		{
			Pagamento.AoFinalizarPagamento += SinalizarEntregador;
		}
		
		public void Dispose()
		{
			Pagamento.AoFinalizarPagamento -= SinalizarEntregador;
		}
		
		private void SinalizarEntregador()
		{
			Console.WriteLine("Entregador selecionado");
		}
	}
}