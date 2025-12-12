using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Atletica.Application.DTOs;
using Atletica.Application.Services;
using Atletica.Presentation.Views;
using Microsoft.Extensions.DependencyInjection;

namespace Atletica.Presentation.Presenters
{
    public class TarefaLimpezaPresenter
    {
        private readonly FormListaLimpezas _view;
        private readonly IServiceProvider _serviceProvider;
        private DateTime _mesAtual = DateTime.Now;
        private List<TarefaLimpezaDto> _todasTarefas = new List<TarefaLimpezaDto>();

        public TarefaLimpezaPresenter(FormListaLimpezas view, IServiceProvider serviceProvider)
        {
            _view = view;
            _serviceProvider = serviceProvider;

            _view.Load += async (s, e) => await CarregarLimpezasAsync();
            _view.btnNovo.Click += BtnNovo_Click;
            _view.btnEditar.Click += async (s, e) => await BtnEditar_ClickAsync();
            _view.btnExcluir.Click += async (s, e) => await BtnExcluir_ClickAsync();
            _view.btnMarcarConcluida.Click += async (s, e) => await BtnMarcarConcluida_ClickAsync();
            _view.btnFechar.Click += (s, e) => _view.Close();
            _view.btnVisualizarLista.Click += (s, e) => AlternarVisualizacao(true);
            _view.btnVisualizarCalendario.Click += async (s, e) => { AlternarVisualizacao(false); await CriarCalendarioCustomizadoAsync(); };
            _view.btnMesAnterior.Click += async (s, e) => { _mesAtual = _mesAtual.AddMonths(-1); await CriarCalendarioCustomizadoAsync(); };
            _view.btnProximoMes.Click += async (s, e) => { _mesAtual = _mesAtual.AddMonths(1); await CriarCalendarioCustomizadoAsync(); };
        }



        private void AlternarVisualizacao(bool mostrarLista)
        {
            _view.dgvLimpezas.Visible = mostrarLista;
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
                var tarefaService = scope.ServiceProvider.GetRequiredService<TarefaLimpezaService>();
                _todasTarefas = (await tarefaService.GetAllTarefasAsync()).ToList();

                _view.pnlCalendario.Controls.Clear();
                _view.lblMesAno.Text = _mesAtual.ToString("MMMM yyyy", new System.Globalization.CultureInfo("pt-BR"));

                var primeiroDia = new DateTime(_mesAtual.Year, _mesAtual.Month, 1);
                var ultimoDia = primeiroDia.AddMonths(1).AddDays(-1);
                var diaSemanaInicio = (int)primeiroDia.DayOfWeek;

                int larguraCelula = 120;
                int alturaCelula = 80;
                int margemX = 5;
                int margemY = 5;

                // Cabeçalhos dos dias da semana
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
                    var tarefasDoDia = _todasTarefas.Where(t => t.Data.Date == dataAtual.Date).ToList();

                    // Definir cor do painel baseado no status das tarefas
                    System.Drawing.Color corFundo;
                    if (dataAtual.Date == DateTime.Now.Date)
                    {
                        corFundo = System.Drawing.Color.LightYellow;
                    }
                    else if (tarefasDoDia.Any())
                    {
                        // Se todas as tarefas estão concluídas, verde claro. Senão, laranja claro
                        corFundo = tarefasDoDia.All(t => t.Concluido) 
                            ? System.Drawing.Color.LightGreen 
                            : System.Drawing.Color.LightCoral;
                    }
                    else
                    {
                        corFundo = System.Drawing.Color.White;
                    }

                    var pnlDia = new Panel
                    {
                        Location = new System.Drawing.Point(margemX + coluna * larguraCelula, yOffset + (linha - 1) * alturaCelula),
                        Size = new System.Drawing.Size(larguraCelula - 2, alturaCelula - 2),
                        BorderStyle = BorderStyle.FixedSingle,
                        BackColor = corFundo,
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
                        var tarefas = _todasTarefas.Where(t => t.Data.Date == data.Date).ToList();
                        
                        if (data.Date == DateTime.Now.Date)
                            pnl.BackColor = System.Drawing.Color.LightYellow;
                        else if (tarefas.Any())
                            pnl.BackColor = tarefas.All(t => t.Concluido) ? System.Drawing.Color.LightGreen : System.Drawing.Color.LightCoral;
                        else
                            pnl.BackColor = System.Drawing.Color.White;
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

                    if (tarefasDoDia.Any())
                    {
                        int yPos = 22;
                        foreach (var tarefa in tarefasDoDia.Take(2))
                        {
                            var lblTarefa = new Label
                            {
                                Text = $"{(tarefa.Concluido ? "[OK]" : "[-]")} {tarefa.MembroResponsavelNome}",
                                Location = new System.Drawing.Point(2, yPos),
                                Size = new System.Drawing.Size(larguraCelula - 6, 16),
                                Font = new System.Drawing.Font("Segoe UI", 7F),
                                ForeColor = tarefa.Concluido ? System.Drawing.Color.Green : System.Drawing.Color.DarkBlue,
                                AutoEllipsis = true,
                                Cursor = System.Windows.Forms.Cursors.Hand
                            };
                            lblTarefa.Click += async (s, ev) => await PnlDia_Click(pnlDia, ev);
                            pnlDia.Controls.Add(lblTarefa);
                            yPos += 16;
                        }

                        if (tarefasDoDia.Count > 2)
                        {
                            var lblMais = new Label
                            {
                                Text = $"+{tarefasDoDia.Count - 2} mais",
                                Location = new System.Drawing.Point(2, yPos),
                                Size = new System.Drawing.Size(larguraCelula - 6, 14),
                                Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Italic),
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

        private async Task CarregarLimpezasAsync()
        {
            try
            {
                using var scope = _serviceProvider.CreateScope();
                var tarefaService = scope.ServiceProvider.GetRequiredService<TarefaLimpezaService>();

                var tarefas = await tarefaService.GetAllTarefasAsync();
                _view.dgvLimpezas.DataSource = tarefas.ToList();

                if (_view.dgvLimpezas.Columns.Contains("MembroResponsavelId"))
                    _view.dgvLimpezas.Columns["MembroResponsavelId"].Visible = false;
                
                if (_view.dgvLimpezas.Columns.Contains("Id"))
                    _view.dgvLimpezas.Columns["Id"].Visible = false;
                
                // Configurar cabeçalhos e ordem
                if (_view.dgvLimpezas.Columns.Contains("Data"))
                {
                    _view.dgvLimpezas.Columns["Data"].DisplayIndex = 0;
                    _view.dgvLimpezas.Columns["Data"].HeaderText = "Data";
                    _view.dgvLimpezas.Columns["Data"].Width = 100;
                    _view.dgvLimpezas.Columns["Data"].DefaultCellStyle.Format = "dd/MM/yyyy";
                }
                if (_view.dgvLimpezas.Columns.Contains("Descricao"))
                {
                    _view.dgvLimpezas.Columns["Descricao"].DisplayIndex = 1;
                    _view.dgvLimpezas.Columns["Descricao"].HeaderText = "Descrição";
                }
                if (_view.dgvLimpezas.Columns.Contains("MembroResponsavelNome"))
                {
                    _view.dgvLimpezas.Columns["MembroResponsavelNome"].DisplayIndex = 2;
                    _view.dgvLimpezas.Columns["MembroResponsavelNome"].HeaderText = "Responsável";
                }
                if (_view.dgvLimpezas.Columns.Contains("Concluido"))
                {
                    _view.dgvLimpezas.Columns["Concluido"].DisplayIndex = 3;
                    _view.dgvLimpezas.Columns["Concluido"].HeaderText = "Concluído";
                    _view.dgvLimpezas.Columns["Concluido"].Width = 100;
                }
                if (_view.dgvLimpezas.Columns.Contains("MembroResponsavelCargo"))
                {
                    _view.dgvLimpezas.Columns["MembroResponsavelCargo"].DisplayIndex = 4;
                    _view.dgvLimpezas.Columns["MembroResponsavelCargo"].HeaderText = "Cargo";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar limpezas: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnNovo_Click(object? sender, EventArgs e)
        {
            var formAgendamento = new FormAgendarLimpeza();
            await CarregarMembrosAsync(formAgendamento);
            new AgendarLimpezaPresenter(formAgendamento, _serviceProvider);

            if (formAgendamento.ShowDialog() == DialogResult.OK)
            {
                await CarregarLimpezasAsync();
            }
        }

        private async Task BtnEditar_ClickAsync()
        {
            if (_view.dgvLimpezas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione uma limpeza para editar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var tarefaDto = (TarefaLimpezaDto)_view.dgvLimpezas.SelectedRows[0].DataBoundItem;
            var formAgendamento = new FormAgendarLimpeza { TarefaId = tarefaDto.Id };

            await CarregarMembrosAsync(formAgendamento);
            formAgendamento.SetEditMode(tarefaDto.Data, tarefaDto.Descricao,
                tarefaDto.MembroResponsavelId, tarefaDto.Concluido);

            new AgendarLimpezaPresenter(formAgendamento, _serviceProvider);

            if (formAgendamento.ShowDialog() == DialogResult.OK)
            {
                await CarregarLimpezasAsync();
            }
        }

        private async Task BtnExcluir_ClickAsync()
        {
            if (_view.dgvLimpezas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione uma limpeza para excluir.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var tarefaDto = (TarefaLimpezaDto)_view.dgvLimpezas.SelectedRows[0].DataBoundItem;

            var result = MessageBox.Show($"Deseja realmente excluir a limpeza de '{tarefaDto.Data:dd/MM/yyyy}'?",
                "Confirmar Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using var scope = _serviceProvider.CreateScope();
                    var tarefaService = scope.ServiceProvider.GetRequiredService<TarefaLimpezaService>();
                    await tarefaService.DeleteTarefaAsync(tarefaDto.Id);

                    MessageBox.Show("Limpeza excluída com sucesso!", "Sucesso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    await CarregarLimpezasAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao excluir limpeza: {ex.Message}", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async Task BtnMarcarConcluida_ClickAsync()
        {
            if (_view.dgvLimpezas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione uma limpeza para marcar como concluída.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var tarefaDto = (TarefaLimpezaDto)_view.dgvLimpezas.SelectedRows[0].DataBoundItem;

            if (tarefaDto.Concluido)
            {
                MessageBox.Show("Esta limpeza já está marcada como concluída.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                using var scope = _serviceProvider.CreateScope();
                var tarefaService = scope.ServiceProvider.GetRequiredService<TarefaLimpezaService>();

                var updateDto = new UpdateTarefaLimpezaDto
                {
                    Id = tarefaDto.Id,
                    Data = tarefaDto.Data,
                    Descricao = tarefaDto.Descricao,
                    MembroResponsavelId = tarefaDto.MembroResponsavelId,
                    Concluido = true
                };

                await tarefaService.UpdateTarefaAsync(updateDto);

                MessageBox.Show("Limpeza marcada como concluída!", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                await CarregarLimpezasAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao marcar limpeza como concluída: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task CarregarMembrosAsync(FormAgendarLimpeza formAgendamento)
        {
            using var scope = _serviceProvider.CreateScope();
            var membroService = scope.ServiceProvider.GetRequiredService<MembroService>();
            var membros = await membroService.GetAllMembrosAsync();

            formAgendamento.cmbResponsavel.DataSource = membros.ToList();
            formAgendamento.cmbResponsavel.DisplayMember = "Nome";
            formAgendamento.cmbResponsavel.ValueMember = "Id";
        }

        private async Task PnlDia_Click(object? sender, EventArgs e)
        {
            if (sender is not Panel pnlDia || pnlDia.Tag is not DateTime dataSelecionada)
                return;

            var tarefasDoDia = _todasTarefas.Where(t => t.Data.Date == dataSelecionada.Date).ToList();

            var mensagem = $"{dataSelecionada:dddd, dd/MM/yyyy}\n\n";

            if (tarefasDoDia.Any())
            {
                mensagem += $"{tarefasDoDia.Count} limpeza(s) agendada(s):\n\n";
                foreach (var tarefa in tarefasDoDia)
                {
                    string status = tarefa.Concluido ? "[Concluida]" : "[Pendente]";
                    mensagem += $"{status}\n";
                    mensagem += $"Descrição: {tarefa.Descricao}\n";
                    mensagem += $"Responsável: {tarefa.MembroResponsavelNome}\n";
                    mensagem += $"Horário: {tarefa.Data:HH:mm}\n\n";
                }

                var resultado = MessageBox.Show(
                    mensagem + "\n\nDeseja gerenciar estas limpezas?",
                    "Limpezas do Dia",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);

                if (resultado == DialogResult.Yes)
                {
                    AlternarVisualizacao(true); // Volta para a lista
                }
            }
            else
            {
                mensagem += "Nenhuma limpeza agendada para este dia.\n\n";
                
                var resultado = MessageBox.Show(
                    mensagem + "Deseja agendar uma limpeza para este dia?",
                    "Limpezas do Dia",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    var formAgendamento = new FormAgendarLimpeza();
                    await CarregarMembrosAsync(formAgendamento);
                    formAgendamento.dtpData.Value = dataSelecionada;
                    new AgendarLimpezaPresenter(formAgendamento, _serviceProvider);

                    if (formAgendamento.ShowDialog() == DialogResult.OK)
                    {
                        await CarregarLimpezasAsync();
                        await CriarCalendarioCustomizadoAsync();
                    }
                }
            }
        }
    }

    public class AgendarLimpezaPresenter
    {
        private readonly FormAgendarLimpeza _view;
        private readonly IServiceProvider _serviceProvider;

        public AgendarLimpezaPresenter(FormAgendarLimpeza view, IServiceProvider serviceProvider)
        {
            _view = view;
            _serviceProvider = serviceProvider;

            _view.btnSalvar.Click += async (s, e) => await BtnSalvar_ClickAsync();
            _view.btnCancelar.Click += (s, e) => _view.Close();
        }

        private async Task BtnSalvar_ClickAsync()
        {
            if (string.IsNullOrWhiteSpace(_view.txtDescricao.Text))
            {
                MessageBox.Show("A descrição é obrigatória.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _view.txtDescricao.Focus();
                return;
            }

            if (_view.cmbResponsavel.SelectedValue == null)
            {
                MessageBox.Show("Selecione um membro responsável.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _view.cmbResponsavel.Focus();
                return;
            }

            try
            {
                using var scope = _serviceProvider.CreateScope();
                var tarefaService = scope.ServiceProvider.GetRequiredService<TarefaLimpezaService>();

                if (_view.TarefaId.HasValue)
                {
                    var updateDto = new UpdateTarefaLimpezaDto
                    {
                        Id = _view.TarefaId.Value,
                        Data = _view.dtpData.Value.Date,
                        Descricao = _view.txtDescricao.Text.Trim(),
                        MembroResponsavelId = (int)_view.cmbResponsavel.SelectedValue,
                        Concluido = _view.chkConcluido.Checked
                    };

                    await tarefaService.UpdateTarefaAsync(updateDto);
                    MessageBox.Show("Limpeza atualizada com sucesso!", "Sucesso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    var createDto = new CreateTarefaLimpezaDto
                    {
                        Data = _view.dtpData.Value.Date,
                        Descricao = _view.txtDescricao.Text.Trim(),
                        MembroResponsavelId = (int)_view.cmbResponsavel.SelectedValue
                    };

                    await tarefaService.CreateTarefaAsync(createDto);
                    MessageBox.Show("Limpeza agendada com sucesso!", "Sucesso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                _view.DialogResult = DialogResult.OK;
                _view.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar limpeza: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
