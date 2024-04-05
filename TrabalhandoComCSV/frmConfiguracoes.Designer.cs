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
			btnMudarXlsx = new Button();
			label1 = new Label();
			lblXlsxDirectory = new Label();
			btnMudarCsv = new Button();
			label3 = new Label();
			lblCsvDirectory = new Label();
			label5 = new Label();
			label6 = new Label();
			label2 = new Label();
			groupBox1 = new GroupBox();
			label4 = new Label();
			label7 = new Label();
			label8 = new Label();
			label9 = new Label();
			label10 = new Label();
			textBox1 = new TextBox();
			textBox2 = new TextBox();
			textBox3 = new TextBox();
			SuspendLayout();
			// 
			// btnMudarXlsx
			// 
			btnMudarXlsx.Location = new Point(308, 36);
			btnMudarXlsx.Name = "btnMudarXlsx";
			btnMudarXlsx.Size = new Size(76, 28);
			btnMudarXlsx.TabIndex = 0;
			btnMudarXlsx.Text = "Mudar";
			btnMudarXlsx.UseVisualStyleBackColor = true;
			btnMudarXlsx.Click += this.button1_Click;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.ForeColor = SystemColors.Control;
			label1.Location = new Point(22, 42);
			label1.Name = "label1";
			label1.Size = new Size(124, 17);
			label1.TabIndex = 1;
			label1.Text = "Arquivo xlsx atual:";
			label1.Click += label1_Click;
			// 
			// lblXlsxDirectory
			// 
			lblXlsxDirectory.AutoSize = true;
			lblXlsxDirectory.ForeColor = Color.Coral;
			lblXlsxDirectory.Location = new Point(22, 74);
			lblXlsxDirectory.Name = "lblXlsxDirectory";
			lblXlsxDirectory.Size = new Size(267, 17);
			lblXlsxDirectory.TabIndex = 1;
			lblXlsxDirectory.Text = "C:\\Documents\\Programação\\Planilha.xlsx";
			lblXlsxDirectory.Click += label1_Click;
			// 
			// btnMudarCsv
			// 
			btnMudarCsv.Location = new Point(308, 130);
			btnMudarCsv.Name = "btnMudarCsv";
			btnMudarCsv.Size = new Size(76, 28);
			btnMudarCsv.TabIndex = 0;
			btnMudarCsv.Text = "Mudar";
			btnMudarCsv.UseVisualStyleBackColor = true;
			btnMudarCsv.Click += this.button1_Click;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.ForeColor = SystemColors.Control;
			label3.Location = new Point(22, 136);
			label3.Name = "label3";
			label3.Size = new Size(124, 17);
			label3.TabIndex = 1;
			label3.Text = "Arquivo CSV atual:";
			label3.Click += label1_Click;
			// 
			// lblCsvDirectory
			// 
			lblCsvDirectory.AutoSize = true;
			lblCsvDirectory.ForeColor = Color.Coral;
			lblCsvDirectory.Location = new Point(22, 168);
			lblCsvDirectory.Name = "lblCsvDirectory";
			lblCsvDirectory.Size = new Size(251, 17);
			lblCsvDirectory.TabIndex = 1;
			lblCsvDirectory.Text = "C:\\Documents\\Programação\\Dados.csv";
			lblCsvDirectory.Click += label1_Click;
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Font = new Font("Segoe UI", 7.75F, FontStyle.Bold);
			label5.ForeColor = SystemColors.Control;
			label5.Location = new Point(22, 25);
			label5.Name = "label5";
			label5.Size = new Size(49, 13);
			label5.TabIndex = 1;
			label5.Text = "Planilha";
			label5.Click += label1_Click;
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Font = new Font("Segoe UI", 7.75F, FontStyle.Bold);
			label6.ForeColor = SystemColors.Control;
			label6.Location = new Point(22, 119);
			label6.Name = "label6";
			label6.Size = new Size(165, 13);
			label6.TabIndex = 1;
			label6.Text = "Arquivo separado por vírgulas";
			label6.Click += label1_Click;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
			label2.ForeColor = SystemColors.Control;
			label2.Location = new Point(22, 250);
			label2.Name = "label2";
			label2.Size = new Size(248, 25);
			label2.TabIndex = 1;
			label2.Text = "Configurações da planilha:";
			label2.Click += label1_Click;
			// 
			// groupBox1
			// 
			groupBox1.ForeColor = SystemColors.ControlLight;
			groupBox1.Location = new Point(410, 25);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(314, 207);
			groupBox1.TabIndex = 2;
			groupBox1.TabStop = false;
			groupBox1.Text = "Prévia";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.ForeColor = SystemColors.Control;
			label4.Location = new Point(22, 327);
			label4.Name = "label4";
			label4.Size = new Size(91, 17);
			label4.TabIndex = 1;
			label4.Text = "Célula inicial:";
			label4.Click += label1_Click;
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Font = new Font("Segoe UI", 7.75F, FontStyle.Bold);
			label7.ForeColor = SystemColors.Control;
			label7.Location = new Point(22, 310);
			label7.Name = "label7";
			label7.Size = new Size(51, 13);
			label7.TabIndex = 1;
			label7.Text = "De A a Z";
			label7.Click += label1_Click;
			// 
			// label8
			// 
			label8.AutoSize = true;
			label8.Font = new Font("Segoe UI", 7.75F, FontStyle.Bold);
			label8.ForeColor = SystemColors.Control;
			label8.Location = new Point(22, 369);
			label8.Name = "label8";
			label8.Size = new Size(51, 13);
			label8.TabIndex = 1;
			label8.Text = "De A a Z";
			label8.Click += label1_Click;
			// 
			// label9
			// 
			label9.AutoSize = true;
			label9.ForeColor = SystemColors.Control;
			label9.Location = new Point(22, 386);
			label9.Name = "label9";
			label9.Size = new Size(82, 17);
			label9.TabIndex = 1;
			label9.Text = "Célula final:";
			label9.Click += label1_Click;
			// 
			// label10
			// 
			label10.AutoSize = true;
			label10.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
			label10.ForeColor = SystemColors.Control;
			label10.Location = new Point(410, 383);
			label10.Name = "label10";
			label10.Size = new Size(136, 20);
			label10.TabIndex = 1;
			label10.Text = "Nome da planilha:";
			label10.Click += label1_Click;
			// 
			// textBox1
			// 
			textBox1.Location = new Point(119, 319);
			textBox1.Name = "textBox1";
			textBox1.Size = new Size(51, 25);
			textBox1.TabIndex = 3;
			// 
			// textBox2
			// 
			textBox2.Location = new Point(119, 378);
			textBox2.Name = "textBox2";
			textBox2.Size = new Size(51, 25);
			textBox2.TabIndex = 3;
			// 
			// textBox3
			// 
			textBox3.Location = new Point(552, 382);
			textBox3.Name = "textBox3";
			textBox3.Size = new Size(172, 25);
			textBox3.TabIndex = 3;
			// 
			// frmConfiguracoes
			// 
			AutoScaleMode = AutoScaleMode.None;
			BackColor = Color.Blue;
			ClientSize = new Size(750, 450);
			Controls.Add(textBox2);
			Controls.Add(textBox3);
			Controls.Add(textBox1);
			Controls.Add(groupBox1);
			Controls.Add(lblCsvDirectory);
			Controls.Add(lblXlsxDirectory);
			Controls.Add(label2);
			Controls.Add(label9);
			Controls.Add(label10);
			Controls.Add(label4);
			Controls.Add(label3);
			Controls.Add(label8);
			Controls.Add(label6);
			Controls.Add(label7);
			Controls.Add(label5);
			Controls.Add(label1);
			Controls.Add(btnMudarCsv);
			Controls.Add(btnMudarXlsx);
			Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			FormBorderStyle = FormBorderStyle.Fixed3D;
			MaximizeBox = false;
			Name = "frmConfiguracoes";
			StartPosition = FormStartPosition.CenterParent;
			Text = "Configurações";
			Load += frmConfiguracoes_Load;
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
		private GroupBox groupBox1;
		private Label label4;
		private Label label7;
		private Label label8;
		private Label label9;
		private Label label10;
		private TextBox textBox1;
		private TextBox textBox2;
		private TextBox textBox3;
	}
}