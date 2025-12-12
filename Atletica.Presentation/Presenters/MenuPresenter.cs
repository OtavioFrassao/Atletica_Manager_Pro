using System;
using Atletica.Presentation.Views;

namespace Atletica.Presentation.Presenters
{
    public class MenuPresenter
    {
        private readonly FormMenuPrincipal _view;
        private readonly IServiceProvider _serviceProvider;

        public MenuPresenter(FormMenuPrincipal view, IServiceProvider serviceProvider)
        {
            _view = view;
            _serviceProvider = serviceProvider;

            _view.btnCargos.Click += BtnCargos_Click;
            _view.btnMembros.Click += BtnMembros_Click;
            _view.btnLimpezas.Click += BtnLimpezas_Click;
            _view.btnEventos.Click += BtnEventos_Click;
            _view.btnSair.Click += BtnSair_Click;
        }

        private void BtnCargos_Click(object? sender, EventArgs e)
        {
            var formCargos = new FormListaCargos();
            new CargoPresenter(formCargos, _serviceProvider);
            formCargos.ShowDialog();
        }

        private void BtnMembros_Click(object? sender, EventArgs e)
        {
            var formMembros = new FormListaMembros();
            new MembroPresenter(formMembros, _serviceProvider);
            formMembros.ShowDialog();
        }

        private void BtnLimpezas_Click(object? sender, EventArgs e)
        {
            var formLimpezas = new FormListaLimpezas();
            new TarefaLimpezaPresenter(formLimpezas, _serviceProvider);
            formLimpezas.ShowDialog();
        }

        private void BtnEventos_Click(object? sender, EventArgs e)
        {
            var formEventos = new FormListaEventos();
            new EventoPresenter(formEventos, _serviceProvider);
            formEventos.ShowDialog();
        }

        private void BtnSair_Click(object? sender, EventArgs e)
        {
            if (System.Windows.Forms.MessageBox.Show("Deseja realmente sair?", "Confirmar", 
                System.Windows.Forms.MessageBoxButtons.YesNo, 
                System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                _view.Close();
                System.Windows.Forms.Application.Exit();
            }
        }
    }
}
