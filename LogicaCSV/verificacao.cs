using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
	public class verificacao
	{
		public void VerificaCampos(string cpf, string nome, int sexo, string endereco, string numero, string bairro, string cep,
			string municipio, string estado)
		{
			var cpfM = cpf.Replace(".", "").Replace("-", "");
			var nomeM = nome.Replace(",", "");
			var enderecoM = endereco.Replace(",", "");
			var numeroM = numero.Replace(")", "").Replace("(", "").Replace("-", "").Replace(" ", "");
			var bairroM = bairro.Replace(",", "");
			var cepM = cep.Replace(".", "").Replace("-", "");
			var municipioM = municipio.Replace(",", "");
			var estadoM = estado.Replace(",", "");

			if (cpfM.Length != 11)
			{
				throw new Exception("Insira um CPF");
			}

			if (VerificaCpf(cpfM) == false)
			{
				throw new Exception("Cpf inválido");
			}

			if (nomeM == "")
			{
				throw new Exception("O campo Nome não pode ser vazio");
			}

			if (sexo == -1)
			{
				throw new Exception("Defina seu Sexo");
			}

			if (enderecoM == "")
			{
				throw new Exception("O campo Endereço não pode ser vazio");
			}

			if (bairroM == "")
			{
				throw new Exception("O campo Bairro não pode ser vazio");
			}

			if (municipioM == "")
			{
				throw new Exception("O campo Municipio não pode ser vazio");
			}

			if (numeroM.Length != 11)
			{
				throw new Exception("Insira um número para contato");
			}

			if (cepM.Length != 8)
			{
				throw new Exception("Insira um Cep");
			}

			if (estadoM == "")
			{
				throw new Exception("O campo Estado não pode ser vazio.");
			}

			if (estadoM.Length != 2)
			{
				throw new Exception("Insira a sigla de um estado");
			}
		}

		private bool VerificaCpf(string cpfModificated)
		{
			try
			{
				int[] multiplicador1 = [10, 9, 8, 7, 6, 5, 4, 3, 2];
				int[] multiplicador2 = [11, 10, 9, 8, 7, 6, 5, 4, 3, 2];

				int soma;
				int resto;

				string cpf9num = cpfModificated.Substring(0, 9);

				soma = 0;

				for (int i = 0; i < 9; i++)
				{
					soma += int.Parse(cpf9num[i].ToString()) * multiplicador1[i];
				}

				resto = soma % 11;

				if (resto < 2)
				{
					resto = 0;
				}
				else
				{
					resto = 11 - resto;
				}

				int digito1 = resto;

				soma = 0;
				resto = 0;

				string cpf10num = cpf9num + digito1;

				for (int i = 0; i < 10; i++)
				{
					soma += int.Parse(cpf10num[i].ToString()) * multiplicador2[i];
				}

				resto = soma % 11;

				if (resto < 2)
				{
					resto = 0;
				}
				else
				{
					resto = 11 - resto;
				}

				int digito2 = resto;

				string cpfVerificado = cpf10num + digito2;

				if (cpfModificated == cpfVerificado)
				{
					return true;
				}

				return false;
			}
			catch (Exception ex)
			{
				throw new Exception($"Ocorreu um erro no método VerificaCpf. \r\nErro: {ex.Message}");
			}
		}
	}
}
