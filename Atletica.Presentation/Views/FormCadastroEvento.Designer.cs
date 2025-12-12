namespace Atletica.Presentation.Views
{
    partial class FormCadastroEvento
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.lblDataInicio = new System.Windows.Forms.Label();
            this.dtpDataInicio = new System.Windows.Forms.DateTimePicker();
            this.chkTemDataFim = new System.Windows.Forms.CheckBox();
            this.dtpDataFim = new System.Windows.Forms.DateTimePicker();
            this.lblLocal = new System.Windows.Forms.Label();
            this.txtLocal = new System.Windows.Forms.TextBox();
            this.lblResponsavel = new System.Windows.Forms.Label();
            this.cmbResponsavel = new System.Windows.Forms.ComboBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTitulo.Location = new System.Drawing.Point(20, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(47, 19);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Título:";
            // 
            // txtTitulo
            // 
            this.txtTitulo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTitulo.Location = new System.Drawing.Point(20, 45);
            this.txtTitulo.MaxLength = 200;
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(440, 25);
            this.txtTitulo.TabIndex = 1;
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDescricao.Location = new System.Drawing.Point(20, 80);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(72, 19);
            this.lblDescricao.TabIndex = 2;
            this.lblDescricao.Text = "Descrição:";
            // 
            // txtDescricao
            // 
            this.txtDescricao.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDescricao.Location = new System.Drawing.Point(20, 105);
            this.txtDescricao.Multiline = true;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescricao.Size = new System.Drawing.Size(440, 80);
            this.txtDescricao.TabIndex = 3;
            // 
            // lblDataInicio
            // 
            this.lblDataInicio.AutoSize = true;
            this.lblDataInicio.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDataInicio.Location = new System.Drawing.Point(20, 200);
            this.lblDataInicio.Name = "lblDataInicio";
            this.lblDataInicio.Size = new System.Drawing.Size(96, 19);
            this.lblDataInicio.TabIndex = 4;
            this.lblDataInicio.Text = "Data de Início:";
            // 
            // dtpDataInicio
            // 
            this.dtpDataInicio.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpDataInicio.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpDataInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDataInicio.Location = new System.Drawing.Point(20, 225);
            this.dtpDataInicio.Name = "dtpDataInicio";
            this.dtpDataInicio.Size = new System.Drawing.Size(200, 25);
            this.dtpDataInicio.TabIndex = 5;
            // 
            // chkTemDataFim
            // 
            this.chkTemDataFim.AutoSize = true;
            this.chkTemDataFim.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkTemDataFim.Location = new System.Drawing.Point(240, 200);
            this.chkTemDataFim.Name = "chkTemDataFim";
            this.chkTemDataFim.Size = new System.Drawing.Size(100, 23);
            this.chkTemDataFim.TabIndex = 6;
            this.chkTemDataFim.Text = "Data de Fim";
            this.chkTemDataFim.UseVisualStyleBackColor = true;
            this.chkTemDataFim.CheckedChanged += new System.EventHandler(this.chkTemDataFim_CheckedChanged);
            // 
            // dtpDataFim
            // 
            this.dtpDataFim.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpDataFim.Enabled = false;
            this.dtpDataFim.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpDataFim.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDataFim.Location = new System.Drawing.Point(240, 225);
            this.dtpDataFim.Name = "dtpDataFim";
            this.dtpDataFim.Size = new System.Drawing.Size(200, 25);
            this.dtpDataFim.TabIndex = 7;
            // 
            // lblLocal
            // 
            this.lblLocal.AutoSize = true;
            this.lblLocal.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblLocal.Location = new System.Drawing.Point(20, 265);
            this.lblLocal.Name = "lblLocal";
            this.lblLocal.Size = new System.Drawing.Size(43, 19);
            this.lblLocal.TabIndex = 8;
            this.lblLocal.Text = "Local:";
            // 
            // txtLocal
            // 
            this.txtLocal.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtLocal.Location = new System.Drawing.Point(20, 290);
            this.txtLocal.MaxLength = 300;
            this.txtLocal.Name = "txtLocal";
            this.txtLocal.Size = new System.Drawing.Size(440, 25);
            this.txtLocal.TabIndex = 9;
            // 
            // lblResponsavel
            // 
            this.lblResponsavel.AutoSize = true;
            this.lblResponsavel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblResponsavel.Location = new System.Drawing.Point(20, 330);
            this.lblResponsavel.Name = "lblResponsavel";
            this.lblResponsavel.Size = new System.Drawing.Size(147, 19);
            this.lblResponsavel.TabIndex = 10;
            this.lblResponsavel.Text = "Responsável (Opcional):";
            // 
            // cmbResponsavel
            // 
            this.cmbResponsavel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbResponsavel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbResponsavel.FormattingEnabled = true;
            this.cmbResponsavel.Location = new System.Drawing.Point(20, 355);
            this.cmbResponsavel.Name = "cmbResponsavel";
            this.cmbResponsavel.Size = new System.Drawing.Size(300, 25);
            this.cmbResponsavel.TabIndex = 11;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSalvar.Location = new System.Drawing.Point(260, 405);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(100, 35);
            this.btnSalvar.TabIndex = 12;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCancelar.Location = new System.Drawing.Point(370, 405);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 35);
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // FormCadastroEvento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.cmbResponsavel);
            this.Controls.Add(this.lblResponsavel);
            this.Controls.Add(this.txtLocal);
            this.Controls.Add(this.lblLocal);
            this.Controls.Add(this.dtpDataFim);
            this.Controls.Add(this.chkTemDataFim);
            this.Controls.Add(this.dtpDataInicio);
            this.Controls.Add(this.lblDataInicio);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.txtTitulo);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCadastroEvento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Evento";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        public System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.Label lblDescricao;
        public System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label lblDataInicio;
        public System.Windows.Forms.DateTimePicker dtpDataInicio;
        public System.Windows.Forms.CheckBox chkTemDataFim;
        public System.Windows.Forms.DateTimePicker dtpDataFim;
        private System.Windows.Forms.Label lblLocal;
        public System.Windows.Forms.TextBox txtLocal;
        private System.Windows.Forms.Label lblResponsavel;
        public System.Windows.Forms.ComboBox cmbResponsavel;
        public System.Windows.Forms.Button btnSalvar;
        public System.Windows.Forms.Button btnCancelar;

        private void chkTemDataFim_CheckedChanged(object sender, System.EventArgs e)
        {
            dtpDataFim.Enabled = chkTemDataFim.Checked;
            if (chkTemDataFim.Checked && dtpDataInicio.Value >= dtpDataFim.Value)
            {
                dtpDataFim.Value = dtpDataInicio.Value.AddHours(2);
            }
        }
    }
}
