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
			var csv = new Logica.csvCrud();
			var frmPlanilha = new frmPlanilha();

			try
			{
				btnSalvar.Enabled = false;

				VerificaCampos();
				csv.SalvarClienteCsv(tbId.Text, mtbCpf.Text, tbNome.Text, cdSexo.Text, tbEndereco.Text, mtbNumero.Text, tbBairro.Text,
					mtbCep.Text, tbMunicipio.Text, tbEstado.Text);
				LimparForm();
				btnSalvar.Enabled = true;
				frmPlanilha.CarregaDadosCsvPlanilha();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Problemas no cadastro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				btnSalvar.Enabled = true;
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
				throw new Exception("O campo Nome n�o pode ser vazio");
			}

			if (sexo == -1)
			{
				throw new Exception("Defina seu Sexo");
			}

			if (endereco == "")
			{
				throw new Exception("O campo Endere�o n�o pode ser vazio");
			}

			if (bairro == "")
			{
				throw new Exception("O campo Bairro n�o pode ser vazio");
			}

			if (municipio == "")
			{
				throw new Exception("O campo Municipio n�o pode ser vazio");
			}

			if (numero.Length != 11)
			{
				throw new Exception("Insira um n�mero para contato");
			}

			if (cep.Length != 8)
			{
				throw new Exception("Insira um Cep");
			}

			if (estado == "")
			{
				throw new Exception("O campo Estado n�o pode ser vazio.");
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

		private void btnConfiguracoes_Click(object sender, EventArgs e)
		{
			var config = new frmConfiguracoes();
			config.ShowDialog();
		}
	}
}
