using Microsoft.Office.Interop.Excel;
using System.Runtime.ConstrainedExecution;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Logica
{
	public class csvCrud
	{
		public static string csvPath;

		public void SalvarClienteCsv(string id, string cpf, string nome, string sexo, string endereco, string numero, string bairro,
			string cep, string municipio, string estado)
		{
			try
			{
				var linha = $"{id},{cpf},{nome},{sexo},{endereco},{numero},{bairro},{cep},{municipio},{estado}";

				using (StreamWriter arquivo = new StreamWriter(csvPath, true))
				{
					arquivo.WriteLine(linha);
				}

				string[] todasLinhas = File.ReadAllLines(csvPath);
				todasLinhas[0] = "ID,CPF,NOME,SEXO,ENDERECO,NUMERO,BAIRRO,CEP,MUNICIPIO,ESTADO";
				File.WriteAllLines(csvPath, todasLinhas, Encoding.UTF8);
			}
			catch (Exception ex)
			{
				throw new Exception($"Ocorreu um erro no método SalvarClienteCsv. \r\nErro: {ex.Message}");
			}
		}

		public void AtualizaCsv(string id, string cpf, string nome, string sexo, string endereco, string numero, string bairro,
			string cep, string municipio, string estado)
		{
			try
			{
				// {id},{cpf},{nome},{sexo},{endereco},{numero},{bairro},{cep},{municipio},{estado} => Ordem dos dados no CSV
				int linhaParaAtualizar = planCrud.planActualLine - planCrud.linhaCorte;

				string[] linhas = File.ReadAllLines(csvPath);

				if (linhaParaAtualizar >= 0 && linhaParaAtualizar < linhas.Length)
				{
					string[] campos = linhas[linhaParaAtualizar].Split(",");
					campos[0] = id.Replace(",", "");
					campos[1] = cpf.Replace(",", "");
					campos[2] = nome.Replace(",", "");
					campos[3] = sexo.Replace(",", "");
					campos[4] = endereco.Replace(",", "");
					campos[5] = numero.Replace(",", "");
					campos[6] = bairro.Replace(",", "");
					campos[7] = cep.Replace(",", "");
					campos[8] = municipio.Replace(",", "");
					campos[9] = estado.Replace(",", "");

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

				int linhaPraExcluir = planCrud.planActualLine - planCrud.linhaCorte;

				string[] linhas = File.ReadAllLines(csvPath);

				if (linhaPraExcluir >= 0 && linhaPraExcluir < linhas.Length)
				{
					var linhasList = new List<string>(linhas);
					linhasList.RemoveAt(linhaPraExcluir);

					File.WriteAllLines(csvPath, linhasList, Encoding.UTF8);

					planCrud.planActualLine = 3;

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
		public void CriarArquivoCsv(string path)
		{
			List<string> dadosClientes = new List<string>
		{
			"ID,CPF,NOME,SEXO,ENDERECO,NUMERO,BAIRRO,CEP,MUNICIPIO,ESTADO",
			"1,222.222.222-22,Ana Silva de Oliveira Souza,Feminino,Rua das Flores,(34) 98765-4321,Centro,34.567-890,Belo Horizonte,MG",
			"2,333.333.333-33,João Santos,Masculino,Avenida das Palmeiras,(45) 12345-6789,Jardim Primavera,45.678-901,Curitiba,PR",
			"3,444.444.444-44,Maria Oliveira,Feminino,Rua dos Passarinhos,(67) 54321-8765,Bairro Novo,67.890-123,Campo Grande,MS",
			"4,555.555.555-55,Luiz Pereira,Masculino,Travessa das Pedras,(21) 87654-3210,Parque das Árvores,21.543-987,Rio de Janeiro,RJ",
			"5,666.666.666-66,Carla Santos,Feminino,Rua dos Girassóis,(81) 23456-7890,Vila Esperança,81.234-567,Recife,PE",
			"6,777.777.777-77,Rafaela Lima,Feminino,Avenida das Acácias,(47) 65432-1098,Alvorada,47.890-234,Blumenau,SC",
			"7,888.888.888-88,André Souza,Masculino,Rua das Mangueiras,(19) 34567-8901,Jardim América,19.876-543,Campinas,SP",
			"8,999.999.999-99,Fernanda Costa,Feminino,Alameda dos Ipês,(32) 78901-2345,Centro,32.109-876,Juiz de Fora,MG",
			"9,101.101.101-01,Lucas Oliveira,Masculino,Rua das Palmeiras,(51) 43210-9876,Jardim Botânico,51.210-987,Porto Alegre,RS",
			"10,212.212.212-12,Juliana Mendes,Feminino,Avenida dos Flamboyants,(82) 10987-6543,Centro,82.543-210,Maceió,AL",
			"11,323.323.323-23,Paulo Nunes,Masculino,Travessa dos Coqueiros,(55) 67890-1234,Novo Horizonte,55.678-901,Caxias do Sul,RS",
			"12,434.434.434-34,Larissa Silva,Feminino,Rua das Rosas,(88) 32109-8765,Bairro Verde,88.765-432,Fortaleza,CE",
			"13,545.545.545-45,Rodrigo Costa,Masculino,Avenida das Orquídeas,(31) 89012-3456,Parque das Flores,31.098-765,Belo Horizonte,MG",
			"14,656.656.656-56,Marcela Santos,Feminino,Rua das Azaleias,(41) 21098-7654,Centro,41.098-765,Curitiba,PR",
			"15,767.767.767-67,Gustavo Almeida,Masculino,Alameda das Violetas,(27) 54321-0987,Jardim das Acácias,27.654-321,Vitória,ES",
			"16,878.878.878-78,Daniela Lima,Feminino,Rua dos Lírios,(84) 43210-9876,Bairro Novo,84.210-987,Natal,RN",
			"17,989.989.989-89,Ricardo Oliveira,Masculino,Avenida das Hortênsias,(83) 32109-8765,Centro,83.109-876,João Pessoa,PB",
			"18,090.090.090-90,Patrícia Souza,Feminino,Travessa das Violetas,(53) 67890-1234,Parque das Palmeiras,53.890-123,Pelotas,RS",
			"19,202.202.202-20,Marcos Santos,Masculino,Rua das Bromélias,(98) 90123-4567,Centro,98.321-098,São Luís,MA",
			"20,313.313.313-31,Ana Paula Costa,Feminino,Avenida das Magnólias,(68) 54321-0987,Jardim Botânico,68.765-432,Rio Branco,AC"
		};

			using (File.Create(path)) { };

			File.WriteAllLines(path, dadosClientes, Encoding.UTF8);
		}
	}
}
