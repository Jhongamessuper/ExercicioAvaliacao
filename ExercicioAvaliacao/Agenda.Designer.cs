namespace ExercicioAvaliacao
{
    partial class Agenda
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIdAgenda = new System.Windows.Forms.TextBox();
            this.dtpData = new System.Windows.Forms.DateTimePicker();
            this.rtbDescricao = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbHora = new System.Windows.Forms.ComboBox();
            this.txtPesquisar = new System.Windows.Forms.TextBox();
            this.dgwAgenda = new System.Windows.Forms.DataGridView();
            this.label11 = new System.Windows.Forms.Label();
            this.btnDeletar = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnInserir = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgwAgenda)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(414, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Data";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Descrição";
            // 
            // txtIdAgenda
            // 
            this.txtIdAgenda.Enabled = false;
            this.txtIdAgenda.Location = new System.Drawing.Point(117, 42);
            this.txtIdAgenda.Name = "txtIdAgenda";
            this.txtIdAgenda.Size = new System.Drawing.Size(56, 20);
            this.txtIdAgenda.TabIndex = 3;
            // 
            // dtpData
            // 
            this.dtpData.Location = new System.Drawing.Point(486, 89);
            this.dtpData.Name = "dtpData";
            this.dtpData.Size = new System.Drawing.Size(262, 20);
            this.dtpData.TabIndex = 4;
            this.dtpData.Value = new System.DateTime(2022, 9, 22, 0, 0, 0, 0);
            // 
            // rtbDescricao
            // 
            this.rtbDescricao.Location = new System.Drawing.Point(117, 136);
            this.rtbDescricao.Name = "rtbDescricao";
            this.rtbDescricao.Size = new System.Drawing.Size(631, 162);
            this.rtbDescricao.TabIndex = 5;
            this.rtbDescricao.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Hora";
            // 
            // cmbHora
            // 
            this.cmbHora.FormattingEnabled = true;
            this.cmbHora.Items.AddRange(new object[] {
            "8:00",
            "9:00"});
            this.cmbHora.Location = new System.Drawing.Point(117, 87);
            this.cmbHora.Name = "cmbHora";
            this.cmbHora.Size = new System.Drawing.Size(112, 21);
            this.cmbHora.TabIndex = 7;
            // 
            // txtPesquisar
            // 
            this.txtPesquisar.Location = new System.Drawing.Point(462, 31);
            this.txtPesquisar.Name = "txtPesquisar";
            this.txtPesquisar.Size = new System.Drawing.Size(245, 20);
            this.txtPesquisar.TabIndex = 14;
            this.txtPesquisar.TextChanged += new System.EventHandler(this.txtPesquisar_TextChanged);
            // 
            // dgwAgenda
            // 
            this.dgwAgenda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwAgenda.Location = new System.Drawing.Point(19, 73);
            this.dgwAgenda.Name = "dgwAgenda";
            this.dgwAgenda.Size = new System.Drawing.Size(690, 135);
            this.dgwAgenda.TabIndex = 13;
            this.dgwAgenda.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwAgenda_CellContentDoubleClick);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(461, 12);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 13);
            this.label11.TabIndex = 3;
            this.label11.Text = "PESQUISAR";
            // 
            // btnDeletar
            // 
            this.btnDeletar.Location = new System.Drawing.Point(319, 22);
            this.btnDeletar.Name = "btnDeletar";
            this.btnDeletar.Size = new System.Drawing.Size(121, 28);
            this.btnDeletar.TabIndex = 0;
            this.btnDeletar.Text = "DELETAR";
            this.btnDeletar.UseVisualStyleBackColor = true;
            this.btnDeletar.Click += new System.EventHandler(this.btnDeletar_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Location = new System.Drawing.Point(169, 22);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(121, 28);
            this.btnAlterar.TabIndex = 0;
            this.btnAlterar.Text = "ALTERAR";
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnInserir
            // 
            this.btnInserir.Location = new System.Drawing.Point(19, 22);
            this.btnInserir.Name = "btnInserir";
            this.btnInserir.Size = new System.Drawing.Size(121, 28);
            this.btnInserir.TabIndex = 0;
            this.btnInserir.Text = "INSERIR";
            this.btnInserir.UseVisualStyleBackColor = true;
            this.btnInserir.Click += new System.EventHandler(this.btnInserir_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtPesquisar);
            this.panel1.Controls.Add(this.dgwAgenda);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.btnDeletar);
            this.panel1.Controls.Add(this.btnAlterar);
            this.panel1.Controls.Add(this.btnInserir);
            this.panel1.Location = new System.Drawing.Point(40, 325);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(728, 225);
            this.panel1.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(263, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Título";
            // 
            // txtTitulo
            // 
            this.txtTitulo.Location = new System.Drawing.Point(330, 41);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(419, 20);
            this.txtTitulo.TabIndex = 18;
            // 
            // Agenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 576);
            this.Controls.Add(this.txtTitulo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmbHora);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rtbDescricao);
            this.Controls.Add(this.dtpData);
            this.Controls.Add(this.txtIdAgenda);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Agenda";
            this.Text = "Agenda";
            ((System.ComponentModel.ISupportInitialize)(this.dgwAgenda)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIdAgenda;
        private System.Windows.Forms.DateTimePicker dtpData;
        private System.Windows.Forms.RichTextBox rtbDescricao;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbHora;
        private System.Windows.Forms.TextBox txtPesquisar;
        private System.Windows.Forms.DataGridView dgwAgenda;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnDeletar;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnInserir;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTitulo;
    }
}