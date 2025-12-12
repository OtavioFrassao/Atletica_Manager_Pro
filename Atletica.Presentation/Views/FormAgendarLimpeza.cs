using System;
using System.Windows.Forms;

namespace Atletica.Presentation.Views
{
    public partial class FormAgendarLimpeza : Form
    {
        public int? TarefaId { get; set; }

        public FormAgendarLimpeza()
        {
            InitializeComponent();
            dtpData.Value = DateTime.Now;
        }

        public void SetEditMode(DateTime data, string descricao, int membroResponsavelId, bool concluido)
        {
            lblTitulo.Text = "Editar Limpeza";
            dtpData.Value = data;
            txtDescricao.Text = descricao;
            cmbResponsavel.SelectedValue = membroResponsavelId;
            chkConcluido.Checked = concluido;
        }
    }
}
