namespace Atletica.Presentation.Views
{
    partial class FormAgendarLimpeza
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
            this.lblData = new System.Windows.Forms.Label();
            this.dtpData = new System.Windows.Forms.DateTimePicker();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.lblResponsavel = new System.Windows.Forms.Label();
            this.cmbResponsavel = new System.Windows.Forms.ComboBox();
            this.chkConcluido = new System.Windows.Forms.CheckBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(12, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(176, 25);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Agendar Limpeza";
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblData.Location = new System.Drawing.Point(12, 60);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(41, 19);
            this.lblData.TabIndex = 1;
            this.lblData.Text = "Data:";
            // 
            // dtpData
            // 
            this.dtpData.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpData.Location = new System.Drawing.Point(12, 82);
            this.dtpData.Name = "dtpData";
            this.dtpData.Size = new System.Drawing.Size(460, 25);
            this.dtpData.TabIndex = 2;
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDescricao.Location = new System.Drawing.Point(12, 120);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(74, 19);
            this.lblDescricao.TabIndex = 3;
            this.lblDescricao.Text = "Descrição:";
            // 
            // txtDescricao
            // 
            this.txtDescricao.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDescricao.Location = new System.Drawing.Point(12, 142);
            this.txtDescricao.MaxLength = 500;
            this.txtDescricao.Multiline = true;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(460, 80);
            this.txtDescricao.TabIndex = 4;
            // 
            // lblResponsavel
            // 
            this.lblResponsavel.AutoSize = true;
            this.lblResponsavel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblResponsavel.Location = new System.Drawing.Point(12, 235);
            this.lblResponsavel.Name = "lblResponsavel";
            this.lblResponsavel.Size = new System.Drawing.Size(136, 19);
            this.lblResponsavel.TabIndex = 5;
            this.lblResponsavel.Text = "Membro Responsável:";
            // 
            // cmbResponsavel
            // 
            this.cmbResponsavel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbResponsavel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbResponsavel.FormattingEnabled = true;
            this.cmbResponsavel.Location = new System.Drawing.Point(12, 257);
            this.cmbResponsavel.Name = "cmbResponsavel";
            this.cmbResponsavel.Size = new System.Drawing.Size(460, 25);
            this.cmbResponsavel.TabIndex = 6;
            // 
            // chkConcluido
            // 
            this.chkConcluido.AutoSize = true;
            this.chkConcluido.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkConcluido.Location = new System.Drawing.Point(12, 300);
            this.chkConcluido.Name = "chkConcluido";
            this.chkConcluido.Size = new System.Drawing.Size(90, 23);
            this.chkConcluido.TabIndex = 7;
            this.chkConcluido.Text = "Concluído";
            this.chkConcluido.UseVisualStyleBackColor = true;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSalvar.Location = new System.Drawing.Point(266, 340);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(100, 35);
            this.btnSalvar.TabIndex = 8;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCancelar.Location = new System.Drawing.Point(372, 340);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 35);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // FormAgendarLimpeza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 386);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.chkConcluido);
            this.Controls.Add(this.cmbResponsavel);
            this.Controls.Add(this.lblResponsavel);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.dtpData);
            this.Controls.Add(this.lblData);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormAgendarLimpeza";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agendar Limpeza";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblData;
        public System.Windows.Forms.DateTimePicker dtpData;
        private System.Windows.Forms.Label lblDescricao;
        public System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label lblResponsavel;
        public System.Windows.Forms.ComboBox cmbResponsavel;
        public System.Windows.Forms.CheckBox chkConcluido;
        public System.Windows.Forms.Button btnSalvar;
        public System.Windows.Forms.Button btnCancelar;
    }
}
