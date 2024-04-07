using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
	public class csvCrud
	{
		public static string csvPath = @"C:\Users\Monica\Documents\TesteDadosCsv\clientes1.csv";

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

				using (StreamWriter arquivo = new StreamWriter(csvPath, true))
				{
					arquivo.WriteLine(linha);
				}
			}
			catch (Exception ex)
			{
				throw new Exception($"Ocorreu um erro no método SalvarClienteCsv. \r\nErro: {ex.Message}");
			}
		}

		public void AtualizaCsv(string id, string cpf, string nome, string sexo, string endereco, string numero, string bairro,
			string cep, string estado, string municipio)
		{
			try
			{
				int actualLine = planCrud.actualLine;

				int linhaParaAtualizar = actualLine - 2;

				string[] linhas = File.ReadAllLines(csvPath);

				if (linhaParaAtualizar >= 0 && linhaParaAtualizar < linhas.Length)
				{
					string[] campos = linhas[linhaParaAtualizar].Split(',');
					campos[0] = id;
					campos[1] = cpf;
					campos[2] = nome;
					campos[3] = sexo;
					campos[4] = endereco;
					campos[5] = numero;
					campos[6] = bairro;
					campos[7] = cep;
					campos[8] = estado;
					campos[9] = municipio;

					linhas[linhaParaAtualizar] = string.Join(",", campos);

					File.WriteAllLines(csvPath, linhas, Encoding.UTF8);
				}
				else
				{
					throw new Exception($"Não há linhas para atualizar.");
				}
			}
			catch (Exception ex)
			{
				throw new Exception($"Erro no método AtualizaCsv.\r\nErro: {ex.Message}");
			}
		}

		public void ExcluirCsv()
		{
			try
			{
				var planilha = new planCrud();

				int linhaPraExcluir = planCrud.actualLine - 2;

				string[] linhas = File.ReadAllLines(csvPath);

				if (linhaPraExcluir >= 0 && linhaPraExcluir < linhas.Length)
				{
					var linhasList = new List<string>(linhas);
					linhasList.RemoveAt(linhaPraExcluir);

					File.WriteAllLines(csvPath, linhasList, Encoding.UTF8);

					planCrud.actualLine = 3;

					planilha.LimparPlanilha();
					planilha.CarregarCsvPlanilha();
				}
				else
				{
					throw new Exception("Sem dados para excluir.");
				}
			}
			catch (Exception ex)
			{
				throw new Exception($"Erro no método ExcluirCsv.\r\nErro: {ex.Message}");
			}
		}
	}
}
