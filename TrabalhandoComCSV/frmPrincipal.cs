using Logica;

namespace TrabalhandoComCSV
{
	public partial class frmPrincipal : Form
	{
		public frmPrincipal()
		{
			InitializeComponent();
		}

		private void frmPrincipal_Load(object sender, EventArgs e)
		{
			string nomeUsuario = Environment.UserName;
			string excelPath = $@"C:/Users/{nomeUsuario}/TabelaClientes.xlsx";
			string csvPath = $@"C:/Users/{nomeUsuario}/clientes.csv";

			try
			{
				if (!File.Exists(excelPath))
				{
					var plan = new planCrud();
					plan.CriarArquivoXlsx(excelPath);
				}

				if (!File.Exists(csvPath))
				{
					var csv = new csvCrud();
					csv.CriarArquivoCsv(csvPath);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Erro ao criar arquivos iniciais. Por favor, selecione um diretório manualmente pelas configurações.\r\n" +
					"Erro: {ex.Message}");
			}
			finally
			{
				planCrud.excelPath = excelPath;
				csvCrud.csvPath = csvPath;
			}
		}

		private void btnSalvar_Click(object sender, EventArgs e)
		{
			Cursor = Cursors.WaitCursor;

			btnSalvar.Visible = false;

			var csv = new Logica.csvCrud();
			var frmPlanilha = new frmPlanilha();
			var verificacao = new verificacao();

			var cpf = mtbCpf.Text;
			var nome = tbNome.Text.Replace(",", "");
			var sexo = cdSexo.SelectedIndex;
			var endereco = tbEndereco.Text.Replace(",", "");
			var numero = mtbNumero.Text;
			var bairro = tbBairro.Text.Replace(",", "");
			var cep = mtbCep.Text;
			var municipio = tbMunicipio.Text.Replace(",", "");
			var estado = tbEstado.Text.Replace(",", "");

			try
			{
				verificacao.VerificaCampos(cpf, nome, sexo, endereco, numero, bairro, cep, municipio, estado);

				csv.SalvarClienteCsv(tbId.Text, cpf, nome, cdSexo.Text, endereco, numero, bairro, cep, municipio, estado.ToUpper());
				LimparForm();
				btnSalvar.Enabled = true;
				frmPlanilha.CarregaDadosCsvPlanilha();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Problemas no cadastro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			finally
			{
				btnSalvar.Visible = true;
				Cursor = Cursors.Default;
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

		private void btnPlanilha_Click(object sender, EventArgs e)
		{
			Cursor = Cursors.WaitCursor;
			var planilha = new frmPlanilha();
			planilha.ShowDialog();
			Cursor = Cursors.Default;
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

		private void btnGerar_Click(object sender, EventArgs e)
		{
			tbId.Text = "1";
			mtbCpf.Text = "123.456.789-09";
			tbNome.Text = "João Oliveira de Souza";
			tbBairro.Text = "Sé";
			tbMunicipio.Text = "São Paulo";
			tbEstado.Text = "SP";
			tbEndereco.Text = "Praça da Sé";
			mtbCep.Text = "01001-000";
			mtbNumero.Text = "(11) 12345-6789";
			cdSexo.SelectedIndex = 0;
		}
	}
}
