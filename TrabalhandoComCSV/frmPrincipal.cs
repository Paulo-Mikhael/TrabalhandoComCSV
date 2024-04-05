using System.IO;

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
			var id = tbId.Text;
			var cpf = mtbCpf.Text;
			var nome = tbNome.Text;
			var sexo = cdSexo.Text;
			var endereco = tbEndereco.Text;
			var numero = mtbNumero.Text;
			var bairro = tbBairro.Text;
			var cep = mtbCep.Text;
			var municipio = tbMunicipio.Text;
			var estado = tbEstado.Text;

			var linha = $"{id},{cpf},{nome},{sexo},{endereco},{numero},{bairro},{cep},{municipio},{estado}";

			using (StreamWriter arquivo = new StreamWriter(@"C:\Users\Monica\Documents\TesteDadosCsv\clientes.csv", true))
			{
				arquivo.WriteLine(linha);
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

		private void mtbNumero_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
		{

		}

		private void btnPlanilha_Click(object sender, EventArgs e)
		{
			var planilha = new frmPlanilha();
			planilha.ShowDialog();
		}
	}
}
