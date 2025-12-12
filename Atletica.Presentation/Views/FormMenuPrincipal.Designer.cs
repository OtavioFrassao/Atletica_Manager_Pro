namespace Atletica.Presentation.Views
{
    partial class FormMenuPrincipal
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
            this.btnCargos = new System.Windows.Forms.Button();
            this.btnMembros = new System.Windows.Forms.Button();
            this.btnLimpezas = new System.Windows.Forms.Button();
            this.btnEventos = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(12, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(287, 32);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Atlética Manager Pro";
            // 
            // btnCargos
            // 
            this.btnCargos.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnCargos.Location = new System.Drawing.Point(50, 100);
            this.btnCargos.Name = "btnCargos";
            this.btnCargos.Size = new System.Drawing.Size(300, 60);
            this.btnCargos.TabIndex = 1;
            this.btnCargos.Text = "Gerenciar Cargos";
            this.btnCargos.UseVisualStyleBackColor = true;
            // 
            // btnMembros
            // 
            this.btnMembros.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnMembros.Location = new System.Drawing.Point(50, 180);
            this.btnMembros.Name = "btnMembros";
            this.btnMembros.Size = new System.Drawing.Size(300, 60);
            this.btnMembros.TabIndex = 2;
            this.btnMembros.Text = "Gerenciar Membros";
            this.btnMembros.UseVisualStyleBackColor = true;
            // 
            // btnLimpezas
            // 
            this.btnLimpezas.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnLimpezas.Location = new System.Drawing.Point(50, 260);
            this.btnLimpezas.Name = "btnLimpezas";
            this.btnLimpezas.Size = new System.Drawing.Size(300, 60);
            this.btnLimpezas.TabIndex = 3;
            this.btnLimpezas.Text = "Cronograma de Limpeza";
            this.btnLimpezas.UseVisualStyleBackColor = true;
            // 
            // btnEventos
            // 
            this.btnEventos.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnEventos.Location = new System.Drawing.Point(50, 340);
            this.btnEventos.Name = "btnEventos";
            this.btnEventos.Size = new System.Drawing.Size(300, 60);
            this.btnEventos.TabIndex = 4;
            this.btnEventos.Text = "Agendamento de Eventos";
            this.btnEventos.UseVisualStyleBackColor = true;
            // 
            // btnSair
            // 
            this.btnSair.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSair.Location = new System.Drawing.Point(50, 440);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(300, 40);
            this.btnSair.TabIndex = 4;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.lblUsuario);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 500);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 30);
            this.panel1.TabIndex = 5;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(12, 8);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(80, 15);
            this.lblUsuario.TabIndex = 0;
            this.lblUsuario.Text = "Usuário: Admin";
            // 
            // FormMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 530);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnEventos);
            this.Controls.Add(this.btnLimpezas);
            this.Controls.Add(this.btnMembros);
            this.Controls.Add(this.btnCargos);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu Principal";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        public System.Windows.Forms.Button btnCargos;
        public System.Windows.Forms.Button btnMembros;
        public System.Windows.Forms.Button btnLimpezas;
        public System.Windows.Forms.Button btnEventos;
        public System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblUsuario;
    }
}
