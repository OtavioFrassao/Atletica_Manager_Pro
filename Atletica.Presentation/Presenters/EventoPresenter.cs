using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using Atletica.Application.DTOs;
using Atletica.Application.Services;
using Atletica.Presentation.Views;
using Microsoft.Extensions.DependencyInjection;

namespace Atletica.Presentation.Presenters
{
    public class EventoPresenter
    {
        private readonly FormListaEventos _view;
        private readonly IServiceProvider _serviceProvider;
        private DateTime _mesAtual = DateTime.Now;
        private List<EventoDto> _todosEventos = new List<EventoDto>();

        public EventoPresenter(FormListaEventos view, IServiceProvider serviceProvider)
        {
            _view = view;
            _serviceProvider = serviceProvider;

            _view.Load += async (s, e) => await CarregarEventosAsync();
            _view.btnNovo.Click += BtnNovo_Click;
            _view.btnEditar.Click += async (s, e) => await BtnEditar_ClickAsync();
            _view.btnExcluir.Click += async (s, e) => await BtnExcluir_ClickAsync();
            _view.btnFechar.Click += (s, e) => _view.Close();
            _view.btnVisualizarLista.Click += (s, e) => AlternarVisualizacao(true);
            _view.btnVisualizarCalendario.Click += async (s, e) => { AlternarVisualizacao(false); await CriarCalendarioCustomizadoAsync(); };
            _view.btnMesAnterior.Click += async (s, e) => { _mesAtual = _mesAtual.AddMonths(-1); await CriarCalendarioCustomizadoAsync(); };
            _view.btnProximoMes.Click += async (s, e) => { _mesAtual = _mesAtual.AddMonths(1); await CriarCalendarioCustomizadoAsync(); };
        }

        private void AlternarVisualizacao(bool mostrarLista)
        {
            _view.dgvEventos.Visible = mostrarLista;
            _view.pnlCalendario.Visible = !mostrarLista;
            _view.btnMesAnterior.Visible = !mostrarLista;
            _view.btnProximoMes.Visible = !mostrarLista;
            _view.lblMesAno.Visible = !mostrarLista;
            
            _view.btnVisualizarLista.Enabled = !mostrarLista;
            _view.btnVisualizarCalendario.Enabled = mostrarLista;
        }

        private async Task CriarCalendarioCustomizadoAsync()
        {
            try
            {
                using var scope = _serviceProvider.CreateScope();
                var eventoService = scope.ServiceProvider.GetRequiredService<EventoService>();
                _todosEventos = (await eventoService.GetAllEventosAsync()).ToList();

                _view.pnlCalendario.Controls.Clear();
                _view.lblMesAno.Text = _mesAtual.ToString("MMMM yyyy", new System.Globalization.CultureInfo("pt-BR"));

                var primeiroDia = new DateTime(_mesAtual.Year, _mesAtual.Month, 1);
                var ultimoDia = primeiroDia.AddMonths(1).AddDays(-1);
                var diaSemanaInicio = (int)primeiroDia.DayOfWeek;

                int larguraCelula = 120;
                int alturaCelula = 80;
                int margemX = 5;
                int margemY = 5;

                string[] diasSemana = { "Dom", "Seg", "Ter", "Qua", "Qui", "Sex", "Sáb" };
                for (int i = 0; i < 7; i++)
                {
                    var lblDia = new Label
                    {
                        Text = diasSemana[i],
                        Location = new System.Drawing.Point(margemX + i * larguraCelula, margemY),
                        Size = new System.Drawing.Size(larguraCelula - 2, 25),
                        Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold),
                        TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                        BorderStyle = BorderStyle.FixedSingle,
                        BackColor = System.Drawing.Color.LightGray
                    };
                    _view.pnlCalendario.Controls.Add(lblDia);
                }

                int linha = 1;
                int coluna = diaSemanaInicio;
                int yOffset = margemY + 25;

                for (int dia = 1; dia <= ultimoDia.Day; dia++)
                {
                    var dataAtual = new DateTime(_mesAtual.Year, _mesAtual.Month, dia);
                    var eventosDoDia = _todosEventos.Where(e => e.DataInicio.Date == dataAtual.Date).ToList();

                    var pnlDia = new Panel
                    {
                        Location = new System.Drawing.Point(margemX + coluna * larguraCelula, yOffset + (linha - 1) * alturaCelula),
                        Size = new System.Drawing.Size(larguraCelula - 2, alturaCelula - 2),
                        BorderStyle = BorderStyle.FixedSingle,
                        BackColor = dataAtual.Date == DateTime.Now.Date ? System.Drawing.Color.LightYellow : System.Drawing.Color.White,
                        Cursor = System.Windows.Forms.Cursors.Hand,
                        Tag = dataAtual
                    };
                    
                    pnlDia.Click += async (s, ev) => await PnlDia_Click(s, ev);
                    pnlDia.MouseEnter += (s, ev) => 
                    {
                        var pnl = (Panel)s!;
                        pnl.BackColor = System.Drawing.Color.LightBlue;
                    };
                    pnlDia.MouseLeave += (s, ev) => 
                    {
                        var pnl = (Panel)s!;
                        var data = (DateTime)pnl.Tag;
                        pnl.BackColor = data.Date == DateTime.Now.Date ? System.Drawing.Color.LightYellow : System.Drawing.Color.White;
                    };

                    var lblNumDia = new Label
                    {
                        Text = dia.ToString(),
                        Location = new System.Drawing.Point(2, 2),
                        Size = new System.Drawing.Size(30, 20),
                        Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold),
                        Cursor = System.Windows.Forms.Cursors.Hand
                    };
                    lblNumDia.Click += async (s, ev) => await PnlDia_Click(pnlDia, ev);
                    pnlDia.Controls.Add(lblNumDia);

                    if (eventosDoDia.Any())
                    {
                        int yPos = 22;
                        foreach (var evento in eventosDoDia.Take(1))
                        {
                            var lblTitulo = new Label
                            {
                                Text = evento.Titulo,
                                Location = new System.Drawing.Point(2, yPos),
                                Size = new System.Drawing.Size(larguraCelula - 6, 18),
                                Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold),
                                ForeColor = System.Drawing.Color.DarkGreen,
                                AutoEllipsis = true,
                                Cursor = System.Windows.Forms.Cursors.Hand
                            };
                            lblTitulo.Click += async (s, ev) => await PnlDia_Click(pnlDia, ev);
                            pnlDia.Controls.Add(lblTitulo);
                            yPos += 18;

                            if (!string.IsNullOrEmpty(evento.Local))
                            {
                                var lblLocal = new Label
                                {
                                    Text = evento.Local,
                                    Location = new System.Drawing.Point(2, yPos),
                                    Size = new System.Drawing.Size(larguraCelula - 6, 14),
                                    Font = new System.Drawing.Font("Segoe UI", 7F),
                                    ForeColor = System.Drawing.Color.Gray,
                                    AutoEllipsis = true,
                                    Cursor = System.Windows.Forms.Cursors.Hand
                                };
                                lblLocal.Click += async (s, ev) => await PnlDia_Click(pnlDia, ev);
                                pnlDia.Controls.Add(lblLocal);
                                yPos += 14;
                            }
                        }

                        if (eventosDoDia.Count > 1)
                        {
                            var lblMais = new Label
                            {
                                Text = $"+{eventosDoDia.Count - 1} mais",
                                Location = new System.Drawing.Point(2, yPos),
                                Size = new System.Drawing.Size(larguraCelula - 6, 14),
                                Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Italic),
                                ForeColor = System.Drawing.Color.Gray,
                                Cursor = System.Windows.Forms.Cursors.Hand
                            };
                            lblMais.Click += async (s, ev) => await PnlDia_Click(pnlDia, ev);
                            pnlDia.Controls.Add(lblMais);
                        }
                    }

                    _view.pnlCalendario.Controls.Add(pnlDia);

                    coluna++;
                    if (coluna == 7)
                    {
                        coluna = 0;
                        linha++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao criar calendário: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task CarregarEventosAsync()
        {
            try
            {
                using var scope = _serviceProvider.CreateScope();
                var eventoService = scope.ServiceProvider.GetRequiredService<EventoService>();

                var eventos = await eventoService.GetAllEventosAsync();
                _view.dgvEventos.DataSource = eventos.ToList();

                if (_view.dgvEventos.Columns.Contains("MembroResponsavelId"))
                    _view.dgvEventos.Columns["MembroResponsavelId"].Visible = false;
                
                if (_view.dgvEventos.Columns.Contains("Id"))
                    _view.dgvEventos.Columns["Id"].Visible = false;
                
                if (_view.dgvEventos.Columns.Contains("Titulo"))
                {
                    _view.dgvEventos.Columns["Titulo"].DisplayIndex = 0;
                    _view.dgvEventos.Columns["Titulo"].HeaderText = "Título";
                    _view.dgvEventos.Columns["Titulo"].Width = 200;
                }
                if (_view.dgvEventos.Columns.Contains("DataInicio"))
                {
                    _view.dgvEventos.Columns["DataInicio"].DisplayIndex = 1;
                    _view.dgvEventos.Columns["DataInicio"].HeaderText = "Data Início";
                    _view.dgvEventos.Columns["DataInicio"].Width = 130;
                    _view.dgvEventos.Columns["DataInicio"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                }
                if (_view.dgvEventos.Columns.Contains("DataFim"))
                {
                    _view.dgvEventos.Columns["DataFim"].DisplayIndex = 2;
                    _view.dgvEventos.Columns["DataFim"].HeaderText = "Data Fim";
                    _view.dgvEventos.Columns["DataFim"].Width = 130;
                    _view.dgvEventos.Columns["DataFim"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                }
                if (_view.dgvEventos.Columns.Contains("Local"))
                {
                    _view.dgvEventos.Columns["Local"].DisplayIndex = 3;
                    _view.dgvEventos.Columns["Local"].HeaderText = "Local";
                    _view.dgvEventos.Columns["Local"].Width = 150;
                }
                if (_view.dgvEventos.Columns.Contains("MembroResponsavelNome"))
                {
                    _view.dgvEventos.Columns["MembroResponsavelNome"].DisplayIndex = 4;
                    _view.dgvEventos.Columns["MembroResponsavelNome"].HeaderText = "Responsável";
                    _view.dgvEventos.Columns["MembroResponsavelNome"].Width = 150;
                }
                if (_view.dgvEventos.Columns.Contains("Descricao"))
                {
                    _view.dgvEventos.Columns["Descricao"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar eventos: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnNovo_Click(object? sender, EventArgs e)
        {
            var formCadastro = new FormCadastroEvento();
            await CarregarMembrosAsync(formCadastro);
            new CadastroEventoPresenter(formCadastro, _serviceProvider);

            if (formCadastro.ShowDialog() == DialogResult.OK)
            {
                await CarregarEventosAsync();
            }
        }

        private async Task BtnEditar_ClickAsync()
        {
            if (_view.dgvEventos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um evento para editar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var eventoDto = (EventoDto)_view.dgvEventos.SelectedRows[0].DataBoundItem;

            var formCadastro = new FormCadastroEvento();
            await CarregarMembrosAsync(formCadastro);
            formCadastro.SetEditMode(
                eventoDto.Id,
                eventoDto.Titulo,
                eventoDto.Descricao,
                eventoDto.DataInicio,
                eventoDto.DataFim,
                eventoDto.Local,
                eventoDto.MembroResponsavelId
            );
            new CadastroEventoPresenter(formCadastro, _serviceProvider);

            if (formCadastro.ShowDialog() == DialogResult.OK)
            {
                await CarregarEventosAsync();
            }
        }

        private async Task BtnExcluir_ClickAsync()
        {
            if (_view.dgvEventos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um evento para excluir.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var resultado = MessageBox.Show(
                "Tem certeza que deseja excluir este evento?",
                "Confirmar Exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado != DialogResult.Yes) return;

            try
            {
                var eventoDto = (EventoDto)_view.dgvEventos.SelectedRows[0].DataBoundItem;

                using var scope = _serviceProvider.CreateScope();
                var eventoService = scope.ServiceProvider.GetRequiredService<EventoService>();

                await eventoService.DeleteEventoAsync(eventoDto.Id);

                MessageBox.Show("Evento excluído com sucesso!", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                await CarregarEventosAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao excluir evento: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task CarregarMembrosAsync(FormCadastroEvento formCadastro)
        {
            using var scope = _serviceProvider.CreateScope();
            var membroService = scope.ServiceProvider.GetRequiredService<MembroService>();
            var membros = await membroService.GetAllMembrosAsync();

            formCadastro.cmbResponsavel.DataSource = membros.ToList();
            formCadastro.cmbResponsavel.DisplayMember = "Nome";
            formCadastro.cmbResponsavel.ValueMember = "Id";
            formCadastro.cmbResponsavel.SelectedIndex = -1;
        }

        private async Task PnlDia_Click(object? sender, EventArgs e)
        {
            if (sender is not Panel pnlDia || pnlDia.Tag is not DateTime dataSelecionada)
                return;

            var eventosDoDia = _todosEventos.Where(ev => ev.DataInicio.Date == dataSelecionada.Date).ToList();

            var mensagem = $"{dataSelecionada:dddd, dd/MM/yyyy}\n\n";

            if (eventosDoDia.Any())
            {
                mensagem += $"{eventosDoDia.Count} evento(s) agendado(s):\n\n";
                foreach (var evento in eventosDoDia)
                {
                    mensagem += $"Titulo: {evento.Titulo}\n";
                    mensagem += $"Horario: {evento.DataInicio:HH:mm}";
                    if (evento.DataFim.HasValue)
                        mensagem += $" ate {evento.DataFim.Value:HH:mm}";
                    mensagem += $"\nLocal: {evento.Local ?? "Nao informado"}\n\n";
                }

                var resultado = MessageBox.Show(
                    mensagem + "\n\nDeseja gerenciar estes eventos?",
                    "Eventos do Dia",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);

                if (resultado == DialogResult.Yes)
                {
                    AlternarVisualizacao(true);
                }
            }
            else
            {
                mensagem += "Nenhum evento agendado para este dia.\n\n";
                
                var resultado = MessageBox.Show(
                    mensagem + "Deseja agendar um evento para este dia?",
                    "Eventos do Dia",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    var formCadastro = new FormCadastroEvento();
                    await CarregarMembrosAsync(formCadastro);
                    formCadastro.dtpDataInicio.Value = dataSelecionada;
                    new CadastroEventoPresenter(formCadastro, _serviceProvider);

                    if (formCadastro.ShowDialog() == DialogResult.OK)
                    {
                        await CarregarEventosAsync();
                        await CriarCalendarioCustomizadoAsync();
                    }
                }
            }
        }
    }

    public class CadastroEventoPresenter
    {
        private readonly FormCadastroEvento _view;
        private readonly IServiceProvider _serviceProvider;

        public CadastroEventoPresenter(FormCadastroEvento view, IServiceProvider serviceProvider)
        {
            _view = view;
            _serviceProvider = serviceProvider;

            _view.btnSalvar.Click += async (s, e) => await BtnSalvar_ClickAsync();
            _view.btnCancelar.Click += (s, e) => _view.Close();
        }

        private async Task BtnSalvar_ClickAsync()
        {
            if (string.IsNullOrWhiteSpace(_view.txtTitulo.Text))
            {
                MessageBox.Show("O título é obrigatório.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _view.txtTitulo.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(_view.txtDescricao.Text))
            {
                MessageBox.Show("A descrição é obrigatória.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _view.txtDescricao.Focus();
                return;
            }

            if (_view.chkTemDataFim.Checked && _view.dtpDataFim.Value <= _view.dtpDataInicio.Value)
            {
                MessageBox.Show("A data de fim deve ser posterior à data de início.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _view.dtpDataFim.Focus();
                return;
            }

            try
            {
                using var scope = _serviceProvider.CreateScope();
                var eventoService = scope.ServiceProvider.GetRequiredService<EventoService>();

                int? membroResponsavelId = _view.cmbResponsavel.SelectedValue != null 
                    ? (int)_view.cmbResponsavel.SelectedValue 
                    : null;

                if (_view.EventoId.HasValue)
                {
                    var updateDto = new UpdateEventoDto
                    {
                        Id = _view.EventoId.Value,
                        Titulo = _view.txtTitulo.Text.Trim(),
                        Descricao = _view.txtDescricao.Text.Trim(),
                        DataInicio = _view.dtpDataInicio.Value,
                        DataFim = _view.chkTemDataFim.Checked ? _view.dtpDataFim.Value : null,
                        Local = string.IsNullOrWhiteSpace(_view.txtLocal.Text) ? null : _view.txtLocal.Text.Trim(),
                        MembroResponsavelId = membroResponsavelId
                    };

                    await eventoService.UpdateEventoAsync(updateDto);
                    MessageBox.Show("Evento atualizado com sucesso!", "Sucesso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    var createDto = new CreateEventoDto
                    {
                        Titulo = _view.txtTitulo.Text.Trim(),
                        Descricao = _view.txtDescricao.Text.Trim(),
                        DataInicio = _view.dtpDataInicio.Value,
                        DataFim = _view.chkTemDataFim.Checked ? _view.dtpDataFim.Value : null,
                        Local = string.IsNullOrWhiteSpace(_view.txtLocal.Text) ? null : _view.txtLocal.Text.Trim(),
                        MembroResponsavelId = membroResponsavelId
                    };

                    await eventoService.CreateEventoAsync(createDto);
                    MessageBox.Show("Evento cadastrado com sucesso!", "Sucesso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                _view.DialogResult = DialogResult.OK;
                _view.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar evento: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
