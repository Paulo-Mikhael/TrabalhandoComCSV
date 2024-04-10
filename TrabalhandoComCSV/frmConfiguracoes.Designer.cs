namespace TrabalhandoComCSV
{
	partial class frmConfiguracoes
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfiguracoes));
			btnMudarXlsx = new Button();
			label1 = new Label();
			lblXlsxDirectory = new Label();
			btnMudarCsv = new Button();
			label3 = new Label();
			lblCsvDirectory = new Label();
			label5 = new Label();
			label6 = new Label();
			label2 = new Label();
			label4 = new Label();
			label7 = new Label();
			label10 = new Label();
			tbCelula = new TextBox();
			tbPlanilha = new TextBox();
			label11 = new Label();
			label12 = new Label();
			groupBox1 = new GroupBox();
			btnSalvar = new Button();
			groupBox1.SuspendLayout();
			SuspendLayout();
			// 
			// btnMudarXlsx
			// 
			btnMudarXlsx.ForeColor = SystemColors.ActiveCaptionText;
			btnMudarXlsx.Location = new Point(609, 24);
			btnMudarXlsx.Name = "btnMudarXlsx";
			btnMudarXlsx.Size = new Size(76, 28);
			btnMudarXlsx.TabIndex = 0;
			btnMudarXlsx.Text = "Mudar";
			btnMudarXlsx.UseVisualStyleBackColor = true;
			btnMudarXlsx.Click += btnMudarXlsx_Click;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.ForeColor = SystemColors.Control;
			label1.Location = new Point(12, 43);
			label1.Name = "label1";
			label1.Size = new Size(124, 17);
			label1.TabIndex = 1;
			label1.Text = "Arquivo xlsx atual:";
			// 
			// lblXlsxDirectory
			// 
			lblXlsxDirectory.AutoSize = true;
			lblXlsxDirectory.ForeColor = Color.Coral;
			lblXlsxDirectory.Location = new Point(12, 73);
			lblXlsxDirectory.Name = "lblXlsxDirectory";
			lblXlsxDirectory.Size = new Size(267, 17);
			lblXlsxDirectory.TabIndex = 1;
			lblXlsxDirectory.Text = "C:\\Documents\\Programação\\Planilha.xlsx";
			// 
			// btnMudarCsv
			// 
			btnMudarCsv.ForeColor = SystemColors.ActiveCaptionText;
			btnMudarCsv.Location = new Point(609, 118);
			btnMudarCsv.Name = "btnMudarCsv";
			btnMudarCsv.Size = new Size(76, 28);
			btnMudarCsv.TabIndex = 0;
			btnMudarCsv.Text = "Mudar";
			btnMudarCsv.UseVisualStyleBackColor = true;
			btnMudarCsv.Click += btnMudarCsv_Click;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.ForeColor = SystemColors.Control;
			label3.Location = new Point(12, 124);
			label3.Name = "label3";
			label3.Size = new Size(124, 17);
			label3.TabIndex = 1;
			label3.Text = "Arquivo CSV atual:";
			// 
			// lblCsvDirectory
			// 
			lblCsvDirectory.AutoSize = true;
			lblCsvDirectory.ForeColor = Color.Coral;
			lblCsvDirectory.Location = new Point(12, 154);
			lblCsvDirectory.Name = "lblCsvDirectory";
			lblCsvDirectory.Size = new Size(251, 17);
			lblCsvDirectory.TabIndex = 1;
			lblCsvDirectory.Text = "C:\\Documents\\Programação\\Dados.csv";
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Font = new Font("Segoe UI", 7.75F, FontStyle.Bold);
			label5.ForeColor = SystemColors.Control;
			label5.Location = new Point(12, 26);
			label5.Name = "label5";
			label5.Size = new Size(49, 13);
			label5.TabIndex = 1;
			label5.Text = "Planilha";
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Font = new Font("Segoe UI", 7.75F, FontStyle.Bold);
			label6.ForeColor = SystemColors.Control;
			label6.Location = new Point(12, 107);
			label6.Name = "label6";
			label6.Size = new Size(165, 13);
			label6.TabIndex = 1;
			label6.Text = "Arquivo separado por vírgulas";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
			label2.ForeColor = SystemColors.Control;
			label2.Location = new Point(23, 220);
			label2.Name = "label2";
			label2.Size = new Size(248, 25);
			label2.TabIndex = 1;
			label2.Text = "Configurações da planilha:";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.ForeColor = SystemColors.Control;
			label4.Location = new Point(23, 289);
			label4.Name = "label4";
			label4.Size = new Size(91, 17);
			label4.TabIndex = 1;
			label4.Text = "Célula inicial:";
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Font = new Font("Segoe UI", 7.75F, FontStyle.Bold);
			label7.ForeColor = SystemColors.Control;
			label7.Location = new Point(23, 272);
			label7.Name = "label7";
			label7.Size = new Size(51, 13);
			label7.TabIndex = 1;
			label7.Text = "De A a Z";
			// 
			// label10
			// 
			label10.AutoSize = true;
			label10.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
			label10.ForeColor = SystemColors.Control;
			label10.Location = new Point(23, 327);
			label10.Name = "label10";
			label10.Size = new Size(136, 20);
			label10.TabIndex = 1;
			label10.Text = "Nome da planilha:";
			// 
			// tbCelula
			// 
			tbCelula.Location = new Point(120, 281);
			tbCelula.Name = "tbCelula";
			tbCelula.Size = new Size(51, 25);
			tbCelula.TabIndex = 3;
			tbCelula.TextChanged += tbCelula_TextChanged;
			// 
			// tbPlanilha
			// 
			tbPlanilha.Location = new Point(165, 326);
			tbPlanilha.Name = "tbPlanilha";
			tbPlanilha.Size = new Size(187, 25);
			tbPlanilha.TabIndex = 3;
			// 
			// label11
			// 
			label11.AutoSize = true;
			label11.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
			label11.ForeColor = Color.Gold;
			label11.Location = new Point(396, 219);
			label11.Name = "label11";
			label11.Size = new Size(68, 25);
			label11.TabIndex = 1;
			label11.Text = "Avisos";
			label11.Click += label11_Click;
			// 
			// label12
			// 
			label12.AutoSize = true;
			label12.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
			label12.ForeColor = Color.Gold;
			label12.Location = new Point(396, 259);
			label12.Name = "label12";
			label12.Size = new Size(327, 95);
			label12.TabIndex = 1;
			label12.Text = "Ficar com a planilha aberta no Excel, \r\nimpossibilitará o software modificar a planilha;\r\n\r\nO arquivo CSV deve conter um cabeçalho, pois \r\no software ignorará a primeira linha;\r\n";
			label12.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(lblCsvDirectory);
			groupBox1.Controls.Add(lblXlsxDirectory);
			groupBox1.Controls.Add(label3);
			groupBox1.Controls.Add(label6);
			groupBox1.Controls.Add(label5);
			groupBox1.Controls.Add(label1);
			groupBox1.Controls.Add(btnMudarCsv);
			groupBox1.Controls.Add(btnMudarXlsx);
			groupBox1.ForeColor = SystemColors.Control;
			groupBox1.Location = new Point(19, 12);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(704, 188);
			groupBox1.TabIndex = 4;
			groupBox1.TabStop = false;
			groupBox1.Text = "Diretórios";
			// 
			// btnSalvar
			// 
			btnSalvar.Location = new Point(277, 220);
			btnSalvar.Name = "btnSalvar";
			btnSalvar.Size = new Size(75, 29);
			btnSalvar.TabIndex = 5;
			btnSalvar.Text = "Salvar";
			btnSalvar.UseVisualStyleBackColor = true;
			btnSalvar.Click += btnSalvar_Click;
			// 
			// frmConfiguracoes
			// 
			AutoScaleMode = AutoScaleMode.None;
			BackColor = Color.Blue;
			ClientSize = new Size(750, 376);
			Controls.Add(btnSalvar);
			Controls.Add(groupBox1);
			Controls.Add(tbPlanilha);
			Controls.Add(tbCelula);
			Controls.Add(label12);
			Controls.Add(label11);
			Controls.Add(label2);
			Controls.Add(label10);
			Controls.Add(label4);
			Controls.Add(label7);
			Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			FormBorderStyle = FormBorderStyle.Fixed3D;
			Icon = (Icon)resources.GetObject("$this.Icon");
			MaximizeBox = false;
			Name = "frmConfiguracoes";
			StartPosition = FormStartPosition.CenterParent;
			Text = "Configurações";
			Load += frmConfiguracoes_Load;
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button btnMudarXlsx;
		private Label label1;
		private Label lblXlsxDirectory;
		private Button btnMudarCsv;
		private Label label3;
		private Label lblCsvDirectory;
		private Label label5;
		private Label label6;
		private Label label2;
		private Label label4;
		private Label label7;
		private Label label10;
		private TextBox tbCelula;
		private TextBox tbPlanilha;
		private Label label11;
		private Label label12;
		private GroupBox groupBox1;
		private Button btnSalvar;
	}
}