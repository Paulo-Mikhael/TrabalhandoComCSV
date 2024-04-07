using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
	public class csvCrud
	{
		public void SalvarClienteCsv(string id, string cpf, string nome, string sexo, string endereco, string numero, string bairro,
			string cep, string municipio, string estado)
		{
			try
			{
				var idFormat = id.Replace(",", "");
				var cpfFormat = cpf.Replace(",", "");
				var nomeFormat = nome.Replace(",", "");
				var sexoFormat = sexo.Replace(",", "");
				var enderecoFormat = endereco.Replace(",", "");
				var numeroFormat = numero.Replace(",", "");
				var bairroFormat = bairro.Replace(",", "");
				var cepFormat = cep.Replace(",", "");
				var municipioFormat = municipio.Replace(",", "");
				var estadoFormat = estado.Replace(",", "");

				var linha = $"{id},{cpf},{nome},{sexo},{endereco},{numero},{bairro},{cep},{municipio},{estado}";

				using (StreamWriter arquivo = new StreamWriter(@"C:\Users\Monica\Documents\TesteDadosCsv\clientes1.csv", true))
				{
					arquivo.WriteLine(linha);
				}
			}
			catch (Exception ex)
			{
				throw new Exception($"Ocorreu um erro no método SalvarClienteCsv. \r\nErro: {ex.Message}");
			}
		}
	}
}
