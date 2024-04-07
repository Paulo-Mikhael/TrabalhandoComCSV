using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CsvHelper;
using Logica;
using Microsoft.Office.Interop.Excel;
using OfficeOpenXml;
using Excel = Microsoft.Office.Interop.Excel;
using LicenseContext = OfficeOpenXml.LicenseContext;

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
			int actualLine = planCrud.actualLine;
			CarregarPlanilha();
			CarregaDadosCsvPlanilha();
			lblStatus.Text = "Status: Pronto";
			tbLinha.Text = Convert.ToString(planCrud.actualLine - 2);
		}

		private void btnAbrir_Click(object sender, EventArgs e)
		{
			CarregarPlanilha();
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
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Erro");
			}
		}

		private void btnSalvar_Click(object sender, EventArgs e)
		{
			lblStatus.Text = "Status: Carregando a planilha de clientes, aguarde...";
			btnSalvar.Enabled = false;
			try
			{
				var csv = new Logica.csvCrud();
				planCrud.AtualizaPlanilha(tbId.Text, mtbCpf.Text, tbNome.Text, cdSexo.Text, tbEndereco.Text, mtbNumero.Text, tbBairro.Text,
					mtbCep.Text, tbEstado.Text, tbMunicipio.Text);
				csvCrud.AtualizaCsv(tbId.Text, mtbCpf.Text, tbNome.Text, cdSexo.Text, tbEndereco.Text, mtbNumero.Text, tbBairro.Text,
					mtbCep.Text, tbEstado.Text, tbMunicipio.Text);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
				lblStatus.Text = "Status: Pronto";
				btnSalvar.Enabled = true;
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
				lblTotal.Text = $"/ {Convert.ToString(planCrud.lastLine - 2)}";
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void btnProximo_Click(object sender, EventArgs e)
		{
			planCrud.actualLine++;
			int actualLine = planCrud.actualLine;

			lblStatus.Text = "Status: Carregando...";

			if (actualLine <= planCrud.lastLine)
			{
				CarregarPlanilha();
				lblStatus.Text = "Status: Pronto";
				tbLinha.Text = Convert.ToString(actualLine - 2);
			}
			else if (actualLine > planCrud.lastLine)
			{
				planCrud.actualLine--;
				lblStatus.Text = "Status: Sem mais dados";
			}

		}

		private void btnAnterior_Click(object sender, EventArgs e)
		{
			planCrud.actualLine--;
			int actualLine = planCrud.actualLine;

			lblStatus.Text = "Status: Carregando...";

			if (actualLine >= planCrud.firstLine)
			{
				CarregarPlanilha();
				lblStatus.Text = "Status: Pronto";
				tbLinha.Text = Convert.ToString(actualLine - 2);
			}
			else if (actualLine < planCrud.firstLine)
			{
				planCrud.actualLine++;
				lblStatus.Text = "Status: Início da tabela";
			}
		}

		private void btnPrimeiro_Click(object sender, EventArgs e)
		{
			lblStatus.Text = "Status: Carregando...";
			planCrud.actualLine = 3;
			CarregarPlanilha();
			lblStatus.Text = "Status: Pronto";
			tbLinha.Text = Convert.ToString(planCrud.actualLine - 2);
		}

		private void btnUltimo_Click(object sender, EventArgs e)
		{
			lblStatus.Text = "Status: Carregando...";
			planCrud.actualLine = planCrud.lastLine;
			CarregarPlanilha();
			lblStatus.Text = "Status: Pronto";
			tbLinha.Text = Convert.ToString(planCrud.lastLine - 2);
		}

		private void btnExcluir_Click(object sender, EventArgs e)
		{
			try
			{
				csvCrud.ExcluirCsv();

				LimparCadastro();

				CarregarPlanilha();

				tbLinha.Text = Convert.ToString(planCrud.actualLine - 2);
				lblTotal.Text = $"/ {Convert.ToString(planCrud.lastLine - 2)}";
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
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
		}
	}
}
