using System.IO;
using System.Windows.Forms;

namespace TrabalhandoComCSV
{
	public partial class frmPrincipal : Form
	{
		public frmPrincipal()
		{
			InitializeComponent();
			this.KeyDown += frmPrincipal_KeyPress;
		}

		private void frmPrincipal_Load(object sender, EventArgs e)
		{

		}

		private void btnSalvar_Click(object sender, EventArgs e)
		{
			var frmPlanilha = new frmPlanilha();

			btnSalvar.Enabled = false;
			SalvarClienteCsv();
			LimparForm();
			btnSalvar.Enabled = true;
			frmPlanilha.CarregaDadosCsvPlanilha();
		}

		private void SalvarClienteCsv()
		{
			try
			{
				VerificaCampos();

				var id = tbId.Text.Replace(",", "");
				var cpf = mtbCpf.Text.Replace(",", "");
				var nome = tbNome.Text.Replace(",", "");
				var sexo = cdSexo.Text.Replace(",", "");
				var endereco = tbEndereco.Text.Replace(",", "");
				var numero = mtbNumero.Text.Replace(",", "");
				var bairro = tbBairro.Text.Replace(",", "");
				var cep = mtbCep.Text.Replace(",", "");
				var municipio = tbMunicipio.Text.Replace(",", "");
				var estado = tbEstado.Text.Replace(",", "");

				var linha = $"{id},{cpf},{nome},{sexo},{endereco},{numero},{bairro},{cep},{municipio},{estado}";

				using (StreamWriter arquivo = new StreamWriter(@"C:\Users\Monica\Documents\TesteDadosCsv\clientes.csv", true))
				{
					arquivo.WriteLine(linha);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Problemas no cadastro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void LimparForm()
		{
			tbId.Clear();
			tbNome.Clear();
			tbEndereco.Clear();
			tbBairro.Clear();
			tbMunicipio.Clear();
			tbEstado.Clear();
			mtbCpf.Clear();
			mtbCep.Clear();
			mtbNumero.Clear();
			cdSexo.SelectedIndex = -1;
		}

		private void VerificaCampos()
		{
			var cpf = mtbCpf.Text.Replace(".", "").Replace("-", "");
			var nome = tbNome.Text.Replace(",", "");
			var sexo = cdSexo.SelectedIndex;
			var endereco = tbEndereco.Text.Replace(",", "");
			var numero = mtbNumero.Text.Replace(")", "").Replace("(", "").Replace("-", "").Replace(" ", "");
			var bairro = tbBairro.Text.Replace(",", "");
			var cep = mtbCep.Text.Replace(".", "").Replace("-", "");
			var municipio = tbMunicipio.Text.Replace(",", "");
			var estado = tbEstado.Text.Replace(",", "");

			if (cpf.Length != 11)
			{
				throw new Exception("Insira um CPF");
			}

			if (nome == "")
			{
				throw new Exception("O campo Nome não pode ser vazio");
			}

			if (sexo == -1)
			{
				throw new Exception("Defina seu Sexo");
			}

			if (endereco == "")
			{
				throw new Exception("O campo Endereço não pode ser vazio");
			}

			if (bairro == "")
			{
				throw new Exception("O campo Bairro não pode ser vazio");
			}

			if (municipio == "")
			{
				throw new Exception("O campo Municipio não pode ser vazio");
			}

			if (numero.Length != 11)
			{
				throw new Exception("Insira um número para contato");
			}

			if (cep.Length != 8)
			{
				throw new Exception("Insira um Cep");
			}

			if (estado == "")
			{
				throw new Exception("O campo Estado não pode ser vazio.");
			}

			if (estado.Length != 2)
			{
				throw new Exception("Insira a sigla de um estado");
			}
		}

		private void btnPlanilha_Click(object sender, EventArgs e)
		{
			var planilha = new frmPlanilha();
			planilha.ShowDialog();
		}

		private void frmPrincipal_KeyPress(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				btnSalvar_Click(sender, e);
			}
		}

		private void btnXlsx_Click(object sender, EventArgs e)
		{
			OpenFileDialog file = new OpenFileDialog();

			file.Filter = "Arquivos Excel (*.xlsx)|*.xlsx|Todos os arquivos (*.*)|*.*";
			file.FilterIndex = 1;

			DialogResult result = file.ShowDialog();

			if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(file.FileName))
			{
				MessageBox.Show("Diretório selecionado: " + file.FileName);
			}
			else
			{
				MessageBox.Show("Diretório selecionado: Nenhum");
			}
		}
	}
}
