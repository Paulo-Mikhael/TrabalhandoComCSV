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
	}
}
