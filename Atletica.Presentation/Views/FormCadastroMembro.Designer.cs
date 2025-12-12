namespace Atletica.Presentation.Views
{
    partial class FormCadastroMembro
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
            this.lblNome = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblCurso = new System.Windows.Forms.Label();
            this.txtCurso = new System.Windows.Forms.TextBox();
            this.lblTurma = new System.Windows.Forms.Label();
            this.txtTurma = new System.Windows.Forms.TextBox();
            this.lblMatricula = new System.Windows.Forms.Label();
            this.txtMatricula = new System.Windows.Forms.TextBox();
            this.lblContato = new System.Windows.Forms.Label();
            this.txtContato = new System.Windows.Forms.MaskedTextBox();
            this.lblDataEntrada = new System.Windows.Forms.Label();
            this.dtpDataEntrada = new System.Windows.Forms.DateTimePicker();
            this.lblCargo = new System.Windows.Forms.Label();
            this.cmbCargo = new System.Windows.Forms.ComboBox();
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
            this.lblTitulo.Size = new System.Drawing.Size(179, 25);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Cadastrar Membro";
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNome.Location = new System.Drawing.Point(12, 60);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(50, 19);
            this.lblNome.TabIndex = 1;
            this.lblNome.Text = "Nome:";
            // 
            // txtNome
            // 
            this.txtNome.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNome.Location = new System.Drawing.Point(12, 82);
            this.txtNome.MaxLength = 100;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(460, 25);
            this.txtNome.TabIndex = 2;
            // 
            // lblCurso
            // 
            this.lblCurso.AutoSize = true;
            this.lblCurso.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCurso.Location = new System.Drawing.Point(12, 120);
            this.lblCurso.Name = "lblCurso";
            this.lblCurso.Size = new System.Drawing.Size(48, 19);
            this.lblCurso.TabIndex = 3;
            this.lblCurso.Text = "Curso:";
            // 
            // txtCurso
            // 
            this.txtCurso.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCurso.Location = new System.Drawing.Point(12, 142);
            this.txtCurso.MaxLength = 100;
            this.txtCurso.Name = "txtCurso";
            this.txtCurso.Size = new System.Drawing.Size(460, 25);
            this.txtCurso.TabIndex = 4;
            // 
            // lblTurma
            // 
            this.lblTurma.AutoSize = true;
            this.lblTurma.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTurma.Location = new System.Drawing.Point(12, 180);
            this.lblTurma.Name = "lblTurma";
            this.lblTurma.Size = new System.Drawing.Size(49, 19);
            this.lblTurma.TabIndex = 5;
            this.lblTurma.Text = "Turma:";
            // 
            // txtTurma
            // 
            this.txtTurma.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTurma.Location = new System.Drawing.Point(12, 202);
            this.txtTurma.MaxLength = 10;
            this.txtTurma.Name = "txtTurma";
            this.txtTurma.Size = new System.Drawing.Size(100, 25);
            this.txtTurma.TabIndex = 6;
            // 
            // lblMatricula
            // 
            this.lblMatricula.AutoSize = true;
            this.lblMatricula.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMatricula.Location = new System.Drawing.Point(132, 180);
            this.lblMatricula.Name = "lblMatricula";
            this.lblMatricula.Size = new System.Drawing.Size(71, 19);
            this.lblMatricula.TabIndex = 7;
            this.lblMatricula.Text = "Matrícula:";
            // 
            // txtMatricula
            // 
            this.txtMatricula.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMatricula.Location = new System.Drawing.Point(132, 202);
            this.txtMatricula.MaxLength = 50;
            this.txtMatricula.Name = "txtMatricula";
            this.txtMatricula.Size = new System.Drawing.Size(100, 25);
            this.txtMatricula.TabIndex = 8;
            // 
            // lblContato
            // 
            this.lblContato.AutoSize = true;
            this.lblContato.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblContato.Location = new System.Drawing.Point(252, 180);
            this.lblContato.Name = "lblContato";
            this.lblContato.Size = new System.Drawing.Size(62, 19);
            this.lblContato.TabIndex = 9;
            this.lblContato.Text = "Contato:";
            // 
            // txtContato
            // 
            this.txtContato.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtContato.Location = new System.Drawing.Point(252, 202);
            this.txtContato.Mask = "(00) 00000-0000";
            this.txtContato.Name = "txtContato";
            this.txtContato.Size = new System.Drawing.Size(220, 25);
            this.txtContato.TabIndex = 10;
            // 
            // lblDataEntrada
            // 
            this.lblDataEntrada.AutoSize = true;
            this.lblDataEntrada.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDataEntrada.Location = new System.Drawing.Point(12, 240);
            this.lblDataEntrada.Name = "lblDataEntrada";
            this.lblDataEntrada.Size = new System.Drawing.Size(112, 19);
            this.lblDataEntrada.TabIndex = 11;
            this.lblDataEntrada.Text = "Data de Entrada:";
            // 
            // dtpDataEntrada
            // 
            this.dtpDataEntrada.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpDataEntrada.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataEntrada.Location = new System.Drawing.Point(12, 262);
            this.dtpDataEntrada.Name = "dtpDataEntrada";
            this.dtpDataEntrada.Size = new System.Drawing.Size(220, 25);
            this.dtpDataEntrada.TabIndex = 12;
            // 
            // lblCargo
            // 
            this.lblCargo.AutoSize = true;
            this.lblCargo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCargo.Location = new System.Drawing.Point(12, 300);
            this.lblCargo.Name = "lblCargo";
            this.lblCargo.Size = new System.Drawing.Size(49, 19);
            this.lblCargo.TabIndex = 13;
            this.lblCargo.Text = "Cargo:";
            // 
            // cmbCargo
            // 
            this.cmbCargo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCargo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbCargo.FormattingEnabled = true;
            this.cmbCargo.Location = new System.Drawing.Point(12, 322);
            this.cmbCargo.Name = "cmbCargo";
            this.cmbCargo.Size = new System.Drawing.Size(460, 25);
            this.cmbCargo.TabIndex = 14;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSalvar.Location = new System.Drawing.Point(272, 375);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(100, 35);
            this.btnSalvar.TabIndex = 15;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCancelar.Location = new System.Drawing.Point(378, 375);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 35);
            this.btnCancelar.TabIndex = 16;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // FormCadastroMembro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 421);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.cmbCargo);
            this.Controls.Add(this.lblCargo);
            this.Controls.Add(this.dtpDataEntrada);
            this.Controls.Add(this.lblDataEntrada);
            this.Controls.Add(this.txtContato);
            this.Controls.Add(this.lblContato);
            this.Controls.Add(this.txtMatricula);
            this.Controls.Add(this.lblMatricula);
            this.Controls.Add(this.txtTurma);
            this.Controls.Add(this.lblTurma);
            this.Controls.Add(this.txtCurso);
            this.Controls.Add(this.lblCurso);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormCadastroMembro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Membro";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblNome;
        public System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblCurso;
        public System.Windows.Forms.TextBox txtCurso;
        private System.Windows.Forms.Label lblTurma;
        public System.Windows.Forms.TextBox txtTurma;
        private System.Windows.Forms.Label lblMatricula;
        public System.Windows.Forms.TextBox txtMatricula;
        private System.Windows.Forms.Label lblContato;
        public System.Windows.Forms.MaskedTextBox txtContato;
        private System.Windows.Forms.Label lblDataEntrada;
        public System.Windows.Forms.DateTimePicker dtpDataEntrada;
        private System.Windows.Forms.Label lblCargo;
        public System.Windows.Forms.ComboBox cmbCargo;
        public System.Windows.Forms.Button btnSalvar;
        public System.Windows.Forms.Button btnCancelar;
    }
}
