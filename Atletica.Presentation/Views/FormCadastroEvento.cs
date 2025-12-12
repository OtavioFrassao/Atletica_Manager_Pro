using System;
using System.Windows.Forms;

namespace Atletica.Presentation.Views
{
    public partial class FormCadastroEvento : Form
    {
        public int? EventoId { get; set; }

        public FormCadastroEvento()
        {
            InitializeComponent();
        }

        public void SetEditMode(int id, string titulo, string descricao, DateTime dataInicio, DateTime? dataFim, string? local, int? membroResponsavelId)
        {
            EventoId = id;
            txtTitulo.Text = titulo;
            txtDescricao.Text = descricao;
            dtpDataInicio.Value = dataInicio;
            
            if (dataFim.HasValue)
            {
                chkTemDataFim.Checked = true;
                dtpDataFim.Value = dataFim.Value;
            }
            
            txtLocal.Text = local ?? string.Empty;
            
            if (membroResponsavelId.HasValue && cmbResponsavel.Items.Count > 0)
            {
                cmbResponsavel.SelectedValue = membroResponsavelId.Value;
            }

            Text = "Editar Evento";
            btnSalvar.Text = "Atualizar";
        }
    }
}
