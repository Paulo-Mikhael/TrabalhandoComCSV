using Logica;

namespace TrabalhandoComCSV
{
	public partial class frmPlanilha : Form
	{
		Logica.csvCrud csvCrud = new Logica.csvCrud();
		Logica.planCrud planCrud = new Logica.planCrud();

		public frmPlanilha()
		{
			InitializeComponent();
		}

		private void frmPlanilha_Load(object sender, EventArgs e)
		{
			var plan = new planCrud();
			plan.NumeroCorte();
			CarregaDadosCsvPlanilha();
			CarregarPlanilha();
			lblStatus.Text = "Status: Pronto";
			tbLinha.Text = Convert.ToString(planCrud.planActualLine - planCrud.linhaCorte);
			tbPlanilha.Text = planCrud.planilha;
		}

		private void btnAbrir_Click(object sender, EventArgs e)
		{
			Cursor = Cursors.WaitCursor;
			btnAbrir.Visible = false;
			try
			{
				CarregaDadosCsvPlanilha();
				CarregarPlanilha();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				btnAbrir.Visible = true;
				Cursor = Cursors.Default;
			}
		}

		private void CarregarPlanilha()
		{
			try
			{
				var dadosPlanilha = planCrud.CarregarPlanilha();

				lblStatus.Text = "Status: Carregando dados...";

				tbId.Text = dadosPlanilha[0];
				mtbCpf.Text = dadosPlanilha[1];
				tbNome.Text = dadosPlanilha[2];
				cdSexo.Text = dadosPlanilha[3];
				tbEndereco.Text = dadosPlanilha[4];
				mtbNumero.Text = dadosPlanilha[5];
				tbBairro.Text = dadosPlanilha[6];
				mtbCep.Text = dadosPlanilha[7];
				tbMunicipio.Text = dadosPlanilha[8];
				tbEstado.Text = dadosPlanilha[9];

				lblStatus.Text = "Status: Pronto";

				mtbCpf.Focus();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnSalvar_Click(object sender, EventArgs e)
		{
			lblStatus.Text = "Status: Carregando a planilha de clientes, aguarde...";
			btnSalvar.Enabled = false;
			Cursor = Cursors.WaitCursor;

			try
			{
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

				verificacao.VerificaCampos(cpf, nome, sexo, endereco, numero, bairro, cep, municipio, estado);

				planCrud.AtualizaPlanilha(tbId.Text, cpf, nome, cdSexo.Text, endereco, numero, bairro, cep, municipio, estado);
				csvCrud.AtualizaCsv(tbId.Text, cpf, nome, cdSexo.Text, endereco, numero, bairro, cep, municipio, estado);

				MessageBox.Show("Dados salvos com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
				lblStatus.Text = "Status: Pronto";
				btnSalvar.Enabled = true;
				Cursor = Cursors.Default;
			}
		}

		private void LimparCadastro()
		{
			tbId.Text = "";
			tbNome.Text = "";
			mtbCpf.Text = "";
			cdSexo.Text = "";
			tbEndereco.Text = "";
			mtbNumero.Text = "";
			tbBairro.Text = "";
			mtbCep.Text = "";
			tbEstado.Text = "";
			tbMunicipio.Text = "";
			cdSexo.SelectedIndex = -1;
		}

		public void CarregaDadosCsvPlanilha()
		{
			try
			{
				planCrud.CarregarCsvPlanilha();
				lblTotal.Text = $"/ {Convert.ToString(planCrud.planLastLine - planCrud.linhaCorte)}";
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnProximo_Click(object sender, EventArgs e)
		{
			if (Cursor != Cursors.WaitCursor)
			{
				Cursor = Cursors.WaitCursor;
				planCrud.planActualLine++;
				int actualLine = planCrud.planActualLine - planCrud.linhaCorte;

				lblStatus.Text = "Status: Carregando...";

				btnProximo.Enabled = false;
				btnAnterior.Enabled = false;

				if (planCrud.planActualLine <= planCrud.planLastLine)
				{
					CarregarPlanilha();
					lblStatus.Text = "Status: Pronto";
					tbLinha.Text = Convert.ToString(actualLine);
				}
				else if (planCrud.planActualLine > planCrud.planLastLine)
				{
					planCrud.planActualLine--;
					lblStatus.Text = "Status: Sem mais dados";
				}

				btnProximo.Enabled = true;
				btnAnterior.Enabled = true;
			}
			Cursor = Cursors.Default;
		}

		private void btnAnterior_Click(object sender, EventArgs e)
		{
			if (Cursor != Cursors.WaitCursor)
			{
				Cursor = Cursors.WaitCursor;
				planCrud.planActualLine--;
				int actualLine = planCrud.planActualLine - planCrud.linhaCorte;

				lblStatus.Text = "Status: Carregando...";

				btnProximo.Enabled = false;
				btnAnterior.Enabled = false;

				if (planCrud.planActualLine >= planCrud.planFirstLine)
				{
					CarregarPlanilha();
					lblStatus.Text = "Status: Pronto";
					tbLinha.Text = Convert.ToString(actualLine);
				}
				else if (planCrud.planActualLine < planCrud.planFirstLine)
				{
					planCrud.planActualLine++;
					lblStatus.Text = "Status: Início da tabela";
				}

				btnProximo.Enabled = true;
				btnAnterior.Enabled = true;
			}
			Cursor = Cursors.Default;
		}

		private void btnPrimeiro_Click(object sender, EventArgs e)
		{
			Cursor = Cursors.WaitCursor;
			lblStatus.Text = "Status: Carregando...";
			planCrud.planActualLine = planCrud.planFirstLine;
			CarregarPlanilha();
			Cursor = Cursors.Default;
			lblStatus.Text = "Status: Pronto";
			tbLinha.Text = Convert.ToString(planCrud.planActualLine - planCrud.linhaCorte);
		}

		private void btnUltimo_Click(object sender, EventArgs e)
		{
			Cursor = Cursors.WaitCursor;
			lblStatus.Text = "Status: Carregando...";
			planCrud.planActualLine = planCrud.planLastLine;
			CarregarPlanilha();
			Cursor = Cursors.Default;
			lblStatus.Text = "Status: Pronto";
			tbLinha.Text = Convert.ToString(planCrud.planLastLine - planCrud.linhaCorte);
		}

		private void btnExcluir_Click(object sender, EventArgs e)
		{
			try
			{
				var result = MessageBox.Show($"Deseja excluir o cliente {tbNome.Text} de ID {tbId.Text}?", "Confirmação",
					MessageBoxButtons.YesNo, MessageBoxIcon.Question);

				if (result == DialogResult.Yes)
				{
					Cursor = Cursors.WaitCursor;
					btnExcluir.Visible = false;

					csvCrud.ExcluirCsv();

					LimparCadastro();

					CarregarPlanilha();

					tbLinha.Text = Convert.ToString(planCrud.planActualLine - planCrud.linhaCorte);
					lblTotal.Text = $"/ {Convert.ToString(planCrud.planLastLine - planCrud.linhaCorte)}";
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
				btnExcluir.Visible = true;
				Cursor = Cursors.Default;
			}
		}

		private void btnAviso_MouseEnter(object sender, EventArgs e)
		{
			btnAviso.BackgroundImage = Properties.Resources.aviso;
		}

		private void btnAviso_MouseLeave(object sender, EventArgs e)
		{
			btnAviso.BackgroundImage = Properties.Resources.aviso_hover;
		}

		private void btnAviso_MouseHover(object sender, EventArgs e)
		{
			btnAviso.BackColor = Color.Sienna;
			btnConfig.BackColor = Color.Sienna;
		}

		private void tbLinha_Leave(object sender, EventArgs e)
		{
			Cursor = Cursors.WaitCursor;
			if (int.TryParse(tbLinha.Text, out int valor) == true && valor <= planCrud.planLastLine - planCrud.linhaCorte
				&& valor >= planCrud.planFirstLine - planCrud.linhaCorte)
			{
				planCrud.planActualLine = valor + planCrud.linhaCorte;
				CarregarPlanilha();
			}
			else if (int.TryParse(tbLinha.Text, out _) == false || valor > planCrud.planLastLine - planCrud.linhaCorte
				|| valor < planCrud.planFirstLine - planCrud.linhaCorte)
			{
				planCrud.planActualLine = planCrud.planFirstLine;
				CarregarPlanilha();
				tbLinha.Text = Convert.ToString(planCrud.planFirstLine - planCrud.linhaCorte);
			}
			Cursor = Cursors.Default;
		}

		private void frmPlanilha_KeyDown(object sender, KeyEventArgs e)
		{
			if (Cursor != Cursors.WaitCursor)
			{
				if (e.KeyCode == Keys.S && e.Control)
				{
					btnSalvar_Click(sender, e);
				}

				if (e.KeyCode == Keys.E && e.Control)
				{
					btnExcluir_Click(sender, e);
				}

				if (e.KeyCode == Keys.F5)
				{
					btnAbrir_Click(sender, e);
				}

				if (e.KeyCode == Keys.Down && e.Shift)
				{
					btnUltimo_Click(sender, e);
				}

				if (e.KeyCode == Keys.Up && e.Shift)
				{
					btnPrimeiro_Click(sender, e);
				}

				if (e.KeyCode == Keys.Left && e.Shift)
				{
					btnAnterior_Click(sender, e);
				}

				if (e.KeyCode == Keys.Right && e.Shift)
				{
					btnProximo_Click(sender, e);
				}
			}
		}

		private void btnConfig_Click(object sender, EventArgs e)
		{
			var config = new frmConfiguracoes();
			config.ShowDialog();

			if (tbPlanilha.Text != planCrud.planilha)
			{
				tbPlanilha.Text = planCrud.planilha;
				MessageBox.Show("A planilha atual foi alterada. É necessário atualizar para passar os dados para a nova planilha.",
					"Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void btnAviso_Click(object sender, EventArgs e)
		{
			var controls = new frmControles();
			controls.ShowDialog();
			mtbCpf.Focus();
		}
	}
}
